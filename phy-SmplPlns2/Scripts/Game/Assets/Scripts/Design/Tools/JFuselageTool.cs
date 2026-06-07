using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Fuselage;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design.Symmetry;
using Assets.Scripts.Design.UI;
using Assets.Scripts.Input.Events;
using Assets.Scripts.UI;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class JFuselageTool : DesignerTool
	{
		public enum SmoothingMode
		{
			Off = 0,
			Smooth = 1,
			FrontOnly = 2,
			BackOnly = 3
		}

		private enum EditType
		{
			Width = 0,
			Height = 1,
			Trapezium = 2,
			Thickness = 3,
			Smoothing = 4,
			Corners = 5,
			Edge = 6,
			Cutting = 7,
			Length = 8,
			Rise = 9,
			Run = 10,
			Roundness = 11,
			SyncFaces = 12
		}

		private interface ISelection
		{
			bool UseReplaceKey { get; set; }
		}

		public class SectionSelection : ISelection
		{
			private struct SectionView
			{
				private AttachPointData _backAp;

				private Vector3? _backAttachPointOriginalPosition;

				private AttachPointData _frontAp;

				private Vector3? _frontAttachPointOriginalPosition;

				private bool _moveParts;

				public JFuselageData Fuselage { get; set; }

				public bool Mirrored { get; set; }

				public int SectionIndex { get; set; }

				public void EndOffsetChange()
				{
					if (_moveParts)
					{
						JFuselageScript.FlushChanges();
						if (_frontAp == null && _backAp != null)
						{
							SymmetryUtility.MoveConnectedParts(Fuselage.Part, _backAp, null, _backAttachPointOriginalPosition.Value, null);
						}
						else if (_frontAp != null)
						{
							SymmetryUtility.MoveConnectedParts(Fuselage.Part, _frontAp, _backAp, _frontAttachPointOriginalPosition.Value, _backAttachPointOriginalPosition);
						}
						_moveParts = false;
						_frontAttachPointOriginalPosition = null;
						_backAttachPointOriginalPosition = null;
						_frontAp = null;
						_backAp = null;
						Designer.Instance.SetAircraftStructureChanged();
					}
				}

				public float GetConeRoundness()
				{
					return Fuselage.NoseconeRoundness;
				}

				public float GetLength()
				{
					return Fuselage.Offset.z;
				}

				public float GetRise()
				{
					return Fuselage.Offset.y;
				}

				public float GetRun()
				{
					if (!Mirrored)
					{
						return Fuselage.Offset.x;
					}
					return 0f - Fuselage.Offset.x;
				}

				public void SetConeRoundness(float value)
				{
					Fuselage.NoseconeRoundness = value;
				}

				public void SetLength(float value)
				{
					Vector3 offset = Fuselage.Offset;
					offset.z = value;
					Fuselage.Offset = offset;
				}

				public void SetRise(float value)
				{
					Vector3 offset = Fuselage.Offset;
					offset.y = value;
					Fuselage.Offset = offset;
				}

				public void SetRun(float value)
				{
					Vector3 offset = Fuselage.Offset;
					offset.x = (Mirrored ? (0f - value) : value);
					Fuselage.Offset = offset;
				}

				public void StartOffsetChange()
				{
					if (Fuselage.GetEndAttachPoints(0, out _backAp, out _frontAp))
					{
						_frontAttachPointOriginalPosition = _frontAp?.AttachPointScript.transform.position;
						_backAttachPointOriginalPosition = _backAp?.AttachPointScript.transform.position;
						_moveParts = true;
					}
					else
					{
						_moveParts = false;
						_frontAttachPointOriginalPosition = null;
						_backAttachPointOriginalPosition = null;
					}
				}
			}

			private JFuselageTool _tool;

			private SectionView _view;

			private List<SectionView> _views = new List<SectionView>();

			public JFuselageData PrimaryFuselage => _view.Fuselage;

			public int PrimaryFuselageIndex => _view.SectionIndex;

			bool ISelection.UseReplaceKey { get; set; }

			internal SectionSelection(JFuselageTool tool)
			{
				_tool = tool;
			}

			public float GetConeRoundness()
			{
				return _view.GetConeRoundness();
			}

			public float GetLength()
			{
				return _view.GetLength();
			}

			public float GetRise()
			{
				return _view.GetRise();
			}

			public float GetRun()
			{
				return _view.GetRun();
			}

			public void Set(JFuselageData fuselage, Designer designer, int sectionIndex)
			{
				((ISelection)this).UseReplaceKey = false;
				if (fuselage == null)
				{
					_view = default(SectionView);
					_views.Clear();
					return;
				}
				_view = new SectionView
				{
					Fuselage = fuselage,
					Mirrored = false,
					SectionIndex = sectionIndex
				};
				_views.Add(_view);
				List<PartData> symmetricParts;
				using (designer.Aircraft.Aircraft.Assembly.GetOtherSymmetricParts(_view.Fuselage.Part, out symmetricParts))
				{
					foreach (PartData item in symmetricParts)
					{
						if (item.TryGetModifier<JFuselageData>(out var result))
						{
							SectionView view = _view;
							view.Mirrored = true;
							view.Fuselage = result;
							_views.Add(view);
						}
					}
				}
			}

			public void SetConeRoundness(float value)
			{
				foreach (SectionView view in _views)
				{
					view.SetConeRoundness(value);
				}
				TrackUndo(EditType.Roundness);
			}

			public bool SetLength(float value)
			{
				if (value <= float.Epsilon)
				{
					return false;
				}
				_view.StartOffsetChange();
				foreach (SectionView view in _views)
				{
					view.SetLength(value);
				}
				_view.EndOffsetChange();
				TrackUndo(EditType.Length);
				return true;
			}

			public bool SetLengthFromGizmo(float value, Vector3 positionDelta)
			{
				if (value <= float.Epsilon)
				{
					return false;
				}
				foreach (SectionView view in _views)
				{
					PartScript partScript = view.Fuselage.Part.PartScript;
					if (partScript != null)
					{
						partScript.transform.position += positionDelta;
					}
					view.SetLength(value);
					QueueRebuild(view.Fuselage);
				}
				Designer.Instance.SetAircraftStructureChanged();
				return true;
			}

			public void SetRise(float value)
			{
				_view.StartOffsetChange();
				foreach (SectionView view in _views)
				{
					view.SetRise(value);
				}
				_view.EndOffsetChange();
				TrackUndo(EditType.Rise);
			}

			public void SetRiseAndRunEdgeFromGizmo(float rise, float run, Vector3 positionDelta)
			{
				foreach (SectionView view in _views)
				{
					PartScript partScript = view.Fuselage.Part.PartScript;
					if (partScript != null)
					{
						partScript.transform.position += positionDelta;
					}
					view.SetRise(rise);
					view.SetRun(run);
					QueueRebuild(view.Fuselage);
				}
				Designer.Instance.SetAircraftStructureChanged();
			}

			public void SetRiseEdgeFromGizmo(float value, Vector3 positionDelta)
			{
				foreach (SectionView view in _views)
				{
					PartScript partScript = view.Fuselage.Part.PartScript;
					if (partScript != null)
					{
						partScript.transform.position += positionDelta;
					}
					view.SetRise(value);
					QueueRebuild(view.Fuselage);
				}
				Designer.Instance.SetAircraftStructureChanged();
			}

			public void SetRun(float value)
			{
				_view.StartOffsetChange();
				foreach (SectionView view in _views)
				{
					view.SetRun(value);
				}
				_view.EndOffsetChange();
				TrackUndo(EditType.Run);
			}

			public void SetRunEdgeFromGizmo(float value, Vector3 positionDelta)
			{
				foreach (SectionView view in _views)
				{
					PartScript partScript = view.Fuselage.Part.PartScript;
					if (partScript != null)
					{
						partScript.transform.position += (view.Mirrored ? (-positionDelta) : positionDelta);
					}
					view.SetRun(value);
					QueueRebuild(view.Fuselage);
				}
				Designer.Instance.SetAircraftStructureChanged();
			}

			private void TrackUndo(EditType type)
			{
				_tool.TrackUndo(type, this);
			}
		}

		public class SliceSelection : ISelection
		{
			private struct SliceView
			{
				public JFuselageData Fuselage { get; set; }

				public bool Mirrored { get; set; }

				public readonly ref readonly SectionParams ReadRef => ref Fuselage.GetSliceRefUntracked(SliceIndex);

				public int SliceIndex { get; set; }

				public bool Symmetric { get; set; }

				private readonly ref SectionParams WriteRefUntracked => ref Fuselage.GetSliceRefUntracked(SliceIndex);

				public readonly float GetCornerRadius(int corner)
				{
					return ReadRef.CornerRadii[Corner(corner)];
				}

				public readonly bool GetCornersEqual()
				{
					float4 cornerRadii = ReadRef.CornerRadii;
					float4 cornersStretch = ReadRef.CornersStretch;
					if (math.all(cornerRadii.x == cornerRadii.yzw))
					{
						return math.all(cornersStretch.x == cornersStretch.yzw);
					}
					return false;
				}

				public readonly bool GetCornerStretch(int corner)
				{
					return ReadRef.CornersStretch[Corner(corner)] > 0.5f;
				}

				public readonly decimal? GetCutting(int side)
				{
					return Fuselage.GetCutting(SliceIndex)[Edge(side)];
				}

				public readonly float GetEdgeCurvature(int edge)
				{
					return ReadRef.EdgeCurvature[Edge(edge)];
				}

				public readonly bool GetEdgesEqual()
				{
					float4 edgeCurvature = ReadRef.EdgeCurvature;
					return math.all(edgeCurvature.x == edgeCurvature.yzw);
				}

				public readonly float GetHeight()
				{
					return ReadRef.Size.y;
				}

				public readonly bool GetSmoothing()
				{
					return Fuselage.GetSmoothing(SliceIndex);
				}

				public readonly bool GetSyncFlag()
				{
					return Fuselage.SyncSlice(SliceIndex);
				}

				public readonly float GetThickness()
				{
					return ReadRef.Thickness;
				}

				public readonly float GetTrapezium()
				{
					return ReadRef.Trapezium;
				}

				public readonly float GetWidth()
				{
					return ReadRef.Size.x;
				}

				public readonly void SetAllCornerRadius(float radius)
				{
					WriteRefUntracked.CornerRadii = radius;
					Changed();
				}

				public readonly void SetAllCornerStretch(bool stretch)
				{
					WriteRefUntracked.CornersStretch = (stretch ? 1f : 0f);
					Changed();
				}

				public readonly void SetAllEdgeCurvatures(float curvature)
				{
					WriteRefUntracked.EdgeCurvature = curvature;
					Changed();
				}

				public readonly void SetCornerRadius(int corner, float radius)
				{
					WriteRefUntracked.CornerRadii[Corner(corner)] = radius;
					Changed();
				}

				public readonly void SetCornerStretch(int corner, bool stretch)
				{
					WriteRefUntracked.CornersStretch[Corner(corner)] = (stretch ? 1f : 0f);
					Changed();
				}

				public readonly void SetCutting(int side, decimal? value)
				{
					JFuselageData.CuttingParams cutting = Fuselage.GetCutting(SliceIndex);
					cutting[Edge(side)] = value;
					Fuselage.SetCutting(SliceIndex, cutting);
				}

				public readonly void SetEdgeCurvature(int edge, float value)
				{
					WriteRefUntracked.EdgeCurvature[Edge(edge)] = value;
					Changed();
				}

				public readonly void SetHeight(float height)
				{
					WriteRefUntracked.Size.y = height;
					Changed();
				}

				public readonly void SetSmoothing(bool value)
				{
					Fuselage.SetSmoothing(SliceIndex, value);
				}

				public readonly void SetSyncFlag(bool value)
				{
					Fuselage.SyncSlice(SliceIndex) = value;
				}

				public readonly void SetThickness(float value)
				{
					WriteRefUntracked.Thickness = value;
					Changed();
				}

				public readonly void SetTrapezium(float value)
				{
					WriteRefUntracked.Trapezium = value;
					Changed();
				}

				public readonly void SetWidth(float width)
				{
					WriteRefUntracked.Size.x = width;
					Changed();
				}

				public readonly bool ShapeMatches(SliceView other)
				{
					return Fuselage.ShapeMatches(other.Fuselage, SliceIndex, other.SliceIndex);
				}

				private readonly void Changed()
				{
					QueueRebuild(Fuselage);
				}

				private readonly int Corner(int corner)
				{
					return corner ^ (Mirrored ? 1 : 0);
				}

				private readonly int Edge(int edge)
				{
					if (Mirrored)
					{
						return edge ^ ((edge & 1) << 1);
					}
					return edge;
				}
			}

			private JFuselageTool _tool;

			private SliceView _view;

			private List<SliceView> _views = new List<SliceView>();

			public ref readonly SectionParams BaseParams => ref _view.ReadRef;

			public JFuselageData PrimaryFuselage => _view.Fuselage;

			public int PrimarySliceIndex => _view.SliceIndex;

			bool ISelection.UseReplaceKey { get; set; }

			internal SliceSelection(JFuselageTool tool)
			{
				_tool = tool;
			}

			public float GetCornerRadius(int corner)
			{
				return _view.GetCornerRadius(corner);
			}

			public bool GetCornersEqual()
			{
				return _view.GetCornersEqual();
			}

			public bool GetCornerStretch(int corner)
			{
				return _view.GetCornerStretch(corner);
			}

			public decimal? GetCutting(int side, out float minCutting, out float maxCutting)
			{
				decimal? cutting = _view.GetCutting(side);
				minCutting = 0f;
				maxCutting = 1f;
				PartScript partScript = _view.Fuselage.Part.PartScript;
				if (partScript == null)
				{
					return cutting;
				}
				JFuselageScript modifier = partScript.GetModifier<JFuselageScript>();
				if (modifier == null)
				{
					return cutting;
				}
				float4 float5 = modifier.MinCutting[_view.SliceIndex];
				minCutting = float5[side];
				maxCutting = 1f - float5[(side + 2) % 4];
				return cutting;
			}

			public float GetEdgeCurvature(int edge)
			{
				return _view.GetEdgeCurvature(edge);
			}

			public bool GetEdgesEqual()
			{
				return _view.GetEdgesEqual();
			}

			public float GetHeight()
			{
				return _view.GetHeight();
			}

			public SmoothingMode GetSmoothingMode()
			{
				bool? flag = null;
				bool? flag2 = null;
				foreach (SliceView view in _views)
				{
					if (!view.Fuselage.SliceIsFront(view.SliceIndex))
					{
						if (!flag.HasValue)
						{
							flag = view.GetSmoothing();
							if (flag2.HasValue)
							{
								break;
							}
						}
					}
					else if (!flag2.HasValue)
					{
						flag2 = view.GetSmoothing();
						if (flag.HasValue)
						{
							break;
						}
					}
				}
				if (flag.HasValue && flag2.HasValue)
				{
					if (flag.Value && flag2.Value)
					{
						return SmoothingMode.Smooth;
					}
					if (flag.Value)
					{
						return SmoothingMode.FrontOnly;
					}
					if (flag2.Value)
					{
						return SmoothingMode.BackOnly;
					}
					return SmoothingMode.Off;
				}
				if (flag == true || flag2 == true)
				{
					return SmoothingMode.Smooth;
				}
				return SmoothingMode.Off;
			}

			public float GetThickness()
			{
				return _view.GetThickness();
			}

			public float GetTrapezium()
			{
				return _view.GetTrapezium();
			}

			public float GetWidth()
			{
				return _view.GetWidth();
			}

			public void Set(JFuselageData fuselage, Designer designer, int index)
			{
				((ISelection)this).UseReplaceKey = false;
				if (fuselage == null)
				{
					_view = default(SliceView);
					_views.Clear();
					return;
				}
				_view = new SliceView
				{
					Fuselage = fuselage,
					Mirrored = false,
					Symmetric = false,
					SliceIndex = index
				};
				_views.Clear();
				_views.Add(_view);
				if (fuselage.SyncSlice(index) && fuselage.TryGetNeighbour(index, out var neighbourFuselage, out var neighbourSliceIndex))
				{
					_views.Add(new SliceView
					{
						Fuselage = neighbourFuselage,
						SliceIndex = neighbourSliceIndex,
						Mirrored = (neighbourFuselage.SliceIsFront(neighbourSliceIndex) == fuselage.SliceIsFront(index)),
						Symmetric = false
					});
				}
				Assembly assembly = designer.Aircraft.Aircraft.Assembly;
				int count = _views.Count;
				for (int i = 0; i < count; i++)
				{
					SliceView sliceView = _views[i];
					List<PartData> symmetricParts;
					using (assembly.GetOtherSymmetricParts(sliceView.Fuselage.Part, out symmetricParts))
					{
						foreach (PartData item2 in symmetricParts)
						{
							if (item2.TryGetModifier<JFuselageData>(out var result))
							{
								SliceView item = sliceView;
								item.Mirrored = !item.Mirrored;
								item.Symmetric = true;
								item.Fuselage = result;
								_views.Add(item);
							}
						}
					}
				}
			}

			public void SetAllCornerRadius(float value)
			{
				foreach (SliceView view in _views)
				{
					view.SetAllCornerRadius(value);
				}
				TrackUndo(EditType.Corners);
			}

			public void SetAllCornerStretch(bool value)
			{
				foreach (SliceView view in _views)
				{
					view.SetAllCornerStretch(value);
				}
				TrackUndo(EditType.Corners);
			}

			public void SetAllEdgeCurvatures(float value)
			{
				foreach (SliceView view in _views)
				{
					view.SetAllEdgeCurvatures(value);
				}
				TrackUndo(EditType.Edge);
			}

			public void SetCornerRadius(int corner, float value)
			{
				foreach (SliceView view in _views)
				{
					view.SetCornerRadius(corner, value);
				}
				TrackUndo(EditType.Corners);
			}

			public void SetCornerStretch(int corner, bool value)
			{
				foreach (SliceView view in _views)
				{
					view.SetCornerStretch(corner, value);
				}
				TrackUndo(EditType.Corners);
			}

			public void SetCutting(int side, decimal? value)
			{
				foreach (SliceView view in _views)
				{
					view.SetCutting(side, value);
				}
				TrackUndo(EditType.Cutting);
			}

			public void SetEdgeCurvature(int edge, float value)
			{
				foreach (SliceView view in _views)
				{
					view.SetEdgeCurvature(edge, value);
				}
				TrackUndo(EditType.Edge);
			}

			public bool SetHeight(float value, bool trackUndo = true)
			{
				if (value < 0f)
				{
					return false;
				}
				foreach (SliceView view in _views)
				{
					view.SetHeight(value);
				}
				if (trackUndo)
				{
					TrackUndo(EditType.Height);
				}
				return true;
			}

			public void SetSmoothingMode(SmoothingMode value)
			{
				bool flag = value == SmoothingMode.Smooth || value == SmoothingMode.BackOnly;
				bool flag2 = value == SmoothingMode.Smooth || value == SmoothingMode.FrontOnly;
				bool flag3 = JFuselageScript.StartChangeBuffer();
				try
				{
					foreach (SliceView view in _views)
					{
						view.SetSmoothing(view.Fuselage.SliceIsFront(view.SliceIndex) ? flag : flag2);
					}
				}
				finally
				{
					if (flag3)
					{
						JFuselageScript.ApplyBufferedChanges();
					}
				}
				TrackUndo(EditType.Smoothing);
			}

			public void SetSyncFlag(bool value)
			{
				foreach (SliceView view in _views)
				{
					view.SetSyncFlag(value);
				}
			}

			public void SetThickness(float value)
			{
				foreach (SliceView view in _views)
				{
					view.SetThickness(value);
				}
				TrackUndo(EditType.Thickness);
			}

			public void SetTrapezium(float value)
			{
				foreach (SliceView view in _views)
				{
					view.SetTrapezium(value);
				}
				TrackUndo(EditType.Trapezium);
			}

			public bool SetWidth(float value, bool trackUndo = true)
			{
				if (value < 0f)
				{
					return false;
				}
				foreach (SliceView view in _views)
				{
					view.SetWidth(value);
				}
				if (trackUndo)
				{
					TrackUndo(EditType.Width);
				}
				return true;
			}

			public bool SlicesSynced()
			{
				if (!_view.GetSyncFlag())
				{
					return false;
				}
				if (_view.Fuselage.TryGetNeighbour(_view.SliceIndex, out var neighbourFuselage, out var neighbourSliceIndex))
				{
					SliceView other = new SliceView
					{
						Fuselage = neighbourFuselage,
						Mirrored = (_view.Fuselage.SliceIsFront(_view.SliceIndex) == neighbourFuselage.SliceIsFront(neighbourSliceIndex)),
						SliceIndex = neighbourSliceIndex,
						Symmetric = false
					};
					if (other.GetSyncFlag())
					{
						return _view.ShapeMatches(other);
					}
					return false;
				}
				return true;
			}

			private void TrackUndo(EditType type)
			{
				_tool.TrackUndo(type, this);
			}
		}

		public const float DefaultSnap = 0.05f;

		private static HashSet<JFuselageData> _dirty = new HashSet<JFuselageData>();

		private JFuselageToolBox _box;

		private JFuselageGizmoController _gizmoController;

		private JFuselageToolBox _hoverBox;

		private SelectionTarget? _hoverTarget;

		private bool _inputHandled;

		private EditType _lastEditType;

		private SectionSelection _section;

		private bool _sectionActive;

		private SliceSelection _slice;

		private bool _sliceActive;

		private bool _undoPhase;

		private ISelection _undoSelection;

		public SelectionTarget? CurrentTarget
		{
			get
			{
				if (_sliceActive)
				{
					return SelectionTarget.ForSlice(_slice.PrimaryFuselage, _slice.PrimarySliceIndex);
				}
				if (_sectionActive)
				{
					return SelectionTarget.ForSection(_section.PrimaryFuselage, _section.PrimaryFuselageIndex);
				}
				return null;
			}
		}

		public JFuselageGizmoController GizmoController => _gizmoController;

		public JFuselageData PrimaryFuselage
		{
			get
			{
				if (_sliceActive)
				{
					return _slice.PrimaryFuselage;
				}
				if (_sectionActive)
				{
					return _section.PrimaryFuselage;
				}
				return null;
			}
		}

		public SectionSelection Section
		{
			get
			{
				if (!_sectionActive)
				{
					return null;
				}
				return _section;
			}
		}

		public SliceSelection Slice
		{
			get
			{
				if (!_sliceActive)
				{
					return null;
				}
				return _slice;
			}
		}

		public float SnapDistance { get; set; } = 0.05f;

		public event Action OnSelectionChanged;

		public event Action OnValuesChanged;

		public JFuselageTool(Designer designer, CameraController cameraController)
			: base(designer, cameraController)
		{
			_box = new JFuselageToolBox(designer);
			_hoverBox = new JFuselageToolBox(designer);
			_slice = new SliceSelection(this);
			_section = new SectionSelection(this);
			base.ShowSelectionHighlight = false;
		}

		public static void QueueRebuild(JFuselageData fuselage)
		{
			_dirty.Add(fuselage);
		}

		public void AddSection()
		{
			SliceSelection slice = Slice;
			if (slice != null && CanAddSection())
			{
				bool num = JFuselageScript.StartChangeBuffer();
				JFuselageData primaryFuselage = slice.PrimaryFuselage;
				PartData partData = SymmetryUtility.DuplicatePart(primaryFuselage.Part, mirrored: false);
				JFuselageData modifier = partData.GetModifier<JFuselageData>();
				AttachPointScript attachPointScript = primaryFuselage.GetAttachPoint(slice.PrimarySliceIndex).AttachPointScript;
				int primarySliceIndex = slice.PrimarySliceIndex;
				int num2 = 1 - primarySliceIndex;
				modifier[num2] = modifier[primarySliceIndex];
				modifier.SetCutting(num2, modifier.GetCutting(primarySliceIndex));
				modifier.SetSmoothing(num2, modifier.GetSmoothing(primarySliceIndex));
				AttachPointScript attachPointScript2 = modifier.GetAttachPoint(num2).AttachPointScript;
				attachPointScript.PartScript.ConnectToPart(attachPointScript, attachPointScript2);
				Vector3 vector = attachPointScript.transform.position - attachPointScript2.transform.position;
				partData.PartScript.transform.position += vector;
				if (primaryFuselage.Part.SymmetryId != 0)
				{
					SymmetryUtility.CreateSymmetricParts(partData, allowOverlappingPositions: false, base.Designer.Symmetry);
					SymmetryUtility.ConnectSymmetricParts(attachPointScript, attachPointScript2, base.Designer.Symmetry, showConnectionFailureMessages: true);
				}
				if (num)
				{
					JFuselageScript.ApplyBufferedChanges();
				}
				SelectSection(modifier, 0);
				base.Designer.SelectedPart = modifier.Part.PartScript;
				base.Designer.CreateUndoStep("Add Fuselage Section");
			}
		}

		public override void AircraftStructureChanged()
		{
			_box.UpdateBox(this);
		}

		public void ApplySelection(SelectionTarget target, bool force = false)
		{
			SelectionTarget? currentTarget = CurrentTarget;
			if (force || !currentTarget.HasValue || !target.Matches(currentTarget.Value))
			{
				ClearSelection(raiseEvent: false);
				if (target.IsSlice)
				{
					_slice.Set(target.Fuselage, base.Designer, target.Index);
					_sliceActive = true;
				}
				else
				{
					_section.Set(target.Fuselage, base.Designer, target.Index);
					_sectionActive = true;
				}
				PrimaryFuselage.OnShapeDataChanged += OnPrimarySelectedFuselageShapeDataChange;
				OnSelectionChange();
			}
		}

		public bool CanAddSection()
		{
			SliceSelection slice = Slice;
			if (slice == null)
			{
				return false;
			}
			if (slice.PrimaryFuselage.Style != FuselageStyle.Body && slice.PrimaryFuselage.Style != FuselageStyle.Hollow)
			{
				return false;
			}
			return slice.PrimaryFuselage.GetAttachPoint(slice.PrimarySliceIndex)?.IsAvailable ?? false;
		}

		public bool CanNavigate(bool forwards)
		{
			return Navigate(forwards, apply: false);
		}

		public override void HandleInput(InputEvent e)
		{
			JFuselageGizmoController gizmoController = _gizmoController;
			if (gizmoController != null && gizmoController.HandleInput(e))
			{
				_inputHandled = false;
				return;
			}
			bool flag = false;
			bool flag2 = UnityEngine.Input.GetKey(KeyCode.LeftControl) || UnityEngine.Input.GetKey(KeyCode.RightControl);
			if (e.InputButton == InputButton.Primary && !base.ViewPortIsMoving && !flag2)
			{
				Ray ray = base.Designer.ScreenPointToRay(e.Position);
				SelectionTarget? selectionTarget = IdentifyTarget(ray);
				if (selectionTarget.HasValue)
				{
					ApplySelection(selectionTarget.Value);
					if (e.InputState == InputState.Updated)
					{
						flag = true;
					}
				}
				if (e.InputState == InputState.End)
				{
					base.Designer.DesignerScript.DesignerUI.HideMainUI(hide: false);
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

		public SelectionTarget? IdentifyNavigation(SelectionTarget from, bool forwards)
		{
			PartScript partScript = from.Fuselage.Part.PartScript;
			if (partScript == null)
			{
				return null;
			}
			JFuselageScript modifier = partScript.GetModifier<JFuselageScript>();
			if (modifier == null)
			{
				return null;
			}
			bool isSlice = from.IsSlice;
			if (!modifier.GetAdjacentPiece(isSlice, from.Index, forwards, out var nextFuselage, out var nextIsSlice, out var nextIndex))
			{
				return null;
			}
			return new SelectionTarget(nextFuselage.Data, nextIndex, nextIsSlice);
		}

		public SelectionTarget? IdentifyTarget(Ray ray)
		{
			int layerMask = 32768;
			(PartScript, RaycastHit, Ray)? partFromRayCast = Designer.GetPartFromRayCast(ray, layerMask);
			if (partFromRayCast?.Item1 == null)
			{
				return null;
			}
			JFuselageScript modifier = partFromRayCast.Value.Item1.GetModifier<JFuselageScript>();
			if (modifier == null)
			{
				return null;
			}
			SelectionTarget selectionTarget = SelectionTarget.ForSection(modifier.Data, 0);
			Vector3 vector = modifier.PartScript.transform.InverseTransformPoint(partFromRayCast.Value.Item2.point);
			SelectionTarget? selectionTarget2 = null;
			if (vector.z < (0f - modifier.Data.Offset.z) * 0.8f * 0.45f)
			{
				selectionTarget2 = IdentifyNavigation(selectionTarget, modifier.IsBackwards);
			}
			else if (vector.z > modifier.Data.Offset.z * 0.8f * 0.45f)
			{
				selectionTarget2 = IdentifyNavigation(selectionTarget, !modifier.IsBackwards);
			}
			return selectionTarget2 ?? selectionTarget;
		}

		public override void MouseHover(Vector3? screenPosition)
		{
			Vector3? screenPosition2 = ((_gizmoController?.HandleHover(screenPosition) != null) ? ((Vector3?)null) : screenPosition);
			if (screenPosition2.HasValue)
			{
				Ray ray = base.Designer.ScreenPointToRay(screenPosition2.Value);
				SelectionTarget? hoverTarget = IdentifyTarget(ray);
				if (hoverTarget.HasValue && CurrentTarget.HasValue && hoverTarget.Value.Matches(CurrentTarget.Value))
				{
					hoverTarget = null;
				}
				if (hoverTarget.HasValue != _hoverTarget.HasValue || (hoverTarget.HasValue && !hoverTarget.Value.Matches(_hoverTarget.Value)))
				{
					_hoverTarget = hoverTarget;
					if (hoverTarget.HasValue)
					{
						Game.Instance.UserInterface.Sound.PlaySound(UISound.Hover);
						_hoverBox.ShowHover(hoverTarget.Value);
					}
					else
					{
						_hoverBox.Hide();
					}
				}
			}
			else if (_hoverTarget.HasValue)
			{
				_hoverTarget = null;
				_hoverBox.Hide();
			}
			base.MouseHover(screenPosition2);
		}

		public bool Navigate(bool forwards, bool apply)
		{
			SelectionTarget? currentTarget = CurrentTarget;
			if (!currentTarget.HasValue)
			{
				return false;
			}
			SelectionTarget? selectionTarget = IdentifyNavigation(currentTarget.Value, forwards);
			if (!selectionTarget.HasValue)
			{
				return false;
			}
			if (apply)
			{
				ApplySelection(selectionTarget.Value);
			}
			return true;
		}

		public void SelectSection(JFuselageData fuselage, int section)
		{
			ApplySelection(SelectionTarget.ForSection(fuselage, section));
		}

		public void SelectSlice(JFuselageData fuselage, int slice)
		{
			ApplySelection(SelectionTarget.ForSlice(fuselage, slice));
		}

		public void SetSliceSync(bool sync)
		{
			if (!_sliceActive)
			{
				return;
			}
			if (sync)
			{
				EnableSync(_slice.PrimaryFuselage, _slice.PrimarySliceIndex);
				List<PartData> symmetricParts;
				using (base.Designer.Aircraft.Aircraft.Assembly.GetOtherSymmetricParts(_slice.PrimaryFuselage.Part, out symmetricParts))
				{
					foreach (PartData item in symmetricParts)
					{
						if (item.TryGetModifier<JFuselageData>(out var result))
						{
							EnableSync(result, _slice.PrimarySliceIndex);
						}
					}
				}
			}
			else
			{
				_slice.SetSyncFlag(value: false);
			}
			ApplySelection(new SelectionTarget(_slice.PrimaryFuselage, _slice.PrimarySliceIndex, isSlice: true), force: true);
			TrackUndo(EditType.SyncFaces, _slice);
			static void EnableSync(JFuselageData fuselage, int slice)
			{
				fuselage.SyncSlice(slice) = true;
				if (fuselage.TryGetNeighbour(slice, out var neighbourFuselage, out var neighbourSliceIndex))
				{
					SectionParams value = fuselage[slice];
					JFuselageData.CuttingParams cutting = fuselage.GetCutting(slice);
					if (fuselage.SliceIsFront(slice) == neighbourFuselage.SliceIsFront(neighbourSliceIndex))
					{
						value.Mirror();
						cutting.Mirror();
					}
					neighbourFuselage.SyncSlice(neighbourSliceIndex) = true;
					neighbourFuselage[neighbourSliceIndex] = value;
					neighbourFuselage.SetCutting(neighbourSliceIndex, cutting);
					neighbourFuselage.AlignToSlice(neighbourSliceIndex, fuselage, slice, tryMoveSliceOnly: true);
				}
			}
		}

		public override void Start()
		{
			base.Start();
			_dirty.Clear();
			_box.Initialize("Fuselage Selection Box");
			_hoverBox.Initialize("Fuselage Hover Box");
			_gizmoController = new JFuselageGizmoController(this, base.Designer)
			{
				OnDragged = delegate
				{
					this.OnValuesChanged?.Invoke();
				}
			};
			if (base.Designer.SelectedPart.Part.TryGetModifier<JFuselageData>(out var result))
			{
				SelectSection(result, 0);
			}
			IDesignerFlyouts flyouts = base.Designer.DesignerScript.DesignerUI.Flyouts;
			flyouts.Selected = flyouts.JFuselageShape;
		}

		public override void Stop()
		{
			base.Stop();
			_box.Hide();
			_hoverBox.Hide();
			_gizmoController.Dispose();
			_gizmoController = null;
			ProcessDirtyFuselages();
			ClearSelection(raiseEvent: false);
			IDesignerFlyouts flyouts = base.Designer.DesignerScript.DesignerUI.Flyouts;
			if (flyouts.Selected == flyouts.JFuselageShape && !flyouts.Selected.IsClosing)
			{
				flyouts.Selected = null;
			}
		}

		public void TrackGizmoUndo(string propertyModified)
		{
			base.Designer.CreateUndoStepForSelectedPart("Modified " + propertyModified);
		}

		public override void Update()
		{
			base.Update();
			_gizmoController?.Update();
			ProcessDirtyFuselages();
		}

		protected override void SelectedPartChanged(PartScript newPart)
		{
			base.SelectedPartChanged(newPart);
			if (newPart == null || !newPart.Part.TryGetModifier<JFuselageData>(out var _))
			{
				base.Designer.Tools.SelectTool(base.Designer.Tools.MovePartTool);
			}
		}

		private void ClearSelection(bool raiseEvent = true)
		{
			JFuselageData primaryFuselage = PrimaryFuselage;
			if (primaryFuselage != null)
			{
				primaryFuselage.OnShapeDataChanged -= OnPrimarySelectedFuselageShapeDataChange;
			}
			if (_sliceActive)
			{
				_slice.Set(null, null, 0);
				_sliceActive = false;
			}
			if (_sectionActive)
			{
				_section.Set(null, null, 0);
				_sectionActive = false;
			}
			if (raiseEvent)
			{
				OnSelectionChange();
			}
		}

		private void OnPrimarySelectedFuselageShapeDataChange()
		{
			_box.UpdateBox(this);
		}

		private void OnSelectionChange()
		{
			this.OnSelectionChanged?.Invoke();
			SelectionTarget? currentTarget = CurrentTarget;
			if (currentTarget.HasValue)
			{
				Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerSelectPart);
				_box.ShowSelection(currentTarget.Value);
			}
			else
			{
				_box.Hide();
			}
			if (_hoverTarget.HasValue && currentTarget.HasValue && _hoverTarget.Value.Matches(currentTarget.Value))
			{
				_hoverTarget = null;
				_hoverBox.Hide();
			}
		}

		private void ProcessDirtyFuselages()
		{
			if (_dirty.Count == 0)
			{
				return;
			}
			foreach (JFuselageData item in _dirty)
			{
				item.RaiseChange();
			}
			_dirty.Clear();
		}

		private void TrackUndo(EditType type, ISelection selection)
		{
			if (selection != _undoSelection || !selection.UseReplaceKey || _lastEditType != type)
			{
				_undoPhase = !_undoPhase;
			}
			string replaceKey = (_undoPhase ? "JFuselage1" : "JFuselage2");
			base.Designer.CreateUndoStep($"Edit Fuselage {type}", replaceKey);
			_undoSelection = selection;
			selection.UseReplaceKey = true;
			_lastEditType = type;
		}
	}
}
