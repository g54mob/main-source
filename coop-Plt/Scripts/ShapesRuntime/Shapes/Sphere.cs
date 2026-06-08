using UnityEngine;

namespace Shapes
{
	[ExecuteInEditMode]
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

		public override bool HasDetailLevels => true;

		public override bool HasScaleModes => false;

		protected override void SetAllMaterialProperties()
		{
			SetFloat(ShapesMaterialUtils.propRadius, radius);
			SetInt(ShapesMaterialUtils.propRadiusSpace, (int)radiusSpace);
		}

		protected override void ShapeClampRanges()
		{
			radius = Mathf.Max(0f, radius);
		}

		protected override Material[] GetMaterials()
		{
			return new Material[1] { ShapesMaterialUtils.matSphere[base.BlendMode] };
		}

		protected override Mesh GetInitialMeshAsset()
		{
			return ShapesMeshUtils.SphereMesh[(int)detailLevel];
		}

		protected override Bounds GetBounds()
		{
			if (radiusSpace != ThicknessSpace.Meters)
			{
				return new Bounds(Vector3.zero, Vector3.one);
			}
			return new Bounds(Vector3.zero, Vector3.one * (radius * 2f));
		}
	}
}
