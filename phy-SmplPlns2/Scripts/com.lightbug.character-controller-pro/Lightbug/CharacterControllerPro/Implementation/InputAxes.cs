using UnityEngine;
using UnityEngine.EventSystems;

namespace Lightbug.CharacterControllerPro.Implementation
{
	[AddComponentMenu("Character Controller Pro/Implementation/UI/Input Axes")]
	public class InputAxes : MonoBehaviour, IDragHandler, IEventSystemHandler, IEndDragHandler, IUIVector2Action, IUIAction
	{
		public enum DeadZoneMode
		{
			Radial = 0,
			PerAxis = 1
		}

		[Header("Targets")]
		[SerializeField]
		private string actionName = "";

		[Header("Handles properties")]
		[SerializeField]
		private bool invertHorizontal;

		[SerializeField]
		private bool invertVertical;

		[Tooltip("How is the dead zone affected the output value. To visualize better the dead zone, think of \"Radial\" as a circle, and \"PerAxis\" as a cardinal cross.")]
		[SerializeField]
		private DeadZoneMode deadZoneMode;

		[Tooltip("Minimum amount of magnitude (considering the axis scale) needed to produce a non zero output. Magnitudes lower than this value will be considered as zero.")]
		[Range(0f, 1f)]
		[SerializeField]
		private float deadZoneDistance = 0.2f;

		[SerializeField]
		private int boundsRadius = 50;

		[Header("Handle visuals")]
		[Range(2f, 50f)]
		[SerializeField]
		private float returnLerpSpeed = 10f;

		private Vector2 vector2Value;

		private Vector2 virtualPosition;

		private Vector2 visiblePosition;

		private RectTransform rectTransform;

		private Vector2 origin = Vector2.zero;

		private bool drag;

		public string ActionName => actionName;

		public Vector2 Vector2Value => vector2Value;

		private void Awake()
		{
			virtualPosition = origin;
			rectTransform = GetComponent<RectTransform>();
		}

		private void Update()
		{
			if (!drag)
			{
				virtualPosition = visiblePosition;
				virtualPosition = Vector2.Lerp(virtualPosition, origin, returnLerpSpeed * Time.deltaTime);
			}
			Vector2 vector = virtualPosition - origin;
			visiblePosition = origin + Vector2.ClampMagnitude(vector, boundsRadius);
			rectTransform.anchoredPosition = visiblePosition;
			Vector2 vector2 = (visiblePosition - origin) / boundsRadius;
			if (deadZoneMode == DeadZoneMode.Radial)
			{
				float num = Vector3.Magnitude(vector2);
				vector2.x = ((num > deadZoneDistance) ? vector2.x : 0f);
				vector2.y = ((num > deadZoneDistance) ? vector2.y : 0f);
			}
			else
			{
				float num2 = Mathf.Abs(vector2.x);
				float num3 = Mathf.Abs(vector2.y);
				vector2.x = ((num2 > deadZoneDistance) ? vector2.x : 0f);
				vector2.y = ((num3 > deadZoneDistance) ? vector2.y : 0f);
			}
			if (invertHorizontal)
			{
				vector2.x *= -1f;
			}
			if (invertVertical)
			{
				vector2.y *= -1f;
			}
			vector2Value = vector2;
		}

		public void OnDrag(PointerEventData eventData)
		{
			drag = true;
			virtualPosition += eventData.delta / 2f;
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			drag = false;
		}
	}
}
