using UnityEngine;

namespace Shapes
{
	[ExecuteInEditMode]
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

		public override bool HasDetailLevels => false;

		public override bool HasScaleModes => false;

		protected override void SetAllMaterialProperties()
		{
			SetVector3(ShapesMaterialUtils.propSize, size);
			SetInt(ShapesMaterialUtils.propSizeSpace, (int)sizeSpace);
		}

		protected override void ShapeClampRanges()
		{
			size = Vector3.Max(default(Vector3), size);
		}

		protected override Material[] GetMaterials()
		{
			return new Material[1] { ShapesMaterialUtils.matCuboid[base.BlendMode] };
		}

		protected override Mesh GetInitialMeshAsset()
		{
			return ShapesMeshUtils.CuboidMesh[0];
		}

		protected override Bounds GetBounds()
		{
			if (sizeSpace != ThicknessSpace.Meters)
			{
				return new Bounds(default(Vector3), Vector3.one);
			}
			return new Bounds(default(Vector3), size);
		}
	}
}
