using System;
using System.Collections.Generic;
using Jobberwocky.TriangleNet.Topology;

namespace Jobberwocky.TriangleNet.Meshing.Iterators
{
	public class RegionIterator
	{
		private sealed class _003C_003Ec__DisplayClass2_0
		{
			public Triangle triangle;

			internal void _003CProcess_003Eb__0(Triangle tri)
			{
				tri.label = triangle.label;
				tri.area = triangle.area;
			}
		}

		private sealed class _003C_003Ec__DisplayClass3_0
		{
			public int boundary;

			internal bool _003CProcess_003Eb__1(SubSegment seg)
			{
				return seg.boundary != boundary;
			}
		}

		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Func<SubSegment, bool> _003C_003E9__3_0;

			internal bool _003CProcess_003Eb__3_0(SubSegment seg)
			{
				return seg.hash == -1;
			}
		}

		private List<Triangle> region;

		public RegionIterator(Mesh mesh)
		{
			region = new List<Triangle>();
		}

		public void Process(Triangle triangle, int boundary = 0)
		{
			_003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass2_0();
			CS_0024_003C_003E8__locals4.triangle = triangle;
			Process(CS_0024_003C_003E8__locals4.triangle, delegate(Triangle tri)
			{
				tri.label = CS_0024_003C_003E8__locals4.triangle.label;
				tri.area = CS_0024_003C_003E8__locals4.triangle.area;
			}, boundary);
		}

		public void Process(Triangle triangle, Action<Triangle> action, int boundary = 0)
		{
			_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass3_0();
			CS_0024_003C_003E8__locals3.boundary = boundary;
			if (triangle.id == -1 || Otri.IsDead(triangle))
			{
				return;
			}
			region.Add(triangle);
			triangle.infected = true;
			if (CS_0024_003C_003E8__locals3.boundary == 0)
			{
				ProcessRegion(action, (SubSegment seg) => seg.hash == -1);
			}
			else
			{
				ProcessRegion(action, (SubSegment seg) => seg.boundary != CS_0024_003C_003E8__locals3.boundary);
			}
			region.Clear();
		}

		private void ProcessRegion(Action<Triangle> action, Func<SubSegment, bool> protector)
		{
			Otri otri = default(Otri);
			Otri ot = default(Otri);
			Osub os = default(Osub);
			for (int i = 0; i < region.Count; i++)
			{
				otri.tri = region[i];
				action(otri.tri);
				otri.orient = 0;
				while (otri.orient < 3)
				{
					otri.Sym(ref ot);
					otri.Pivot(ref os);
					if (ot.tri.id != -1 && !ot.IsInfected() && protector(os.seg))
					{
						ot.Infect();
						region.Add(ot.tri);
					}
					otri.orient++;
				}
			}
			foreach (Triangle item in region)
			{
				item.infected = false;
			}
			region.Clear();
		}
	}
}
