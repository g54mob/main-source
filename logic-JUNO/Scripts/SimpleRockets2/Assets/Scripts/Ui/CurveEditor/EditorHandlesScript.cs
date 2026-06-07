using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Ui.CurveEditor
{
	public class EditorHandlesScript : MonoBehaviour
	{
		[SerializeField]
		private float _fixedHandleLength = 60f;

		[SerializeField]
		private CurveEditorScript _parent;

		[SerializeField]
		private RectTransform _rectTransform;

		[SerializeField]
		private RectTransform _leftHandle;

		[SerializeField]
		private RectTransform _leftHandleLine;

		[SerializeField]
		private RectTransform _rightHandle;

		[SerializeField]
		private RectTransform _rightHandleLine;

		[SerializeField]
		private HandleScript _leftHandleScript;

		[SerializeField]
		private HandleScript _rightHandleScript;

		private Keyframe _keyframe;

		private Keyframe? _previous;

		private Keyframe? _next;

		private int _index;

		private bool _leftLengthLocked;

		private bool _rightLengthLocked;

		public void UpdateFrom(Keyframe k, Keyframe? previous, Keyframe? next, int index)
		{
			if (_rectTransform == null)
			{
				_rectTransform = GetComponent<RectTransform>();
			}
			_keyframe = k;
			_index = index;
			Vector2 vector = _parent.CurveToPixel(new Vector2(k.time, k.value));
			_rectTransform.localPosition = vector;
			_previous = previous;
			_next = next;
			if (!previous.HasValue)
			{
				_leftHandle.gameObject.SetActive(value: false);
				_leftHandleLine.gameObject.SetActive(value: false);
			}
			else if ((k.weightedMode == WeightedMode.In || k.weightedMode == WeightedMode.Both) && k.inTangent != float.PositiveInfinity)
			{
				_leftLengthLocked = false;
				_leftHandle.gameObject.SetActive(value: true);
				_leftHandleLine.gameObject.SetActive(value: true);
				Vector2 curve = new Vector2(Mathf.Lerp(k.time, previous.Value.time, k.inWeight), 0f);
				curve.y = k.inTangent * (curve.x - k.time) + k.value;
				curve = _parent.CurveToPixel(curve) - (Vector2)_rectTransform.localPosition;
				_leftHandle.localPosition = curve;
				SetLine(_leftHandleLine, curve);
			}
			else
			{
				_leftHandle.gameObject.SetActive(value: true);
				_leftHandleLine.gameObject.SetActive(value: true);
				_leftLengthLocked = true;
				Vector2 vector2 = -TangentToVector(k.inTangent * _parent.AspectRatio) * _fixedHandleLength;
				_leftHandle.localPosition = vector2;
				SetLine(_leftHandleLine, vector2);
			}
			if (!next.HasValue)
			{
				_rightHandle.gameObject.SetActive(value: false);
				_rightHandleLine.gameObject.SetActive(value: false);
			}
			else if ((k.weightedMode == WeightedMode.Out || k.weightedMode == WeightedMode.Both) && k.outTangent != float.PositiveInfinity)
			{
				_rightLengthLocked = false;
				_rightHandle.gameObject.SetActive(value: true);
				_rightHandleLine.gameObject.SetActive(value: true);
				Vector2 curve2 = new Vector2(Mathf.Lerp(k.time, next.Value.time, k.outWeight), 0f);
				curve2.y = k.outTangent * (curve2.x - k.time) + k.value;
				curve2 = _parent.CurveToPixel(curve2) - (Vector2)_rectTransform.localPosition;
				_rightHandle.localPosition = curve2;
				SetLine(_rightHandleLine, curve2);
			}
			else
			{
				_rightHandle.gameObject.SetActive(value: true);
				_rightHandleLine.gameObject.SetActive(value: true);
				_rightLengthLocked = true;
				Vector2 vector3 = TangentToVector(k.outTangent * _parent.AspectRatio) * _fixedHandleLength;
				_rightHandle.localPosition = vector3;
				SetLine(_rightHandleLine, vector3);
			}
		}

		private void Start()
		{
			_leftHandleScript.OnDrag += LeftHandleDrag;
			_rightHandleScript.OnDrag += RightHandleDrag;
			_parent.PrepareGrabbableElement(_leftHandle);
			_parent.PrepareGrabbableElement(_rightHandle);
		}

		private void SetLine(RectTransform line, Vector2 pos)
		{
			line.localRotation = Quaternion.AngleAxis(Mathf.Atan2(pos.y, pos.x) * 57.29578f, Vector3.forward);
			line.sizeDelta = new Vector2(pos.magnitude, line.sizeDelta.y);
		}

		private Vector2 TangentToVector(float tangent)
		{
			if (tangent == float.PositiveInfinity)
			{
				return Vector2.up;
			}
			return new Vector2(1f, tangent).normalized;
		}

		private void LeftHandleDrag(PointerEventData eventData)
		{
			if (!_previous.HasValue)
			{
				return;
			}
			Keyframe value = _previous.Value;
			if (_leftLengthLocked)
			{
				Vector2 vector = -(eventData.position - (Vector2)_rectTransform.position);
				float num;
				if (vector.x <= 0f)
				{
					num = float.PositiveInfinity;
					vector.x = 0f;
				}
				else
				{
					num = vector.y / vector.x / _parent.AspectRatio;
				}
				Vector2 vector2 = -vector.normalized * _fixedHandleLength;
				_leftHandle.localPosition = vector2;
				SetLine(_leftHandleLine, vector2);
				_keyframe.inTangent = num;
				if (_keyframe.tangentMode == 0)
				{
					_rightHandle.localPosition = -vector2;
					SetLine(_rightHandleLine, -vector2);
					_keyframe.outTangent = num;
				}
				_parent.OnTangentsChanged(_keyframe, _index);
				return;
			}
			Vector2 vector3 = eventData.position - (Vector2)_rectTransform.position;
			float num2;
			float inWeight;
			if (vector3.x >= 0f)
			{
				num2 = float.PositiveInfinity;
				inWeight = _keyframe.inWeight;
				vector3.x = 0f;
				vector3.y = 0f - _fixedHandleLength;
			}
			else
			{
				vector3 = _parent.PixelToCurve(vector3 + (Vector2)_rectTransform.localPosition);
				inWeight = Mathf.InverseLerp(_keyframe.time, value.time, vector3.x);
				vector3 -= new Vector2(_keyframe.time, _keyframe.value);
				num2 = vector3.y / vector3.x;
			}
			_keyframe.inTangent = num2;
			_keyframe.inWeight = inWeight;
			if (_keyframe.tangentMode == 0)
			{
				_keyframe.outTangent = num2;
			}
			_parent.OnTangentsChanged(_keyframe, _index);
		}

		private void RightHandleDrag(PointerEventData eventData)
		{
			if (!_next.HasValue)
			{
				return;
			}
			Keyframe value = _next.Value;
			if (_rightLengthLocked)
			{
				Vector2 vector = eventData.position - (Vector2)_rectTransform.position;
				float num;
				if (vector.x <= 0f)
				{
					num = float.PositiveInfinity;
					vector.x = 0f;
				}
				else
				{
					num = vector.y / vector.x / _parent.AspectRatio;
				}
				Vector2 vector2 = vector.normalized * _fixedHandleLength;
				_rightHandle.localPosition = vector2;
				SetLine(_rightHandleLine, vector2);
				_keyframe.outTangent = num;
				if (_keyframe.tangentMode == 0)
				{
					_leftHandle.localPosition = -vector2;
					SetLine(_leftHandleLine, -vector2);
					_keyframe.inTangent = num;
				}
				_parent.OnTangentsChanged(_keyframe, _index);
				return;
			}
			Vector2 vector3 = eventData.position - (Vector2)_rectTransform.position;
			float num2;
			float outWeight;
			if (vector3.x <= 0f)
			{
				num2 = float.PositiveInfinity;
				outWeight = _keyframe.outWeight;
				vector3.x = 0f;
				vector3.y = _fixedHandleLength;
			}
			else
			{
				vector3 = _parent.PixelToCurve(vector3 + (Vector2)_rectTransform.localPosition);
				outWeight = Mathf.InverseLerp(_keyframe.time, value.time, vector3.x);
				vector3 -= new Vector2(_keyframe.time, _keyframe.value);
				num2 = vector3.y / vector3.x;
			}
			_keyframe.outTangent = num2;
			_keyframe.outWeight = outWeight;
			if (_keyframe.tangentMode == 0)
			{
				_keyframe.inTangent = num2;
			}
			_parent.OnTangentsChanged(_keyframe, _index);
		}
	}
}
