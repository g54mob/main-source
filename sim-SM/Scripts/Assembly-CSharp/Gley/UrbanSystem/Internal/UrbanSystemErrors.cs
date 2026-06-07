namespace Gley.UrbanSystem.Internal
{
	public static class UrbanSystemErrors
	{
		public static string SceneDataIsNull => null;

		public static string SceneGridIsNull => null;

		public static string EmptyScene => null;

		public static string NoPathFindingWaypoints => null;

		public static string NullPathFindingData => null;

		public static string TypeNotFound<T>()
		{
			return null;
		}

		public static string MultipleComponentsOfTypeFound<T>()
		{
			return null;
		}

		public static string ComponentAlreadyExistsOn<T>(string name)
		{
			return null;
		}

		internal static string ObjectNotFound(string path)
		{
			return null;
		}

		public static string NoPrevs(string name)
		{
			return null;
		}
	}
}
