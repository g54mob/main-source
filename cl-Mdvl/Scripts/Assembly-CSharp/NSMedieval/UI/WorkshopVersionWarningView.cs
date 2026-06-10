using NSEipix.Base;
using NSMedieval.Modding;
using NSMedieval.UI.Utils;
using Steamworks;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class WorkshopVersionWarningView : MonoBehaviour
	{
		[SerializeField]
		private GameObject icon;

		private PublishedFileId_t publishedFileId;

		private void Start()
		{
			icon.GetComponent<Image>().color = ColorUtils.GetColor("orange");
		}

		private void OnEnable()
		{
			MonoSingleton<SteamWorkshopManager>.Instance.WorkshopItemVersionUpdateEvent += OnItemVersionUpdate;
			MonoSingleton<ModManager>.Instance.ModsChangedEvent += OnItemVersionUpdate;
			OnItemVersionUpdate();
		}

		private void OnDisable()
		{
			if (MonoSingleton<SteamWorkshopManager>.IsInstantiated())
			{
				MonoSingleton<SteamWorkshopManager>.Instance.WorkshopItemVersionUpdateEvent -= OnItemVersionUpdate;
			}
			if (MonoSingleton<ModManager>.IsInstantiated())
			{
				MonoSingleton<ModManager>.Instance.ModsChangedEvent -= OnItemVersionUpdate;
			}
		}

		private void OnItemVersionUpdate()
		{
			if (MonoSingleton<SteamWorkshopManager>.Instance.WorkshopItemVersion != null)
			{
				icon.SetActive(MonoSingleton<SteamWorkshopManager>.Instance.WorkshopItemVersion.AnyModVersionInvalid());
			}
		}
	}
}
