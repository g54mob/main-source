using System;
using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Design.Tools;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Design;
using ModApi.Design.Events;
using ModApi.Settings;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class DesignerPlatformScript : MonoBehaviour
	{
		private static List<Collider> _tempListCalculateBoundsColliders = new List<Collider>();

		private Bounds _bounds;

		[SerializeField]
		private float _boundsBoxCastSize = 10000f;

		[SerializeField]
		private float _boundsBoxCastThickness = 1f;

		private IDesigner _designer;

		private DesignerSettings _designerSettings;

		private bool _draggingParts;

		private float _gridSize;

		[SerializeField]
		private Transform _mirrorPlane;

		[SerializeField]
		private Transform _platform;

		private Material _platformGridMaterial;

		[SerializeField]
		private MeshRenderer _platformRenderer;

		private bool _reposition;

		private bool _resize;

		private TweenerCore<Vector3, Vector3, VectorOptions> _tween;

		public bool AutoResize { get; set; }

		public bool MirrorPlaneEnabled
		{
			get
			{
				return _mirrorPlane.gameObject.activeSelf;
			}
			set
			{
				_mirrorPlane.gameObject.SetActive(value);
				if (value)
				{
					UpdateMirrorPlane();
				}
			}
		}

		public Vector2 MirrorPlaneScale
		{
			get
			{
				Vector3 localScale = _mirrorPlane.GetChild(0).transform.localScale;
				return new Vector2(localScale.x, localScale.y);
			}
			set
			{
				_mirrorPlane.GetChild(0).transform.localScale = new Vector3(value.x, value.y, 1f);
			}
		}

		public Transform MirrorPlaneTransform => _mirrorPlane;

		public void Initialize(IDesigner designer)
		{
			_designer = designer;
			designer.CraftStructureChanged += OnCraftStructureChanged;
			designer.CraftLoaded += OnCraftStructureChanged;
			designer.SelectedPartChanged += OnSelectedPartChanged;
			designer.TutorialStepLoaded += OnTutorialStepLoaded;
			MovePartTool obj = _designer.MovePartTool as MovePartTool;
			obj.DragPartSelectionStarted += OnDragPartSelectionStarted;
			obj.DragPartSelectionEnded += OnDragPartSelectionEnded;
		}

		protected virtual void Awake()
		{
			_designerSettings = Game.Instance.Settings.Game.Designer;
		}

		protected virtual void OnDestroy()
		{
			if (_designer != null)
			{
				_designer.SelectedPartChanged -= OnSelectedPartChanged;
			}
			if (_platformGridMaterial != null)
			{
				UnityEngine.Object.Destroy(_platformGridMaterial);
				_platformGridMaterial = null;
			}
		}

		protected virtual void Start()
		{
			_resize = AutoResize;
			Reposition(animate: false);
			for (int i = 0; i < _platformRenderer.materials.Length; i++)
			{
				if (_platformRenderer.materials[i].name == "DesignerPlatform (Instance)")
				{
					_platformGridMaterial = _platformRenderer.materials[i];
				}
			}
		}

		protected virtual void Update()
		{
			if (!_draggingParts)
			{
				DesignerTool capturedTool = _designer.CapturedTool;
				if (capturedTool == null || !capturedTool.IsInputCaptured)
				{
					goto IL_0028;
				}
			}
			_reposition = true;
			goto IL_0028;
			IL_0028:
			if (_reposition)
			{
				_reposition = false;
				Reposition(animate: true);
			}
			bool flag = _designer.DesignerCamera.Transform.position.y > _platform.position.y;
			if (flag != _platform.gameObject.activeSelf)
			{
				_platform.gameObject.SetActive(flag);
			}
			if (_gridSize != _designerSettings.GridSize.Value)
			{
				_gridSize = _designerSettings.GridSize;
				float num = (float)_designerSettings.GridSize * 5f;
				num = ((num == 0f) ? 1.25f : num);
				_platformGridMaterial.SetFloat("_GridSize", num);
			}
		}

		private Bounds CalculateCraftBounds(CraftScript craftScript)
		{
			int layerMask = -2147475452;
			return Utilities.PhysicsUtils.BoxcastBounds(Vector3.zero, layerMask, _boundsBoxCastSize, _boundsBoxCastThickness, QueryTriggerInteraction.Collide) ?? new Bounds(Vector3.zero, Vector3.zero);
		}

		private void OnCraftStructureChanged()
		{
			_reposition = true;
			_resize = true;
		}

		private void OnDragPartSelectionEnded()
		{
			_draggingParts = false;
		}

		private void OnDragPartSelectionStarted()
		{
			_draggingParts = true;
		}

		private void OnSelectedPartChanged(IPartScript oldPart, IPartScript newPart)
		{
			if (MirrorPlaneEnabled)
			{
				UpdateMirrorPlane();
			}
		}

		private void OnTutorialStepLoaded(object sender, DesignerTutorialStepLoadedEventArgs e)
		{
			_reposition = true;
			_resize = true;
		}

		private void Reposition(bool animate)
		{
			CraftScript craftScript = _designer.CraftScript as CraftScript;
			if (craftScript == null)
			{
				return;
			}
			_bounds = CalculateCraftBounds(craftScript);
			Transform transform = craftScript.RootPart.Transform;
			Vector3 vector = _bounds.min - transform.position;
			Vector3 vector2 = _bounds.max - transform.position;
			Vector3 position = craftScript.CenterOfMass.transform.position;
			position.y = transform.position.y + vector.y - 0.0573f;
			if (position.y < _platform.position.y)
			{
				animate = false;
			}
			Vector3? vector3 = null;
			if (_resize)
			{
				_resize = false;
				if (AutoResize)
				{
					Vector3 vector4 = vector2 - vector;
					float num = Mathf.Max(Mathf.Abs(vector4.x), Mathf.Abs(vector4.z)) / 2f + 5f;
					vector3 = new Vector3(num, 1f, num);
				}
				else
				{
					vector3 = new Vector3(20f, 1f, 20f);
				}
			}
			if (animate)
			{
				_tween?.Kill();
				_tween = DOTween.To(() => _platform.position, delegate(Vector3 x)
				{
					_platform.position = x;
					_platformGridMaterial.SetVector("_Center", x);
				}, position, 0.5f);
				if (vector3.HasValue)
				{
					DOTween.To(() => _platform.localScale, delegate(Vector3 x)
					{
						_platform.localScale = x;
					}, vector3.Value, 0.5f);
				}
			}
			else
			{
				_tween?.Kill();
				_tween = null;
				_platform.position = position;
				if (vector3.HasValue)
				{
					_platform.localScale = vector3.Value;
				}
			}
		}

		private void UpdateMirrorPlane()
		{
			IPartScript selectedPart = _designer.SelectedPart;
			if (selectedPart != null)
			{
				IPartScript partScript = selectedPart?.SymmetrySlice?.SymmetryGroup?.RootPart;
				if (partScript != null)
				{
					Transform obj = partScript.Transform;
					Vector3 position = obj.position;
					Quaternion rotation = obj.rotation;
					Vector3 position2 = selectedPart.Transform.position;
					Vector3 vector = Quaternion.Inverse(rotation) * (position2 - position);
					Vector3 vector2 = new Vector3(1f, (Math.Abs(vector.y) + 3f) * 2f, (Math.Abs(vector.z) + 3f) * 2f);
					_mirrorPlane.SetPositionAndRotation(position, rotation);
					MirrorPlaneScale = new Vector2(vector2.z, vector2.y);
				}
			}
		}
	}
}
