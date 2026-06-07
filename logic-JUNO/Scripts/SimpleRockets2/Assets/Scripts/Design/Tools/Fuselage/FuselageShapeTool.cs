using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
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
	public class FuselageShapeTool : FuselageBaseTool
	{
		private TranslateGizmoAxisScript _activeGizmo;

		private PartCollisionDetector _collisionDetector;

		private Vector3 _draggingBoxOffset;

		private bool _draggingFuselageBox;

		private FuselageBoxScript _fuselageBox;

		private FuselageCube _fuselageCube;

		private TranslateGizmoAxisScript _gizmoBackward;

		private TranslateGizmoAxisScript _gizmoForward;

		private TranslateGizmoAxisScript _gizmoLeft;

		private TranslateGizmoAxisScript _gizmoRight;

		private List<TranslateGizmoAxisScript> _gizmos = new List<TranslateGizmoAxisScript>();

		private Vector3 _gizmoStartingPosition;

		private Vector3[] _gizmoStartPositions = new Vector3[5];

		private Vector3 _gizmoTotalDragDelta;

		private TranslateGizmoAxisScript _gizmoVertical;

		private GridScript _grid;

		private FuselageJoint _joint;

		private MouseInputSettingsDesigner _mouseInputSettings;

		private AttachPoint _selectedAttachPoint;

		public override ICollection<IPartScript> ActiveParts
		{
			get
			{
				ICollection<IPartScript> collection = ((base.SelectedPart == null) ? null : new IPartScript[1] { base.SelectedPart });
				return collection ?? Array.Empty<IPartScript>();
			}
		}

		public bool CanAddSection
		{
			get
			{
				if (_joint != null && _joint.Fuselages.Count == 1 && _joint.Fuselages[0].Fuselage.Data.SupportsAddSection && _joint.Fuselages[0].AttachPoint != null && _joint.Fuselages[0].AttachPoint.PartConnections.Count == 0 && _joint.Scale.x > 0f && _joint.Scale.y > 0f)
				{
					if (!(_joint.Fuselages[0].AttachPoint.Name == "AttachPointTop"))
					{
						return _joint.Fuselages[0].AttachPoint.Name == "AttachPointBottom";
					}
					return true;
				}
				return false;
			}
		}

		public override bool IsBaseTool => false;

		public Vector2 MaxOffsetInGrid { get; private set; }

		public Vector2 MinOffsetInGrid { get; private set; }

		public MouseDrag MouseDrag { get; private set; }

		public Action<FuselageScript> OnFuselageSelected { get; set; }

		public Action<FuselageJoint> OnJointSelected { get; set; }

		public Action<FuselageJoint> OnJointUpdated { get; set; }

		public PartCollisionDetector PartCollisionDetector => _collisionDetector;

		public FuselageScript SelectedFuselage { get; private set; }

		public FuselageJoint SelectedJoint => _joint;

		public FuselageShapeTool(DesignerScript designer)
			: base(designer)
		{
			_collisionDetector = new PartCollisionDetector();
			base.Movement = MovementType.Self;
			MouseDrag = new MouseDrag(designer.GizmoCamera);
			_mouseInputSettings = Game.Instance.Settings.Game.MouseInputDesigner;
		}

		public override void Activate()
		{
			base.Activate();
			if (base.SelectedPart != null)
			{
				FuselageScript modifier = base.SelectedPart.GetModifier<FuselageScript>();
				if (modifier != null && !modifier.Data.ToolIgnore)
				{
					base.DesignerScript.DeselectPart();
					SetSelectedTransform(base.GizmosParent, justAdded: false, notifyGizmo: true);
					SelectAttachPoint(modifier, modifier.MarkerBottom, modifier.AttachPointBottom);
				}
			}
			base.DesignerScript.AllowPartSelection = false;
		}

		public FuselageScript AddSection(out ICollection<AttachPointScript> attachPoints)
		{
			attachPoints = null;
			if (!CanAddSection)
			{
				return null;
			}
			string tag = _joint.Fuselages[0].AttachPoint.Tag;
			string tag2;
			if (!(tag == "Top"))
			{
				if (!(tag == "Bottom"))
				{
					return null;
				}
				tag2 = "Top";
			}
			else
			{
				tag2 = "Bottom";
			}
			PartData partData = CraftBuilder.DuplicatePart(_joint.Fuselages[0].Fuselage.PartScript.Data, base.Designer.CraftScript as CraftScript, clearSymmetryIds: true, clearGroupIds: true);
			FuselageScript modifier = partData.PartScript.GetModifier<FuselageScript>();
			AttachPointScript attachPointScript = FindBestAttachPoint(partData, tag2)?.AttachPointScript;
			AttachPointScript attachPointScript2 = FindBestAttachPoint(partData, tag2, fuelLine: false)?.AttachPointScript;
			if (attachPointScript == null && attachPointScript2 != null)
			{
				attachPointScript = attachPointScript2;
				attachPoints = new List<AttachPointScript> { attachPointScript };
			}
			else if (attachPointScript != null && attachPointScript2 == null)
			{
				attachPoints = new List<AttachPointScript> { attachPointScript };
			}
			else
			{
				if (!(attachPointScript != null) || !(attachPointScript2 != null))
				{
					return null;
				}
				attachPoints = new List<AttachPointScript> { attachPointScript, attachPointScript2 };
			}
			modifier.Data.TopScale = _joint.Scale;
			modifier.Data.BottomScale = _joint.Scale;
			modifier.UpdateMeshes(updateNormalSmoothing: true);
			Vector3 vector = _joint.Fuselages[0].AttachPoint.AttachPointScript.transform.position - attachPointScript.transform.position;
			partData.PartScript.Transform.position += vector;
			Symmetry.UpdateSymmetry(new List<IPartScript>(new IPartScript[1] { modifier.PartScript }), modifier.PartScript as PartScript, _joint.Fuselages[0].AttachPoint);
			return modifier;
		}

		public void ChangeSelection(bool moveSelectionForward)
		{
			if (_joint != null)
			{
				if (_joint.Fuselages.Count == 2)
				{
					if (IsFirstAttachPointMoreForward(_joint.Fuselages[0].AttachPoint.AttachPointScript, _joint.Fuselages[1].AttachPoint.AttachPointScript) == moveSelectionForward)
					{
						SelectFuselage(_joint.Fuselages[1].Fuselage);
					}
					else
					{
						SelectFuselage(_joint.Fuselages[0].Fuselage);
					}
				}
				else if (_joint.Fuselages.Count == 1)
				{
					SelectFuselage(_joint.Fuselages[0].Fuselage);
				}
			}
			else if (SelectedFuselage != null)
			{
				if (IsFirstAttachPointMoreForward(SelectedFuselage.AttachPointTop?.AttachPointScript, SelectedFuselage.AttachPointBottom?.AttachPointScript) == moveSelectionForward)
				{
					SelectAttachPoint(SelectedFuselage, SelectedFuselage.MarkerTop, SelectedFuselage.AttachPointTop);
				}
				else
				{
					SelectAttachPoint(SelectedFuselage, SelectedFuselage.MarkerBottom, SelectedFuselage.AttachPointBottom);
				}
			}
		}

		public override void Deactivate()
		{
			IPartScript partScript = SelectedFuselage?.PartScript ?? _joint?.Fuselages.Select((FuselageJoint.FuselageInfo x) => x.Fuselage?.PartScript).FirstOrDefault((IPartScript x) => x != null);
			base.Deactivate();
			DestroyGizmos();
			base.DesignerScript.AllowPartSelection = true;
			if (partScript != null)
			{
				base.Designer.SelectPart(partScript, null, justAdded: false);
			}
		}

		public override bool HandleClick(ClickEventArgs e)
		{
			MouseDrag.Update(e);
			return base.HandleClick(e);
		}

		public override void SelectedPartChanged(IPartScript newPart, RaycastHit? hit, bool justAdded)
		{
		}

		public void SelectFuselage(FuselageScript fuselageScript)
		{
			DestroyGizmos();
			Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Design.GizmoFlyout);
			SelectedFuselage = fuselageScript;
			_fuselageCube = new FuselageCube();
			_fuselageCube.FuselageScript = fuselageScript;
			_fuselageCube.Update();
			OnFuselageSelected?.Invoke(fuselageScript);
		}

		public void SetJointSize(Vector2 size)
		{
			UpdateJoint(size.x, size.y);
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
		}

		public void UpdateFuselageOffset(Vector3 offset, IPartScript partSymmetric = null)
		{
			IPartScript partScript = ((partSymmetric != null) ? partSymmetric : SelectedFuselage.PartScript);
			List<Vector3?> list = new List<Vector3?>();
			foreach (AttachPointScript attachPointScript2 in partScript.AttachPointScripts)
			{
				if (!attachPointScript2.AttachPoint.IsSurfaceAttachPoint && attachPointScript2.AttachPoint.PartConnections.Count == 1)
				{
					list.Add(attachPointScript2.transform.position);
				}
				else
				{
					list.Add(null);
				}
			}
			FuselageScript fuselageScript = ((partSymmetric != null) ? partScript.GetModifier<FuselageScript>() : SelectedFuselage);
			fuselageScript.TryUpdateOffset(offset);
			fuselageScript.UpdateMeshes(updateNormalSmoothing: true);
			Dictionary<int, bool> movedParts = new Dictionary<int, bool>();
			for (int i = 0; i < partScript.AttachPointScripts.Count; i++)
			{
				AttachPointScript attachPointScript = partScript.AttachPointScripts[i];
				if (list[i].HasValue)
				{
					Vector3 delta = attachPointScript.transform.position - list[i].Value;
					if (delta.sqrMagnitude > 0f)
					{
						DesignerUtilities.RepositionParts(partScript.Data, attachPointScript.AttachPoint.PartConnections[0], delta, movedParts);
					}
				}
			}
			if (partSymmetric == null)
			{
				foreach (IPartScript symmetricPartScript in Symmetry.GetSymmetricPartScripts(partScript))
				{
					if (partScript.SymmetrySlice.SymmetryGroup.SymmetryMode == SymmetryMode.Mirror)
					{
						offset = Vector3.Scale(offset, new Vector3(-1f, 1f, 1f));
					}
					UpdateFuselageOffset(offset, symmetricPartScript);
				}
				_fuselageCube.Update();
			}
			base.Designer.CraftScript.SetStructureChanged();
		}

		public void UpdateFuselagePinch(float pinch)
		{
			Vector3 deformations = SelectedFuselage.Data.Deformations;
			deformations.x = pinch;
			deformations.z = pinch;
			SelectedFuselage.Data.Deformations = deformations;
			SelectedFuselage.UpdateMeshes(updateNormalSmoothing: true);
			UpdateSymmetricFuselages(SelectedFuselage);
			base.Designer.CraftScript.SetStructureChanged();
		}

		public void UpdateFuselageSlant(float slant)
		{
			Vector3 deformations = SelectedFuselage.Data.Deformations;
			deformations.y = slant;
			SelectedFuselage.Data.Deformations = deformations;
			SelectedFuselage.UpdateMeshes(updateNormalSmoothing: true);
			UpdateSymmetricFuselages(SelectedFuselage);
			base.Designer.CraftScript.SetStructureChanged();
		}

		protected override void CreateGizmos(bool local, bool playGizmoFlyout)
		{
		}

		protected override void DestroyGizmos()
		{
			base.DestroyGizmos();
			_selectedAttachPoint = null;
			_joint = null;
			_fuselageBox = null;
			_gizmos.Clear();
			_gizmoForward = null;
			_gizmoBackward = null;
			_gizmoLeft = null;
			_gizmoRight = null;
			_gizmoVertical = null;
			DestroyGrid();
			DestroyFuselageCube();
		}

		protected override bool OnMouseBegin(ClickEventArgs e)
		{
			bool flag = base.OnMouseBegin(e);
			if (e.IsTouchPrimary || _mouseInputSettings.CanSelectPart(e.InputButton))
			{
				MouseDrag.ProcessMouseBegin(e);
				_gizmoTotalDragDelta = Vector3.zero;
				MonoBehaviour monoBehaviour = Utilities.RaycastComponent<MonoBehaviour>(MouseDrag.MouseScreenRay);
				if (monoBehaviour != null)
				{
					FuselageBoxScript component2;
					if (monoBehaviour.TryGetComponent<TranslateGizmoAxisScript>(out var component))
					{
						flag = true;
						OnStartDraggingGizmo(component);
						SetGizmosVisibility(visible: false, component);
						_gizmoStartingPosition = _activeGizmo.transform.position;
						component.AdjustmentGizmoScript.IsSelected = true;
						CreateGrid();
						if (component == _gizmoVertical)
						{
							_grid.gameObject.SetActive(value: false);
						}
						else
						{
							_fuselageBox.IsSelected = true;
						}
					}
					else if (monoBehaviour.TryGetComponent<FuselageBoxScript>(out component2))
					{
						Vector3? pointOnFuselageBoxPlane = GetPointOnFuselageBoxPlane(e.Ray);
						if (pointOnFuselageBoxPlane.HasValue)
						{
							flag = true;
							_draggingFuselageBox = true;
							_fuselageBox.IsSelected = true;
							_draggingBoxOffset = base.GizmosParent.position - pointOnFuselageBoxPlane.Value;
							CreateGrid();
							SetGizmosVisibility(visible: false, null);
						}
					}
				}
				if (flag)
				{
					for (int i = 0; i < _gizmos.Count; i++)
					{
						_gizmoStartPositions[i] = _gizmos[i].transform.position;
					}
					foreach (FuselageJoint.FuselageInfo fuselage in _joint.Fuselages)
					{
						_collisionDetector.AddPartSelection(fuselage.Fuselage.PartScript);
					}
				}
				else
				{
					PartRaycastResult partAtScreenPosition = base.Designer.GetPartAtScreenPosition(e.Position);
					if (partAtScreenPosition.PartScript != null)
					{
						FuselageScript modifier = partAtScreenPosition.PartScript.GetModifier<FuselageScript>();
						if (modifier != null)
						{
							Vector3 vector = modifier.PartScript.Transform.InverseTransformPoint(partAtScreenPosition.Hit.point);
							AttachPoint attachPoint = null;
							Transform transform = null;
							if (vector.y > 0f && modifier.Data.ToolShapeTop)
							{
								attachPoint = modifier.AttachPointTop;
								transform = modifier.MarkerTop;
							}
							else if (modifier.Data.ToolShapeBottom)
							{
								attachPoint = modifier.AttachPointBottom;
								transform = modifier.MarkerBottom;
							}
							if (transform != null)
							{
								if (_selectedAttachPoint != attachPoint)
								{
									SelectAttachPoint(modifier, transform, attachPoint);
								}
								else
								{
									SelectFuselage(modifier);
								}
							}
						}
					}
				}
			}
			return flag;
		}

		protected override bool OnMouseDrag(ClickEventArgs e)
		{
			MouseDrag.ProcessMouseDrag(e);
			if (_draggingFuselageBox)
			{
				Vector3? pointOnFuselageBoxPlane = GetPointOnFuselageBoxPlane(e.Ray);
				if (pointOnFuselageBoxPlane.HasValue)
				{
					base.GizmosParent.position = ((_grid != null) ? _grid.GetGridPosition(pointOnFuselageBoxPlane.Value + _draggingBoxOffset) : (pointOnFuselageBoxPlane.Value + _draggingBoxOffset));
					UpdateJointFromGizmoDrag();
				}
			}
			else
			{
				base.OnMouseDrag(e);
				_gizmoTotalDragDelta += MouseDrag.DeltaVec;
				_activeGizmo.transform.position = _grid.GetGridPosition(_gizmoStartingPosition + _gizmoTotalDragDelta, _gizmoStartingPosition);
				UpdateJointFromGizmoDrag();
			}
			return true;
		}

		protected override bool OnMouseEnd()
		{
			bool result = base.OnMouseEnd();
			if (_activeGizmo != null)
			{
				_activeGizmo.AdjustmentGizmoScript.IsSelected = false;
			}
			SetGizmosVisibility(visible: true, null);
			_draggingFuselageBox = false;
			FuselageBoxScript fuselageBox = _fuselageBox;
			if ((object)fuselageBox != null && fuselageBox.IsSelected)
			{
				_fuselageBox.IsSelected = false;
			}
			DestroyGrid();
			if (_collisionDetector.DetectCollisions(updateMaterials: true))
			{
				for (int i = 0; i < _gizmos.Count; i++)
				{
					_gizmos[i].transform.position = _gizmoStartPositions[i];
				}
				UpdateJointFromGizmoDrag();
			}
			_collisionDetector.ClearPartSelection();
			base.Designer.CraftScript.SetStructureChanged();
			base.Designer.CreateUndoStep();
			return result;
		}

		private static AttachPoint FindBestAttachPoint(PartData part, string tag, bool fuelLine = true)
		{
			AttachPoint result = null;
			foreach (AttachPoint attachPoint in part.AttachPoints)
			{
				if (attachPoint.Tag == tag && attachPoint.FuelLine == fuelLine)
				{
					result = attachPoint;
					break;
				}
			}
			return result;
		}

		private static void UpdateSymmetricFuselages(FuselageScript fuselage)
		{
			Symmetry.SynchronizePartConnections(fuselage.PartScript);
			Symmetry.SynchronizePartModifiers(fuselage.PartScript);
			Symmetry.UpdatePartPositions(new List<IPartScript> { fuselage.PartScript });
		}

		private TranslateGizmoAxisScript CreateGizmo(Transform parent, Vector3 direction, Vector2 fuselageScale, Vector2i id, Color color)
		{
			TranslateGizmoAxisScript translateGizmoAxisScript = TranslateGizmoAxisScript.Create(parent, () => direction, color, 1.5f, screenSizeConstant: true, base.Designer.DesignerCamera.Camera, TranslateGizmoAxisScript.GizmoAxisType.Custom);
			Vector2 vector = fuselageScale;
			vector.Scale(id.ToVector2());
			translateGizmoAxisScript.transform.localPosition = new Vector3(vector.x, 0f, vector.y);
			translateGizmoAxisScript.Id = id;
			_gizmos.Add(translateGizmoAxisScript);
			return translateGizmoAxisScript;
		}

		private void CreateGrid()
		{
			Vector2 vector = new Vector2(float.MinValue, float.MinValue);
			Vector2 vector2 = new Vector2(float.MaxValue, float.MaxValue);
			Vector3 anchorPosition = _joint.AnchorPosition;
			Vector3 vector3 = base.GizmosParent.InverseTransformPoint(anchorPosition);
			vector3.y = 0f;
			foreach (FuselageJoint.FuselageInfo fuselage in _joint.Fuselages)
			{
				Vector3 vector4 = base.GizmosParent.InverseTransformPoint(fuselage.AnchorPoint.position);
				vector4.y = 0f;
				Vector3 vector5 = vector4 - new Vector3(2.4f, 0f, 2.4f) - vector3;
				Vector3 vector6 = vector4 + new Vector3(2.4f, 0f, 2.4f) - vector3;
				vector.x = Mathf.Max(vector.x, vector5.x);
				vector.y = Mathf.Max(vector.y, vector5.z);
				vector2.x = Mathf.Min(vector2.x, vector6.x);
				vector2.y = Mathf.Min(vector2.y, vector6.z);
			}
			MinOffsetInGrid = vector;
			MaxOffsetInGrid = vector2;
			_grid = GridScript.Create(base.GridSize, vector, vector2, 2.4f, _joint.Transform.position - anchorPosition);
			_grid.transform.SetPositionAndRotation(base.GizmosParent.TransformPoint(vector3), base.GizmosParent.rotation);
		}

		private void DestroyFuselageCube()
		{
			if (_fuselageCube != null)
			{
				_fuselageCube.Destroy();
				_fuselageCube = null;
			}
		}

		private void DestroyGrid()
		{
			if (_grid != null)
			{
				UnityEngine.Object.Destroy(_grid.gameObject);
				_grid = null;
			}
		}

		private Vector3? GetPointOnFuselageBoxPlane(Ray ray)
		{
			Vector3? result = null;
			if (new Plane(_fuselageBox.transform.up, _fuselageBox.transform.position).Raycast(ray, out var enter))
			{
				result = ray.GetPoint(enter);
			}
			return result;
		}

		private bool HasForeignLoadAttachment(FuselageJoint.FuselageInfo fuselage)
		{
			foreach (AttachPoint attachPoint in fuselage.Fuselage.PartScript.Data.AttachPoints)
			{
				_ = attachPoint;
				PartConnection loadPartConnection = fuselage.GetLoadPartConnection();
				if (loadPartConnection != null)
				{
					FuselageScript modifier = loadPartConnection.GetOtherPart(fuselage.Fuselage.PartScript.Data).PartScript.GetModifier<FuselageScript>();
					if (!_joint.ContainsFuselage(modifier))
					{
						return true;
					}
				}
			}
			return false;
		}

		private bool IsFirstAttachPointMoreForward(AttachPointScript ap1, AttachPointScript ap2)
		{
			if (ap1 == null && ap2 == null)
			{
				return true;
			}
			Vector3 lhs = ((!(ap1 != null)) ? (-ap2.WorldNormal) : ap1.WorldNormal);
			Vector3 lhs2 = ((!(ap2 != null)) ? (-ap1.WorldNormal) : ap2.WorldNormal);
			float num = Vector3.Dot(lhs, Vector3.up) - Vector3.Dot(lhs2, Vector3.up);
			if (Mathf.Abs(num) < 0.1f)
			{
				num = Vector3.Dot(lhs, Vector3.forward) - Vector3.Dot(lhs2, Vector3.forward);
				if (Mathf.Abs(num) < 0.1f)
				{
					num = Vector3.Dot(lhs, Vector3.right) - Vector3.Dot(lhs2, Vector3.right);
					if (num > 0f)
					{
						return true;
					}
				}
				else if (num > 0f)
				{
					return true;
				}
			}
			else if (num > 0f)
			{
				return true;
			}
			return false;
		}

		private void OnStartDraggingGizmo(TranslateGizmoAxisScript gizmo)
		{
			_activeGizmo = gizmo;
			MouseDrag.SetTransform(gizmo.transform);
			MouseDrag.SetDragDirection(_activeGizmo.Direction);
		}

		private void SelectAttachPoint(FuselageScript fuselageScript, Transform fuselageMarker, AttachPoint attachPoint)
		{
			DestroyFuselageCube();
			SelectedFuselage = null;
			FuselageJoint fuselageJoint = new FuselageJoint();
			fuselageJoint.AddFuselage(fuselageScript, fuselageMarker);
			if (attachPoint != null && attachPoint.PartConnections.Count == 1)
			{
				PartConnection partConnection = attachPoint.PartConnections[0];
				FuselageScript modifier = partConnection.GetOtherPart(fuselageScript.PartScript.Data).PartScript.GetModifier<FuselageScript>();
				if (modifier != null && modifier.Data.AutoResize)
				{
					foreach (PartConnection.Attachment attachment in partConnection.Attachments)
					{
						AttachPoint otherAttachPoint = attachment.GetOtherAttachPoint(attachPoint);
						if (otherAttachPoint == modifier.AttachPointTop)
						{
							fuselageJoint.AddFuselage(modifier, modifier.MarkerTop);
						}
						else if (otherAttachPoint == modifier.AttachPointBottom)
						{
							fuselageJoint.AddFuselage(modifier, modifier.MarkerBottom);
						}
					}
				}
			}
			SetFuselageJoint(fuselageJoint);
			_selectedAttachPoint = attachPoint;
			OnJointSelected?.Invoke(fuselageJoint);
		}

		private void SetFuselageJoint(FuselageJoint joint)
		{
			if (_joint != null && (joint.Fuselages[0].TargetPoint == _joint.Fuselages[0].TargetPoint || (_joint.Fuselages.Count == 2 && joint.Fuselages[0].TargetPoint == _joint.Fuselages[1].TargetPoint)))
			{
				return;
			}
			if (base.GizmosActive)
			{
				DestroyGizmos();
			}
			_joint = joint;
			Transform transform = CreateGizmosParent(joint.Fuselages[0].Fuselage.PartScript.Transform, playGizmoFlyout: true);
			transform.position = joint.Transform.position;
			Color gamma = Constants.Colors.Primary.Gamma;
			_gizmoForward = CreateGizmo(transform, transform.forward, joint.Scale, new Vector2i(0, 1), gamma);
			_gizmoBackward = CreateGizmo(transform, -transform.forward, joint.Scale, new Vector2i(0, -1), gamma);
			_gizmoRight = CreateGizmo(transform, transform.right, joint.Scale, new Vector2i(1, 0), gamma);
			_gizmoLeft = CreateGizmo(transform, -transform.right, joint.Scale, new Vector2i(-1, 0), gamma);
			bool flag = true;
			if (_joint.Fuselages.Count == 1)
			{
				flag = !HasForeignLoadAttachment(_joint.Fuselages[0]);
			}
			foreach (FuselageJoint.FuselageInfo fuselage in _joint.Fuselages)
			{
				if (flag)
				{
					flag = flag && fuselage.Fuselage.Data.ToolResizeHeight;
					flag = flag && !HasForeignLoadAttachment(fuselage);
				}
			}
			if (flag)
			{
				_gizmoVertical = CreateGizmo(transform, transform.up, joint.Scale, new Vector2i(0, 0), new Color(0f, 1f, 0f));
			}
			UpdateFuselageBox(joint.Scale);
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

		private void UpdateFuselageBox(Vector2 size)
		{
			if (_fuselageBox == null)
			{
				_fuselageBox = Game.Instance.ResourceLoader.InstantiatePrefab<FuselageBoxScript>("Design/Tools/FuselageBox");
				_fuselageBox.transform.SetParent(base.GizmosParent, worldPositionStays: false);
				_fuselageBox.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
				_fuselageBox.transform.localScale = Vector3.one;
			}
			_fuselageBox.SetSize(size);
		}

		private void UpdateJoint(float width, float depth)
		{
			Vector2 vector = new Vector2(Mathf.Clamp(width, 0f, base.DesignerScript.MaxRadius), Mathf.Clamp(depth, 0f, base.DesignerScript.MaxRadius));
			Vector3 zero = Vector3.zero;
			zero.x = (_gizmoRight.transform.localPosition.x + _gizmoLeft.transform.localPosition.x) * 0.5f;
			zero.z = (_gizmoForward.transform.localPosition.z + _gizmoBackward.transform.localPosition.z) * 0.5f;
			if (_gizmoVertical != null)
			{
				zero.y = _gizmoVertical.transform.localPosition.y;
			}
			Vector3 position = base.GizmosParent.TransformPoint(zero);
			if (_grid != null)
			{
				Vector3 position2 = _grid.transform.InverseTransformPoint(position);
				position2.x = Mathf.Min(position2.x, MaxOffsetInGrid.x);
				position2.z = Mathf.Min(position2.z, MaxOffsetInGrid.y);
				position2.x = Mathf.Max(position2.x, MinOffsetInGrid.x);
				position2.z = Mathf.Max(position2.z, MinOffsetInGrid.y);
				position = _grid.transform.TransformPoint(position2);
			}
			_joint.SetDimensions(position, vector, undoInvalidChanges: true);
			base.GizmosParent.position = _joint.Transform.position;
			foreach (TranslateGizmoAxisScript gizmo in _gizmos)
			{
				Vector2 vector2 = vector;
				vector2.Scale(gizmo.Id.ToVector2());
				gizmo.transform.localPosition = new Vector3(vector2.x, 0f, vector2.y);
			}
			UpdateFuselageBox(_joint.Scale);
			foreach (FuselageJoint.FuselageInfo fuselage in _joint.Fuselages)
			{
				UpdateSymmetricFuselages(fuselage.Fuselage);
			}
			_collisionDetector.DetectCollisions(updateMaterials: true);
			OnJointUpdated?.Invoke(_joint);
		}

		private void UpdateJointFromGizmoDrag()
		{
			float width = (_gizmoRight.transform.localPosition.x - _gizmoLeft.transform.localPosition.x) / 2f;
			float depth = (_gizmoForward.transform.localPosition.z - _gizmoBackward.transform.localPosition.z) / 2f;
			UpdateJoint(width, depth);
		}
	}
}
