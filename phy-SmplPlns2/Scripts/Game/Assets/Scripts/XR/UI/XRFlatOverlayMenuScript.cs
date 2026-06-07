using Jundroo.Common.Events;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.XR.UI
{
	public class XRFlatOverlayMenuScript : MonoBehaviour
	{
		private bool _hideMenu;

		[SerializeField]
		private GameObject _menu;

		[SerializeField]
		private TextMeshProUGUI _messagesText;

		[SerializeField]
		private GameObject _root;

		public void OnExitVRClicked()
		{
			ExitXR();
		}

		public void OnHideMenuClicked()
		{
			_hideMenu = true;
			_menu.SetActive(value: false);
			_messagesText.gameObject.SetActive(value: true);
			_messagesText.text = "Hit ESC to exit VR";
			UnityEventDispatcher.Instance.ExecuteWaitForSeconds(delegate
			{
				SetUIVisible(visible: false);
			}, 4f);
		}

		protected virtual void Awake()
		{
			Object.DontDestroyOnLoad(this);
			Game.Instance.XRDeviceManager.HmdActiveChanged += OnHmdActiveChanged;
			_messagesText.gameObject.SetActive(value: false);
			SetUIVisible(visible: false);
		}

		protected virtual void Update()
		{
			if (Game.Instance.XRDeviceManager.HmdActive && UnityEngine.Input.GetKeyDown(KeyCode.Escape))
			{
				ExitXR();
			}
		}

		private void ExitXR()
		{
			Game.Instance.XRDeviceManager.SetXrActive(active: false);
		}

		private void OnHmdActiveChanged(bool active)
		{
			if (!active || !_hideMenu)
			{
				SetUIVisible(active);
			}
		}

		private void SetUIVisible(bool visible)
		{
			_root.SetActive(visible);
			_menu.SetActive(visible);
		}
	}
}
