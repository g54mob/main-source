using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.UI;

namespace NSMedieval.Managers
{
	public class SecureSaveLoadingManager : MonoSingleton<SecureSaveLoadingManager>
	{
		public static bool HasSaves
		{
			get
			{
				List<VillageSaveInfo> savesList = MonoSingleton<GlobalSaveController>.Instance.SavesList;
				if (savesList != null)
				{
					return savesList.Count > 0;
				}
				return false;
			}
		}

		public static VillageSaveInfo LatestSave => MonoSingleton<GlobalSaveController>.Instance.SavesList.OrderByDescending((VillageSaveInfo vsi) => vsi.LastPlayed).First();

		public void LoadLatestVillageSaveData()
		{
			LoadVillageSaveData(LatestSave);
		}

		public void LoadVillageSaveData(VillageSaveInfo villageSaveInfo)
		{
			MonoSingleton<LoadingOverlayController>.Instance.ShowOverlay(show: true);
			MonoSingleton<TaskController>.Instance.WaitForUnscaled(0.3f).Then(delegate
			{
				MonoSingleton<LoadingController>.Instance.DebugMeasureLoadingTime("Resume from main menu complete.");
				TryLoadingDelayed(villageSaveInfo);
			});
		}

		private static void TryLoadingDelayed(VillageSaveInfo villageSaveInfo)
		{
			Log.Debug("Village save is obsolete", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\SecureSaveLoadingManager.cs");
			if (villageSaveInfo.IsObsolete)
			{
				Log.Debug("Village save is obsolete", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\SecureSaveLoadingManager.cs");
				MainMenuView.ShowObsoleteSaveMessage(villageSaveInfo.ModifiedVersion, "0.17.0");
				MonoSingleton<LoadingOverlayController>.Instance.ShowOverlay(show: false);
			}
			else if (!MonoSingleton<GlobalSaveController>.Instance.LoadVillageData(villageSaveInfo))
			{
				Log.Debug("Failed to load Village save", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\SecureSaveLoadingManager.cs");
				MainMenuView.ShowCorruptedSaveMessage(villageSaveInfo.Meta);
				MonoSingleton<LoadingOverlayController>.Instance.ShowOverlay(show: false);
			}
			else if (MonoSingleton<GlobalSaveController>.Instance.CorruptedBlueprintIds.Count > 0)
			{
				Log.Debug("Corrupted blueprint ID", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\SecureSaveLoadingManager.cs");
				MainMenuView.ShowMissingModMessage(villageSaveInfo.Meta);
				MonoSingleton<LoadingOverlayController>.Instance.ShowOverlay(show: false);
			}
			else
			{
				MonoSingleton<AddressableSceneLoadingManager>.Instance.LoadMainScene();
			}
		}
	}
}
