using UnityEngine;

namespace Shapes
{
	[ExecuteAlways]
	[AddComponentMenu("Shapes/Cuboid")]
	public class Cuboid : ShapeRenderer
	{
		[SerializeField]
		private Vector3 size = Vector3.one;

		[SerializeField]
		private ThicknessSpace sizeSpace;

		public Vector3 Size
		{
			get
			{
				return size;
			}
			set
			{
				SetVector3Now(ShapesMaterialUtils.propSize, size = value);
			}
		}

		public ThicknessSpace SizeSpace
		{
			get
			{
				return sizeSpace;
			}
			set
			{
				SetIntNow(ShapesMaterialUtils.propSizeSpace, (int)(sizeSpace = value));
			}
		}

		internal override bool HasDetailLevels => false;

		internal override bool HasScaleModes => false;

		private protected override void SetAllMaterialProperties()
		{
			SetVector3(ShapesMaterialUtils.propSize, size);
			SetInt(ShapesMaterialUtils.propSizeSpace, (int)sizeSpace);
		}

		private protected override void ShapeClampRanges()
		{
			size = Vector3.Max(default(Vector3), size);
		}

		private protected override void GetMaterials(Material[] mats)
		{
			mats[0] = ShapesMaterialUtils.matCuboid[base.BlendMode];
		}

		private protected override Mesh GetInitialMeshAsset()
		{
			return ShapesMeshUtils.CuboidMesh[0];
		}

		private protected override Bounds GetUnpaddedLocalBounds_Internal()
		{
			if (sizeSpace != ThicknessSpace.Meters)
			{
				return new Bounds(default(Vector3), Vector3.zero);
			}
			return new Bounds(default(Vector3), size);
		}
	}
}
