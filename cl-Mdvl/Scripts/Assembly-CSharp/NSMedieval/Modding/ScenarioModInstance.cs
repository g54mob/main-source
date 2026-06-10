using System.IO;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Repository;
using NSMedieval.Tools;
using UnityEngine;

namespace NSMedieval.Modding
{
	public class ScenarioModInstance : ModInstance
	{
		public const string DefaultScenarioFileName = "Scenarios.json";

		public string ScenarioFilePath;

		public ScenarioModInstance(ModModel modModel, Sprite sprite, string rootFolderPath, ModSource source)
			: base(modModel, sprite, rootFolderPath, source)
		{
		}

		public override void UpdateData()
		{
			MonoSingleton<RepositoryManager>.Instance.UpdateRepository("Scenarios.json", ScenarioFilePath);
		}

		protected override void Initialize()
		{
			base.Initialize();
			if (UpdateScenarios())
			{
				SetEnabled(enabled: true);
			}
		}

		private bool UpdateScenarios()
		{
			string path = Path.Combine(DataPath, "Scenarios");
			if (Directory.Exists(path))
			{
				string[] files = Directory.GetFiles(path, "*.json", SearchOption.AllDirectories);
				if (files.Length == 0)
				{
					return false;
				}
				ScenarioFilePath = files[0];
				return true;
			}
			bool isEnabled;
			FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(30, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\ScenarioModInstance.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Couldn't find any scenario at ");
				messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(path));
			}
			Log.Error(messageBuilder);
			return false;
		}

		protected override void OnEnable()
		{
			MonoSingleton<RepositoryManager>.Instance.AddRepository("Scenarios.json", ScenarioFilePath);
			base.OnEnable();
		}

		public override void Dispose()
		{
			base.Dispose();
			MonoSingleton<RepositoryManager>.Instance.RemoveRepository("Scenarios.json", ScenarioFilePath);
			MonoSingleton<RepositoryManager>.Instance.RefreshRepositories();
		}
	}
}
