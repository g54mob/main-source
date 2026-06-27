using Restory.Data.Tables.Parameters;
using UnityEngine;

namespace Restory.Data.Equipment
{
	[CreateAssetMenu(fileName = "PaintingSettings", menuName = "Restory/Equipment/DevicePainter/PaintingSettings")]
	public class PaintingSettings : ScriptableObject, IGameParametersEntity
	{
		[SerializeField]
		private TextureFormat textureFormat = TextureFormat.RGBAHalf;

		[SerializeField]
		private int uVMaskTexturePadding = 2;

		[SerializeField]
		[Min(1f)]
		private int paintingHistorySize = 5;

		public TextureFormat TextureFormat => textureFormat;

		public int UVMaskTexturePadding => uVMaskTexturePadding;

		public int PaintingHistorySize => paintingHistorySize;
	}
}
