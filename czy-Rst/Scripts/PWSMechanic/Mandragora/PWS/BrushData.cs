using UnityEngine;

namespace Mandragora.PWS
{
	[CreateAssetMenu(fileName = "Cursor Brush - Name", menuName = "Mandragora/PWS/Create Cursor Brush")]
	public class BrushData : ScriptableObject
	{
		[SerializeField]
		private Texture2D brushTextureSource;

		[SerializeField]
		private Vector2Int brushSize = new Vector2Int(128, 128);

		[SerializeField]
		private bool invertRed = true;

		[SerializeField]
		private bool invertGreen = true;

		[SerializeField]
		private bool invertBlue = true;

		[SerializeField]
		private bool invertAlpha = true;

		public Texture2D BrushTexture => brushTextureSource;

		public Vector2Int BrushSize => brushSize;

		public bool InvertRed => invertRed;

		public bool InvertGreen => invertGreen;

		public bool InvertBlue => invertBlue;

		public bool InvertAlpha => invertAlpha;
	}
}
