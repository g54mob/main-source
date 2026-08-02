using System;
using FishingGameTool.CustomAttribute;
using FishingGameTool.Fishing.Line;
using UnityEngine;

namespace FishingGameTool.Fishing.Rod
{
	[AddComponentMenu("Fishing Game Tool/Fishing Rod")]
	[RequireComponent(typeof(Animator), typeof(LineRenderer))]
	public class FishingRod : MonoBehaviour
	{
		[Serializable]
		public class FishingLineSettings
		{
			public Transform _lineAttachment;

			[InfoBox("This is the range of the number of points for the Line Renderer. It is adjusted based on the distance between the line attachment and the float.")]
			public Vector2 _resolutionRange = new Vector2
			{
				x = 40f,
				y = 10f
			};

			[Range(-2f, 0f)]
			public float _simulateGravity = -1f;

			[Space]
			public Color _color = new Color32(0, 0, 0, byte.MaxValue);

			public float _width = 0.005f;
		}

		[BetterHeader("Fishing Line Settings", 20)]
		public FishingLineSettings _line;

		[Space]
		[BetterHeader("Fishing Line Status", 20)]
		public FishingLineStatus _lineStatus;

		public bool _isLineBreakable = true;

		[Space]
		[BetterHeader("Fishing Rod Settings", 20)]
		public float _baseAttractSpeed = 5f;

		[InfoBox("Determines the allowable range of bending angles for the fishing rod. It is used to adjust the bending of the rod based on the calculated angles. The x-component represents the minimum angle, while the y-component represents the maximum angle.")]
		public Vector2 _angleRange = new Vector2
		{
			x = -110f,
			y = 110f
		};

		[Space]
		[AddButton("Show Debug Options", "_showDebugOption")]
		public bool _showDebugOption;

		[ShowVariable("_showDebugOption")]
		[Space]
		[BetterHeader("For Debug", 20)]
		[InfoBox("The variables below allow you to test the fishing rod during configuration. These variables are modified by the main Fishing System script.")]
		public Transform _fishingFloat;

		[ShowVariable("_showDebugOption")]
		public bool _lootCaught;

		public GameObject _controllerToFollow;

		private Animator _animator;

		private LineRenderer _fishingLineRenderer;

		private float _smoothedSimGravity;

		private Vector2 _smoothedBend;

		private Vector3 lastPos = Vector3.zero;

		private Quaternion lastRot = Quaternion.identity;

		private void Awake()
		{
			if (_line._lineAttachment == null)
			{
				Debug.LogError("Please add a fishing line attachment!");
				base.enabled = false;
			}
			_animator = GetComponent<Animator>();
			_fishingLineRenderer = GetComponent<LineRenderer>();
			_fishingLineRenderer.startColor = _line._color;
			_fishingLineRenderer.endColor = _line._color;
			_fishingLineRenderer.startWidth = _line._width;
			_fishingLineRenderer.endWidth = _line._width;
		}

		private void Update()
		{
			CalculateBend();
			FishingLine();
			FollowController();
		}

		private void FollowController()
		{
			if (lastPos != Vector3.zero && lastRot != Quaternion.identity)
			{
				base.gameObject.transform.SetPositionAndRotation(Vector3.Lerp(lastPos, _controllerToFollow.transform.position, Time.deltaTime * 0.5f), Quaternion.Lerp(lastRot, _controllerToFollow.transform.rotation, Time.deltaTime * 0.5f));
			}
			if (_controllerToFollow != null)
			{
				lastPos = _controllerToFollow.transform.position;
				lastRot = _controllerToFollow.transform.rotation;
			}
		}

		private void CalculateBend()
		{
			Vector2 zero = Vector2.zero;
			zero = ((!_lineStatus._isLineBroken && !(_fishingFloat == null) && _lootCaught) ? RemapAngleToBend(CalculateAngles(_fishingFloat.position, base.transform.position), _angleRange) : Vector2.zero);
			float num = 14f;
			_smoothedBend = Vector2.Lerp(_smoothedBend, zero, Time.deltaTime * num);
			_animator.SetFloat("HorizontalBend", _smoothedBend.x);
			_animator.SetFloat("VerticalBend", _smoothedBend.y);
		}

		private static Vector2 RemapAngleToBend(Vector2 angle, Vector2 angleRange)
		{
			float t = Mathf.InverseLerp(angleRange.x, angleRange.y, angle.x);
			float t2 = Mathf.InverseLerp(angleRange.x, angleRange.y, angle.y);
			float num = Mathf.Lerp(-1f, 1f, t);
			float num2 = Mathf.Lerp(-1f, 1f, t2);
			return new Vector2(0f - num, 0f - num2);
		}

		private Vector2 CalculateAngles(Vector3 floatPosition, Vector3 position)
		{
			Vector3 to = floatPosition - position;
			float num = 90f;
			float x = Vector3.Angle(base.transform.right, to) - num;
			float y = Vector3.Angle(base.transform.up, to) - num;
			return new Vector2(x, y);
		}

		private void FishingLine()
		{
			if (_lineStatus._isLineBroken || _fishingFloat == null)
			{
				_fishingLineRenderer.positionCount = 0;
				return;
			}
			float num = Vector3.Distance(_line._lineAttachment.position, _fishingFloat.position);
			int num2 = CalculateLineResolution(num, _line._resolutionRange);
			_lineStatus._currentLineLength = num;
			_fishingLineRenderer.positionCount = num2;
			for (int i = 0; i < num2; i++)
			{
				float t = (float)i / (float)num2;
				Vector3 position = CalculatePointOnCurve(t, _line._lineAttachment.position, _fishingFloat.position, _lootCaught, _line._simulateGravity);
				_fishingLineRenderer.SetPosition(i, position);
			}
		}

		private static int CalculateLineResolution(float distance, Vector2 resolutionRange)
		{
			float b = 20f;
			float t = Mathf.InverseLerp(1f, b, distance);
			return (int)Mathf.Lerp(resolutionRange.x, resolutionRange.y, t);
		}

		private Vector3 CalculatePointOnCurve(float t, Vector3 attachmentPosition, Vector3 floatPosition, bool lootCaught, float simulateGravity)
		{
			float num = 2f;
			_smoothedSimGravity = Mathf.Lerp(_smoothedSimGravity, lootCaught ? 0f : simulateGravity, Time.deltaTime * num);
			Vector3 p = Vector3.Lerp(attachmentPosition, floatPosition, 0.5f) + Vector3.up * _smoothedSimGravity;
			return CalculateBezier(attachmentPosition, p, floatPosition, t, floatPosition);
		}

		private Vector3 CalculateBezier(Vector3 p0, Vector3 p1, Vector3 p2, float t, Vector3 floatPosition)
		{
			float num = 1f - t;
			float num2 = t * t;
			float num3 = num * num;
			float num4 = num3 * num;
			float num5 = num2 * t;
			return num4 * p0 + 3f * num3 * t * p1 + 3f * num * num2 * p2 + num5 * floatPosition;
		}

		public FishingLineStatus CalculateLineLoad(bool attractInput, float lootWeight, int lootTier)
		{
			Vector3 to = _fishingFloat.position - base.transform.position;
			float num = Vector3.Angle(base.transform.forward, to);
			num = ((num > _angleRange.y) ? _angleRange.y : num);
			if (attractInput)
			{
				float num2 = 4f;
				float num3 = ((lootWeight - lootWeight / (float)lootTier <= 0f) ? 1f : (lootWeight - lootWeight / (float)lootTier));
				_lineStatus._currentLineLoad += num * num3 * Time.deltaTime / num2;
				_lineStatus._currentLineLoad = ((_lineStatus._currentLineLoad > _lineStatus._maxLineLoad) ? _lineStatus._maxLineLoad : _lineStatus._currentLineLoad);
			}
			else
			{
				_lineStatus._currentOverLoad = 0f;
				float num4 = 5f;
				_lineStatus._currentLineLoad -= num4 * Time.deltaTime;
				_lineStatus._currentLineLoad = ((_lineStatus._currentLineLoad < 0f) ? 0f : _lineStatus._currentLineLoad);
			}
			if (_lineStatus._currentLineLoad == _lineStatus._maxLineLoad)
			{
				_lineStatus._currentOverLoad += Time.deltaTime;
				if (_lineStatus._currentOverLoad >= _lineStatus._overLoadDuration)
				{
					if (_isLineBreakable)
					{
						_lineStatus._isLineBroken = true;
					}
					FishingSystem[] array = UnityEngine.Object.FindObjectsOfType<FishingSystem>();
					if (array.Length > 1)
					{
						Debug.LogWarning("There is more than one object on the scene containing the Fishing System component. Please remove the other components containing Fishing System!");
					}
					else
					{
						array[0].ForceStopFishing();
					}
				}
			}
			_lineStatus._attractFloatSpeed = CalculateAttractSpeed(num, _angleRange, _lineStatus._currentLineLoad, _lineStatus._maxLineLoad, _baseAttractSpeed, lootTier);
			return _lineStatus;
		}

		private float CalculateAttractSpeed(float angle, Vector2 angleRange, float currentLineLoad, float maxLineLoad, float baseAttractSpeed, int lootTier)
		{
			float num = angle / angleRange.y;
			float num2 = CalculateAttractBonus(currentLineLoad, maxLineLoad, lootTier);
			float num3 = num * num2;
			return baseAttractSpeed + num3;
		}

		private static float CalculateAttractBonus(float currentLineLoad, float maxLineLoad, int lootTier)
		{
			float[] array = new float[5] { 0.2f, 0.4f, 0.6f, 0.8f, 1f };
			float t = Mathf.InverseLerp(0f, maxLineLoad, currentLineLoad);
			return Mathf.Lerp(1f, currentLineLoad * array[lootTier], t);
		}

		public void LootCaught(bool value)
		{
			_lootCaught = value;
		}

		public void FinishFishing()
		{
			_lineStatus._attractFloatSpeed = 0f;
			_lineStatus._currentLineLoad = 0f;
			_lineStatus._currentOverLoad = 0f;
			_lootCaught = false;
		}
	}
}
