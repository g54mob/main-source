using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Wings.ControlSurfaces;
using UnityEngine;

namespace Assets.Scripts.Craft.Wings
{
	[Serializable]
	public class WingDebugInfo
	{
		[Serializable]
		public class CrossSectionDebugInfo
		{
			[SerializeField]
			private int _meshIndex;

			[SerializeField]
			private Point[] _points;

			[SerializeReference]
			private SliceDebugInfoBase _slice;

			public int MeshIndex
			{
				get
				{
					return _meshIndex;
				}
				set
				{
					_meshIndex = value;
				}
			}

			public Point[] Points
			{
				get
				{
					return _points;
				}
				set
				{
					_points = value;
				}
			}

			public SliceDebugInfoBase Slice
			{
				get
				{
					return _slice;
				}
				set
				{
					_slice = value;
				}
			}

			public CrossSectionDebugInfo(SliceDebugInfoBase slice, int meshIndex, CrossSection section)
			{
				Slice = slice;
				MeshIndex = meshIndex;
				Points = section.Points.AsArray().ToArray();
			}

			public override string ToString()
			{
				return $"Cross Section {MeshIndex} ({Points.Length} points)";
			}
		}

		[Serializable]
		public class RegionSliceDebugInfo : SliceDebugInfoBase
		{
			public enum Part
			{
				Single = 0,
				PreChange = 1,
				PostChange = 2
			}

			[SerializeField]
			private int _controlSurfaceIndex;

			[SerializeField]
			private SurfaceRegion.Slice _slice;

			[SerializeField]
			private Part _slicePart;

			public int ControlSurfaceIndex
			{
				get
				{
					return _controlSurfaceIndex;
				}
				set
				{
					_controlSurfaceIndex = value;
				}
			}

			public SurfaceRegion.Slice Slice
			{
				get
				{
					return _slice;
				}
				set
				{
					_slice = value;
				}
			}

			public Part SlicePart
			{
				get
				{
					return _slicePart;
				}
				set
				{
					_slicePart = value;
				}
			}

			public RegionSliceDebugInfo(CrossSection[] sections, ControlSurface cs, SurfaceRegion.Slice slice, Part part)
				: base(slice.SpanPosition, slice.Scale, GetSurfaceSections(sections, cs))
			{
				ControlSurfaceIndex = cs.SurfaceId;
				Slice = slice;
				SlicePart = part;
			}

			public override string ToString()
			{
				return $"Region Slice x = {Slice.SpanPosition}. CS {ControlSurfaceIndex}, Region {Slice.RegionIndex}, {Slice.Type} ({SlicePart})";
			}

			protected static Span<CrossSection> GetSurfaceSections(CrossSection[] sections, ControlSurface cs)
			{
				return sections.AsSpan(cs.MeshIndexOffset, cs.MeshCount);
			}
		}

		[Serializable]
		public class SliceDebugInfo : SliceDebugInfoBase
		{
			public enum SliceType
			{
				Normal = 0,
				PreCS = 1,
				PostCS = 2
			}

			[SerializeField]
			private uint _controlSurfaceMask;

			[SerializeField]
			private SliceType _type;

			public uint ControlSurfaceMask
			{
				get
				{
					return _controlSurfaceMask;
				}
				set
				{
					_controlSurfaceMask = value;
				}
			}

			public SliceType Type
			{
				get
				{
					return _type;
				}
				set
				{
					_type = value;
				}
			}

			public SliceDebugInfo(WingSlice slice, SliceType type, CrossSection[] crossSections)
				: base(slice.SpanPosition, slice.Scale, crossSections)
			{
				ControlSurfaceMask = slice.ControlSurfaceMask;
				Type = type;
			}

			public override string ToString()
			{
				return $"Slice x = {base.SpanPosition} ({Type})";
			}
		}

		[Serializable]
		public abstract class SliceDebugInfoBase
		{
			[SerializeReference]
			private List<CrossSectionDebugInfo> _crossSections;

			[SerializeField]
			private float _scale;

			[SerializeField]
			private float _spanPosition;

			public List<CrossSectionDebugInfo> CrossSections
			{
				get
				{
					return _crossSections;
				}
				set
				{
					_crossSections = value;
				}
			}

			public float Scale
			{
				get
				{
					return _scale;
				}
				set
				{
					_scale = value;
				}
			}

			public float SpanPosition
			{
				get
				{
					return _spanPosition;
				}
				set
				{
					_spanPosition = value;
				}
			}

			public SliceDebugInfoBase(float spanPos, float scale, Span<CrossSection> crossSections)
			{
				SpanPosition = spanPos;
				Scale = scale;
				CrossSections = new List<CrossSectionDebugInfo>();
				for (int i = 0; i < crossSections.Length; i++)
				{
					if (crossSections[i].HasPoints)
					{
						CrossSections.Add(new CrossSectionDebugInfo(this, i, crossSections[i]));
					}
				}
			}
		}

		[SerializeReference]
		private List<SliceDebugInfoBase> _slices = new List<SliceDebugInfoBase>();

		public List<SliceDebugInfoBase> Slices
		{
			get
			{
				return _slices;
			}
			set
			{
				_slices = value;
			}
		}

		public void AddFullSlice(WingSlice slice, SliceDebugInfo.SliceType type, CrossSection[] sections)
		{
			Slices.Add(new SliceDebugInfo(slice, type, sections));
		}

		public void AddRegionSlice(CrossSection[] sections, ControlSurface cs, SurfaceRegion.Slice slice, RegionSliceDebugInfo.Part part)
		{
			Slices.Add(new RegionSliceDebugInfo(sections, cs, slice, part));
		}
	}
}
