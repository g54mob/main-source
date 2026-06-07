using System;
using Assets.Scripts.Craft.MeshGen;
using Unity.Collections;

namespace Assets.Scripts.Craft.Wings
{
	public struct SectionPatch : IDisposable
	{
		public bool Valid;

		public CrossSection CrossSection;

		public LoopCutout Cutout;

		public NativeList<Point> Patch;

		private int _cutOutLength;

		private int _cutOutStart;

		public SectionPatch(CrossSection source, float start, float end, SurfaceLocation location, Allocator allocator = Allocator.TempJob)
		{
			CrossSection = source;
			Patch = new NativeList<Point>(8, allocator);
			if (!source.GetCutoutRange(start, end, location, out var startIndex, out var endIndex))
			{
				Valid = false;
				Cutout = default(LoopCutout);
				CrossSection = source;
				_cutOutLength = 0;
				_cutOutStart = 0;
				return;
			}
			Valid = true;
			Point startPoint = source.InterpolatePoint(startIndex, start);
			Point endPoint = source.InterpolatePoint(endIndex, end);
			Cutout = new LoopCutout(source.Points.AsArray(), startPoint, endPoint, startIndex, endIndex);
			_cutOutStart = startIndex;
			if (endIndex > startIndex)
			{
				int cutOutLength = endIndex - startIndex;
				_cutOutLength = cutOutLength;
			}
			else
			{
				int cutOutLength2 = endIndex - startIndex + source.Points.Length;
				_cutOutLength = cutOutLength2;
			}
		}

		public void ApplyAndDispose()
		{
			NativeList<Point> points = CrossSection.Points;
			int num = _cutOutStart + _cutOutLength;
			if (num > CrossSection.Points.Length)
			{
				int count = num - points.Length;
				points.Length = _cutOutStart;
				points.RemoveRange(0, count);
				points.AddRange(Patch.AsArray());
			}
			else
			{
				points.ReplaceRange(_cutOutStart, _cutOutLength, Patch.AsArray());
			}
			Dispose();
		}

		public void Dispose()
		{
			Extensions.DisposeIfCreated(ref Patch);
		}
	}
}
