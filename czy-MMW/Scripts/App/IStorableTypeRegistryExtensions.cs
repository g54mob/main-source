public static class IStorableTypeRegistryExtensions
{
	public static bool IsFilenameRecognized(this IStorableTypeHandlerRegistry registry, string filename, out string playerId, out string deviceId)
	{
		return registry.GetHandlerForFilename(filename, out playerId, out deviceId) != null;
	}

	public static bool IsFilenameRecognized(this IStorableTypeHandlerRegistry registry, string filename)
	{
		string playerId;
		string deviceId;
		return registry.IsFilenameRecognized(filename, out playerId, out deviceId);
	}

	public static IStorableTypeHandler GetHandlerForStorable(this IStorableTypeHandlerRegistry registry, IStorable storable)
	{
		return registry.GetHandlerForType(storable.GetType());
	}

	public static IStorableTypeHandler GetHandlerForType<T>(this IStorableTypeHandlerRegistry registry)
	{
		return registry.GetHandlerForType(typeof(T));
	}
}
