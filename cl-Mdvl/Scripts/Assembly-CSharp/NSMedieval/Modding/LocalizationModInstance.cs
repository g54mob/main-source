using System.IO;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Tools;
using UnityEngine;

namespace NSMedieval.Modding
{
	public class LocalizationModInstance : ModInstance
	{
		public string LanguageName { get; private set; }

		public string CsvFile { get; private set; }

		public LocalizationModInstance(ModModel modModel, Sprite sprite, string rootFolderPath, ModSource source)
			: base(modModel, sprite, rootFolderPath, source)
		{
		}

		protected override void Initialize()
		{
			base.Initialize();
			string path = Path.Combine(DataPath, "Localization");
			bool isEnabled;
			if (!Directory.Exists(path))
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(72, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\LocalizationModInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Skipping localization directory ");
					messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(path));
					messageBuilder.AppendLiteral(" for mod ");
					messageBuilder.AppendFormatted(base.ModModel.Name);
					messageBuilder.AppendLiteral(", There is no localization file");
				}
				Log.Error(messageBuilder);
				return;
			}
			CsvFile = Directory.GetFiles(path, "*.csv", SearchOption.AllDirectories).FirstOrDefault();
			LanguageName = Path.GetFileNameWithoutExtension(CsvFile);
			FVLogDebugInterpolationHandler messageBuilder2 = new FVLogDebugInterpolationHandler(41, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\LocalizationModInstance.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("Initialized LocalizationMod (");
				messageBuilder2.AppendFormatted(CsvFile);
				messageBuilder2.AppendLiteral(")  ");
				messageBuilder2.AppendFormatted(LanguageName);
				messageBuilder2.AppendLiteral(" for mod ");
				messageBuilder2.AppendFormatted(base.ModModel.Name);
			}
			Log.Debug(messageBuilder2);
			MonoSingleton<LocalizationModManager>.Instance.CacheLocalizationMod(LanguageName, CsvFile);
			messageBuilder2 = new FVLogDebugInterpolationHandler(46, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Modding\\LocalizationModInstance.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("Successfully cached localization mod ");
				messageBuilder2.AppendFormatted(LanguageName);
				messageBuilder2.AppendLiteral(" for mod ");
				messageBuilder2.AppendFormatted(base.ModModel.Name);
			}
			Log.Debug(messageBuilder2);
		}
	}
}
