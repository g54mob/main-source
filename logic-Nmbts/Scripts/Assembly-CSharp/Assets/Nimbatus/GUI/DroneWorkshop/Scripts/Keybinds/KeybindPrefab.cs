using Assets.Nimbatus.Scripts.Controls.Keybinds;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.Keybinds
{
	[RequireComponent(typeof(UIDragScrollView))]
	public class KeybindPrefab : MonoBehaviour
	{
		public UILabel Name;

		private UIDragScrollView _uiDragPanelContents;

		public void Awake()
		{
			_uiDragPanelContents = GetComponent<UIDragScrollView>();
		}

		public void Init(KeybindSetting setting, UIScrollView itemPanel)
		{
			_uiDragPanelContents.scrollView = itemPanel;
			Name.text = setting.ToString();
		}
	}
}
