using UnityEngine;

namespace Utilities
{
	public class StretchByReference : MonoBehaviour
	{
		[Tooltip("Об'єкт, чия Y-позиція керує масштабом")]
		public Transform referenceObject;

		[Tooltip("Y-позиція, при якій scale.x = 1")]
		public float baseY;

		[Tooltip("Коефіцієнт чутливості (наскільки сильно scale.x змінюється при русі)")]
		public float scaleFactor = 1f;

		[Tooltip("Мінімальне та максимальне значення масштабу по X")]
		public Vector2 scaleLimits = new Vector2(0.1f, 10f);

		private Vector3 startScale;

		private void Start()
		{
			startScale = base.transform.localScale;
		}

		private void Update()
		{
			if (!(referenceObject == null))
			{
				float num = referenceObject.localPosition.y - baseY;
				float value = startScale.x + num * scaleFactor;
				value = Mathf.Clamp(value, scaleLimits.x, scaleLimits.y);
				Vector3 localScale = base.transform.localScale;
				localScale.x = value;
				base.transform.localScale = localScale;
			}
		}
	}
}
