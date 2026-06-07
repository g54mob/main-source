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

		private protected override Material[] GetMaterials()
		{
			return new Material[1] { ShapesMaterialUtils.matSphere[base.BlendMode] };
		}

		private protected override Mesh GetInitialMeshAsset()
		{
			return ShapesMeshUtils.SphereMesh[(int)detailLevel];
		}

		private protected override Bounds GetBounds_Internal()
		{
			if (radiusSpace != ThicknessSpace.Meters)
			{
				return new Bounds(Vector3.zero, Vector3.one);
			}
			return new Bounds(Vector3.zero, Vector3.one * (radius * 2f));
		}
	}
}
