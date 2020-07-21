import com.fasterxml.jackson.annotation.JsonProperty;

import java.io.Serializable;

public class PlatformEventModel implements Serializable {
    @JsonProperty("headers")
    public PlatformEventHeader Headers;

    @JsonProperty("payload")
    public String Payload;
}