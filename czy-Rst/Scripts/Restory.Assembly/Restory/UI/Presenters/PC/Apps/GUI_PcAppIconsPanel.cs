using System;
using System.Collections.Generic;
using Restory.Data.Localization;
using Restory.Data.PC;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters.PC.Apps
{
	public class GUI_PcAppIconsPanel : MonoBehaviour
	{
		private readonly List<GUI_PcAppIcon> icons = new List<GUI_PcAppIcon>();

		[SerializeField]
		private Transform iconsContainer;

		[SerializeField]
		private GUI_PcAppIcon iconPrefab;

		private DiContainer diContainer;

		private LocalizationSystem localizationSystem;

		public event Action<PcAppInfo> OnAppIconClick;

		[Inject]
		private void Construct(DiContainer diContainer, LocalizationSystem localizationSystem)
		{
			this.diContainer = diContainer;
			this.localizationSystem = localizationSystem;
		}

		public void CreateAppIcon(PcAppInfo appInfo)
		{
			GUI_PcAppIcon icon = diContainer.InstantiatePrefabForComponent<GUI_PcAppIcon>(iconPrefab, iconsContainer);
			icon.Init(appInfo, localizationSystem.GetTranslation(appInfo.NameLocalizationKey));
			icon.Button.onClick.AddListener(delegate
			{
				ResolveAppIconClick(icon);
			});
			icons.Add(icon);
		}

		public void RemoveAppIcon(PcAppInfo appInfo)
		{
			for (int num = icons.Count - 1; num >= 0; num--)
			{
				GUI_PcAppIcon gUI_PcAppIcon = icons[num];
				if (gUI_PcAppIcon == null)
				{
					icons.RemoveAt(num);
				}
				else if (!(gUI_PcAppIcon.AppInfo != appInfo))
				{
					icons.RemoveAt(num);
					UnityEngine.Object.Destroy(gUI_PcAppIcon.gameObject);
				}
			}
		}

		private void ResolveAppIconClick(GUI_PcAppIcon icon)
		{
			if (!icon.AppInfo)
			{
				Debug.LogError("Clicked not initialized GUI_PcAppIcon");
			}
			else
			{
				this.OnAppIconClick?.Invoke(icon.AppInfo);
			}
		}
	}
}
