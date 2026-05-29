using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class ScreenshotSwitch : UIBehaviour, UiMaster.IUiSetup
	{
		[SerializeField]
		private UiMaster master;

		[SerializeField]
		private CanvasGroup frameCanvasGroup;

		[SerializeField]
		private CanvasGroup frameCanvasGroup1;

		[SerializeField]
		private CanvasGroup cornersCanvasGroup;

		[SerializeField]
		private ScreenshotFrame frame;

		[SerializeField]
		private UpdateState frameState;

		[SerializeField]
		private BaseButton screenshotButton;

		[SerializeField]
		private RectTransform selector;

		[SerializeField]
		private BaseButton frameButtonOne;

		[SerializeField]
		private BaseButton frameButtonTwo;

		[SerializeField]
		private BaseButton frameButtonThree;

		[SerializeField]
		private UpdateState frameOneState;

		[SerializeField]
		private UpdateState frameTwoState;

		[SerializeField]
		private UpdateState frameThreeState;

		[SerializeField]
		private Vector4 buttonsCurrent;

		[SerializeField]
		private Vector4 buttonsTarget;

		[SerializeField]
		private bool isUpdating;

		[SerializeField]
		private Vector2Int[] frameSizes;

		[SerializeField]
		private Vector2 frameTarget;

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		private void SetFrameSizes()
		{
		}

		private void SubscribeButton(BaseButton button, UpdateState updateState)
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		public void Button_One()
		{
		}

		public void Button_Two()
		{
		}

		public void Button_Three()
		{
		}

		public void OnUpdate()
		{
		}

		public void SetFrameTarget(float buttonOne, float buttonTwo, float buttonThree)
		{
		}

		public void Button_ToggleFrame()
		{
		}

		public void Button_ScreenshotPNG()
		{
		}
	}
}
