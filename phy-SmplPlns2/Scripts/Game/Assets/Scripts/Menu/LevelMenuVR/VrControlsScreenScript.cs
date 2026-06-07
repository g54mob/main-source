using Assets.Scripts.Input.Gui;
using Assets.Scripts.XR.UI.Layout;
using UnityEngine;

namespace Assets.Scripts.Menu.LevelMenuVR
{
	public class VrControlsScreenScript : MonoBehaviour
	{
		[SerializeField]
		private GameObject _bindingsText;

		[SerializeField]
		private ControllerLayoutScript _controllerLayout;

		[SerializeField]
		private GameObject _joystickButton;

		public void OnJoyStickControlsButtonClicked()
		{
			ControlMapperDialogScript controlMapper = ControlMapperDialogScript.CreateDialog();
			controlMapper.GetComponentInChildren<Canvas>().worldCamera = GetComponentInParent<Canvas>().worldCamera;
			controlMapper.Closed += delegate
			{
				Debug.Log("Closed Event Received");
				Object.Destroy(controlMapper.gameObject);
				base.gameObject.SetActive(value: true);
			};
			base.gameObject.SetActive(value: false);
		}

		public void Show(bool show)
		{
			if (show)
			{
				base.gameObject.SetActive(value: true);
				_controllerLayout.ShowLayouts();
			}
			else
			{
				_controllerLayout.HideLayouts();
				base.gameObject.SetActive(value: false);
			}
		}

		protected virtual void Start()
		{
			if (Game.Instance.Device.IsAndroidVRBuild)
			{
				_joystickButton.SetActive(value: false);
				_bindingsText.SetActive(value: false);
			}
		}
	}
}
