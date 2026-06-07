using UnityEngine;

namespace Shapes
{
	public class IMColorPickerInteraction : MonoBehaviour
	{
		private enum ColorPickerElement
		{
			None = 0,
			HueStrip = 1,
			Rectangle = 2
		}

		public IMColorPickerRenderer picker;

		private ColorPickerElement currentInteraction;

		private void Update()
		{
			if (Camera.main != null)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastInteract(ray, Input.GetMouseButtonDown(0), Input.GetMouseButton(0), Input.GetMouseButtonUp(0));
			}
		}

		private void OnDisable()
		{
			currentInteraction = ColorPickerElement.None;
		}

		public void RaycastInteract(Ray ray, bool onPress, bool whileHeld, bool onRelease)
		{
			if (onPress || whileHeld)
			{
				ray.origin = base.transform.InverseTransformPoint(ray.origin);
				ray.direction = base.transform.InverseTransformDirection(ray.direction);
				if (new Plane(Vector3.back, 0f).Raycast(ray, out var enter))
				{
					Vector2 pt = ray.GetPoint(enter);
					if (onPress)
					{
						currentInteraction = GetPickerElementAt(pt);
					}
					if (whileHeld && currentInteraction != ColorPickerElement.None)
					{
						UpdatePickerColor(pt);
					}
				}
			}
			if (onRelease)
			{
				currentInteraction = ColorPickerElement.None;
			}
		}

		private void UpdatePickerColor(Vector2 pt)
		{
			if (currentInteraction == ColorPickerElement.HueStrip)
			{
				picker.hue = IMColorPickerRenderer.VectorToHue(pt);
			}
			else if (currentInteraction == ColorPickerElement.Rectangle)
			{
				Vector2 vector = ShapesMath.InverseLerp(picker.QuadRect, pt);
				picker.saturation = Mathf.Clamp01(vector.x);
				picker.value = Mathf.Clamp01(vector.y);
			}
		}

		private ColorPickerElement GetPickerElementAt(Vector2 pt)
		{
			if (HueStripContains(pt))
			{
				return ColorPickerElement.HueStrip;
			}
			if (picker.QuadRect.Contains(pt))
			{
				return ColorPickerElement.Rectangle;
			}
			return ColorPickerElement.None;
		}

		private bool HueStripContains(Vector2 pt)
		{
			float magnitude = pt.magnitude;
			if (magnitude >= picker.HueStripRadiusInner)
			{
				return magnitude <= picker.HueStripRadiusOuter;
			}
			return false;
		}
	}
}
