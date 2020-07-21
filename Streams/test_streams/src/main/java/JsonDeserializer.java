import com.fasterxml.jackson.databind.ObjectMapper;
import org.apache.kafka.common.errors.SerializationException;
import org.apache.kafka.common.serialization.Deserializer;

import java.util.Map;

public class JsonDeserializer<T> implements Deserializer<T> {
    private ObjectMapper objectMapper = new ObjectMapper();
    private Class<T> type;

    /**
     * Default constructor needed by Kafka
     */
    public JsonDeserializer() {
    }

    public JsonDeserializer(Class<T> type) {
        this.type = type;
    }

    @SuppressWarnings("unchecked")
    @Override
    public void configure(Map<String, ?> map, boolean isKey) {
        type = (Class<T>) map.get("type");
    }

    @Override
    public T deserialize(String topic, byte[] bytes) {
        if (bytes == null || bytes.length == 0) {
            return null;
        }

        T data;
        try {
            System.out.println(getType());
            data = objectMapper.readValue(bytes, type);
        } catch (Exception e) {
            throw new SerializationException(e);
        }

        return data;
    }

    protected Class<T> getType() {
        return type;
    }

    @Override
    public void close() {

    }
}