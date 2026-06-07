using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers.Fuselage;
using Assets.Scripts.Tools.ObjectTransform;
using ModApi;
using ModApi.Audio;
using ModApi.Craft.Parts;
using ModApi.Design;
using ModApi.Input.Events;
using ModApi.Settings;
using ModApi.Ui;
using UnityEngine;

namespace Assets.Scripts.Design.Tools.Fuselage
{
	public class FuselageTool : FuselageBaseTool
	{
		private static AudioSource _resizeSound;

		private TranslateGizmoAxisScript _activeGizmo;

		private PartCollisionDetector _collisionDetector;

		private bool _disableGizmoFlyoutSoundForNextFrame;

		private List<FuselageScript> _fuselages = new List<FuselageScript>();

		private TranslateGizmoAxisScript _gizmoRadius;

		private TranslateGizmoAxisScript _gizmoRadiusBottom;

		private TranslateGizmoAxisScript _gizmoRadiusTop;

		private List<TranslateGizmoAxisScript> _gizmos = new List<TranslateGizmoAxisScript>();

		private Vector3 _gizmoStartingPosition;

		private float _gizmoTotalDragDelta;

		private TranslateGizmoAxisScript _gizmoVerticalBottom;

		private TranslateGizmoAxisScript _gizmoVerticalTop;

		private List<FuselageJoint> _joints = new List<FuselageJoint>();

		private MouseInputSettingsDesigner _mouseInputSettings;

		public override ICollection<IPartScript> ActiveParts
		{
			get
			{
				ICollection<IPartScript> collection = ((base.SelectedPart == null) ? null : new IPartScript[1] { base.SelectedPart });
				return collection ?? Array.Empty<IPartScript>();
			}
		}

		public override bool IsBaseTool => false;

		public MouseDrag MouseDrag { get; private set; }

		public PartCollisionDetector PartCollisionDetector => _collisionDetector;

		protected override bool UsePartSelection => false;

		public FuselageTool(DesignerScript designer)
			: base(designer)
		{
			_collisionDetector = new PartCollisionDetector();
			if (_resizeSound == null)
			{
				_resizeSound = Game.Instance.AudioPlayer.CreateAudioSource(AudioLibrary.Design.ResizeSampleLooped, null);
			}
			MouseDrag = new MouseDrag(designer.GizmoCamera);
			_mouseInputSettings = Game.Instance.Settings.Game.MouseInputDesigner;
		}

		public override void Activate()
		{
			base.Activate();
			_collisionDetector.AddPartSelection(base.SelectedPart);
			CreateFuselageGizmos(!_disableGizmoFlyoutSoundForNextFrame);
		}

		public override void Deactivate()
		{
			base.Deactivate();
			_collisionDetector.ClearPartSelection();
			DestroyGizmos();
		}

		public override bool HandleClick(ClickEventArgs e)
		{
			MouseDrag.Update(e);
			return base.HandleClick(e);
		}

		public override void OnCapturedToolChanged(DesignerTool designerTool)
		{
			if (designerTool == base.DesignerScript.MovePartTool)
			{
				DestroyGizmos();
			}
			else if (!base.GizmosActive)
			{
				CreateFuselageGizmos(!_disableGizmoFlyoutSoundForNextFrame);
			}
		}

		public override void OnOtherToolActivated(DesignerTool toolActivated)
		{
			base.OnOtherToolActivated(toolActivated);
			if (toolActivated is MovementTool)
			{
				base.Designer.DeselectTool(this);
			}
		}

		public override void SelectedPartChanged(IPartScript newPart, RaycastHit? hit, bool justAdded)
		{
			if (newPart != null && newPart.GetModifier<FuselageScript>() != null && (bool)Game.Instance.Settings.Game.Designer.EnableGizmos)
			{
				if (!base.Designer.IsToolActive<MovementTool>() || base.Designer.IsToolActive(this))
				{
					if (base.Active)
					{
						base.Designer.DeselectTool(this);
					}
					if (justAdded)
					{
						_disableGizmoFlyoutSoundForNextFrame = true;
					}
					base.Designer.SelectTool(this);
				}
			}
			else
			{
				base.Designer.DeselectTool(this);
			}
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			_disableGizmoFlyoutSoundForNextFrame = false;
		}

		public void UpdateGizmoPositions()
		{
			if (base.SelectedPart == null)
			{
				return;
			}
			FuselageScript modifier = base.SelectedPart.GetModifier<FuselageScript>();
			if (modifier != null && !modifier.Data.ToolIgnore)
			{
				FuselageJoint fuselageJoint = _joints[0];
				FuselageJoint fuselageJoint2 = _joints[1];
				Vector2 vector = (fuselageJoint.Scale + fuselageJoint2.Scale) * 0.5f;
				base.GizmosParent.transform.SetPositionAndRotation(modifier.PartScript.Transform.position, modifier.PartScript.Transform.rotation);
				if (_gizmoRadius != null)
				{
					_gizmoRadius.transform.localPosition = new Vector3(vector.x, 0f, 0f);
				}
				if (_gizmoRadiusTop != null)
				{
					_gizmoRadiusTop.transform.localPosition = new Vector3(0f - fuselageJoint.Scale.x + modifier.Data.Offset.x, modifier.Data.Offset.y, modifier.Data.Offset.z);
				}
				if (_gizmoRadiusBottom != null)
				{
					_gizmoRadiusBottom.transform.localPosition = new Vector3(0f - fuselageJoint2.Scale.x - modifier.Data.Offset.x, 0f - modifier.Data.Offset.y, 0f - modifier.Data.Offset.z);
				}
				if (_gizmoVerticalTop != null)
				{
					_gizmoVerticalTop.transform.localPosition = new Vector3(modifier.Data.Offset.x, modifier.Data.Offset.y, modifier.Data.Offset.z);
				}
				if (_gizmoVerticalBottom != null)
				{
					_gizmoVerticalBottom.transform.localPosition = new Vector3(0f - modifier.Data.Offset.x, 0f - modifier.Data.Offset.y, 0f - modifier.Data.Offset.z);
				}
			}
		}

		protected override void CreateGizmos(bool local, bool playGizmoFlyout)
		{
		}

		protected override void DestroyGizmos()
		{
			base.DestroyGizmos();
			_joints.Clear();
			_fuselages.Clear();
			_gizmos.Clear();
			_gizmoRadius = null;
			_gizmoRadiusTop = null;
			_gizmoVerticalTop = null;
			_gizmoRadiusBottom = null;
			_gizmoVerticalBottom = null;
		}

		protected override bool OnMouseBegin(ClickEventArgs e)
		{
			bool result = base.OnMouseBegin(e);
			if (e.IsTouchPrimary || _mouseInputSettings.CanSelectPart(e.InputButton))
			{
				MouseDrag.ProcessMouseBegin(e);
				_gizmoTotalDragDelta = 0f;
				MonoBehaviour monoBehaviour = Utilities.RaycastComponent<MonoBehaviour>(MouseDrag.MouseScreenRay);
				if (monoBehaviour != null)
				{
					TranslateGizmoAxisScript component = monoBehaviour.GetComponent<TranslateGizmoAxisScript>();
					if (component != null)
					{
						result = true;
						OnStartDraggingGizmo(component);
						SetGizmosVisibility(visible: false, component);
						_gizmoStartingPosition = _activeGizmo.transform.position;
						_activeGizmo.AdjustmentGizmoScript.IsSelected = true;
					}
				}
			}
			return result;
		}

		protected override bool OnMouseDrag(ClickEventArgs e)
		{
			base.OnMouseDrag(e);
			MouseDrag.ProcessMouseDrag(e);
			Vector3 position = _activeGizmo.transform.position;
			_gizmoTotalDragDelta += MouseDrag.DeltaMag;
			Vector3 vector = _activeGizmo.Direction * Utilities.SnapToGrid(_gizmoTotalDragDelta, base.GridSize);
			_activeGizmo.transform.position = _gizmoStartingPosition + vector;
			ApplyActiveGimzoChanges();
			if ((_activeGizmo.transform.position - position).magnitude > 0f)
			{
				PlayGizmoSound();
			}
			return true;
		}

		protected override bool OnMouseEnd()
		{
			bool result = base.OnMouseEnd();
			if (_collisionDetector.DetectCollisions(updateMaterials: true))
			{
				_activeGizmo.transform.position = _gizmoStartingPosition;
				ApplyActiveGimzoChanges();
			}
			if (_activeGizmo != null)
			{
				_activeGizmo.AdjustmentGizmoScript.IsSelected = false;
				_activeGizmo = null;
				base.Designer.CraftScript.SetStructureChanged();
				base.Designer.CreateUndoStep();
			}
			UpdateGizmoPositions();
			SetGizmosVisibility(visible: true, null);
			StopGizmoSound();
			return result;
		}

		protected override void ProcessSelectedTransformChanged(Transform newTransform, bool justAddedPart, bool notifyGizmo)
		{
			base.ProcessSelectedTransformChanged(newTransform, justAddedPart, notifyGizmo);
			MouseDrag.SetTransform(newTransform);
		}

		private static bool ShowGizmoOnEnd(FuselageScript fuselage, string tagName)
		{
			AttachPoint attachPoint = null;
			List<AttachPoint> list = new List<AttachPoint>();
			foreach (AttachPoint attachPoint2 in fuselage.PartScript.Data.AttachPoints)
			{
				if (attachPoint2.IsSurfaceAttachPoint)
				{
					attachPoint = attachPoint2;
				}
				if (attachPoint2.Tag == tagName)
				{
					list.Add(attachPoint2);
				}
			}
			foreach (AttachPoint item in list)
			{
				if (item.NumPartConnections > 0)
				{
					return false;
				}
			}
			if (attachPoint != null && list.Count > 0)
			{
				foreach (PartConnection partConnection in attachPoint.PartConnections)
				{
					foreach (PartConnection.Attachment attachment in partConnection.Attachments)
					{
						AttachPoint otherAttachPoint = attachment.GetOtherAttachPoint(attachPoint);
						if (Mathf.Abs(list[0].AttachPointScript.transform.InverseTransformPoint(otherAttachPoint.AttachPointScript.transform.position).z) < 0.01f)
						{
							return false;
						}
					}
				}
			}
			return true;
		}

		private void ApplyActiveGimzoChanges()
		{
			if (_activeGizmo == _gizmoRadius)
			{
				float num = _activeGizmo.transform.localPosition.x;
				if (num < 0f)
				{
					num = 0f;
				}
				num = Mathf.Clamp(num, 0.05f, base.DesignerScript.MaxRadius);
				foreach (FuselageJoint joint in _joints)
				{
					Vector2 size = new Vector2(num, num);
					joint.SetSize(size);
					joint.UpdateMeshes();
				}
				UpdateGizmoPositions();
				DisplayRadius(num);
			}
			else if (_activeGizmo == _gizmoRadiusTop)
			{
				float x = _activeGizmo.transform.localPosition.x;
				x = ((!(x > 0f)) ? Mathf.Abs(x) : 0f);
				x = Mathf.Clamp(x, 0f, base.DesignerScript.MaxRadius);
				UpdateFuselageJoint(0, x);
				UpdateGizmoPositions();
				DisplayRadius(x);
			}
			else if (_activeGizmo == _gizmoRadiusBottom)
			{
				float x2 = _activeGizmo.transform.localPosition.x;
				x2 = ((!(x2 > 0f)) ? Mathf.Abs(x2) : 0f);
				x2 = Mathf.Clamp(x2, 0f, base.DesignerScript.MaxRadius);
				UpdateFuselageJoint(1, x2);
				UpdateGizmoPositions();
				DisplayRadius(x2);
			}
			else if (_activeGizmo == _gizmoVerticalTop)
			{
				_joints[0].SetPosition(_activeGizmo.transform.position, undoInvalidChanges: true);
				_joints[0].UpdateAttachedParts(checkForBrokenConnections: false, updateSymmetry: true);
				DisplayLength(_joints[0]);
			}
			else if (_activeGizmo == _gizmoVerticalBottom)
			{
				_joints[1].SetPosition(_activeGizmo.transform.position, undoInvalidChanges: true);
				_joints[1].UpdateAttachedParts(checkForBrokenConnections: false, updateSymmetry: true);
				DisplayLength(_joints[1]);
			}
			foreach (FuselageScript fuselage in _fuselages)
			{
				Symmetry.SynchronizePartModifiers(fuselage.PartScript);
			}
			_collisionDetector.DetectCollisions(updateMaterials: true);
		}

		private void CreateFuselageGizmos(bool playGizmoFlyout)
		{
			if (base.SelectedPart == null)
			{
				return;
			}
			FuselageScript modifier = base.SelectedPart.GetModifier<FuselageScript>();
			if (!(modifier != null) || modifier.Data.ToolIgnore)
			{
				return;
			}
			if (base.GizmosActive)
			{
				DestroyGizmos();
			}
			_joints.Clear();
			_fuselages.Clear();
			CreateJoint(modifier, modifier.MarkerTop, modifier.AttachPointTop);
			CreateJoint(modifier, modifier.MarkerBottom, modifier.AttachPointBottom);
			Transform transform = CreateGizmosParent(null, playGizmoFlyout);
			transform.transform.SetPositionAndRotation(modifier.PartScript.Transform.position, modifier.PartScript.Transform.rotation);
			if (modifier.Data.ToolResizeRadius)
			{
				_gizmoRadius = CreateGizmo(transform, transform.right, Constants.Colors.Complementary.Gamma);
			}
			if (modifier.Data.ToolResizeTop)
			{
				_gizmoRadiusTop = CreateGizmo(transform, -transform.right, Constants.Colors.Primary.Gamma);
			}
			if (modifier.Data.ToolResizeBottom)
			{
				_gizmoRadiusBottom = CreateGizmo(transform, -transform.right, Constants.Colors.Primary.Gamma);
			}
			if (modifier.Data.ToolResizeHeight)
			{
				if (ShowGizmoOnEnd(modifier, "Top"))
				{
					_gizmoVerticalTop = CreateGizmo(transform, transform.up, new Color(0f, 1f, 0f));
				}
				if (ShowGizmoOnEnd(modifier, "Bottom"))
				{
					_gizmoVerticalBottom = CreateGizmo(transform, -transform.up, new Color(0f, 1f, 0f));
				}
			}
			UpdateGizmoPositions();
		}

		private TranslateGizmoAxisScript CreateGizmo(Transform parent, Vector3 direction, Color color)
		{
			TranslateGizmoAxisScript translateGizmoAxisScript = TranslateGizmoAxisScript.Create(parent, () => direction, color, 1.5f, screenSizeConstant: true, base.Designer.DesignerCamera.Camera, TranslateGizmoAxisScript.GizmoAxisType.Custom);
			_gizmos.Add(translateGizmoAxisScript);
			return translateGizmoAxisScript;
		}

		private FuselageJoint CreateJoint(FuselageScript fuselageScript, Transform fuselageMarker, AttachPoint attachPoint)
		{
			FuselageJoint fuselageJoint = new FuselageJoint();
			fuselageJoint.AddFuselage(fuselageScript, fuselageMarker);
			FuselageScript fuselageScript2 = fuselageJoint.AddOtherFuselageToJoint(fuselageScript, attachPoint);
			if (fuselageScript2 != null && !_fuselages.Contains(fuselageScript2))
			{
				_fuselages.Add(fuselageScript2);
			}
			_joints.Add(fuselageJoint);
			if (!_fuselages.Contains(fuselageScript))
			{
				_fuselages.Add(fuselageScript);
			}
			return fuselageJoint;
		}

		private void DisplayLength(FuselageJoint fuselageJoint)
		{
			if (fuselageJoint.Fuselages.Count == 1)
			{
				float num = fuselageJoint.Fuselages[0].Fuselage.Data.Offset.y * 2f;
				base.Designer.ShowMessage($"Length: {num:n2}m");
			}
		}

		private void DisplayRadius(float radius)
		{
			base.Designer.ShowMessage($"Radius: {radius:n2}m");
		}

		private void OnStartDraggingGizmo(TranslateGizmoAxisScript gizmo)
		{
			_activeGizmo = gizmo;
			MouseDrag.SetDragDirection(_activeGizmo.Direction);
		}

		private void PlayGizmoSound()
		{
			if (!_resizeSound.isPlaying)
			{
				_resizeSound.Play();
			}
		}

		private void SetGizmosVisibility(bool visible, TranslateGizmoAxisScript ignoreGizmo)
		{
			foreach (TranslateGizmoAxisScript gizmo in _gizmos)
			{
				if (ignoreGizmo != gizmo)
				{
					gizmo.AdjustmentGizmoScript.SetVisibility(visible);
				}
			}
		}

		private void StopGizmoSound()
		{
			if (_resizeSound.isPlaying)
			{
				_resizeSound.Stop();
			}
		}

		private void UpdateFuselageJoint(int jointIndex, float distance)
		{
			FuselageJoint fuselageJoint = _joints[jointIndex];
			Vector2 size = new Vector2(distance, distance);
			fuselageJoint.SetSize(size);
			fuselageJoint.UpdateMeshes();
		}
	}
}
