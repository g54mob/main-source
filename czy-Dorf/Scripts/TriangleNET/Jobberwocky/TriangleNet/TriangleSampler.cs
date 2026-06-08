using System;
using System.Collections;
using System.Collections.Generic;
using Jobberwocky.TriangleNet.Topology;

namespace Jobberwocky.TriangleNet
{
	internal class TriangleSampler : IEnumerable<Triangle>, IEnumerable
	{
		private Random random;

		private Mesh mesh;

		private int samples = 1;

		private int triangleCount = 0;

		public TriangleSampler(Mesh mesh)
			: this(mesh, new Random(110503))
		{
		}

		public TriangleSampler(Mesh mesh, Random random)
		{
			this.mesh = mesh;
			this.random = random;
		}

		public void Update()
		{
			int count = mesh.triangles.Count;
			if (triangleCount != count)
			{
				triangleCount = count;
				while (11 * samples * samples * samples < count)
				{
					samples++;
				}
			}
		}

		public IEnumerator<Triangle> GetEnumerator()
		{
			return mesh.triangles.Sample(samples, random).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
