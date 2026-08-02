using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	public class PaintBrushController : MonoBehaviour
	{
		public Color paintColor = Color.red;

		public float paintDistance = 3f;

		public LayerMask paintLayerMask = -1;

		public Camera paintCamera;

		public GrabbableObject lastPaintedTarget;

		[Tooltip("Sağ tıkla açılan radial renk seçici. Boşsa sahnede otomatik bulunur.")]
		public RadialColorPicker colorPicker;

		private void OnEnable()
		{
			if (paintCamera == null)
			{
				paintCamera = Camera.main;
			}
			if (colorPicker == null)
			{
				colorPicker = Object.FindObjectOfType<RadialColorPicker>(includeInactive: true);
			}
		}

		private void OnDisable()
		{
			if (colorPicker != null && colorPicker.IsOpen)
			{
				colorPicker.Close();
			}
		}

		private void Update()
		{
			if (Input.GetMouseButtonDown(1) && colorPicker != null && (colorPicker.IsOpen || TrainGameManager.isInputActive))
			{
				colorPicker.Toggle(delegate(Color c)
				{
					paintColor = c;
				});
			}
			else
			{
				if ((colorPicker != null && colorPicker.IsOpen) || !TrainGameManager.isInputActive || TrainGameManager.isMouseLocked || !Input.GetMouseButtonDown(0))
				{
					return;
				}
				if (paintCamera == null)
				{
					paintCamera = Camera.main;
				}
				if (!(paintCamera == null) && Physics.Raycast(paintCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)), out var hitInfo, paintDistance, paintLayerMask, QueryTriggerInteraction.Ignore))
				{
					GrabbableObject componentInParent = hitInfo.collider.GetComponentInParent<GrabbableObject>();
					if (componentInParent != null && componentInParent.isPaintable)
					{
						componentInParent.Paint(paintColor);
						lastPaintedTarget = componentInParent;
					}
				}
			}
		}
	}
}
