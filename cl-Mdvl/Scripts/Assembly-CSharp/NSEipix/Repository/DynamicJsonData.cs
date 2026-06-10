using System;
using System.Collections.Generic;
using System.IO;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Repository;

namespace NSEipix.Repository
{
	public abstract class DynamicJsonData<T, TM> : JsonRepository<T, TM> where T : Repository<T, TM> where TM : NSEipix.Base.Model
	{
		protected readonly List<string> JsonFilePathRegistry = new List<string>();

		protected override void Initialize()
		{
			JsonFilePathRegistry.Add(JsonFile());
			base.Initialize();
			MonoSingleton<RepositoryManager>.Instance.RegisterRepoActions(Path.GetFileName(JsonFile()), AddRepository, RemoveRepository, UpdateRepository);
			RepositoryManager repositoryManager = MonoSingleton<RepositoryManager>.Instance;
			repositoryManager.OnRefreshRepoAction = (Action)Delegate.Combine(repositoryManager.OnRefreshRepoAction, new Action(Refresh));
		}

		protected virtual void Refresh()
		{
		}

		private void RemoveRepository(string jsonPath)
		{
			if (!JsonFilePathRegistry.Remove(jsonPath))
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(17, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\Repository\\DynamicJsonData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(jsonPath);
					messageBuilder.AppendLiteral(" not in registry.");
				}
				Log.Error(messageBuilder);
			}
			else
			{
				Deserialize();
			}
		}

		private void UpdateRepository(string jsonPath)
		{
			if (!JsonFilePathRegistry.Contains(jsonPath))
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(17, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\Repository\\DynamicJsonData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(jsonPath);
					messageBuilder.AppendLiteral(" not in registry.");
				}
				Log.Error(messageBuilder);
			}
			else
			{
				Deserialize();
			}
		}

		private void AddRepository(string jsonPath)
		{
			if (JsonFilePathRegistry.Contains(jsonPath))
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(21, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\EipixSDK\\Scripts\\Repository\\DynamicJsonData.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Path already exists: ");
					messageBuilder.AppendFormatted(jsonPath);
				}
				Log.Error(messageBuilder);
			}
			else
			{
				JsonFilePathRegistry.Add(jsonPath);
				Deserialize();
			}
		}
	}
}
