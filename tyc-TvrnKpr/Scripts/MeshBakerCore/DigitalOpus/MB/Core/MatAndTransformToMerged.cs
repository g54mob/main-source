using UnityEngine;

namespace DigitalOpus.MB.Core
{
	public class MatAndTransformToMerged
	{
		public Material mat;

		public string objName;

		public DRect obUVRectIfTilingSame { get; private set; }

		public DRect samplingRectMatAndUVTiling { get; private set; }

		public DRect materialTiling { get; private set; }

		public MatAndTransformToMerged(DRect obUVrect, bool fixOutOfBoundsUVs)
		{
		}

		public MatAndTransformToMerged(DRect obUVrect, bool fixOutOfBoundsUVs, Material m)
		{
		}

		private void _init(DRect obUVrect, bool fixOutOfBoundsUVs, Material m)
		{
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public string GetMaterialName()
		{
			return null;
		}

		public void AssignInitialValuesForMaterialTilingAndSamplingRectMatAndUVTiling(bool allTexturesUseSameMatTiling, DRect matTiling)
		{
		}
	}
}
