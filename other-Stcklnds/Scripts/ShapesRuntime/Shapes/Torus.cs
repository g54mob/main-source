using UnityEngine;

namespace Shapes
{
	[ExecuteAlways]
	[AddComponentMenu("Shapes/Torus")]
	public class Torus : ShapeRenderer
	{
		[SerializeField]
		private float radius = 1f;

		[SerializeField]
		private float thickness = 0.5f;

		[SerializeField]
		private ThicknessSpace thicknessSpace;

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

		public float Thickness
		{
			get
			{
				return thickness;
			}
			set
			{
				SetFloatNow(ShapesMaterialUtils.propThickness, thickness = Mathf.Max(0f, value));
			}
		}

		public ThicknessSpace ThicknessSpace
		{
			get
			{
				return thicknessSpace;
			}
			set
			{
				SetIntNow(ShapesMaterialUtils.propThicknessSpace, (int)(thicknessSpace = value));
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
				SetIntNow(ShapesMaterialUtils.propThicknessSpace, (int)(radiusSpace = value));
			}
		}

		internal override bool HasDetailLevels => true;

		private protected override void SetAllMaterialProperties()
		{
			SetFloat(ShapesMaterialUtils.propRadius, radius);
			SetFloat(ShapesMaterialUtils.propThickness, thickness);
			SetInt(ShapesMaterialUtils.propThicknessSpace, (int)thicknessSpace);
			SetInt(ShapesMaterialUtils.propRadiusSpace, (int)radiusSpace);
		}

		private protected override void ShapeClampRanges()
		{
			radius = Mathf.Max(0f, radius);
			thickness = Mathf.Max(0f, thickness);
		}

		private protected override Material[] GetMaterials()
		{
			return new Material[1] { ShapesMaterialUtils.matTorus[base.BlendMode] };
		}

		private protected override Mesh GetInitialMeshAsset()
		{
			return ShapesMeshUtils.TorusMesh[(int)detailLevel];
		}

		private protected override Bounds GetBounds_Internal()
		{
			if (radiusSpace != ThicknessSpace.Meters)
			{
				return new Bounds(default(Vector3), Vector3.one);
			}
			float num = ((thicknessSpace == ThicknessSpace.Meters) ? thickness : 0f);
			float num2 = radius * 2f + num;
			return new Bounds(Vector3.zero, new Vector3(num2, num2, num));
		}
	}
}
