using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.ObjectMapper;

namespace NSEipix.Repository
{
	public abstract class DynamicSettingsData<T, TM> : DynamicJsonData<T, TM>, ISettingsData<TM> where T : Repository<T, TM> where TM : NSEipix.Base.Model
	{
		private TM dataModel;

		public TM GetData<TModel>() where TModel : NSEipix.Base.Model
		{
			if (dataModel != null)
			{
				return dataModel;
			}
			bool isEnabled;
			FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(12, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\Repository\\DynamicSettingsData.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("No data for ");
				messageBuilder.AppendFormatted(typeof(TModel));
			}
			Log.Error(messageBuilder);
			return null;
		}

		public override void Deserialize()
		{
			RemoveAll();
			dataModel = Serializer().Deserialize();
			if (dataModel != null)
			{
				repository.Add(dataModel);
			}
		}

		protected new ISerializer<TM> Serializer()
		{
			return new JsonSerializer<TM>.Builder(JsonFilePathRegistry).BuildWithoutSerializerMultiple();
		}
	}
}
