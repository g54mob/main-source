using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Design.Symmetry;
using Assets.Scripts.Input.Events;
using Assets.Scripts.UI;
using DG.Tweening;
using Jundroo.Common.Pool;
using Jundroo.Common.Settings;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public abstract class TransformTool : DesignerTool
	{
		public const int GizmoMask = 1024;

		private static bool _connectedMode = true;

		private static bool _useLocalSpace;

		private ITransformToolGizmo _hoverAxis;

		private float _scale;

		private ITransformToolGizmo _selectedAxis;

		private NumericSetting<float> _uiScale;

		public ITransformToolGizmo HoverAxis
		{
			get
			{
				return _hoverAxis;
			}
			set
			{
				if (_hoverAxis != value)
				{
					if (_hoverAxis != null)
					{
						_hoverAxis.Highlighted = false;
					}
					_hoverAxis = value;
					if (_hoverAxis != null)
					{
						_hoverAxis.Highlighted = true;
					}
				}
			}
		}

		public bool InConnectedMode
		{
			get
			{
				return _connectedMode;
			}
			set
			{
				if (_connectedMode != value)
				{
					_connectedMode = value;
					CreatePartSelection();
				}
			}
		}

		public ITransformToolGizmo SelectedAxis
		{
			get
			{
				return _selectedAxis;
			}
			set
			{
				if (_selectedAxis == value)
				{
					return;
				}
				if (_selectedAxis != null)
				{
					_selectedAxis.Selected = false;
				}
				_selectedAxis = value;
				if (_selectedAxis != null)
				{
					_selectedAxis.Selected = true;
				}
				foreach (ITransformToolGizmo gizmo in Gizmos)
				{
					gizmo.Inactive = _selectedAxis != null && _selectedAxis != gizmo;
				}
			}
		}

		public Transform SelectedTransform { get; private set; }

		public override bool UseDragThreshold => false;

		public bool UseLocalSpace
		{
			get
			{
				return _useLocalSpace;
			}
			set
			{
				if (_useLocalSpace != value)
				{
					_useLocalSpace = value;
					CreatePartSelection();
				}
			}
		}

		protected abstract float BaseToolScale { get; }

		protected Camera Camera { get; }

		protected List<ITransformToolGizmo> Gizmos { get; private set; } = new List<ITransformToolGizmo>();

		protected override bool PartHighlightEnabled => true;

		protected PartSelection PartSelection { get; private set; }

		protected List<PartSelection> SymmetricPartSelections { get; private set; }

		protected GameObject ToolObject { get; private set; }

		protected abstract string ToolPrefabName { get; }

		protected Transform TrackedTransform { get; private set; }

		public TransformTool(Designer designer, CameraController cameraController)
			: base(designer, cameraController)
		{
			base.AllowPartSelection = true;
			base.AllowFingerAid = false;
			Camera = cameraController.Camera;
			_uiScale = Game.Instance.Settings.Gameplay.General.UserInterfaceScale;
		}

		public override void HandleInput(InputEvent e)
		{
			bool flag = false;
			if (e.InputState == InputState.Begin)
			{
				ITransformToolGizmo axisAtScreenPosition = GetAxisAtScreenPosition(e.Position);
				if (axisAtScreenPosition != null)
				{
					SelectedAxis = axisAtScreenPosition;
					base.AllowPartSelection = false;
					ProcessMouseStart(e);
					flag = true;
				}
			}
			else if (e.InputState == InputState.Updated)
			{
				if (SelectedAxis != null)
				{
					ProcessMouseDrag(e);
					flag = true;
				}
			}
			else if (e.InputState == InputState.End && SelectedAxis != null)
			{
				ProcessMouseEnd(e);
				base.AllowPartSelection = true;
				SelectedAxis = null;
			}
			if (!flag)
			{
				base.HandleInput(e);
			}
		}

		public override void MouseHover(Vector3? screenPosition)
		{
			if (screenPosition.HasValue)
			{
				HoverAxis = GetAxisAtScreenPosition(screenPosition.Value);
			}
			base.MouseHover((HoverAxis == null) ? screenPosition : ((Vector3?)null));
		}

		public override void OnAircraftRepositionStart(Vector3 delta)
		{
			base.OnAircraftRepositionStart(delta);
			base.Designer.DeselectPart();
		}

		public override void Start()
		{
			base.Start();
			base.Designer.DisableMovePart = true;
			if (ToolObject == null)
			{
				ToolObject = Game.Instance.ResourceLoader.InstantiatePrefab("Designer/" + ToolPrefabName);
				Gizmos.AddRange(ToolObject.GetComponentsInChildren<ITransformToolGizmo>());
			}
			if (SymmetricPartSelections == null)
			{
				List<PartSelection> list = (SymmetricPartSelections = new List<PartSelection>());
			}
			Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerStartGizmoTool);
			CreatePartSelection();
		}

		public override void Stop()
		{
			base.Stop();
			base.Designer.DisableMovePart = false;
			base.AllowPartSelection = true;
			SelectedAxis = null;
			ClearPartSelection();
			SetTransform(null);
		}

		public override void Update()
		{
			base.Update();
			float num = CalculateScale();
			ToolObject.transform.localScale = new Vector3(num, num, num);
			if (TrackedTransform != null && TrackedTransform.hasChanged)
			{
				CreatePartSelection();
			}
		}

		protected virtual float CalculateScale()
		{
			float num = _scale;
			if (SelectedAxis == null)
			{
				num *= Mathf.Lerp(0.95f, 1f, (1f + Mathf.Sin(Time.time * 5f)) / 2f);
			}
			float num2 = num * BaseToolScale * _uiScale.Value;
			float value;
			if (Camera.orthographic)
			{
				value = num2 * Camera.orthographicSize * 2f;
			}
			else
			{
				float num3 = Vector3.Distance(Camera.transform.position, ToolObject.transform.position);
				float num4 = Camera.fieldOfView / 60f;
				value = num2 * num3 * num4;
			}
			return Mathf.Clamp(value, 0.01f, 5f);
		}

		protected void CreatePartSelection()
		{
			ClearPartSelection();
			if (base.Designer.SelectedPart != null)
			{
				Quaternion? containerRotation = (UseLocalSpace ? ((Quaternion?)null) : new Quaternion?(Quaternion.identity));
				PartSelection = PartSelection.CreatePartSelection(base.Designer.SelectedPart, preserveConnections: true, containerRotation, null, !InConnectedMode, showAttachPoints: false);
				TrackedTransform = PartSelection.Parts[0].transform;
				TrackedTransform.hasChanged = false;
				SymmetryUtility.CreateSymmetricPartSelections(base.Designer, PartSelection, base.Designer.SelectedPart, rebuildValidSymmetry: false, !InConnectedMode, preserveConnections: true, raiseAircraftStructureChanged: false, SymmetricPartSelections);
			}
			SetTransform(PartSelection?.ContainerParent);
		}

		protected virtual ITransformToolGizmo GetAxisAtScreenPosition(Vector2 screenPosition)
		{
			if (Physics.Raycast(base.CameraController.Camera.ScreenPointToRay(screenPosition), out var hitInfo, 10000f, 1024))
			{
				return hitInfo.collider.gameObject.GetComponentInParent<ITransformToolGizmo>();
			}
			return null;
		}

		protected abstract void ProcessMouseDrag(InputEvent e);

		protected abstract void ProcessMouseEnd(InputEvent e);

		protected abstract void ProcessMouseStart(InputEvent e);

		protected override void SelectedPartChanged(PartScript newPart)
		{
			base.SelectedPartChanged(newPart);
			SelectedAxis = null;
			CreatePartSelection();
		}

		protected virtual void SetTransform(Transform transform)
		{
			SelectedTransform = transform;
			if (transform != null)
			{
				SelectedTransform.hasChanged = false;
				ToolObject.SetActive(value: true);
				ToolObject.transform.position = transform.position;
				_scale = 0.5f;
				DOTween.To(() => _scale, delegate(float x)
				{
					_scale = x;
				}, 1f, 0.25f).SetEase(Ease.OutBack).SetUpdate(isIndependentUpdate: true);
				if (UseLocalSpace)
				{
					ToolObject.transform.rotation = SelectedTransform.rotation;
				}
				else
				{
					ToolObject.transform.rotation = Quaternion.identity;
				}
			}
			else
			{
				ToolObject.SetActive(value: false);
			}
		}

		protected virtual void SyncSymmetricTransforms()
		{
			List<SymmetryTransform> value;
			using (CollectionPool<List<SymmetryTransform>, SymmetryTransform>.Get(out value))
			{
				SymmetryUtility.GetSymmetricTransforms(new SymmetryTransform(PartSelection.ContainerParent.position, PartSelection.ContainerParent.rotation), base.Designer.Symmetry, value);
				if (SymmetricPartSelections.Count != value.Count)
				{
					Debug.LogError("Unable to sync the transforms of the current symmetric part selections. " + $"The symmetric part selection count ({SymmetricPartSelections.Count}) does not match the symmetric transform count ({value.Count}).");
					return;
				}
				for (int i = 0; i < SymmetricPartSelections.Count; i++)
				{
					PartSelection partSelection = SymmetricPartSelections[i];
					SymmetryTransform symmetryTransform = value[i];
					partSelection.ContainerParent.SetPositionAndRotation(symmetryTransform.Position, symmetryTransform.Rotation);
				}
			}
		}

		private void ClearPartSelection()
		{
			TrackedTransform = null;
			if (PartSelection != null)
			{
				PartSelection.Deselect();
				PartSelection = null;
			}
			foreach (PartSelection symmetricPartSelection in SymmetricPartSelections)
			{
				symmetricPartSelection.Deselect();
			}
			SymmetricPartSelections.Clear();
		}
	}
}
