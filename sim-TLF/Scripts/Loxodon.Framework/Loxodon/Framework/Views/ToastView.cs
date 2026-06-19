using UnityEngine.UI;

namespace Loxodon.Framework.Views
{
	public class ToastView : ToastViewBase
	{
		public Text text;

		protected override void OnContentChanged()
		{
			if (text != null)
			{
				text.text = content;
			}
		}
	}
}
