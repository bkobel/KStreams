import org.apache.kafka.common.serialization.Serializer;

import java.io.Serializable;

public class PlatformEventModel implements Serializer<PlatformEventModel> {
    public PlatformEventHeader Headers;

    public String Payload;

    @Override
    public byte[] serialize(String s, PlatformEventModel platformEventModel) {
        return new byte[0];
    }
}