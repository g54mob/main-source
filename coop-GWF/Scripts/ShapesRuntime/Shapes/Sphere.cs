using UnityEngine;

namespace Shapes
{
	[ExecuteAlways]
	[AddComponentMenu("Shapes/Sphere")]
	public class Sphere : ShapeRenderer
	{
		[SerializeField]
		private float radius = 1f;

		[SerializeField]
		private ThicknessSpace radiusSpace;

		public float Radius
		{
			get
			{
				return radius;
			}
			set
			{
				SetFloatNow(ShapesMaterialUtils.propRadius, radius = Mathf.Max(0f, value));
			}
		}

		public ThicknessSpace RadiusSpace
		{
			get
			{
				return radiusSpace;
			}
			set
			{
				SetIntNow(ShapesMaterialUtils.propRadiusSpace, (int)(radiusSpace = value));
			}
		}

		internal override bool HasDetailLevels => true;

		internal override bool HasScaleModes => false;

		private protected override void SetAllMaterialProperties()
		{
			SetFloat(ShapesMaterialUtils.propRadius, radius);
			SetInt(ShapesMaterialUtils.propRadiusSpace, (int)radiusSpace);
		}

		private protected override void ShapeClampRanges()
		{
			radius = Mathf.Max(0f, radius);
		}

		private protected override void GetMaterials(Material[] mats)
		{
			mats[0] = ShapesMaterialUtils.matSphere[base.BlendMode];
		}

		private protected override Mesh GetInitialMeshAsset()
		{
			return ShapesMeshUtils.SphereMesh[(int)detailLevel];
		}

		private protected override Bounds GetUnpaddedLocalBounds_Internal()
		{
			float num = ((radiusSpace == ThicknessSpace.Meters) ? (2f * radius) : 0f);
			return new Bounds(Vector3.zero, new Vector3(num, num, num));
		}
	}
}
