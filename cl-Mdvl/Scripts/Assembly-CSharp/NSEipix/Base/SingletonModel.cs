using System;
using System.Reflection;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;

namespace NSEipix.Base
{
	[Serializable]
	public abstract class SingletonModel<TModel, TRepo> : Model where TModel : SingletonModel<TModel, TRepo> where TRepo : ISettingsData<TModel>
	{
		private static TModel instance;

		public static TModel I
		{
			get
			{
				if (instance != null)
				{
					return instance;
				}
				ForceReloadFromDisk();
				return instance;
			}
		}

		public static void ForceReloadFromDisk()
		{
			instance = null;
			PropertyInfo property = typeof(TRepo).GetProperty("Instance", BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
			if (property == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(80, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\Base\\SingletonModel.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Failed to load SingletonModel instance from type ");
					messageBuilder.AppendFormatted(typeof(TRepo).Name);
					messageBuilder.AppendLiteral(", property 'Instance' not found");
				}
				Log.Error(messageBuilder);
			}
			else
			{
				instance = ((TRepo)property.GetValue(null)/*cast due to .constrained prefix*/).GetData<TModel>();
			}
		}
	}
}
