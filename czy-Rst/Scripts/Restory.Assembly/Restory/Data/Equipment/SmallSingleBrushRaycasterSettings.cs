using UnityEngine;

namespace Restory.Data.Equipment
{
	[CreateAssetMenu(fileName = "SmallSingleBrushSettings - Name", menuName = "Restory/Equipment/SmallSingleBrushRaycasterSettings")]
	public class SmallSingleBrushRaycasterSettings : ScriptableObject
	{
		[SerializeField]
		private Texture2D brushTextureSource;

		[SerializeField]
		private Vector2Int brushSize = new Vector2Int(16, 16);

		[SerializeField]
		private Vector2 cursorSize = new Vector2Int(16, 16);

		public Texture2D BrushTexture => brushTextureSource;

		public Vector2Int BrushSize => brushSize;

		public Vector2 CursorSize => cursorSize;
	}
}
