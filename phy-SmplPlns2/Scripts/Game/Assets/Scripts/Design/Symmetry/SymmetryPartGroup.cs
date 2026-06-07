using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Jundroo.Common.Pool;

namespace Assets.Scripts.Design.Symmetry
{
	public class SymmetryPartGroup : IDisposable
	{
		public List<PartData> Parts { get; private set; }

		public float RadialAngle { get; }

		public SymmetryPartGroup(float radialAngle = 0f)
		{
			Parts = CollectionPool<List<PartData>, PartData>.Get();
			RadialAngle = radialAngle;
		}

		public void Dispose()
		{
			if (Parts != null)
			{
				CollectionPool<List<PartData>, PartData>.Release(Parts);
				Parts = null;
			}
		}
	}
}
