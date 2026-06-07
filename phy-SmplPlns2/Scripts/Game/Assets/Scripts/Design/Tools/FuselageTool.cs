using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.Symmetry;
using Assets.Scripts.Input.Events;
using DG.Tweening;
using Jundroo.Common.Extensions;
using Jundroo.Common.Pool;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class FuselageTool : DesignerTool
	{
		public class FuselageSelection
		{
			public class Slice
			{
				public AttachPointData AttachPoint { get; set; }

				public int CornerOffset { get; set; }

				public FuselageData.FillParameters FillAmount
				{
					get
					{
						if (!IsFront)
						{
							return Fuselage.Fuselage.FillBack;
						}
						return Fuselage.Fuselage.FillFront;
					}
					set
					{
						if (IsFront)
						{
							Fuselage.Fuselage.FillFront = value;
						}
						else
						{
							Fuselage.Fuselage.FillBack = value;
						}
					}
				}

				public FuselageScript Fuselage { get; set; }

				public bool InvertOrder { get; set; }

				public bool IsFront { get; set; }

				public bool IsMirrored { get; set; }

				public void SetCornerType(int globalCornerIndex, int cornerType)
				{
					int num = globalCornerIndex;
					if (IsMirrored)
					{
						num = num switch
						{
							0 => 3, 
							1 => 2, 
							2 => 1, 
							3 => 0, 
							4 => 7, 
							5 => 6, 
							6 => 5, 
							7 => 4, 
							_ => num, 
						};
					}
					num = ((!InvertOrder) ? (num - CornerOffset) : (3 - (num - CornerOffset)));
					if (num >= 4)
					{
						num -= 4;
					}
					else if (num < 0)
					{
						num += 4;
					}
					if (!IsFront)
					{
						num += 4;
					}
					Fuselage.Fuselage.CornerTypes[num] = cornerType;
					Fuselage.UpdateMeshes();
				}
			}

			public IEnumerable<(FuselageScript Fuselage, bool IsMirrored)> AllFuselages
			{
				get
				{
					PartData part = Fuselage?.Fuselage.Part;
					if (part == null)
					{
						yield break;
					}
					yield return (Fuselage: Fuselage, IsMirrored: false);
					if (part.SymmetryId == 0)
					{
						yield break;
					}
					IReadOnlyList<PartData> symmetricParts = Fuselage.PartScript.Aircraft.Aircraft.Assembly.GetSymmetricParts(part);
					bool isMirrored = symmetricParts.Count == 2;
					foreach (PartData item in symmetricParts)
					{
						if (item != part)
						{
							FuselageScript modifier = item.PartScript.GetModifier<FuselageScript>();
							if (modifier != null)
							{
								yield return (Fuselage: modifier, IsMirrored: isMirrored);
							}
						}
					}
				}
			}

			public IEnumerable<List<Slice>> AllSliceGroups
			{
				get
				{
					yield return Slices;
					foreach (List<Slice> symmetricSlice in SymmetricSlices)
					{
						yield return symmetricSlice;
					}
				}
			}

			public FuselageData.FillParameters FillAmount
			{
				get
				{
					if (!IsSlice)
					{
						return Fuselage.Fuselage.FillFront.Average(Fuselage.Fuselage.FillBack);
					}
					if (Slices.Count == 2)
					{
						return Slices[0].FillAmount.Average(Slices[1].FillAmount);
					}
					return Slices[0].FillAmount;
				}
				set
				{
					if (!IsSlice)
					{
						Fuselage.Fuselage.FillFront = value;
						Fuselage.Fuselage.FillBack = value;
						return;
					}
					foreach (List<Slice> allSliceGroup in AllSliceGroups)
					{
						foreach (Slice item in allSliceGroup)
						{
							FuselageData.FillParameters fillAmount = value;
							if (item.IsMirrored)
							{
								fillAmount.Right = value.Left;
								fillAmount.Left = value.Right;
							}
							item.FillAmount = fillAmount;
						}
					}
				}
			}

			public FuselageScript Fuselage { get; set; }

			public bool IsRotationCompatible => true;

			public bool IsSlice => Slices.Count > 0;

			public Vector3 Position { get; private set; }

			public Quaternion Rotation { get; set; }

			public List<Slice> Slices { get; private set; }

			public Vector2 SliceScale
			{
				get
				{
					Vector2 zero = Vector2.zero;
					if (Slices.Count > 0)
					{
						Vector2 zero2 = Vector2.zero;
						Slice slice = Slices[0];
						zero2 = ((!slice.IsFront) ? slice.Fuselage.Fuselage.RearScale : slice.Fuselage.Fuselage.FrontScale);
						zero.x = Mathf.Max(zero.x, zero2.x);
						zero.y = Mathf.Max(zero.y, zero2.y);
					}
					return zero;
				}
				set
				{
					Vector2 vector = value;
					if (Slices.Count == 2)
					{
						vector.x = Mathf.Max(0.05f, vector.x);
						vector.y = Mathf.Max(0.05f, vector.y);
					}
					foreach (List<Slice> allSliceGroup in AllSliceGroups)
					{
						foreach (Slice item in allSliceGroup)
						{
							Vector2 vector2 = vector;
							if (item.CornerOffset == 1 || item.CornerOffset == 3)
							{
								vector2.x = vector.y;
								vector2.y = vector.x;
							}
							if (item.IsFront)
							{
								item.Fuselage.Fuselage.FrontScale = vector2;
							}
							else
							{
								item.Fuselage.Fuselage.RearScale = vector2;
							}
						}
					}
				}
			}

			public List<List<Slice>> SymmetricSlices { get; private set; }

			public FuselageSelection(Transform t)
			{
				Slices = new List<Slice>();
				Position = t.position;
				Rotation = t.rotation;
			}

			public void CreateSymmetricSlices()
			{
				SymmetricSlices = new List<List<Slice>>();
				int count = Slices.Count;
				if (count == 0)
				{
					return;
				}
				Slice slice = Slices[0];
				if ((slice?.Fuselage?.PartScript.Part.SymmetryId).GetValueOrDefault() == 0)
				{
					slice = ((count == 2) ? Slices[1] : null);
					if ((slice?.Fuselage?.PartScript.Part.SymmetryId).GetValueOrDefault() == 0)
					{
						slice = null;
					}
				}
				FuselageScript fuselageScript = slice?.Fuselage;
				if (fuselageScript == null)
				{
					return;
				}
				int id = slice.AttachPoint.Id;
				List<PartData> value;
				using (CollectionPool<List<PartData>, PartData>.Get(out value))
				{
					fuselageScript.PartScript.Aircraft.Aircraft.Assembly.GetOtherSymmetricParts(fuselageScript.PartScript.Part, value);
					foreach (PartData item2 in value)
					{
						FuselageScript modifier = item2.PartScript.GetModifier<FuselageScript>();
						if (modifier == null)
						{
							Debug.LogError($"Unable to find the fuselage script for part '{item2.Id}', which is symmetric to fuselage part '{fuselageScript.PartScript.Part.Id}'");
							SymmetricSlices.Clear();
							break;
						}
						Slice item = new Slice
						{
							Fuselage = modifier,
							AttachPoint = item2.AttachPoints[id],
							IsFront = slice.IsFront,
							IsMirrored = (value.Count == 1)
						};
						SymmetricSlices.Add(new List<Slice> { item });
						AttachPointData attachPointData = item2.AttachPoints[id];
						PartConnection partConnection = attachPointData.PartConnections.FirstOrDefault();
						if (partConnection == null)
						{
							continue;
						}
						bool flag = false;
						foreach (AttachPointData item3 in partConnection.AttachPointsA)
						{
							if (item3.Id > 1)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							foreach (AttachPointData item4 in partConnection.AttachPointsB)
							{
								if (item4.Id > 1)
								{
									flag = true;
									break;
								}
							}
						}
						if (flag)
						{
							continue;
						}
						FuselageScript fuselageScript2 = (partConnection?.GetOtherPart(item2))?.PartScript.GetModifier<FuselageScript>();
						if (fuselageScript2 != null)
						{
							bool backwards = modifier.Backwards;
							bool backwards2 = fuselageScript2.Backwards;
							bool isFront = slice.IsFront;
							bool isFront2 = (((backwards && backwards2) || (!backwards && !backwards2)) ? (!isFront) : isFront);
							item = new Slice
							{
								Fuselage = fuselageScript2,
								AttachPoint = partConnection.GetOtherAttachPoint(attachPointData),
								IsFront = isFront2,
								IsMirrored = (value.Count == 1)
							};
							item.InvertOrder = backwards != backwards2;
							Vector3 vector = modifier.transform.InverseTransformDirection(fuselageScript2.transform.up);
							if (Utilities.CompareFloats(vector.x, 1f, 0.01f))
							{
								item.CornerOffset = 1;
							}
							else if (Utilities.CompareFloats(vector.y, -1f, 0.01f))
							{
								item.CornerOffset = 2;
							}
							else if (Utilities.CompareFloats(vector.x, -1f, 0.01f))
							{
								item.CornerOffset = 3;
							}
							SymmetricSlices.Add(new List<Slice> { item });
						}
					}
				}
			}

			public void UpdateMeshes()
			{
				if (IsSlice)
				{
					foreach (List<Slice> allSliceGroup in AllSliceGroups)
					{
						foreach (Slice item in allSliceGroup)
						{
							item.Fuselage.UpdateMeshes();
						}
					}
					return;
				}
				Fuselage.UpdateMeshes();
			}
		}

		private WireframeCubeScript _box;

		private FuselageSelection _currentSelection;

		private GameObject _fuselageToolbox;

		private bool _inputHandled;

		public bool CanAddSection
		{
			get
			{
				if (CurrentSelection.IsSlice && !CurrentSelection.Slices[0].Fuselage.IsCone && !CurrentSelection.Slices[0].Fuselage.IsInlet && CurrentSelection.Slices[0].AttachPoint != null && CurrentSelection.Slices[0].AttachPoint.PartConnections.Count == 0 && CurrentSelection.SliceScale.x > 0f)
				{
					return CurrentSelection.SliceScale.y > 0f;
				}
				return false;
			}
		}

		public FuselageSelection CurrentSelection
		{
			get
			{
				return _currentSelection;
			}
			set
			{
				if (_currentSelection != value)
				{
					_currentSelection = value;
					UpdateSelectionBox(animate: true);
				}
			}
		}

		public FuselageTool(Designer designer, CameraController cameraController)
			: base(designer, cameraController)
		{
			base.AllowPartSelection = true;
			base.ShowSelectionHighlight = false;
		}

		public FuselageScript AddSection()
		{
			FuselageSelection.Slice slice = CurrentSelection.Slices[0];
			if (CanAddSection)
			{
				FuselageScript fuselage = slice.Fuselage;
				PartData partData = SymmetryUtility.DuplicatePart(fuselage.PartScript.Part, mirrored: false);
				FuselageScript modifier = partData.PartScript.GetModifier<FuselageScript>();
				int num = 0;
				int num2 = 0;
				if (slice.IsFront)
				{
					num2 = 4;
				}
				else
				{
					num = 4;
				}
				for (int i = 0; i < 4; i++)
				{
					modifier.Fuselage.CornerTypes[i + num2] = fuselage.Fuselage.CornerTypes[i + num];
				}
				AttachPointScript attachPointScript = slice.AttachPoint.AttachPointScript;
				AttachPointScript attachPointScript2;
				Vector2 vector;
				FuselageData.FillParameters fillParameters;
				if (slice.AttachPoint.Id == 0)
				{
					attachPointScript2 = partData.AttachPoints[1].AttachPointScript;
					vector = fuselage.Fuselage.FrontScale;
					fillParameters = fuselage.Fuselage.FillFront;
				}
				else
				{
					attachPointScript2 = partData.AttachPoints[0].AttachPointScript;
					vector = fuselage.Fuselage.RearScale;
					fillParameters = fuselage.Fuselage.FillBack;
				}
				attachPointScript.PartScript.ConnectToPart(attachPointScript, attachPointScript2);
				modifier.Fuselage.FrontScale = vector;
				modifier.Fuselage.RearScale = vector;
				modifier.Fuselage.FillFront = fillParameters;
				modifier.Fuselage.FillBack = fillParameters;
				modifier.UpdateMeshes();
				Vector3 vector2 = slice.AttachPoint.AttachPointScript.transform.position - attachPointScript2.transform.position;
				partData.PartScript.transform.position += vector2;
				if (fuselage.PartScript.Part.SymmetryId != 0)
				{
					SymmetryUtility.CreateSymmetricParts(partData, allowOverlappingPositions: false, base.Designer.Symmetry);
					SymmetryUtility.ConnectSymmetricParts(attachPointScript, attachPointScript2, base.Designer.Symmetry, showConnectionFailureMessages: true);
				}
				base.Designer.CreateUndoStep("Add Fuselage Section");
				return modifier;
			}
			return null;
		}

		public void ChangeSelection(bool moveSelectionForward)
		{
			FuselageSelection fuselageSelection = null;
			if (!CurrentSelection.IsSlice)
			{
				PartData part = CurrentSelection.Fuselage.PartScript.Part;
				int num = 1;
				if (moveSelectionForward)
				{
					num = 0;
				}
				if (CurrentSelection.Fuselage.Backwards)
				{
					num = ((num != 1) ? 1 : 0);
				}
				AttachPointData attachPointData = null;
				if (part.AttachPoints.Count > num)
				{
					attachPointData = part.AttachPoints[num];
					if (attachPointData.PartConnections.Count == 1)
					{
						bool flag = false;
						foreach (AttachPointData item in attachPointData.PartConnections[0].AttachPointsA)
						{
							if (item.Id > 1)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							foreach (AttachPointData item2 in attachPointData.PartConnections[0].AttachPointsB)
							{
								if (item2.Id > 1)
								{
									flag = true;
									break;
								}
							}
						}
						AttachPointData otherAttachPoint = attachPointData.PartConnections[0].GetOtherAttachPoint(attachPointData);
						if (!flag)
						{
							FuselageScript modifier = attachPointData.PartConnections[0].GetOtherPart(part).PartScript.GetModifier<FuselageScript>();
							if (modifier != null)
							{
								fuselageSelection = new FuselageSelection(attachPointData.AttachPointScript.transform);
								FuselageSelection.Slice slice = new FuselageSelection.Slice();
								slice.Fuselage = CurrentSelection.Fuselage;
								slice.AttachPoint = attachPointData;
								if (moveSelectionForward)
								{
									slice.IsFront = !slice.Fuselage.Backwards;
								}
								else
								{
									slice.IsFront = slice.Fuselage.Backwards;
								}
								fuselageSelection.Slices.Add(slice);
								slice = new FuselageSelection.Slice();
								slice.Fuselage = modifier;
								slice.AttachPoint = otherAttachPoint;
								slice.IsFront = slice.Fuselage.Backwards;
								if (moveSelectionForward)
								{
									slice.IsFront = slice.Fuselage.Backwards;
								}
								else
								{
									slice.IsFront = !slice.Fuselage.Backwards;
								}
								slice.InvertOrder = CurrentSelection.Fuselage.Backwards != modifier.Backwards;
								Vector3 vector = CurrentSelection.Fuselage.transform.InverseTransformDirection(modifier.transform.up);
								if (Utilities.CompareFloats(vector.x, 1f, 0.01f))
								{
									slice.CornerOffset = 1;
								}
								else if (Utilities.CompareFloats(vector.y, -1f, 0.01f))
								{
									slice.CornerOffset = 2;
								}
								else if (Utilities.CompareFloats(vector.x, -1f, 0.01f))
								{
									slice.CornerOffset = 3;
								}
								fuselageSelection.Slices.Add(slice);
							}
						}
					}
				}
				if (fuselageSelection == null && attachPointData != null && !attachPointData.IsSurfaceAttachPoint)
				{
					fuselageSelection = new FuselageSelection(attachPointData.AttachPointScript.transform);
					FuselageSelection.Slice slice2 = new FuselageSelection.Slice();
					slice2.AttachPoint = attachPointData;
					slice2.Fuselage = CurrentSelection.Fuselage;
					if (moveSelectionForward)
					{
						slice2.IsFront = !slice2.Fuselage.Backwards;
					}
					else
					{
						slice2.IsFront = slice2.Fuselage.Backwards;
					}
					fuselageSelection.Slices.Add(slice2);
				}
				fuselageSelection?.CreateSymmetricSlices();
			}
			else
			{
				foreach (FuselageSelection.Slice slice3 in CurrentSelection.Slices)
				{
					if (moveSelectionForward)
					{
						if ((!slice3.IsFront && !slice3.Fuselage.Backwards) || (slice3.IsFront && slice3.Fuselage.Backwards))
						{
							fuselageSelection = new FuselageSelection(slice3.Fuselage.transform);
							fuselageSelection.Fuselage = slice3.Fuselage;
						}
					}
					else if (!moveSelectionForward && (slice3.IsFront || slice3.Fuselage.Backwards) && ((slice3.IsFront && !slice3.Fuselage.Backwards) || (!slice3.IsFront && slice3.Fuselage.Backwards)))
					{
						fuselageSelection = new FuselageSelection(slice3.Fuselage.transform);
						fuselageSelection.Fuselage = slice3.Fuselage;
					}
				}
			}
			if (fuselageSelection != null)
			{
				CurrentSelection = fuselageSelection;
			}
		}

		public override void HandleInput(InputEvent e)
		{
			bool flag = false;
			bool flag2 = UnityEngine.Input.GetKey(KeyCode.LeftControl) || UnityEngine.Input.GetKey(KeyCode.RightControl);
			if (e.InputButton == InputButton.Primary && !base.ViewPortIsMoving && !flag2)
			{
				Ray ray = base.Designer.ScreenPointToRay(e.Position);
				int layerMask = 32768;
				(PartScript, RaycastHit, Ray)? partFromRayCast = Designer.GetPartFromRayCast(ray, layerMask);
				if (partFromRayCast?.Item1 != null)
				{
					FuselageScript modifier = partFromRayCast.Value.Item1.GetModifier<FuselageScript>();
					if (modifier != null)
					{
						SelectFuselage(modifier.PartScript.Part);
						Vector3 vector = modifier.PartScript.transform.InverseTransformPoint(partFromRayCast.Value.Item2.point);
						if (vector.z < (0f - modifier.Fuselage.Offset.z) * 0.8f * 0.25f)
						{
							ChangeSelection(modifier.Backwards);
						}
						else if (vector.z > modifier.Fuselage.Offset.z * 0.8f * 0.25f)
						{
							ChangeSelection(!modifier.Backwards);
						}
						if (e.InputState == InputState.Updated)
						{
							flag = true;
						}
					}
				}
			}
			if (flag)
			{
				_inputHandled = true;
			}
			else if (!_inputHandled)
			{
				base.HandleInput(e);
			}
			else if (e.InputState == InputState.End)
			{
				_inputHandled = false;
			}
		}

		public void ModifyCurrentSelection(Vector2 changeSliceScale, Vector3 changeSize)
		{
			if (!CurrentSelection.IsSlice)
			{
				PartData part = CurrentSelection.Fuselage.PartScript.Part;
				AttachPointData attachPointData = part.AttachPoints[0];
				AttachPointData attachPointData2 = ((part.AttachPoints.Count > 1) ? part.AttachPoints[1] : null);
				Vector3 position = attachPointData.AttachPointScript.transform.position;
				Vector3? previousPosition = attachPointData2?.AttachPointScript.transform.position;
				foreach (var allFuselage in CurrentSelection.AllFuselages)
				{
					Vector3 vector = changeSize;
					if (allFuselage.IsMirrored)
					{
						vector.x = 0f - vector.x;
					}
					allFuselage.Fuselage.Fuselage.Offset += vector;
					allFuselage.Fuselage.Fuselage.ValidateParameters();
					allFuselage.Fuselage.UpdateMeshes();
				}
				SymmetryUtility.MoveConnectedParts(part, attachPointData, attachPointData2, position, previousPosition);
			}
			else
			{
				CurrentSelection.SliceScale += changeSliceScale;
				foreach (List<FuselageSelection.Slice> allSliceGroup in CurrentSelection.AllSliceGroups)
				{
					foreach (FuselageSelection.Slice item in allSliceGroup)
					{
						item.Fuselage.Fuselage.ValidateParameters();
						item.Fuselage.UpdateMeshes();
						if (allSliceGroup.Count == 1)
						{
							item.Fuselage.Fuselage.AutoSizeOnConnected = false;
						}
					}
				}
			}
			UpdateSelectionBox();
			base.Designer.OnAircraftStructureChanged();
		}

		public void SelectFuselage(PartData part)
		{
			FuselageScript modifier = part.PartScript.GetModifier<FuselageScript>();
			if (modifier != null)
			{
				FuselageSelection fuselageSelection = new FuselageSelection(modifier.transform);
				fuselageSelection.Fuselage = modifier;
				CurrentSelection = fuselageSelection;
			}
		}

		public override void Start()
		{
			base.Start();
			if (_fuselageToolbox == null)
			{
				_fuselageToolbox = base.Designer.DesignerScript.transform.Find("FuselageToolBox").gameObject;
			}
			_fuselageToolbox.SetActive(value: true);
			base.Designer.HighlightedPart = null;
			_box = _fuselageToolbox.AddMissingComponent<WireframeCubeScript>();
			_box.LineWidth = 2.5f;
			_box.Color = Constants.Colors.PrimaryLight;
			SelectFuselage(base.Designer.SelectedPart.Part);
		}

		public override void Stop()
		{
			base.Stop();
			_fuselageToolbox.SetActive(value: false);
			if (base.Designer.DesignerScript.DesignerUI.Flyouts.Selected == base.Designer.DesignerScript.DesignerUI.Flyouts.FuselageShape)
			{
				base.Designer.DesignerScript.DesignerUI.Flyouts.Selected = null;
			}
		}

		protected override void SelectedPartChanged(PartScript newPart)
		{
			base.SelectedPartChanged(newPart);
			if (newPart == null || !newPart.HasModifier<FuselageScript>())
			{
				base.Designer.Tools.SelectMovePartTool();
			}
			else if (CurrentSelection.IsSlice)
			{
				for (int i = 0; i < CurrentSelection.Slices.Count; i++)
				{
					if (CurrentSelection.Slices[i].Fuselage.PartScript.Part == newPart.Part)
					{
						CurrentSelection.Slices[i].Fuselage = newPart.GetModifier<FuselageScript>();
						break;
					}
				}
			}
			else if (CurrentSelection.Fuselage.PartScript.Part == newPart.Part)
			{
				CurrentSelection.Fuselage = newPart.GetModifier<FuselageScript>();
			}
		}

		private void UpdateSelectionBox(bool animate = false)
		{
			if (CurrentSelection != null)
			{
				_box.IsVisible = true;
				_box.transform.position = CurrentSelection.Position;
				if (CurrentSelection.IsSlice)
				{
					Vector2 vector = CurrentSelection.SliceScale * 0.2625f;
					_box.ToggleFaceVisibility(zPlus: true, zMinus: false, connectingEdges: false);
					_box.SetCornerPoints(-vector, vector);
					_box.transform.rotation = CurrentSelection.Rotation;
				}
				else
				{
					Vector3 vector2 = CurrentSelection.Fuselage.Collider.bounds.size * 0.525f;
					_box.ToggleFaceVisibility(zPlus: true, zMinus: true, connectingEdges: true);
					_box.SetCornerPoints(-vector2, vector2);
					_box.transform.SetPositionAndRotation(CurrentSelection.Fuselage.Collider.bounds.center, Quaternion.identity);
				}
				if (animate)
				{
					_box.transform.localScale = Vector3.zero;
					_box.transform.DOScale(1f, 0.25f).SetEase(Ease.OutBack);
				}
			}
			else
			{
				_box.IsVisible = false;
			}
		}
	}
}
