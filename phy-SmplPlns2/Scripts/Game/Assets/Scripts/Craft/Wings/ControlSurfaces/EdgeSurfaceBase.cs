using System;
using System.Xml.Linq;
using Assets.Scripts.Craft.Wings.Utilities;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.ControlSurfaces
{
	public abstract class EdgeSurfaceBase : ControlSurface
	{
		private float2 _range;

		private float2 _startPos;

		public abstract float DefaultStartPos { get; }

		public abstract bool IsLeadingEdge { get; }

		public sealed override SurfaceLocation Location
		{
			get
			{
				if (!IsLeadingEdge)
				{
					return SurfaceLocation.TrailingEdge;
				}
				return SurfaceLocation.LeadingEdge;
			}
		}

		public override float2 Range
		{
			get
			{
				return _range;
			}
			set
			{
				_range = value;
				EdgeClaim.SpanRange = _range;
			}
		}

		public float2 StartPos
		{
			get
			{
				return _startPos;
			}
			set
			{
				_startPos = value;
				UpdateClaim();
			}
		}

		protected Claim EdgeClaim { get; } = new Claim();

		protected abstract float2 MinMaxChordSize { get; }

		public override void AddToClaims(WingSurfaceClaims claims)
		{
			claims.Claims.Add(EdgeClaim);
		}

		public override void CopySettingsTo(ControlSurface dest)
		{
			base.CopySettingsTo(dest);
			(dest as EdgeSurfaceBase).StartPos = StartPos;
		}

		public override void HandleSectionChange(in WingSectionChange change)
		{
			float2 range = Range;
			float2 startPos = StartPos;
			ref float x = ref range.x;
			ref float x2 = ref startPos.x;
			(float, float) tuple = change.RemapChordPosition(range.x, startPos.x);
			x = tuple.Item1;
			x2 = tuple.Item2;
			ref float y = ref range.y;
			x2 = ref startPos.y;
			tuple = change.RemapChordPosition(range.y, startPos.y);
			y = tuple.Item1;
			x2 = tuple.Item2;
			Range = range;
			StartPos = startPos;
		}

		public override void HandleSliceChange(in WingSliceChange change)
		{
			float2 startPos = StartPos;
			startPos.x = change.RemapChord(Range.x, startPos.x);
			startPos.y = change.RemapChord(Range.y, startPos.y);
			StartPos = startPos;
		}

		public override void Init(XElement xml)
		{
			base.Init(xml);
			float2? float5 = xml.Float2Attribute("startPos");
			if (!float5.HasValue)
			{
				throw new ArgumentException($"startpos attribute missing: {xml}");
			}
			StartPos = float5.Value;
		}

		public override void ResetShape()
		{
			base.ResetShape();
			StartPos = DefaultStartPos;
		}

		public override void SaveToXml(XElement xml)
		{
			base.SaveToXml(xml);
			xml.SetAttribute("startPos", StartPos);
		}

		public override bool TryChangeRange(float newPos, bool isRootSide, WingSurfaceClaims claims)
		{
			int num = ((!isRootSide) ? 1 : 0);
			float2 startPos = StartPos;
			float2 range = Range;
			float2 insertingRange = range;
			insertingRange[num] = newPos;
			float2? freeEdgeSpanRange = claims.GetFreeEdgeSpanRange(0.5f * (insertingRange.x + insertingRange.y), IsLeadingEdge, searchToRoot: false, EdgeClaim);
			if (freeEdgeSpanRange.HasValue)
			{
				float2 valueOrDefault = freeEdgeSpanRange.GetValueOrDefault();
				insertingRange = Claim.ClipRange(insertingRange, valueOrDefault);
				if (math.all(insertingRange == range))
				{
					return true;
				}
				float2 newStartPos = startPos;
				newStartPos[num] = math.remap(range.x, range.y, startPos.x, startPos.y, insertingRange[num]);
				Range = insertingRange;
				if (TrySetStartPos(claims, newStartPos, num))
				{
					return true;
				}
				Range = range;
				StartPos = startPos;
				return false;
			}
			return false;
		}

		public override bool TryPlaceOnWing(WingSurfaceClaims claims, float placePosition, float2 originalScale, float2 originalOffset)
		{
			float2? freeEdgeSpanRange = claims.GetFreeEdgeSpanRange(placePosition, IsLeadingEdge, searchToRoot: false, EdgeClaim);
			if (freeEdgeSpanRange.HasValue)
			{
				float2 valueOrDefault = freeEdgeSpanRange.GetValueOrDefault();
				float2 range = Claim.PlaceInRange(Range.y - Range.x, placePosition, valueOrDefault);
				float2 range2 = Range;
				Range = range;
				float2 float5 = (StartPos - originalOffset) / originalScale;
				(float Offset, float Scale) interpolatedSlice = WingBuilder.GetInterpolatedSlice(Range.x, claims.Slices);
				(float, float) interpolatedSlice2 = WingBuilder.GetInterpolatedSlice(Range.y, claims.Slices);
				float2 float6 = math.float2(interpolatedSlice.Offset, interpolatedSlice2.Item1);
				float2 float7 = math.float2(interpolatedSlice.Scale, interpolatedSlice2.Item2);
				float2 newStartPos = float6 + float5 * float7;
				if (TrySetStartPos(claims, newStartPos, 0.5f))
				{
					return true;
				}
				Range = range2;
				return false;
			}
			return false;
		}

		public bool TrySetStartPos(WingSurfaceClaims claims, float2 newStartPos, float enforceAtPos)
		{
			float2? float5 = claims.TryEnforceChordSizeRange(EdgeClaim, newStartPos, MinMaxChordSize, enforceAtPos, IsLeadingEdge);
			if (float5.HasValue)
			{
				StartPos = float5.Value;
				return true;
			}
			return false;
		}

		public override string Validate(WingSlice[] slices)
		{
			string text = base.Validate(slices);
			if (text != null)
			{
				return text;
			}
			bool flag = false;
			for (int i = 0; i < slices.Length; i++)
			{
				WingSlice wingSlice = slices[i];
				if ((wingSlice.ControlSurfaceMask & (1 << (int)base.SurfaceId)) == 0L)
				{
					if (!flag)
					{
						continue;
					}
					flag = false;
				}
				else
				{
					flag = true;
				}
				float pos = math.remap(Range.x, Range.y, StartPos.x, StartPos.y, wingSlice.SpanPosition);
				float num = wingSlice.MeshToSliceChord(pos);
				float num2 = (IsLeadingEdge ? (0.5f - num) : (0.5f + num));
				if (num2 <= 2.3841858E-07f)
				{
					return $"Control surface too small at slice {i}";
				}
				if (num2 >= 0.99999976f)
				{
					return $"Control surface too big at slice {i}";
				}
			}
			return null;
		}

		protected void UpdateClaim()
		{
			if (IsLeadingEdge)
			{
				EdgeClaim.SetLeadingEdge(Range, StartPos);
			}
			else
			{
				EdgeClaim.SetTrailingEdge(Range, StartPos);
			}
		}
	}
}
