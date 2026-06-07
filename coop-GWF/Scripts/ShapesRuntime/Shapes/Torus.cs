using System;
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

		[SerializeField]
		private AngularUnit angUnitInput = AngularUnit.Degrees;

		[SerializeField]
		private float angRadiansStart;

		[SerializeField]
		private float angRadiansEnd = MathF.PI * 2f;

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

		public float AngRadiansStart
		{
			get
			{
				return angRadiansStart;
			}
			set
			{
				SetFloatNow(ShapesMaterialUtils.propAngStart, angRadiansStart = value);
			}
		}

		public float AngRadiansEnd
		{
			get
			{
				return angRadiansEnd;
			}
			set
			{
				SetFloatNow(ShapesMaterialUtils.propAngEnd, angRadiansEnd = value);
			}
		}

		internal override bool HasDetailLevels => true;

		private protected override void SetAllMaterialProperties()
		{
			SetFloat(ShapesMaterialUtils.propRadius, radius);
			SetFloat(ShapesMaterialUtils.propThickness, thickness);
			SetInt(ShapesMaterialUtils.propThicknessSpace, (int)thicknessSpace);
			SetInt(ShapesMaterialUtils.propRadiusSpace, (int)radiusSpace);
			SetFloat(ShapesMaterialUtils.propAngStart, angRadiansStart);
			SetFloat(ShapesMaterialUtils.propAngEnd, angRadiansEnd);
		}

		private protected override void ShapeClampRanges()
		{
			radius = Mathf.Max(0f, radius);
			thickness = Mathf.Max(0f, thickness);
		}

		private protected override void GetMaterials(Material[] mats)
		{
			mats[0] = ShapesMaterialUtils.matTorus[base.BlendMode];
		}

		private protected override Mesh GetInitialMeshAsset()
		{
			return ShapesMeshUtils.TorusMesh[(int)detailLevel];
		}

		private protected override Bounds GetUnpaddedLocalBounds_Internal()
		{
			float num = ((radiusSpace == ThicknessSpace.Meters) ? (radius * 2f) : 0f);
			float num2 = ((thicknessSpace == ThicknessSpace.Meters) ? thickness : 0f);
			num += num2;
			return new Bounds(Vector3.zero, new Vector3(num, num, num2));
		}
	}
}
