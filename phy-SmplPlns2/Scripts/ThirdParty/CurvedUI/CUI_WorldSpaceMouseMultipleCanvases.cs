using System.Collections.Generic;
using UnityEngine;

namespace CurvedUI
{
	public class CUI_WorldSpaceMouseMultipleCanvases : MonoBehaviour
	{
		[SerializeField]
		private List<CurvedUISettings> ControlledCanvases;

		[SerializeField]
		private Transform WorldSpaceMouse;

		[SerializeField]
		private CurvedUISettings MouseCanvas;

		private void Update()
		{
			Vector3 vector = MouseCanvas.CanvasToCurvedCanvas(WorldSpaceMouse.localPosition);
			Ray ray = (CurvedUIInputModule.CustomControllerRay = new Ray(Camera.main.transform.position, vector - Camera.main.transform.position));
			if (Input.GetButton("Fire2"))
			{
				Vector2 o_positionOnCanvas = Vector2.zero;
				MouseCanvas.RaycastToCanvasSpace(new Ray(Camera.main.transform.position, Camera.main.transform.forward), out o_positionOnCanvas);
				CurvedUIInputModule.Instance.WorldSpaceMouseInCanvasSpace = o_positionOnCanvas;
			}
			Debug.DrawRay(ray.GetPoint(0f), ray.direction * 1000f, Color.cyan);
		}
	}
}
