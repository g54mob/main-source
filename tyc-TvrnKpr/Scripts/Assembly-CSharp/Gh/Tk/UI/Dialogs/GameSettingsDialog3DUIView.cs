using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class GameSettingsDialog3DUIView : BaseDialog3DUIView, IPrefabProvider
	{
		public static int AudioTabIndex;

		[SerializeField]
		private Button3DUIView[] _closeButtons;

		[SerializeField]
		private Button3DUIView _quitGameButton;

		[SerializeField]
		private TMP_Text _versionText;

		[SerializeField]
		private SystemStatusSettingsPage3DUIView _systemStatusSettings;

		[SerializeField]
		private List<Button3DUIView> _tabButtons;

		[SerializeField]
		private List<SettingsPage3DUIView> _tabPages;

		private float _updateDelayDuration;

		[SerializeField]
		private List<GameObject> _settingsPrefabs;

		protected override void Awake()
		{
		}

		private bool ShouldDifficultSettingsBeActive()
		{
			return false;
		}

		private void Start()
		{
		}

		public void Init()
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		protected override void Opened()
		{
		}

		public void ApplyTabButtonListeners()
		{
		}

		private void CloseAllTabs()
		{
		}

		public void SelectTab<T>() where T : SettingsPage3DUIView
		{
		}

		public void OpenTab(int index)
		{
		}

		protected override void Closed()
		{
		}

		public void ShowQuitButton()
		{
		}

		private void Update()
		{
		}

		public GameObject GetPrefab(string prefabName)
		{
			return null;
		}
	}
}
