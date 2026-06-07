using UnityEngine;

namespace Placemaker.Ui
{
	public class GamepadScreenCursor : MonoBehaviour, UiMaster.IUiSetup
	{
		[SerializeField]
		private UiMaster master;

		[SerializeField]
		private RectTransform field;

		[SerializeField]
		private RectTransform cursor;

		[SerializeField]
		private RectTransform arrow;

		[SerializeField]
		private RectTransform arrowScale;

		[SerializeField]
		private UpdateState openState;

		[SerializeField]
		private UpdateState visibleState;

		[SerializeField]
		private UpdateState arrowState;

		private int actionCount;

		private float actionT;

		private float disappearTime;

		public bool isAdding;

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		public void OnCameraRotate()
		{
		}

		public void Pan()
		{
		}

		private void Update()
		{
		}
	}
}
