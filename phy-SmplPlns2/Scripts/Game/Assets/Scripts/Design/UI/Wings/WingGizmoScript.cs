using System;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.UI;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Jundroo.Common.Settings;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Design.UI.Wings
{
	public class WingGizmoScript : MonoBehaviour, ITransformToolGizmo
	{
		public enum HandleOrientation
		{
			Default = 0,
			Clockwise = 1,
			CounterClockwise = 2
		}

		[SerializeField]
		private AnimationCurve _animateInCurve;

		private Vector3? _cursorStartPosition;

		[SerializeField]
		private Material _dragMaterial;

		[SerializeField]
		private Transform _handle;

		[SerializeField]
		private float _handleLength = 1f;

		[SerializeField]
		private Renderer _handleRenderer;

		[SerializeField]
		private AnimationCurve _handleScaleCurve;

		private bool _highlighted;

		private bool _inactive;

		private float _initialScale;

		private LineRenderer _lineRenderer;

		private bool _moved;

		[SerializeField]
		private Material _normalMaterial;

		private Vector3 _planeNormal;

		private Func<Vector3> _positionInput;

		private Action<Vector3> _positionOutput;

		private Vector3 _primaryAxis = Vector3.right;

		private Func<Vector3> _primaryAxisFunc;

		private Vector3? _secondaryAxis;

		private Func<Vector3> _secondaryAxisFunc;

		private bool _selected;

		private Vector3 _targetStartPosition;

		private float _time;

		private Material _tutorialMaterialInstance;

		private bool _tutorialSubdued;

		private TweenerCore<Vector3, Vector3, VectorOptions> _tween;

		private TweenerCore<Color, Color, ColorOptions> _tweenColor;

		private NumericSetting<float> _uiScale;

		public Func<float> GridSize { get; set; } = () => 0f;

		public bool Highlighted
		{
			get
			{
				return _highlighted;
			}
			set
			{
				_highlighted = value;
				UpdateVisuals();
				if (value)
				{
					Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerGizmoHover);
				}
			}
		}

		public int? Id { get; set; }

		public bool Inactive
		{
			get
			{
				return _inactive;
			}
			set
			{
				if (_inactive != value)
				{
					_inactive = value;
					base.gameObject.SetActive(!value);
					if (!_inactive)
					{
						ResetTime();
						base.transform.position = _positionInput();
						UpdateRotation();
					}
				}
			}
		}

		public Vector3 Position
		{
			get
			{
				return base.transform.position;
			}
			set
			{
				base.transform.position = value;
			}
		}

		public Vector3 PrimaryAxis => _primaryAxis;

		public Vector3? SecondaryAxis => _secondaryAxis;

		public bool SecondaryAxisFree { get; set; }

		public bool Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				_selected = value;
				UpdateVisuals();
				if (value)
				{
					Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerGizmoClick);
				}
				else
				{
					Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerGizmoRelease);
				}
			}
		}

		public Transform Transform => base.transform;

		public bool TutorialSubdued
		{
			get
			{
				return _tutorialSubdued;
			}
			set
			{
				if (_tutorialSubdued != value)
				{
					_tutorialSubdued = value;
					UpdateVisuals();
				}
			}
		}

		public void Configure(Func<Vector3> getPosition, Action<Vector3> onDrag, Func<Vector3> primaryAxis, Func<Vector3> secondaryAxis = null, bool secondaryFree = true, Color? overrideColor = null, HandleOrientation handleOrientation = HandleOrientation.Default)
		{
			SecondaryAxisFree = secondaryFree;
			_primaryAxisFunc = primaryAxis;
			_secondaryAxisFunc = secondaryAxis;
			base.transform.position = getPosition();
			UpdateRotation();
			_positionInput = getPosition;
			_positionOutput = onDrag;
			if (overrideColor.HasValue)
			{
				_normalMaterial = new Material(_normalMaterial);
				_normalMaterial.SetColor("_BaseColor", overrideColor.Value);
				UpdateVisuals();
			}
			switch (handleOrientation)
			{
			case HandleOrientation.Default:
				_handleRenderer.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
				break;
			case HandleOrientation.Clockwise:
				_handleRenderer.transform.SetLocalPositionAndRotation(new Vector3(0f, 0f, 0.15f), Quaternion.Euler(90f, 0f, 0f));
				break;
			case HandleOrientation.CounterClockwise:
				_handleRenderer.transform.SetLocalPositionAndRotation(new Vector3(0f, 0f, -0.15f), Quaternion.Euler(-90f, 0f, 0f));
				break;
			}
		}

		public void OnDragContinue(Ray mouseRay)
		{
			if (!_cursorStartPosition.HasValue)
			{
				return;
			}
			Vector3? vector = ProjectPosition(mouseRay);
			if (!vector.HasValue)
			{
				return;
			}
			Vector3 vector2 = _positionInput();
			Vector3 vector3 = vector.Value - _cursorStartPosition.Value;
			float num = GridSize();
			if (num > 0f)
			{
				float value = Vector3.Dot(PrimaryAxis, vector3);
				value = MovePartTool.SnapToGrid(value, num, centerAroundZero: false);
				if (SecondaryAxis.HasValue)
				{
					float value2 = Vector3.Dot(SecondaryAxis.Value, vector3);
					value2 = MovePartTool.SnapToGrid(value2, num, centerAroundZero: false);
					vector3 = PrimaryAxis * value + SecondaryAxis.Value * value2;
				}
				else
				{
					vector3 = PrimaryAxis * value;
				}
			}
			_positionOutput?.Invoke(_targetStartPosition + vector3);
			if ((_positionInput() - vector2).magnitude > 0.01f)
			{
				_moved = true;
				Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerResize);
			}
		}

		public bool OnDragEnd()
		{
			_cursorStartPosition = null;
			Selected = false;
			return _moved;
		}

		public void OnDragStart(Ray mouseRay)
		{
			_moved = false;
			_targetStartPosition = base.transform.position;
			_cursorStartPosition = ProjectPosition(mouseRay);
			Selected = true;
		}

		[ContextMenu("Reset Time")]
		public void ResetTime()
		{
			_time = 0f;
		}

		protected void LateUpdate()
		{
			if (_positionInput != null)
			{
				base.transform.position = _positionInput();
			}
			UpdateRotation();
			if (!Selected && !Inactive)
			{
				Camera camera = Designer.Instance.CameraController.Camera;
				float num = 0.1f * _uiScale.Value;
				float num2 = Vector3.Distance(camera.transform.position, base.transform.position);
				float num3 = 0.015f;
				float value;
				float a;
				if (camera.orthographic)
				{
					value = num * 2f * camera.orthographicSize;
					value = Mathf.Clamp(value, 0.01f, 5f);
					a = num3 * camera.orthographicSize;
				}
				else
				{
					float num4 = camera.fieldOfView / 60f;
					value = num * num2 * num4;
					value = Mathf.Clamp(value, 0.01f, 5f);
					a = num3 * num2 * Mathf.Tan(camera.fieldOfView * 0.5f * (MathF.PI / 180f));
				}
				base.transform.localScale = Vector3.one * value;
				if (!Highlighted && !Selected)
				{
					float num5 = (_tutorialSubdued ? 1f : (_handleScaleCurve.Evaluate(Time.unscaledTime) * _initialScale));
					_handle.localScale = new Vector3(num5, num5, num5);
				}
				_time += Time.unscaledDeltaTime;
				float z = _animateInCurve.Evaluate(_time) * _handleLength;
				_handle.localPosition = new Vector3(0f, 0f, z);
				if (_lineRenderer != null)
				{
					_lineRenderer.SetPosition(0, Vector3.zero);
					_lineRenderer.SetPosition(1, new Vector3(0f, 0f, z));
					a = Mathf.Max(a, 0.0001f);
					_lineRenderer.startWidth = a;
					_lineRenderer.endWidth = a;
				}
			}
		}

		protected void OnDestroy()
		{
			if (_tutorialMaterialInstance != null)
			{
				UnityEngine.Object.Destroy(_tutorialMaterialInstance);
				_tutorialMaterialInstance = null;
			}
		}

		protected void OnEnable()
		{
			CreateLine();
			_handleRenderer.sharedMaterial = _normalMaterial;
		}

		protected void Start()
		{
			_uiScale = Game.Instance.Settings.Gameplay.General.UserInterfaceScale;
			_initialScale = _handle.localScale.x;
			bool isTouchEnabled = Game.Instance.Device.IsTouchEnabled;
			_handle.GetComponentInChildren<BoxCollider>().enabled = isTouchEnabled;
			_handle.GetComponentInChildren<MeshCollider>().enabled = !isTouchEnabled;
			CreateLine();
		}

		private void CreateLine()
		{
			if (!(_lineRenderer != null))
			{
				_lineRenderer = base.gameObject.GetComponent<LineRenderer>();
				_lineRenderer.positionCount = 2;
				_lineRenderer.SetPositions(new Vector3[2]
				{
					Vector3.zero,
					Vector3.zero
				});
				_lineRenderer.useWorldSpace = false;
				_lineRenderer.enabled = true;
			}
		}

		private Vector3? ProjectPosition(Ray ray)
		{
			if (SecondaryAxis.HasValue && SecondaryAxisFree)
			{
				if (new Plane(_planeNormal, base.transform.position).Raycast(ray, out var enter))
				{
					return ray.GetPoint(enter);
				}
				return null;
			}
			Vector3 lhs = ray.origin - base.transform.position;
			Vector3 primaryAxis = _primaryAxis;
			Vector3 direction = ray.direction;
			float num = Vector3.Dot(primaryAxis, direction);
			float2 float5 = math.mul(math.inverse(new float2x2(1f, 0f - num, num, -1f)), math.float2(Vector3.Dot(lhs, primaryAxis), Vector3.Dot(lhs, direction)));
			if (float5.y < 0f)
			{
				return null;
			}
			return base.transform.position + _primaryAxis * float5.x;
		}

		private void UpdateRotation()
		{
			Vector3 vector = _primaryAxisFunc();
			Vector3? vector2 = _secondaryAxisFunc?.Invoke();
			if (vector != _primaryAxis || vector2 != _secondaryAxis)
			{
				_primaryAxis = vector;
				_secondaryAxis = vector2;
				Vector3 vector3;
				if (!SecondaryAxis.HasValue)
				{
					vector3 = ((!(Mathf.Abs(PrimaryAxis.normalized.y) < 0.7f)) ? Vector3.forward : Vector3.up);
				}
				else
				{
					vector3 = SecondaryAxis.Value;
					_planeNormal = Vector3.Cross(_primaryAxis, vector3).normalized;
				}
				base.transform.rotation = Quaternion.LookRotation(PrimaryAxis, vector3);
			}
		}

		private void UpdateVisuals()
		{
			_tween?.Kill(complete: true);
			_tween = null;
			_tweenColor?.Kill(complete: true);
			_tweenColor = null;
			Material material = _normalMaterial;
			float? num = null;
			if (_tutorialSubdued)
			{
				_normalMaterial.GetColor("_BaseColor");
				_dragMaterial.GetColor("_BaseColor");
				_tutorialMaterialInstance = new Material(material);
				_handleRenderer.sharedMaterial = _tutorialMaterialInstance;
				float num2 = 0.25f;
				_tutorialMaterialInstance.SetColor("_BaseColor", new Color(num2, num2, num2, 1f));
				return;
			}
			if (_selected)
			{
				num = _initialScale;
				material = _dragMaterial;
			}
			else if (_highlighted)
			{
				num = _initialScale * 1.2f;
			}
			_handleRenderer.sharedMaterial = material;
			if (num.HasValue)
			{
				_tween = _handle.DOScale(num.Value, 0.35f).SetEase(Ease.OutElastic).SetUpdate(isIndependentUpdate: true)
					.SetLink(_handle.gameObject);
			}
		}
	}
}
