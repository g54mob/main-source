using System;
using System.Collections.Generic;
using FractureField.Achievements.UI;
using FractureField.DevTools.UI;
using FractureField.UI.Popups.Changelog;
using FractureField.UI.Popups.Demo;
using FractureField.UI.Popups.DroneHub;
using FractureField.UI.Popups.ImportSave;
using FractureField.UI.Popups.Info;
using FractureField.UI.Popups.Language;
using FractureField.UI.Popups.QuarryForeman;
using FractureField.UI.Popups.RealityShatter;
using FractureField.UI.Popups.Settings;
using FractureField.UI.Popups.Tools;
using FractureField.UI.Popups.WorldFracture;
using Reactivity;
using Reactivity.Unity.Components;
using UnityEngine;
using UnityEngine.UI;

namespace FractureField.UI.Popups
{
	public class PopupHub : InitableSingleton<PopupHub>
	{
		[Header("References")]
		[SerializeField]
		private Image _overlay;

		[SerializeField]
		private Canvas _canvas;

		[Header("Popups")]
		[SerializeField]
		private SettingsPopup _settingsPopup;

		[SerializeField]
		private ConfirmPopup _confirmPopup;

		[SerializeField]
		private ChangelogPopup _changelogPopup;

		[SerializeField]
		private DemoPopup _demoPopup;

		[SerializeField]
		private WorldFracturePopup _worldFracturePopup;

		[SerializeField]
		private QuarryForemanPopup _quarryForemanPopup;

		[SerializeField]
		private ToolsPopup _toolsPopup;

		[SerializeField]
		private ImportSavePopup _importSavePopup;

		[SerializeField]
		private InfoPopup _infoPopup;

		[SerializeField]
		private DroneHubPopup _droneHubPopup;

		[SerializeField]
		private RealityShatterPopup _realityShatterPopup;

		[SerializeField]
		private AchievementsPopup _achievementsPopup;

		[SerializeField]
		private LanguagePopup _languagePopup;

		[SerializeField]
		private DevToolsPopup _devToolsPopup;

		private RComponent _rComponent;

		public override bool InitInStart => false;

		public static Canvas Canvas => null;

		public static SettingsPopup SettingsPopup => null;

		public static ConfirmPopup ConfirmPopup => null;

		public static ChangelogPopup ChangelogPopup => null;

		public static DemoPopup DemoPopup => null;

		public static WorldFracturePopup WorldFracturePopup => null;

		public static QuarryForemanPopup QuarryForemanPopup => null;

		public static ToolsPopup ToolsPopup => null;

		public static ImportSavePopup ImportSavePopup => null;

		public static InfoPopup InfoPopup => null;

		public static DroneHubPopup DroneHubPopup => null;

		public static RealityShatterPopup RealityShatterPopup => null;

		public static AchievementsPopup AchievementsPopup => null;

		public static LanguagePopup LanguagePopup => null;

		public static DevToolsPopup DevToolsPopup => null;

		private List<Popup> AllPopups => null;

		public RTrigger ActivePopupsChanged { get; }

		public List<Popup> ActivePopups { get; }

		private List<Action> QueuedActions { get; }

		private bool CanExecuteQueuedActions => false;

		public Popup GetPopupByType(PopupType type)
		{
			return null;
		}

		protected override void InitHandler()
		{
		}

		private void Setup()
		{
		}

		private void OnActivePopupsChanged()
		{
		}

		private void CheckQueuedActions()
		{
		}

		public void QueueAction(Action action)
		{
		}

		public void Open(PopupType popupType)
		{
		}

		public void Open(Popup popup)
		{
		}

		public void Close(Popup popup)
		{
		}

		public void CloseTopPopup()
		{
		}

		public bool TryCloseTopPopup()
		{
			return false;
		}
	}
}
