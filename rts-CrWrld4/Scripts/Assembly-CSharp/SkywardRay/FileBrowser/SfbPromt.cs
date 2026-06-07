using UnityEngine;

namespace SkywardRay.FileBrowser
{
	public abstract class SfbPromt : MonoBehaviour, SfbIElement
	{
		protected SfbInternal fileBrowser;

		protected virtual void SetListeners()
		{
		}

		public abstract void Init(SfbInternal fileBrowser);

		public void SetText(string text)
		{
		}

		public void Close()
		{
		}

		public void SetFocus()
		{
		}

		public void RecieveMessage(string message)
		{
		}
	}
}
