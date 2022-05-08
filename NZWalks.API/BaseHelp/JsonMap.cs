using Newtonsoft.Json;

namespace NZWalks.API.BaseHelp
{
    public static class JsonMap
    {
        public static T Deserialize<T>(object data)
        {
            var obj = JsonConvert.SerializeObject(data, Formatting.Indented,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });

            return JsonConvert.DeserializeObject<T>(obj);
        }
    }
}
