using System.Linq;
using Assets.Scripts.XR.UI.Layout;
using UnityEngine;

namespace Assets.Scripts.GuiNew
{
	public class VRFlightControlsDialogScript : MonoBehaviour
	{
		private const string NotificationId = "ControlsDialogFlight";

		[SerializeField]
		private GameObject _content;

		private ControllerLayoutScript _controllerLayout;

		private int _numFrames;

		private bool _shown;

		public void Close()
		{
			if (_shown)
			{
				Game.Instance.Settings.App.AddNotification("ControlsDialogFlight");
				Game.Instance.Settings.App.Save();
			}
			Object.Destroy(base.gameObject);
			base.gameObject.SetActive(value: false);
			if (_controllerLayout != null)
			{
				_controllerLayout.HideLayouts();
			}
		}

		public void OkayClicked()
		{
			Close();
		}

		protected virtual void Start()
		{
			if (Game.Instance.Settings.App.SeenNotifications.Contains("ControlsDialogFlight"))
			{
				Close();
			}
		}

		protected virtual void Update()
		{
			if (_numFrames > 20 && !_shown)
			{
				ShowControls();
			}
			else
			{
				_numFrames++;
			}
		}

		private void ShowControls()
		{
			_shown = true;
			_content.SetActive(value: true);
			_controllerLayout = Object.FindFirstObjectByType<ControllerLayoutScript>(FindObjectsInactive.Include);
			if (_controllerLayout != null)
			{
				Debug.Log("Found Controller Layout");
				_controllerLayout.ShowLayouts();
			}
			else
			{
				Debug.Log("Could not find Controller Layout");
				Close();
			}
		}
	}
}
