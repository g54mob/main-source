using UnityEngine.Events;
using UnityEngine.UI;

namespace SkywardRay.FileBrowser
{
	public class SfbPromtNewFolder : SfbPromt
	{
		public Button buttonAction;

		public Button buttonCancel;

		public SfbInputField inputField;

		protected override void SetListeners()
		{
		}

		public void AddActionButtonListener(UnityAction action)
		{
		}

		public void AddCancelButtonListener(UnityAction action)
		{
		}

		private void ListenerConfirm()
		{
		}

		private void ListenerCancel()
		{
		}

		public override void Init(SfbInternal fileBrowser)
		{
		}
	}
}
