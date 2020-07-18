import java.io.File;
import java.io.IOException;
import java.nio.file.*;
import java.nio.file.attribute.BasicFileAttributes;

public class TestUtils {
    public TestUtils() {
    }

    public static File tempDirectory() {
        final File file;
        try {
            file = Files.createTempDirectory("confluent").toFile();
        } catch (IOException var2) {
            throw new RuntimeException("Failed to create a temp dir", var2);
        }

        file.deleteOnExit();

        Runtime.getRuntime().addShutdownHook(new Thread(() -> {
            try {
                delete(file);
            } catch (IOException var2) {
                System.out.println("Error deleting " + file.getAbsolutePath());
            }
        }));

        return file;
    }

    public static void delete(final File file) throws IOException {
        if (file != null) {
            Files.walkFileTree(file.toPath(), new SimpleFileVisitor<Path>() {
                public FileVisitResult visitFileFailed(Path path, IOException exc) throws IOException {
                    if (exc instanceof NoSuchFileException && path.toFile().equals(file)) {
                        return FileVisitResult.TERMINATE;
                    } else {
                        throw exc;
                    }
                }

                public FileVisitResult visitFile(Path path, BasicFileAttributes attrs) throws IOException {
                    Files.delete(path);
                    return FileVisitResult.CONTINUE;
                }

                public FileVisitResult postVisitDirectory(Path path, IOException exc) throws IOException {
                    Files.delete(path);
                    return FileVisitResult.CONTINUE;
                }
            });
        }
    }
}