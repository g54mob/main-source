using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class ScreenshotButtons : UIBehaviour, UiMaster.IUiSetup
	{
		[SerializeField]
		private UiMaster master;

		[SerializeField]
		private CanvasGroup frameCanvasGroup;

		[SerializeField]
		private CanvasGroup frameCanvasGroup1;

		[SerializeField]
		private CanvasGroup tick;

		[SerializeField]
		private CanvasGroup cornersCanvasGroup;

		[SerializeField]
		private ScreenshotFrame frame;

		[SerializeField]
		private UpdateState frameState;

		[SerializeField]
		private UpdateState sideDimState;

		[SerializeField]
		private UpdateState errorWidth;

		[SerializeField]
		private UpdateState errorHeight;

		[SerializeField]
		private UpdateState errorPath;

		[SerializeField]
		private BaseButton screenshotButton;

		[SerializeField]
		private TMP_InputField widthInput;

		[SerializeField]
		private TMP_InputField heightInput;

		[SerializeField]
		private TMP_InputField pathInput;

		[SerializeField]
		private int width;

		[SerializeField]
		private int height;

		private const int minSize = 16;

		private const int maxSize = 4096;

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		public void Button_ScreenshotPNG()
		{
		}

		public void Button_InputUpdated()
		{
		}

		public void Button_PathUpdated()
		{
		}

		public void Button_SetPath()
		{
		}

		private void OnFolderBrowsingComplete(bool selected, string singleFolder, string[] folders)
		{
		}

		private string ResetPath()
		{
			return null;
		}
	}
}
