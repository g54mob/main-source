using System;
using System.Collections.Generic;
using UI.Apps;
using UI.Common;
using UI.Utilities;
using UnityEngine;
using UnityEngine.Localization.Tables;

namespace UI
{
	public class UIMultitoolManager : MonoSingleton<UIMultitoolManager>, ILogOrigin
	{
		public enum UIColorLabels
		{
			Castle = 0,
			Cliff = 1,
			Cloud = 2,
			Green = 3,
			ShinyGreen = 4
		}

		public MultitoolCanvasResolutionChanger canvasResolutionChanger;

		public MultitoolCanvas canvasLarge;

		public Transform transparentPanelLarge;

		public MultitoolCanvas canvasSmall;

		public Workbench workbench;

		public Dictionary<UIColorLabels, Color> UIColorsDictionary;

		public UISettingBar settingBar;

		public List<MultiToolAppInfo> appsInfo;

		[NonSerialized]
		[HideInInspector]
		public MultiToolAppInfo currentApp;

		public Transform appArea;

		public Transform smallAppArea;

		public MultitoolUIIntro introUI;

		[NonSerialized]
		[HideInInspector]
		private List<MultiToolAppInfo> appHistory;

		[NonSerialized]
		[HideInInspector]
		public MultiTool3000 multitool;

		public UIModalManager modalManager;

		public MultiToolAppTypes mainMenu;

		public InputWrapper input;

		[NonSerialized]
		[HideInInspector]
		public List<char> forbiddenChar;

		protected Gadget gadget => null;

		public void Init()
		{
		}

		private void SetUIColorDictionary()
		{
		}

		public void ResetAppButtonColor()
		{
		}

		public void LaunchAppMenu(Action onAppLaunched = null)
		{
		}

		public MultiToolApp LaunchApp(MultiToolAppTypes appToLaunch, bool addInHistory = true, bool clearHistory = false, Action onAppLaunched = null)
		{
			return null;
		}

		public void GoBackToApp(MultiToolAppTypes appType)
		{
		}

		public void AddInAppHistory(MultiToolAppInfo currentApp)
		{
		}

		public T AddToSmallCanvas<T>(T smallCanvasPrefab) where T : MonoBehaviour
		{
			return null;
		}

		public void RemoveAppsFromHistory(MultiToolAppInfo app)
		{
		}

		public void ClearHistory()
		{
		}

		private MultiToolAppInfo GetAppInfo(MultiToolAppTypes appTypeToGet)
		{
			return null;
		}

		public MultiToolApp GetApp(MultiToolAppTypes appToGet)
		{
			return null;
		}

		public Sprite GetIcon(MultiToolAppTypes appToGet)
		{
			return null;
		}

		public void SetTitle(TableEntryReference titleEntryRef, bool useLocalization = true)
		{
		}

		public void SetIcon(Sprite icon)
		{
		}

		public static Transform GetAppArea()
		{
			return null;
		}

		public static UISettingBar GetSettingBar()
		{
			return null;
		}

		public void OnGadgetTurnOn()
		{
		}

		public void OnGadgetTurnOff()
		{
		}

		public void OnGadgetEndEdit()
		{
		}

		public void OnMultitoolOpen()
		{
		}

		public void OnMultitoolClose()
		{
		}

		public void OnSetGadget(Gadget gadget)
		{
		}

		public void OnSelectModule(Module module)
		{
		}

		public void OnSolderModule(Module module)
		{
		}

		public void OnUnsolderModule(Module module)
		{
		}

		public void EditAsset(Asset asset)
		{
		}

		public void SetLanguage()
		{
		}

		public void SetDefaultCursor()
		{
		}

		public void SetCursor(Sprite cursorSprite)
		{
		}

		public void CheckAllowedChar(string name)
		{
		}

		public void ShowIntro(float startDelay = 0f, Action onComplete = null)
		{
		}
	}
}
