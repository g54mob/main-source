using Restory.Data.Base;
using UnityEngine;

namespace Restory.Data.Equipment
{
	[CreateAssetMenu(fileName = "PaintingPalette - Name", menuName = "Restory/Equipment/DevicePainter/PaintingPaletteInfo")]
	public class PaintingPaletteInfo : RestoryEntityInfoBase
	{
		private static int MAX_COLORS_IN_PALETTE = 9;

		[SerializeField]
		private string nameLocalizationKey;

		[SerializeField]
		private string descriptionLocalizationKey;

		[SerializeField]
		private Color[] colors = new Color[MAX_COLORS_IN_PALETTE];

		public string NameLocalizationKey => nameLocalizationKey;

		public string DescriptionLocalizationKey => descriptionLocalizationKey;

		public Color[] Colors => colors;
	}
}
