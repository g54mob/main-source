using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Wings;
using Assets.Scripts.Craft.Wings.ControlSurfaces;
using Assets.Scripts.Design.Symmetry;
using Assets.Scripts.Design.UI;
using Assets.Scripts.Design.UI.Wings;
using Assets.Scripts.Input.Events;
using Assets.Scripts.UI;
using Jundroo.Common.Pool;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class JWingTool : DesignerTool
	{
		public delegate void WingSelectionEvent(JWingData wing, SelectionType selectionType, int selection, ControlSurfacePartScript controlSurface);

		public enum SelectionType
		{
			Section = 0,
			Slice = 1,
			ControlSurface = 2
		}

		public const float DefaultSnap = 0.05f;

		private int _activeGizmos;

		private JWingData _currentWing;

		private JWingScript _currentWingScript;

		private WingGizmoScript _draggingGizmo;

		private bool _draggingOverWing;

		private GameObject _gizmoPrefab;

		private List<WingGizmoScript> _gizmos = new List<WingGizmoScript>();

		private WingGizmoScript _hoverGizmo;

		private ControlSurfacePartScript _selectedCsPart;

		private int _selectedSliceIndex;

		private SelectionType _selectionType;

		public bool CanDeleteSection
		{
			get
			{
				if (SelectionIsSection && _currentWing != null)
				{
					return _currentWing.WingSlices.Count > 2;
				}
				return false;
			}
		}

		public (InputWingSlice Root, InputWingSlice Tip)? CurrentSection
		{
			get
			{
				if (_currentWing == null || !SelectionIsSection || _selectedSliceIndex < 0 || _selectedSliceIndex >= _currentWing.WingSlices.Count - 1)
				{
					return null;
				}
				return (_currentWing.WingSlices[_selectedSliceIndex], _currentWing.WingSlices[_selectedSliceIndex + 1]);
			}
		}

		public InputWingSlice CurrentSlice
		{
			get
			{
				if (_currentWing == null || !SelectionIsSlice || _selectedSliceIndex < 0 || _selectedSliceIndex >= _currentWing.WingSlices.Count)
				{
					return null;
				}
				return _currentWing.WingSlices[_selectedSliceIndex];
			}
		}

		public JWingData CurrentWing => _currentWing;

		public float MinScaleUnit
		{
			get
			{
				if (SnapDistance != 0f)
				{
					return SnapDistance;
				}
				return 0.05f;
			}
		}

		public float? SectionSweep
		{
			get
			{
				(InputWingSlice, InputWingSlice)? currentSection = CurrentSection;
				if (currentSection.HasValue)
				{
					if (!currentSection.Value.Item1.UseOffset)
					{
						WingBuilder.InterpolateOffset(_selectedSliceIndex, _currentWing.WingSlices);
					}
					if (!currentSection.Value.Item2.UseOffset)
					{
						WingBuilder.InterpolateOffset(_selectedSliceIndex + 1, _currentWing.WingSlices);
					}
					return currentSection.Value.Item2.Offset - currentSection.Value.Item1.Offset;
				}
				return null;
			}
			set
			{
				if (!value.HasValue || _currentWing == null || !SelectionIsSection || _selectedSliceIndex < 0 || _selectedSliceIndex >= _currentWing.WingSlices.Count + 1)
				{
					return;
				}
				WingSectionChange? wingSectionChange = StartSectionChange();
				if (wingSectionChange.HasValue)
				{
					WingSectionChange change = wingSectionChange.GetValueOrDefault();
					InputWingSlice inputWingSlice = _currentWing.WingSlices[_selectedSliceIndex];
					InputWingSlice inputWingSlice2 = _currentWing.WingSlices[_selectedSliceIndex + 1];
					float num = inputWingSlice2.Offset - inputWingSlice.Offset;
					float num2 = (change.TipwardsOffsetDiff = value.Value - num);
					for (int i = _selectedSliceIndex + 1; i < _currentWing.WingSlices.Count; i++)
					{
						_currentWing.WingSlices[i].Offset += num2;
					}
					inputWingSlice2.UseOffset = true;
					EndSectionChange(ref change);
					UpdateMeshes();
				}
			}
		}

		public bool SectionSweepSet
		{
			get
			{
				return CurrentSection?.Tip?.UseOffset == true;
			}
			set
			{
				InputWingSlice inputWingSlice = CurrentSection?.Tip;
				if (inputWingSlice != null && inputWingSlice.UseScale != value)
				{
					inputWingSlice.UseScale = value;
					UpdateMeshes();
				}
			}
		}

		public float? SectionWidth
		{
			get
			{
				(InputWingSlice, InputWingSlice)? currentSection = CurrentSection;
				if (currentSection.HasValue)
				{
					return currentSection.Value.Item2.Position - currentSection.Value.Item1.Position;
				}
				return null;
			}
			set
			{
				if (!value.HasValue || _currentWing == null || !SelectionIsSection || _selectedSliceIndex < 0 || _selectedSliceIndex >= _currentWing.WingSlices.Count + 1)
				{
					return;
				}
				WingSectionChange? wingSectionChange = StartSectionChange();
				if (wingSectionChange.HasValue)
				{
					WingSectionChange change = wingSectionChange.GetValueOrDefault();
					float value2 = value.Value;
					value2 = Mathf.Max(value2, MinScaleUnit);
					float num = _currentWing.WingSlices[_selectedSliceIndex + 1].Position - _currentWing.WingSlices[_selectedSliceIndex].Position;
					float num2 = (change.TipwardsPositionDiff = value2 - num);
					for (int i = _selectedSliceIndex + 1; i < _currentWing.WingSlices.Count; i++)
					{
						_currentWing.WingSlices[i].Position += num2;
					}
					EndSectionChange(ref change);
					UpdateMeshes();
				}
			}
		}

		public int SelectionBaseIndex => _selectedSliceIndex;

		public bool SelectionIsFirst => _selectedSliceIndex == 0;

		public string SliceAirfoil
		{
			get
			{
				return CurrentSlice?.Airfoil;
			}
			set
			{
				InputWingSlice currentSlice = CurrentSlice;
				if (currentSlice != null)
				{
					currentSlice.Airfoil = value;
					UpdateMeshes();
				}
			}
		}

		public float SliceBend
		{
			get
			{
				return CurrentSlice?.Bend ?? 0f;
			}
			set
			{
				InputWingSlice currentSlice = CurrentSlice;
				if (currentSlice != null)
				{
					currentSlice.Bend = value;
					UpdateMeshes();
				}
			}
		}

		public float? SliceScale
		{
			get
			{
				InputWingSlice currentSlice = CurrentSlice;
				if (currentSlice != null)
				{
					if (!currentSlice.UseScale)
					{
						WingBuilder.InterpolateScale(_selectedSliceIndex, _currentWing.WingSlices);
					}
					return currentSlice.Scale;
				}
				return null;
			}
			set
			{
				if (value.HasValue && _currentWing != null && SelectionIsSlice && _selectedSliceIndex >= 0 && _selectedSliceIndex < _currentWing.WingSlices.Count)
				{
					InputWingSlice inputWingSlice = _currentWing.WingSlices[_selectedSliceIndex];
					WingSliceChange? wingSliceChange = StartSliceChange(inputWingSlice);
					if (wingSliceChange.HasValue)
					{
						WingSliceChange change = wingSliceChange.GetValueOrDefault();
						inputWingSlice.Scale = value.Value;
						inputWingSlice.UseScale = true;
						EndSliceChange(ref change, inputWingSlice);
						UpdateMeshes();
					}
				}
			}
		}

		public bool SliceScaleSet
		{
			get
			{
				return CurrentSlice?.UseScale ?? false;
			}
			set
			{
				InputWingSlice currentSlice = CurrentSlice;
				if (currentSlice != null && currentSlice.UseScale != value)
				{
					currentSlice.UseScale = value;
					UpdateMeshes();
				}
			}
		}

		public float SnapDistance { get; set; } = 0.05f;

		private WingGizmoScript HoverGizmo
		{
			get
			{
				return _hoverGizmo;
			}
			set
			{
				if (_hoverGizmo != value)
				{
					if (_hoverGizmo != null)
					{
						_hoverGizmo.Highlighted = false;
					}
					_hoverGizmo = value;
					if (_hoverGizmo != null)
					{
						_hoverGizmo.Highlighted = true;
					}
				}
			}
		}

		private bool SelectionIsControlSurface => _selectionType == SelectionType.ControlSurface;

		private bool SelectionIsSection => _selectionType == SelectionType.Section;

		private bool SelectionIsSlice => _selectionType == SelectionType.Slice;

		public event WingSelectionEvent SelectionChanged;

		public JWingTool(Designer designer, CameraController cameraController)
			: base(designer, cameraController)
		{
			base.AllowFingerAid = false;
			base.AllowPartSelection = true;
			_gizmoPrefab = Resources.Load<GameObject>("Designer/JWingGizmo");
		}

		public static WingGizmoScript GetGizmo(Ray ray)
		{
			WingGizmoScript result = null;
			if (Physics.Raycast(ray, out var hitInfo, float.PositiveInfinity, 1024))
			{
				result = hitInfo.transform.GetComponentInParent<WingGizmoScript>();
			}
			return result;
		}

		public void AddSection()
		{
			if (CanAddSlice())
			{
				InputWingSlice inputWingSlice;
				if (_currentWing.WingSlices.Count == 1)
				{
					_currentWing.WingSlices[0].Offset = 0f;
					inputWingSlice = _currentWing.WingSlices[0].Clone();
					inputWingSlice.Offset = 0.5f;
				}
				else
				{
					List<InputWingSlice> wingSlices = _currentWing.WingSlices;
					InputWingSlice inputWingSlice2 = wingSlices[wingSlices.Count - 2];
					List<InputWingSlice> wingSlices2 = _currentWing.WingSlices;
					InputWingSlice inputWingSlice3 = wingSlices2[wingSlices2.Count - 1];
					inputWingSlice = inputWingSlice3.Clone();
					inputWingSlice.Offset += inputWingSlice3.Offset - inputWingSlice2.Offset;
					inputWingSlice.Position += inputWingSlice3.Position - inputWingSlice2.Position;
					inputWingSlice.Bend = 0f;
				}
				_currentWing.WingSlices.Add(inputWingSlice);
				UpdateMeshes();
				ChangeSelection(forwards: true);
				base.Designer.CreateUndoStepForSelectedPart("Add Wing Section");
			}
		}

		public void AttachControlSurfaceToWing(ControlSurfacePartScript controlSurface, JWingScript wingScript, RaycastHit raycastHit)
		{
			Assembly assembly = controlSurface.PartScript.Aircraft.Aircraft.Assembly;
			PartData part = controlSurface.PartScript.Part;
			PartData partData = wingScript?.PartScript.Part;
			List<(PartData, PartData)> value;
			using (CollectionPool<List<(PartData, PartData)>, (PartData, PartData)>.Get(out value))
			{
				if (wingScript == null)
				{
					if (part.SymmetryId == 0)
					{
						value.Add((part, null));
					}
					else
					{
						foreach (PartData symmetricPart in assembly.GetSymmetricParts(part))
						{
							value.Add((symmetricPart, null));
						}
					}
				}
				else
				{
					IReadOnlyList<PartData> symmetricParts = assembly.GetSymmetricParts(part);
					IReadOnlyList<PartData> symmetricParts2 = assembly.GetSymmetricParts(partData);
					if (symmetricParts.Count > 0 && symmetricParts.Count == symmetricParts2.Count)
					{
						SymmetryUtility.GetSymmetricPairs(part, partData, allowUnlinkedSymmetricParts: false, base.Designer.Symmetry, value);
						value.Insert(0, (part, partData));
					}
					else if (symmetricParts.Count > 0)
					{
						for (int i = 0; i < symmetricParts.Count; i++)
						{
							if (symmetricParts[i] == part)
							{
								value.Add((part, partData));
								continue;
							}
							List<PartConnection> partConnections = symmetricParts[i].PartConnections;
							while (partConnections.Count > 0)
							{
								partConnections[partConnections.Count - 1].DestroyConnection(isSymmetryOperation: false, destroySymmetricConnections: false, raiseConnectionChangedEvents: true);
							}
						}
					}
					else if (symmetricParts2.Count > 0)
					{
						value.Add((part, partData));
					}
					else
					{
						value.Add((part, partData));
					}
				}
				float? num = null;
				if (wingScript != null && wingScript.ResolveRaycast(in raycastHit, out var _, out var spanPosition))
				{
					num = spanPosition;
				}
				bool flag = num.HasValue;
				if (num.HasValue)
				{
					foreach (var item3 in value)
					{
						if (item3.Item2 == null)
						{
							flag = false;
							break;
						}
						JWingScript modifier = item3.Item2.PartScript.GetModifier<JWingScript>();
						if (modifier == null)
						{
							flag = false;
							Debug.LogError(string.Format("Could not find {0} modifier on symmetric wing part '{1}'", "JWingScript", item3.Item2.Id));
							break;
						}
						ControlSurfacePartScript modifier2 = item3.Item1.PartScript.GetModifier<ControlSurfacePartScript>();
						if (modifier2 == null)
						{
							flag = false;
							Debug.LogError(string.Format("Could not find {0} modifier on symmetric control surface part '{1}'", "ControlSurfacePartScript", item3.Item1.Id));
							break;
						}
						ControlSurface controlSurface2 = modifier2.Data.ControlSurface;
						modifier.SuspendMeshUpdates();
						modifier.UpdateSurfaceClaims(controlSurface);
						modifier2.Data.DummyControlSurface.CopySettingsTo(controlSurface2);
						flag &= controlSurface2.TryPlaceOnWing(modifier.SurfaceClaims, num.Value, modifier2.Data.DummyWingScale, modifier2.Data.DummyWingOffset);
					}
				}
				bool flag2 = false;
				foreach (var item4 in value)
				{
					PartData item = item4.Item1;
					PartData item2 = item4.Item2;
					JWingScript jWingScript = item2?.PartScript.GetModifier<JWingScript>();
					if (item2 != null && jWingScript == null)
					{
						flag = false;
						Debug.LogError(string.Format("Could not find {0} modifier on symmetric wing part '{1}'", "JWingScript", item2.Id));
						break;
					}
					if (item.PartScript.GetModifier<ControlSurfacePartScript>() == null)
					{
						flag = false;
						Debug.LogError(string.Format("Could not find {0} modifier on symmetric control surface part '{1}'", "ControlSurfacePartScript", item.Id));
						break;
					}
					if (flag)
					{
						bool flag3 = false;
						bool flag4 = false;
						List<PartConnection> partConnections2 = item.PartConnections;
						for (int j = 0; j < partConnections2.Count; j++)
						{
							if (partConnections2[j].GetOtherPart(item) == item2)
							{
								flag3 = true;
								continue;
							}
							partConnections2[j--].DestroyConnection(isSymmetryOperation: false, destroySymmetricConnections: false, raiseConnectionChangedEvents: true);
							flag4 = true;
						}
						if (!flag3)
						{
							PartConnection partConnection = new PartConnection(item2, item);
							partConnection.AddAttachPointA(item2.AttachPoints[1]);
							partConnection.AddAttachPointB(item.AttachPoints[0]);
							partConnection.RaiseConnectionChangedEvents(isSymmetryOperation: false);
							flag4 = true;
						}
						if (!flag4)
						{
							jWingScript.Data.UpdateMeshes();
						}
					}
					else
					{
						List<PartConnection> partConnections3 = item.PartConnections;
						while (partConnections3.Count > 0)
						{
							partConnections3[partConnections3.Count - 1].DestroyConnection(isSymmetryOperation: false, destroySymmetricConnections: false, raiseConnectionChangedEvents: true);
						}
					}
					if (jWingScript != null && jWingScript.ResumeMeshUpdates())
					{
						flag2 |= jWingScript.ResumeMeshUpdates();
					}
				}
				if (flag2)
				{
					base.Designer.OnAircraftStructureChanged();
				}
			}
		}

		public bool CanAddSlice()
		{
			if (_currentWing != null && SelectionIsSlice)
			{
				return _selectedSliceIndex == _currentWing.WingSlices.Count - 1;
			}
			return false;
		}

		public (bool Fwd, bool Back) CanChangeSelection()
		{
			if (_currentWing == null)
			{
				return (Fwd: false, Back: false);
			}
			if (SelectionIsSlice)
			{
				return (Fwd: _selectedSliceIndex != _currentWing.WingSlices.Count - 1, Back: _selectedSliceIndex != 0);
			}
			if (SelectionIsSection)
			{
				return (Fwd: true, Back: true);
			}
			return (Fwd: false, Back: false);
		}

		public void ChangeSelection(bool forwards)
		{
			(bool, bool) tuple = CanChangeSelection();
			if (!(forwards ? tuple.Item1 : tuple.Item2))
			{
				return;
			}
			if (SelectionIsSlice)
			{
				_selectionType = SelectionType.Section;
				if (!forwards)
				{
					_selectedSliceIndex--;
				}
			}
			else
			{
				_selectionType = SelectionType.Slice;
				if (forwards)
				{
					_selectedSliceIndex++;
				}
			}
			RaiseSelectionChange();
		}

		public void DeleteCurrentSection()
		{
			(InputWingSlice, InputWingSlice)? currentSection = CurrentSection;
			if (!currentSection.HasValue)
			{
				return;
			}
			(InputWingSlice, InputWingSlice) valueOrDefault = currentSection.GetValueOrDefault();
			var (inputWingSlice, _) = valueOrDefault;
			if (inputWingSlice != null)
			{
				InputWingSlice item = valueOrDefault.Item2;
				if (item != null)
				{
					DeleteSection(inputWingSlice, item);
				}
			}
		}

		public void DeleteSection(InputWingSlice root, InputWingSlice tip)
		{
			JWingData currentWing = _currentWing;
			if (currentWing.WingSlices.Count < 3)
			{
				return;
			}
			_currentWingScript.SuspendMeshUpdates();
			float2 float5 = new float2(root.Position, tip.Position);
			List<ControlSurface> list = new List<ControlSurface>();
			foreach (ControlSurfacePartData item in currentWing.ControlSurfacesInformational)
			{
				ControlSurface controlSurface = item.ControlSurface;
				if (!(controlSurface.Range.y <= float5.x) && !(controlSurface.Range.x >= float5.y))
				{
					bool flag = controlSurface.Range.x >= float5.x;
					bool flag2 = controlSurface.Range.y <= float5.y;
					if (flag && flag2)
					{
						list.Add(controlSurface);
					}
					else if (flag)
					{
						controlSurface.Range = new float2(float5.y, controlSurface.Range.y);
					}
					else if (flag2)
					{
						controlSurface.Range = new float2(controlSurface.Range.x, float5.x);
					}
				}
			}
			foreach (ControlSurface item2 in list)
			{
				RemoveControlSurface(currentWing, item2);
			}
			WingSectionChange change = default(WingSectionChange);
			change.Before.Load(currentWing.WingSlices, currentWing.WingSlices.IndexOf(root));
			change.After = change.Before;
			change.After.SpanRange = change.Before.SpanRange.x;
			float num = root.Position - tip.Position;
			float num2 = root.Offset - tip.Offset;
			bool flag3 = false;
			foreach (InputWingSlice wingSlice in currentWing.WingSlices)
			{
				if (flag3)
				{
					wingSlice.Position += num;
					wingSlice.Offset += num2;
				}
				else if (wingSlice == tip)
				{
					flag3 = true;
				}
			}
			change.TipwardsOffsetDiff = num2;
			change.TipwardsPositionDiff = num;
			foreach (ControlSurfacePartData item3 in currentWing.ControlSurfacesInformational)
			{
				item3.ControlSurface.HandleSectionChange(in change);
			}
			int num3 = currentWing.WingSlices.IndexOf(tip);
			currentWing.WingSlices.RemoveAt(num3);
			currentWing.UpdateMeshes();
			_currentWingScript.ResumeMeshUpdates();
			base.Designer.OnAircraftStructureChanged();
			base.Designer.CreateUndoStepForSelectedPart("Delete Wing Section");
			if (_currentWing == currentWing && ((SelectionIsSlice && _selectedSliceIndex == num3) || (SelectionIsSection && _selectedSliceIndex + 1 == num3)))
			{
				_selectionType = SelectionType.Slice;
				_selectedSliceIndex = num3 - 1;
				RaiseSelectionChange();
			}
		}

		public void EndSectionChange(ref WingSectionChange change)
		{
			change.After.Load(_currentWing.WingSlices, _selectedSliceIndex);
			foreach (ControlSurfacePartData item in _currentWing.ControlSurfacesInformational)
			{
				item.ControlSurface.HandleSectionChange(in change);
			}
		}

		public void EndSliceChange(ref WingSliceChange change, InputWingSlice slice)
		{
			change.LoadAfter(_currentWing.WingSlices, _currentWing.WingSlices.IndexOf(slice));
			foreach (ControlSurfacePartData item in _currentWing.ControlSurfacesInformational)
			{
				item.ControlSurface.HandleSliceChange(in change);
			}
		}

		public override void HandleInput(InputEvent e)
		{
			if (e.InputButton != InputButton.Primary)
			{
				base.HandleInput(e);
				return;
			}
			bool flag = UnityEngine.Input.GetKey(KeyCode.LeftControl) || UnityEngine.Input.GetKey(KeyCode.RightControl);
			if (e.InputState == InputState.Begin && !flag)
			{
				if (_draggingGizmo != null)
				{
					_draggingGizmo.OnDragEnd();
					_draggingGizmo = null;
				}
				WingGizmoScript gizmo = GetGizmo(e.Ray);
				if (gizmo != null)
				{
					base.PartScript.PartMaterialScript.SetSelected(selected: false, updateSymmetricParts: true);
					gizmo.OnDragStart(e.Ray);
					_draggingGizmo = gizmo;
					base.AllowPartSelection = false;
					return;
				}
				(PartScript, RaycastHit, Ray)? partFromRayCast = Designer.GetPartFromRayCast(e.Ray);
				if (partFromRayCast.HasValue)
				{
					(PartScript, RaycastHit, Ray) valueOrDefault = partFromRayCast.GetValueOrDefault();
					var (partScript, _, _) = valueOrDefault;
					if ((object)partScript != null)
					{
						RaycastHit hit = valueOrDefault.Item2;
						JWingScript modifier = partScript.GetModifier<JWingScript>();
						if ((object)modifier != null)
						{
							if (modifier.Data != _currentWing)
							{
								base.Designer.SelectedPart = partScript;
							}
							SelectSliceFromRayHit(in hit);
							_draggingOverWing = true;
						}
						return;
					}
				}
				_draggingOverWing = false;
			}
			else if (e.InputState == InputState.Updated)
			{
				if (_draggingGizmo != null)
				{
					_draggingGizmo.OnDragContinue(e.Ray);
					return;
				}
				if (_draggingOverWing)
				{
					base.Designer.DesignerScript.DesignerUI.HideMainUI(hide: false);
					(PartScript, RaycastHit, Ray)? partFromRayCast = Designer.GetPartFromRayCast(e.Ray);
					if (partFromRayCast.HasValue)
					{
						RaycastHit hit2 = partFromRayCast.GetValueOrDefault().Item2;
						SelectSliceFromRayHit(in hit2);
					}
					return;
				}
			}
			else if (e.InputState == InputState.End)
			{
				EndGizmoDrag();
				_draggingOverWing = false;
			}
			base.HandleInput(e);
		}

		public override void MouseHover(Vector3? screenPosition)
		{
			if (screenPosition.HasValue)
			{
				Ray ray = base.CameraController.Camera.ScreenPointToRay(screenPosition.Value);
				HoverGizmo = GetGizmo(ray);
			}
			base.MouseHover((HoverGizmo == null) ? screenPosition : ((Vector3?)null));
		}

		public void RemoveControlSurface(JWingData wing, ControlSurface controlSurface)
		{
			ControlSurfacePartData controlSurfacePartData = null;
			foreach (ControlSurfacePartData item in wing.ControlSurfacesInformational)
			{
				if (item.ControlSurface == controlSurface)
				{
					controlSurfacePartData = item;
					break;
				}
			}
			if (controlSurfacePartData == null)
			{
				Debug.LogError("Could not find control surface part for removal of control surface");
			}
			else
			{
				wing.Part.GetPartConnection(controlSurfacePartData.Part)?.DestroyConnection(isSymmetryOperation: false, destroySymmetricConnections: false, raiseConnectionChangedEvents: true);
			}
		}

		public void SelectSliceFromRayHit(in RaycastHit hit)
		{
			if (_currentWing == null)
			{
				return;
			}
			JWingScript modifier = _currentWing.Part.PartScript.GetModifier<JWingScript>();
			if (modifier == null || !modifier.ResolveRaycast(in hit, out var meshIdx, out var spanPosition))
			{
				return;
			}
			if (meshIdx > 0)
			{
				_selectedCsPart = hit.transform.GetComponentInParent<ControlSurfacePartScript>();
				_selectionType = SelectionType.ControlSurface;
				return;
			}
			InputWingSlice inputWingSlice = null;
			InputWingSlice inputWingSlice2 = null;
			int i;
			for (i = 0; i < _currentWing.WingSlices.Count; i++)
			{
				InputWingSlice inputWingSlice3 = _currentWing.WingSlices[i];
				if (inputWingSlice3.Position >= spanPosition)
				{
					inputWingSlice2 = inputWingSlice3;
					break;
				}
				inputWingSlice = inputWingSlice3;
			}
			if (inputWingSlice != null && inputWingSlice2 != null)
			{
				float num = math.unlerp(inputWingSlice.Position, inputWingSlice2.Position, spanPosition);
				int num2;
				bool flag;
				if (num < 0.1f)
				{
					num2 = i - 1;
					flag = true;
				}
				else if (num > 0.9f)
				{
					num2 = i;
					flag = true;
				}
				else
				{
					num2 = i - 1;
					flag = false;
				}
				if ((flag && !SelectionIsSlice) || (!flag && !SelectionIsSection) || num2 != _selectedSliceIndex)
				{
					_selectionType = (flag ? SelectionType.Slice : SelectionType.Section);
					_selectedSliceIndex = num2;
					_selectedCsPart = null;
					RaiseSelectionChange();
				}
			}
		}

		public float SetSectionWidth(float newWidth)
		{
			newWidth = Mathf.Max(newWidth, MinScaleUnit);
			SectionWidth = newWidth;
			return newWidth;
		}

		public float SetSliceScale(float newScale)
		{
			newScale = Mathf.Max(newScale, MinScaleUnit);
			SliceScale = newScale;
			return newScale;
		}

		public override void Start()
		{
			base.Start();
			base.Designer.HighlightedPart = null;
			IDesignerFlyouts flyouts = base.Designer.DesignerScript.DesignerUI.Flyouts;
			flyouts.Selected = flyouts.WingEditor;
			flyouts.WingEditor.Closed += OnWingEditorClosed;
			base.Designer.SelectedPartChangedEvent += OnSelectedPartChanged;
			OnSelectedPartChanged(base.Designer.SelectedPart);
		}

		public WingSectionChange? StartSectionChange()
		{
			if (!CurrentSection.HasValue)
			{
				return null;
			}
			WingSectionChange value = default(WingSectionChange);
			value.Before.Load(_currentWing.WingSlices, _selectedSliceIndex);
			return value;
		}

		public WingSliceChange? StartSliceChange(InputWingSlice slice)
		{
			WingSliceChange value = default(WingSliceChange);
			value.LoadBefore(_currentWing.WingSlices, _currentWing.WingSlices.IndexOf(slice));
			return value;
		}

		public override void Stop()
		{
			EndGizmoDrag();
			HoverGizmo = null;
			ResetGizmos(0);
			base.Stop();
			base.Designer.DesignerScript.DesignerUI.Flyouts.WingEditor.Closed -= OnWingEditorClosed;
			base.Designer.SelectedPartChangedEvent -= OnSelectedPartChanged;
			IDesignerFlyouts flyouts = base.Designer.DesignerScript.DesignerUI.Flyouts;
			if (flyouts.WingEditor.IsOpen)
			{
				flyouts.WingEditor.Close();
			}
		}

		public override void Update()
		{
			if (_currentWing != null && _currentWing.Part.PartScript == null)
			{
				SetSelectedWing(null);
				base.Designer.Tools.SelectMovePartTool();
			}
		}

		private static (InputWingSlice Root, InputWingSlice Tip, float T) GetSectionAtSpanPos(float spanPos, List<InputWingSlice> slices)
		{
			var (index, index2, item) = GetSectionIndexAtSpanPos(spanPos, slices);
			return (Root: slices[index], Tip: slices[index2], T: item);
		}

		private static (int Root, int Tip, float T) GetSectionIndexAtSpanPos(float spanPos, List<InputWingSlice> slices)
		{
			int num = 0;
			int num2 = slices.Count - 1;
			while (num2 - num > 1)
			{
				int num3 = (num + num2) / 2;
				InputWingSlice inputWingSlice = slices[num3];
				if (inputWingSlice.ApproximatelyEqualPosition(spanPos))
				{
					return (Root: num3, Tip: num3, T: 0f);
				}
				if (inputWingSlice.Position < spanPos)
				{
					num = num3;
				}
				else
				{
					num2 = num3;
				}
			}
			return (Root: num, Tip: num2, T: math.unlerp(slices[num].Position, slices[num2].Position, spanPos));
		}

		private Vector3 ControlSurfaceSpanDir(bool isRootSide)
		{
			ControlSurface controlSurface = _selectedCsPart.Data.ControlSurface;
			(InputWingSlice Root, InputWingSlice Tip, float T) sectionAtSpanPos = GetSectionAtSpanPos(isRootSide ? controlSurface.Range.x : controlSurface.Range.y);
			var (inputWingSlice, _, _) = sectionAtSpanPos;
			if (sectionAtSpanPos.T == 0f && !isRootSide)
			{
				return inputWingSlice.LastDerivedSliceRoot.SpanVec;
			}
			return inputWingSlice.LastDerivedSliceTip.SpanVec;
		}

		private void EndGizmoDrag()
		{
			if (_draggingGizmo != null)
			{
				_draggingGizmo.OnDragEnd();
				base.PartScript?.PartMaterialScript.SetSelected(selected: true, updateSymmetricParts: true);
				int num = _gizmos.IndexOf(_draggingGizmo);
				_draggingGizmo = null;
				base.Designer.CreateUndoStepForSelectedPart("Modified wing shape", $"WingToolHandle-{num}");
				base.AllowPartSelection = true;
			}
		}

		private Vector3 GetChordPosition(InputWingSlice slice, float chord, bool toRoot)
		{
			WingSlice derivedSlice = slice.GetDerivedSlice(toRoot);
			if (derivedSlice == null)
			{
				return default(Vector3);
			}
			return derivedSlice.Position + new float3(0f, 0f, chord * slice.Scale);
		}

		private (InputWingSlice Root, InputWingSlice Tip, float T) GetSectionAtSpanPos(float spanPos)
		{
			return GetSectionAtSpanPos(spanPos, _currentWing.WingSlices);
		}

		private Vector3 GetSurfaceHingePos(bool isRootSide)
		{
			EdgeSurfaceBase edgeSurfaceBase = _selectedCsPart.Data.ControlSurface as EdgeSurfaceBase;
			if (!isRootSide)
			{
				return GetWingPoint(edgeSurfaceBase.Range.y, edgeSurfaceBase.StartPos.y, !isRootSide);
			}
			return GetWingPoint(edgeSurfaceBase.Range.x, edgeSurfaceBase.StartPos.x, !isRootSide);
		}

		private Vector3 GetWingPoint(float spanPos, float zPos, bool rootOfBend)
		{
			(InputWingSlice Root, InputWingSlice Tip, float T) sectionAtSpanPos = GetSectionAtSpanPos(spanPos);
			InputWingSlice item = sectionAtSpanPos.Root;
			InputWingSlice item2 = sectionAtSpanPos.Tip;
			float item3 = sectionAtSpanPos.T;
			float3 float5 = ((item3 != 0f) ? math.lerp(item.LastDerivedSliceTip.Position, item2.LastDerivedSliceRoot.Position, item3) : item.GetDerivedSlice(rootOfBend).Position);
			float5.z = zPos;
			return float5;
		}

		private Vector3 GetWingPointChord(float spanPos, float chordPos, bool rootOfBend)
		{
			var (inputWingSlice, inputWingSlice2, num) = GetSectionAtSpanPos(spanPos);
			float3 float5;
			float num2;
			if (num == 0f)
			{
				WingSlice derivedSlice = inputWingSlice.GetDerivedSlice(rootOfBend);
				float5 = derivedSlice.Position;
				num2 = derivedSlice.Scale;
			}
			else
			{
				float5 = math.lerp(inputWingSlice.LastDerivedSliceTip.Position, inputWingSlice2.LastDerivedSliceRoot.Position, num);
				num2 = math.lerp(inputWingSlice.LastDerivedSliceTip.Scale, inputWingSlice2.LastDerivedSliceRoot.Scale, num);
			}
			float5.z += chordPos * num2;
			return float5;
		}

		private void OnSelectedPartChanged(PartScript newPart)
		{
			if (newPart != null)
			{
				ControlSurfacePartScript modifier = newPart.GetModifier<ControlSurfacePartScript>();
				if (modifier != null && modifier.ConnectedWing != null)
				{
					_selectedCsPart = modifier;
					_selectionType = SelectionType.ControlSurface;
					SetSelectedWing(modifier.ConnectedWing);
					RaiseSelectionChange();
					return;
				}
				JWingScript modifier2 = newPart.GetModifier<JWingScript>();
				if (modifier2 != null)
				{
					if (_currentWingScript != modifier2)
					{
						SetSelectedWing(modifier2);
					}
					_selectedSliceIndex = 0;
					_selectionType = SelectionType.Section;
					RaiseSelectionChange();
					return;
				}
			}
			base.Designer.Tools.SelectMovePartTool();
		}

		private void OnWingEditorClosed(IFlyout flyout)
		{
			base.Designer.Tools.SelectMovePartTool();
			IDesignerFlyouts flyouts = base.Designer.DesignerScript.DesignerUI.Flyouts;
			IDesignerFlyouts designerFlyouts = flyouts;
			if (designerFlyouts.Selected == null)
			{
				IFlyout flyout2 = (designerFlyouts.Selected = flyouts.PartProperties);
			}
		}

		private void RaiseSelectionChange(bool dataOnlyChange = false)
		{
			this.SelectionChanged?.Invoke(_currentWing, _selectionType, _selectedSliceIndex, _selectedCsPart);
			if (!dataOnlyChange)
			{
				UpdateGizmos();
				Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerStartGizmoTool);
			}
		}

		private void ResetGizmos(int size)
		{
			if (_activeGizmos > size)
			{
				for (int i = size; i < _activeGizmos; i++)
				{
					_gizmos[i].gameObject.SetActive(value: false);
				}
			}
			else
			{
				while (_activeGizmos < size)
				{
					if (_gizmos.Count > _activeGizmos)
					{
						_gizmos[_activeGizmos++].gameObject.SetActive(value: true);
						continue;
					}
					_gizmos.Add(Object.Instantiate(_gizmoPrefab).GetComponent<WingGizmoScript>());
					_activeGizmos++;
				}
			}
			_activeGizmos = size;
			if (!_draggingOverWing)
			{
				for (int j = 0; j < size; j++)
				{
					_gizmos[j].ResetTime();
				}
			}
		}

		private void SetCentrePosition(InputWingSlice rootSlice, InputWingSlice tipSlice, Vector3 pos)
		{
			WingSectionChange? wingSectionChange = StartSectionChange();
			if (!wingSectionChange.HasValue)
			{
				return;
			}
			WingSectionChange change = wingSectionChange.GetValueOrDefault();
			bool flag = false;
			float num = 0f;
			if (rootSlice.LastDerivedSliceTip != null && tipSlice.LastDerivedSliceRoot != null)
			{
				float x = Vector3.Dot(tipSlice.LastDerivedSliceRoot?.SpanVec ?? ((float3)Vector3.right), pos - (Vector3)rootSlice.LastDerivedSliceTip.Position);
				x = Snap(x);
				x = Mathf.Max(x, (SnapDistance == 0f) ? 0.05f : SnapDistance);
				float num2 = x + rootSlice.Position;
				flag = tipSlice.Position != num2;
				num = num2 - tipSlice.Position;
				tipSlice.Position = num2;
			}
			pos.z = Snap(pos.z);
			change.TipwardsPositionDiff = num;
			if (num != 0f || tipSlice.Offset != pos.z || !tipSlice.UseOffset)
			{
				flag = true;
				float num3 = (change.TipwardsOffsetDiff = pos.z - tipSlice.Offset);
				bool flag2 = false;
				for (int i = 0; i < _currentWing.WingSlices.Count; i++)
				{
					InputWingSlice inputWingSlice = _currentWing.WingSlices[i];
					if (flag2)
					{
						inputWingSlice.Position += num;
						inputWingSlice.Offset += num3;
					}
					else if (inputWingSlice == tipSlice)
					{
						flag2 = true;
					}
				}
				tipSlice.Offset = pos.z;
				tipSlice.UseOffset = true;
			}
			if (flag)
			{
				EndSectionChange(ref change);
				UpdateMeshes();
				RaiseSelectionChange(dataOnlyChange: true);
			}
		}

		private void SetControlSurfaceRange(Vector3 pos, bool isRootSide)
		{
			ControlSurface controlSurface = _selectedCsPart.Data.ControlSurface;
			(int Root, int Tip, float T) sectionIndexAtSpanPos = GetSectionIndexAtSpanPos(isRootSide ? controlSurface.Range.x : controlSurface.Range.y, _currentWing.WingSlices);
			int num = sectionIndexAtSpanPos.Root;
			int i = sectionIndexAtSpanPos.Tip;
			List<InputWingSlice> wingSlices = _currentWing.WingSlices;
			float num2 = wingSlices[isRootSide ? i : num].Scale * 0.05f;
			if (num == i)
			{
				if (isRootSide)
				{
					i++;
				}
				else
				{
					num--;
				}
			}
			while (num > 0 && wingSlices[num - 1].Bend == 0f)
			{
				num--;
			}
			for (; i < wingSlices.Count - 1 && wingSlices[i + 1].Bend == 0f; i++)
			{
			}
			InputWingSlice inputWingSlice = wingSlices[num];
			InputWingSlice inputWingSlice2 = wingSlices[i];
			float x = math.dot((float3)pos - inputWingSlice.LastDerivedSliceTip.Position, inputWingSlice.LastDerivedSliceTip.SpanVec) + inputWingSlice.Position;
			x = Snap(x);
			x = math.clamp(x, inputWingSlice.Position, inputWingSlice2.Position);
			float2 range = controlSurface.Range;
			x = (isRootSide ? math.min(x, range.y - num2) : math.max(x, range.x + num2));
			if (controlSurface.Location == SurfaceLocation.LeadingEdge || controlSurface.Location == SurfaceLocation.TrailingEdge)
			{
				JWingScript connectedWing = _selectedCsPart.ConnectedWing;
				connectedWing.UpdateSurfaceClaims(_selectedCsPart);
				WingSurfaceClaims surfaceClaims = connectedWing.SurfaceClaims;
				float spanPos = (isRootSide ? range.y : range.x);
				bool searchToRoot = isRootSide;
				float2? freeEdgeSpanRange = surfaceClaims.GetFreeEdgeSpanRange(spanPos, controlSurface.Location == SurfaceLocation.LeadingEdge, searchToRoot);
				if (freeEdgeSpanRange.HasValue)
				{
					x = math.clamp(x, freeEdgeSpanRange.Value.x, freeEdgeSpanRange.Value.y);
					if (controlSurface.TryChangeRange(x, isRootSide, connectedWing.SurfaceClaims))
					{
						_selectedCsPart.Data.UpdateMeshes();
					}
				}
			}
			else
			{
				controlSurface.Range = range;
				_selectedCsPart.Data.UpdateMeshes();
				RaiseSelectionChange(dataOnlyChange: true);
			}
		}

		private void SetLeadingEdgePosition(InputWingSlice slice, Vector3 pos)
		{
			WingSliceChange? wingSliceChange = StartSliceChange(slice);
			if (!wingSliceChange.HasValue)
			{
				return;
			}
			WingSliceChange change = wingSliceChange.GetValueOrDefault();
			WingSlice lastDerivedSliceTip = slice.LastDerivedSliceTip;
			if (lastDerivedSliceTip != null)
			{
				float num = 0.05f;
				float num2 = lastDerivedSliceTip.Position.z - slice.Scale * 0.5f;
				pos.z = Mathf.Max(pos.z, num2 + num);
				float num3 = Snap(pos.z) - lastDerivedSliceTip.Position.z - slice.Scale * 0.5f;
				bool num4 = num3 != 0f || !slice.UseOffset || !slice.UseScale;
				slice.Scale += num3;
				slice.Offset += num3 * 0.5f;
				slice.UseOffset = true;
				slice.UseScale = true;
				if (num4)
				{
					EndSliceChange(ref change, slice);
					UpdateMeshes();
					RaiseSelectionChange(dataOnlyChange: true);
				}
			}
		}

		private void SetSelectedWing(JWingScript wing)
		{
			_currentWingScript = wing;
			_currentWing = ((wing == null) ? null : wing.Data);
		}

		private void SetSurfaceHingePos(Vector3 pos, bool isRootSide)
		{
			EdgeSurfaceBase edgeSurfaceBase = _selectedCsPart.Data.ControlSurface as EdgeSurfaceBase;
			float num = Snap(pos.z);
			float2 newStartPos = ((!isRootSide) ? new float2(edgeSurfaceBase.StartPos.x, num) : new float2(num, edgeSurfaceBase.StartPos.y));
			JWingScript connectedWing = _selectedCsPart.ConnectedWing;
			connectedWing.UpdateSurfaceClaims(_selectedCsPart);
			WingSurfaceClaims surfaceClaims = connectedWing.SurfaceClaims;
			if (edgeSurfaceBase.TrySetStartPos(surfaceClaims, newStartPos, isRootSide ? 0f : 1f))
			{
				_selectedCsPart.Data.UpdateMeshes();
				RaiseSelectionChange(dataOnlyChange: true);
			}
		}

		private void SetTrailingEdgePosition(InputWingSlice slice, Vector3 pos)
		{
			WingSliceChange? wingSliceChange = StartSliceChange(slice);
			if (!wingSliceChange.HasValue)
			{
				return;
			}
			WingSliceChange change = wingSliceChange.GetValueOrDefault();
			WingSlice lastDerivedSliceTip = slice.LastDerivedSliceTip;
			if (lastDerivedSliceTip != null)
			{
				float num = 0.05f;
				float num2 = lastDerivedSliceTip.Position.z + slice.Scale * 0.5f;
				pos.z = Mathf.Min(pos.z, num2 - num);
				float num3 = Snap(pos.z) - lastDerivedSliceTip.Position.z;
				float num4 = slice.Scale * -0.5f - num3;
				bool num5 = num4 != 0f || !slice.UseOffset || !slice.UseScale;
				slice.Scale += num4;
				slice.Offset -= num4 * 0.5f;
				slice.UseOffset = true;
				slice.UseScale = true;
				if (num5)
				{
					EndSliceChange(ref change, slice);
					UpdateMeshes();
					RaiseSelectionChange(dataOnlyChange: true);
				}
			}
		}

		private float Snap(float x)
		{
			float snapDistance = SnapDistance;
			if (snapDistance <= 0f)
			{
				return x;
			}
			return math.round(x / snapDistance) * snapDistance;
		}

		private void UpdateGizmos()
		{
			if (_currentWing == null)
			{
				return;
			}
			if (CurrentSection.HasValue)
			{
				var (root, tip) = CurrentSection.Value;
				ResetGizmos(5);
				_gizmos[0].Configure(() => WingPoint(GetChordPosition(root, 0.5f, toRoot: true)), delegate(Vector3 p)
				{
					SetLeadingEdgePosition(root, InvWingPoint(p));
				}, () => Direction(Vector3.forward), () => Direction(root.LastDerivedSliceTip.Up), secondaryFree: false);
				_gizmos[1].Configure(() => WingPoint(GetChordPosition(root, -0.5f, toRoot: true)), delegate(Vector3 p)
				{
					SetTrailingEdgePosition(root, InvWingPoint(p));
				}, () => Direction(Vector3.back), () => Direction(root.LastDerivedSliceTip.Up), secondaryFree: false);
				_gizmos[2].Configure(() => WingPoint(GetChordPosition(tip, 0.5f, toRoot: true)), delegate(Vector3 p)
				{
					SetLeadingEdgePosition(tip, InvWingPoint(p));
				}, () => Direction(Vector3.forward), () => Direction(root.LastDerivedSliceTip.Up), secondaryFree: false);
				_gizmos[3].Configure(() => WingPoint(GetChordPosition(tip, -0.5f, toRoot: true)), delegate(Vector3 p)
				{
					SetTrailingEdgePosition(tip, InvWingPoint(p));
				}, () => Direction(Vector3.back), () => Direction(root.LastDerivedSliceTip.Up), secondaryFree: false);
				_gizmos[4].Configure(() => WingPoint(GetChordPosition(tip, 0f, toRoot: true)), delegate(Vector3 p)
				{
					SetCentrePosition(root, tip, InvWingPoint(p));
				}, () => Direction(root.LastDerivedSliceTip?.SpanVec ?? ((float3)Vector3.right)), () => Direction(Vector3.forward));
			}
			else if (CurrentSlice != null)
			{
				ResetGizmos(2);
				InputWingSlice slice = CurrentSlice;
				_gizmos[0].Configure(() => WingPoint(GetChordPosition(slice, 0.5f, toRoot: true)), delegate(Vector3 p)
				{
					SetLeadingEdgePosition(slice, InvWingPoint(p));
				}, () => Direction(Vector3.forward), () => Direction(slice.LastDerivedSliceRoot.Up), secondaryFree: false);
				_gizmos[1].Configure(() => WingPoint(GetChordPosition(slice, -0.5f, toRoot: true)), delegate(Vector3 p)
				{
					SetTrailingEdgePosition(slice, InvWingPoint(p));
				}, () => Direction(Vector3.back), () => Direction(slice.LastDerivedSliceRoot.Up), secondaryFree: false);
			}
			else if (SelectionIsControlSurface)
			{
				ControlSurfacePartData data = _selectedCsPart.Data;
				ControlSurface cs = data.ControlSurface;
				if (cs is EdgeSurfaceBase edgeSurfaceBase)
				{
					ResetGizmos(4);
					float wingEdge = (edgeSurfaceBase.IsLeadingEdge ? 0.5f : (-0.5f));
					Vector3 outwards = (edgeSurfaceBase.IsLeadingEdge ? Vector3.forward : Vector3.back);
					_gizmos[0].Configure(() => WingPoint(GetWingPointChord(cs.Range.x, wingEdge, rootOfBend: false)), delegate(Vector3 p)
					{
						SetControlSurfaceRange(InvWingPoint(p), isRootSide: true);
					}, () => Direction(outwards), () => Direction(ControlSurfaceSpanDir(isRootSide: true)));
					_gizmos[1].Configure(() => WingPoint(GetWingPointChord(cs.Range.y, wingEdge, rootOfBend: true)), delegate(Vector3 p)
					{
						SetControlSurfaceRange(InvWingPoint(p), isRootSide: false);
					}, () => Direction(outwards), () => Direction(ControlSurfaceSpanDir(isRootSide: true)));
					_gizmos[2].Configure(() => WingPoint(GetSurfaceHingePos(isRootSide: true)), delegate(Vector3 p)
					{
						SetSurfaceHingePos(InvWingPoint(p), isRootSide: true);
					}, () => Direction(-outwards), () => Direction(ControlSurfaceSpanDir(isRootSide: true)), secondaryFree: false);
					_gizmos[3].Configure(() => WingPoint(GetSurfaceHingePos(isRootSide: false)), delegate(Vector3 p)
					{
						SetSurfaceHingePos(InvWingPoint(p), isRootSide: false);
					}, () => Direction(-outwards), () => Direction(ControlSurfaceSpanDir(isRootSide: true)), secondaryFree: false);
				}
			}
			else
			{
				ResetGizmos(0);
			}
			Vector3 Direction(Vector3 local)
			{
				if (_currentWing.Flipped)
				{
					local.y = 0f - local.y;
				}
				return _currentWing.Part.PartScript.transform.rotation * local;
			}
			Vector3 InvWingPoint(Vector3 world)
			{
				if (_currentWing.Part.PartScript == null)
				{
					return world;
				}
				Vector3 result = _currentWing.Part.PartScript.transform.InverseTransformPoint(world);
				if (_currentWing.Flipped)
				{
					result.y = 0f - result.y;
				}
				return result;
			}
			Vector3 WingPoint(Vector3 local)
			{
				if (_currentWing.Part.PartScript == null)
				{
					return local;
				}
				if (_currentWing.Flipped)
				{
					local.y = 0f - local.y;
				}
				return _currentWing.Part.PartScript.transform.TransformPoint(local);
			}
		}

		private void UpdateMeshes()
		{
			_currentWing.UpdateMeshes();
			base.Designer.OnAircraftStructureChanged();
		}
	}
}
