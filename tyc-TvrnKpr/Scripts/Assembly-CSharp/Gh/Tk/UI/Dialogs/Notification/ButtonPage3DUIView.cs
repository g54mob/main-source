using UnityEngine;

namespace Gh.Tk.UI.Dialogs.Notification
{
	public class ButtonPage3DUIView : MonoBehaviour
	{
		[SerializeField]
		private Container3DUIView _container;

		[SerializeField]
		private RelativeScaler3DUIView _scaler;

		[SerializeField]
		private BoxCollider _collider;

		private float _buttonContainerZLevel;

		public void UpdateLayout()
		{
		}
	}
}
