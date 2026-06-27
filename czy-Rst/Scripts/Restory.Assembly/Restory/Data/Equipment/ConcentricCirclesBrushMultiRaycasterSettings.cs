using UnityEngine;
using UnityEngine.Serialization;

namespace Restory.Data.Equipment
{
	[CreateAssetMenu(fileName = "ConcentricCirclesBrushSettings - Name", menuName = "Restory/Equipment/ConcentricCirclesBrushMultiRaycasterSettings")]
	public class ConcentricCirclesBrushMultiRaycasterSettings : ScriptableObject
	{
		[SerializeField]
		private Texture2D brushTextureSource;

		[SerializeField]
		private Vector2Int brushSize = new Vector2Int(128, 128);

		[SerializeField]
		[Min(0.1f)]
		private float brushRaycastRingsSpacing = 10f;

		[SerializeField]
		[Min(0f)]
		private float brushRaycastRayMaxRandomDeviation = 1f;

		[SerializeField]
		private bool areBrushRaysCastParallelInWorldSpace;

		[FormerlySerializedAs("cleaningCursorSize")]
		[SerializeField]
		private Vector2 cursorSize = new Vector2Int(128, 128);

		public Texture2D BrushTexture => brushTextureSource;

		public Vector2Int BrushSize => brushSize;

		public float BrushRaycastRingsSpacing => brushRaycastRingsSpacing;

		public float BrushRaycastRayMaxRandomDeviation => brushRaycastRayMaxRandomDeviation;

		public bool AreBrushRaysCastParallelInWorldSpace => areBrushRaysCastParallelInWorldSpace;

		public Vector2 CursorSize => cursorSize;
	}
}
