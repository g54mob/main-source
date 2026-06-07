using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Placemaker.Ui
{
	public class SideMenu : UIBehaviour, UiMaster.IUiSetup
	{
		[SerializeField]
		private UiMaster master;

		[SerializeField]
		public RectTransform sideTransform;

		[SerializeField]
		public RectTransform iconNotch;

		[SerializeField]
		public UpdateState openState;

		[SerializeField]
		private UpdateState sideButtonState;

		[SerializeField]
		private Graphic sideButtonOpen;

		[SerializeField]
		private Graphic sideButtonClose;

		[SerializeField]
		private CanvasGroup tabCanvasGroup;

		[SerializeField]
		private CanvasGroup sideCanvasGroup;

		[SerializeField]
		private AudioClip openClip;

		[SerializeField]
		private AudioClip closeClip;

		[SerializeField]
		private ButtonAudio_Clip openCloseButtonAudio;

		[SerializeField]
		private RectTransform trimAndIconContainer;

		public SimpleMessage newSaveGameMessage;

		private float iconNotchDefaultSize;

		public SideMenuNavigator navigator;

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		public void Button_ExportObj(BaseButton button)
		{
		}

		public void Button_Load()
		{
		}

		public void Button_New(BaseButton button)
		{
		}

		public void Button_Quit_Down()
		{
		}

		public void Button_Quit_Full(BaseButton button)
		{
		}

		public void Button_SideButton()
		{
		}

		public void Toggle()
		{
		}

		public void Open()
		{
		}

		public void Close()
		{
		}

		public void RemoveLayouts(bool isBuild)
		{
		}
	}
}
