using Factory;
using UnityEngine;

namespace Popups
{
	public class ExamplePopup : BasePopup
	{
		[Dependency]
		private PopupStack _popupStack;

		public void YesPressed()
		{
			if (isFullyVisible)
			{
				Debug.Log("Yes");
				_popupStack.PopPopup();
			}
		}

		public void NoPressed()
		{
			if (isFullyVisible)
			{
				Debug.Log("No");
				_popupStack.PopPopup();
			}
		}

		public void BackPressed()
		{
			if (isFullyVisible)
			{
				Debug.Log("Back");
				_popupStack.PopPopup();
			}
		}
	}
}
