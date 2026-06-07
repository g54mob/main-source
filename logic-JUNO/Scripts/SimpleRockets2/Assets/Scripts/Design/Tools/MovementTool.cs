using System;
using System.Collections.Generic;
using System.Linq;
using ModApi.Craft.Parts;
using ModApi.Input.Events;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public abstract class MovementTool : DesignerToolBase
	{
		public enum MovementType
		{
			Self = 0,
			Connected = 1
		}

		private const float AdjustmentSpeed = 10f;

		private bool _localOrientation = true;

		private MovementType _movement = MovementType.Connected;

		private PartSelection _partSelection;

		private Transform _selectedTransform;

		public override ICollection<IPartScript> ActiveParts
		{
			get
			{
				ICollection<IPartScript> collection = _partSelection?.Parts;
				object obj = collection;
				if (obj == null)
				{
					collection = ((base.SelectedPart == null) ? null : new IPartScript[1] { base.SelectedPart });
					obj = collection ?? Array.Empty<IPartScript>();
				}
				return (ICollection<IPartScript>)obj;
			}
		}

		public float GridSize
		{
			get
			{
				return Game.Instance.Settings.Game.Designer.GridSize;
			}
			set
			{
				Game.Instance.Settings.Game.Designer.GridSize.UpdateAndCommit(value);
			}
		}

		public bool LocalOrientation
		{
			get
			{
				return _localOrientation;
			}
			set
			{
				_localOrientation = value;
				OnOrientationChanged();
			}
		}

		public MovementType Movement
		{
			get
			{
				return _movement;
			}
			set
			{
				if (_movement != value)
				{
					_movement = value;
				}
			}
		}

		protected Transform SelectedTransform => _selectedTransform;

		protected virtual bool UsePartSelection => true;

		public event ToolAdjustmentOccurredHandler ToolAdjustmentOccurred;

		public MovementTool(DesignerScript designer)
			: base(designer)
		{
			designer.BeforeCraftUnloaded += OnDesignerCraftUnloaded;
		}

		public override void Activate()
		{
			base.Activate();
			if (base.SelectedPart != null)
			{
				ReselectCurrentPart();
			}
		}

		public override void Deactivate()
		{
			base.Deactivate();
			if (_partSelection != null)
			{
				DestroyPartSelection(ref _partSelection);
			}
			SetSelectedTransform(null, justAdded: false, notifyGizmo: true);
		}

		public override bool HandleClick(ClickEventArgs e)
		{
			bool result = base.HandleClick(e);
			switch (e.InputState)
			{
			case InputState.Begin:
				result = OnMouseBegin(e);
				break;
			case InputState.Updated:
				if (base.IsInputCaptured)
				{
					result = OnMouseDrag(e);
				}
				break;
			case InputState.End:
				result = OnMouseEnd();
				break;
			}
			return result;
		}

		public override void SelectedPartChanged(IPartScript newPart, RaycastHit? hit, bool justAdded)
		{
			base.SelectedPartChanged(newPart, hit, justAdded);
			if (base.Active)
			{
				SetSelectedPart(newPart, justAdded);
			}
		}

		protected void DirectAdjustmentBegin()
		{
			if (ShouldCreatePartSelection(base.SelectedPart))
			{
				CreatePartSelection(base.SelectedPart, notifyGizmo: false);
			}
			else
			{
				SetSelectedTransform(base.SelectedPart.Transform, justAdded: false, notifyGizmo: false);
			}
		}

		protected void DirectAdjustmentEnd()
		{
			UpdateSymmetricParts();
			if (_partSelection != null)
			{
				DestroyPartSelection(ref _partSelection);
			}
			RaiseToolAdjustmentOccurred();
		}

		protected virtual bool OnMouseBegin(ClickEventArgs e)
		{
			return false;
		}

		protected virtual bool OnMouseDrag(ClickEventArgs e)
		{
			if (ShouldCreatePartSelection(base.SelectedPart))
			{
				CreatePartSelection(base.SelectedPart, notifyGizmo: true);
			}
			return false;
		}

		protected virtual bool OnMouseEnd()
		{
			if (_partSelection != null)
			{
				DestroyPartSelection(ref _partSelection);
				SetSelectedTransform(base.SelectedPart.Transform, justAdded: false, notifyGizmo: true);
			}
			return false;
		}

		protected virtual void OnOrientationChanged()
		{
		}

		protected virtual void ProcessSelectedTransformChanged(Transform newTransform, bool justAddedPart, bool notifyGizmo)
		{
		}

		protected void RaiseToolAdjustmentOccurred()
		{
			this.ToolAdjustmentOccurred?.Invoke(this);
		}

		protected void SetSelectedTransform(Transform transform, bool justAdded, bool notifyGizmo)
		{
			_selectedTransform = transform;
			ProcessSelectedTransformChanged(_selectedTransform, justAdded, notifyGizmo);
		}

		protected void UpdateSymmetricParts()
		{
			if (_partSelection != null)
			{
				Symmetry.UpdatePartPositions(_partSelection.Parts.ToList());
				return;
			}
			Symmetry.UpdatePartPositions(new List<IPartScript> { base.SelectedPart });
		}

		private static void DestroyPartSelection(ref PartSelection partSelection)
		{
			partSelection.Deselect();
			partSelection = null;
		}

		private void CreatePartSelection(IPartScript basePart, bool notifyGizmo)
		{
			Transform transform = null;
			if (basePart != null)
			{
				if (ShouldCreatePartSelection(basePart))
				{
					bool selectSinglePart = _movement != MovementType.Connected;
					_partSelection = PartSelection.CreatePartSelection(basePart, preserveConnections: true, null, null, selectSinglePart);
					transform = _partSelection.ContainerParent;
				}
				else
				{
					transform = basePart.Transform;
				}
			}
			SetSelectedTransform(transform, justAdded: false, notifyGizmo);
		}

		private void OnDesignerCraftUnloaded()
		{
			if (_partSelection != null)
			{
				Debug.LogWarning("this.OnMouseEnd(); was being called here but has been removed...verify that nothing funky happened");
			}
		}

		private void ReselectCurrentPart()
		{
			if (base.SelectedPart != null)
			{
				SetSelectedPart(base.SelectedPart, justAdded: false);
			}
		}

		private void SetSelectedPart(IPartScript newPart, bool justAdded)
		{
			SetSelectedTransform(newPart?.Transform, justAdded, notifyGizmo: true);
			if (newPart == null)
			{
				base.Designer.DeselectTool(this);
			}
		}

		private bool ShouldCreatePartSelection(IPartScript part)
		{
			if (UsePartSelection && part != null)
			{
				return _partSelection == null;
			}
			return false;
		}
	}
}
