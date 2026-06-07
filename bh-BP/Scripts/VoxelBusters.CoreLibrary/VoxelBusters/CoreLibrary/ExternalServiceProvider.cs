namespace VoxelBusters.CoreLibrary
{
	public static class ExternalServiceProvider
	{
		private static IJsonServiceProvider s_jsonServiceProvider;

		private static ISaveServiceProvider s_saveServiceProvider;

		private static ILocalisationServiceProvider s_localisationServiceProvider;

		public static IJsonServiceProvider JsonServiceProvider
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static ISaveServiceProvider SaveServiceProvider
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static ILocalisationServiceProvider LocalisationServiceProvider
		{
			get
			{
				return null;
			}
			set
			{
			}
		}
	}
}
