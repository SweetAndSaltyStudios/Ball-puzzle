using System.IO;
using System.Xml.Serialization;

public static class ConvertHelper
{
    // Serialize
    public static string Serialize<T>(this T toSerialize)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        StringWriter stringWriter = new StringWriter();
        xmlSerializer.Serialize(stringWriter, toSerialize);
        return stringWriter.ToString();
    }

    // De-Serialize
    public static T Deserialize<T>(this string toDeserialize)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        StringReader stringReader = new StringReader(toDeserialize);
        return (T)xmlSerializer.Deserialize(stringReader);
    }
	
}
