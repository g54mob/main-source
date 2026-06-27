using System.Collections.Generic;
using Restory.Data.Tables.Parameters;
using UnityEngine;

namespace Restory.Data.Equipment
{
	[CreateAssetMenu(fileName = "PaintingPalette - Name", menuName = "Restory/Equipment/DevicePainter/PaintingPaletteInfoDatabase")]
	public class PaintingPaletteInfoDatabase : ScriptableObject, IGameParametersEntity
	{
		[SerializeField]
		private List<PaintingPaletteInfo> palettes;

		public IReadOnlyList<PaintingPaletteInfo> All => palettes;
	}
}
