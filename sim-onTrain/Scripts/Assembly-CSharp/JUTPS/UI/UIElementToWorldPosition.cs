using UnityEngine;

namespace JUTPS.UI
{
	public class UIElementToWorldPosition : MonoBehaviour
	{
		public Vector3 WorldPosition;

		public Vector3 Offset;

		private Camera cam;

		private void Start()
		{
			cam = Camera.main;
		}

		private void Update()
		{
			if (!(cam == null))
			{
				Vector3 vector = cam.WorldToScreenPoint(WorldPosition + Offset);
				if (base.transform.position != vector)
				{
					base.transform.position = vector;
				}
			}
		}

		public static void SetUIWorldPosition(GameObject UIElement, Vector3 position, Vector3 offset, bool ClampOffscreen = false, float OffScreenOffset = 20f)
		{
			Vector3 vector = Camera.main.WorldToScreenPoint(position + offset);
			if (UIElement.transform.position != vector)
			{
				UIElement.transform.position = vector;
			}
			if (ClampOffscreen)
			{
				RectTransform component = UIElement.GetComponent<RectTransform>();
				RectTransform componentInParent = component.parent.GetComponentInParent<RectTransform>();
				float num = componentInParent.rect.width / 2f;
				float num2 = componentInParent.rect.height / 2f;
				float x = Mathf.Clamp(component.localPosition.x, 0f - num + OffScreenOffset, num - OffScreenOffset);
				float y = Mathf.Clamp(component.localPosition.y, 0f - num2 + OffScreenOffset, num2 - OffScreenOffset);
				Vector3 localPosition = new Vector3(x, y, component.localPosition.z);
				component.localPosition = localPosition;
			}
		}
	}
}
