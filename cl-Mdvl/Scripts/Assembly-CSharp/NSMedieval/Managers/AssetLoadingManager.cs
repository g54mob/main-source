using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Modding;
using NSMedieval.Repository;
using NSMedieval.UI;

namespace NSMedieval.Managers
{
	public class AssetLoadingManager : MonoSingleton<AssetLoadingManager>
	{
		protected override void Awake()
		{
			if (MonoSingleton<AssetLoadingManager>.IsInstantiated())
			{
				base.Awake();
				return;
			}
			base.Awake();
			MonoSingleton<RepositoryManager>.Instance.Initialize();
		}

		private void Start()
		{
			MonoSingleton<LocalizationModManager>.Instance.Initialize();
			MonoSingleton<ModManager>.Instance.Initialize();
			MonoSingleton<SteamWorkshopManager>.Instance.Initialize();
			MonoSingleton<OptionsController>.Instance.Initialize();
			MonoSingleton<LocalizationController>.Instance.Initialize();
			MonoSingleton<ManageGroupPresetController>.Instance.Initialize();
		}
	}
}
