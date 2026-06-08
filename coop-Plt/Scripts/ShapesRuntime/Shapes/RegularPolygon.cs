using System;
using UnityEngine;

namespace Shapes
{
	[ExecuteInEditMode]
	[AddComponentMenu("Shapes/RegularPolygon")]
	public class RegularPolygon : ShapeRendererFillable
	{
		[SerializeField]
		private bool hollow;

		[SerializeField]
		private int sides = 3;

		[SerializeField]
		[Range(0f, 1f)]
		private float roundness;

		[SerializeField]
		private float angle = (float)Math.PI / 2f;

		[SerializeField]
		private float radius = 1f;

		[SerializeField]
		private AngularUnit angUnitInput = AngularUnit.Degrees;

		[SerializeField]
		private RegularPolygonGeometry geometry;

		[SerializeField]
		private ThicknessSpace radiusSpace;

		[SerializeField]
		private float thickness = 0.5f;

		[SerializeField]
		private ThicknessSpace thicknessSpace;

		public bool Hollow
		{
			get
			{
				return hollow;
			}
			set
			{
				SetIntNow(ShapesMaterialUtils.propHollow, (hollow = value).AsInt());
			}
		}

		public int Sides
		{
			get
			{
				return sides;
			}
			set
			{
				SetIntNow(ShapesMaterialUtils.propSides, sides = Mathf.Max(3, value));
			}
		}

		public float Roundness
		{
			get
			{
				return roundness;
			}
			set
			{
				SetFloatNow(ShapesMaterialUtils.propRoundness, roundness = Mathf.Clamp01(value));
			}
		}

		public float Angle
		{
			get
			{
				return angle;
			}
			set
			{
				SetFloatNow(ShapesMaterialUtils.propAng, angle = value);
			}
		}

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

		public RegularPolygonGeometry Geometry
		{
			get
			{
				return geometry;
			}
			set
			{
				SetIntNow(ShapesMaterialUtils.propAlignment, (int)(geometry = value));
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

		public override bool HasDetailLevels => false;

		protected override void SetAllMaterialProperties()
		{
			SetFillProperties();
			SetIntNow(ShapesMaterialUtils.propHollow, hollow.AsInt());
			SetInt(ShapesMaterialUtils.propAlignment, (int)geometry);
			SetFloat(ShapesMaterialUtils.propRadius, radius);
			SetInt(ShapesMaterialUtils.propRadiusSpace, (int)radiusSpace);
			SetFloat(ShapesMaterialUtils.propThickness, thickness);
			SetInt(ShapesMaterialUtils.propThicknessSpace, (int)thicknessSpace);
			SetFloat(ShapesMaterialUtils.propAng, angle);
			SetFloat(ShapesMaterialUtils.propSides, sides);
			SetFloat(ShapesMaterialUtils.propRoundness, roundness);
		}

		protected override Material[] GetMaterials()
		{
			return new Material[1] { ShapesMaterialUtils.matRegularPolygon[base.BlendMode] };
		}

		protected override Bounds GetBounds()
		{
			if (radiusSpace != ThicknessSpace.Meters)
			{
				return new Bounds(Vector3.zero, Vector3.one);
			}
			float num = ((thicknessSpace == ThicknessSpace.Meters) ? (thickness * 0.5f) : 0f);
			float num2 = (hollow ? (radius + num) : radius) * 2f;
			return new Bounds(Vector3.zero, new Vector3(num2, num2, 0f));
		}
	}
}
