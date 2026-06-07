using UnityEngine;

namespace CurvedUI
{
	public class CUI_RaycastToCanvas : MonoBehaviour
	{
		private CurvedUISettings mySettings;

		private void Start()
		{
			mySettings = GetComponentInParent<CurvedUISettings>();
		}

		private void Update()
		{
			Vector2 o_positionOnCanvas = Vector2.zero;
			mySettings.RaycastToCanvasSpace(Camera.main.ScreenPointToRay(Input.mousePosition), out o_positionOnCanvas);
			base.transform.localPosition = o_positionOnCanvas;
		}
	}
}
