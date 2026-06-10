using UnityEngine.UI;

namespace ModIOBrowser
{
	internal class ColorApplierImage : ColorApplier<Image>
	{
		public Image image;

		protected override Image graphic => null;

		private void OnValidate()
		{
		}
	}
}
