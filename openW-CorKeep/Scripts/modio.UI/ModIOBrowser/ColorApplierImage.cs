using UnityEngine.UI;

namespace ModIOBrowser
{
	internal class ColorApplierImage : ColorApplier<Image>
	{
		public Image image;

		protected override Image graphic => image;

		private void OnValidate()
		{
			if (image == null)
			{
				image = GetComponent<Image>();
			}
		}
	}
}
