using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class TextSaveButtons : UIBehaviour, UiMaster.IUiSetup
	{
		[SerializeField]
		private UiMaster master;

		[SerializeField]
		private string lastSaveString;

		[SerializeField]
		private SimpleMessage copyMessage;

		[SerializeField]
		private SimpleMessage loadMessage;

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		public void Button_CopyToClipboard()
		{
		}

		public void Button_LoadFromClipboard(BaseButton button)
		{
		}
	}
}
