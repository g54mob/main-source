using System;
using UnityEngine;

namespace Shapes
{
	[ExecuteAlways]
	[AddComponentMenu("Shapes/Cone")]
	public class Cone : ShapeRenderer
	{
		[SerializeField]
		private float radius = 1f;

		[SerializeField]
		private float length = 1.5f;

		[SerializeField]
		private ThicknessSpace sizeSpace;

		[SerializeField]
		private bool fillCap = true;

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

		public float Length
		{
			get
			{
				return length;
			}
			set
			{
				SetFloatNow(ShapesMaterialUtils.propLength, length = Mathf.Max(0f, value));
			}
		}

		[Obsolete("this property is obsolete I'm sorry! this was a typo, please use SizeSpace instead!", true)]
		public ThicknessSpace RadiusSpace
		{
			get
			{
				return SizeSpace;
			}
			set
			{
				SizeSpace = value;
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

		public bool FillCap
		{
			get
			{
				return fillCap;
			}
			set
			{
				fillCap = value;
				UpdateMesh(force: true);
			}
		}

		internal override bool HasDetailLevels => true;

		internal override bool HasScaleModes => false;

		private protected override void SetAllMaterialProperties()
		{
			SetFloat(ShapesMaterialUtils.propRadius, radius);
			SetFloat(ShapesMaterialUtils.propLength, length);
			SetInt(ShapesMaterialUtils.propSizeSpace, (int)sizeSpace);
		}

		private protected override void ShapeClampRanges()
		{
			radius = Mathf.Max(0f, radius);
			length = Mathf.Max(0f, length);
		}

		private protected override Material[] GetMaterials()
		{
			return new Material[1] { ShapesMaterialUtils.matCone[base.BlendMode] };
		}

		private protected override Mesh GetInitialMeshAsset()
		{
			if (!fillCap)
			{
				return ShapesMeshUtils.ConeMeshUncapped[(int)detailLevel];
			}
			return ShapesMeshUtils.ConeMesh[(int)detailLevel];
		}

		private protected override Bounds GetBounds_Internal()
		{
			if (sizeSpace != ThicknessSpace.Meters)
			{
				return new Bounds(Vector3.zero, Vector3.one);
			}
			return new Bounds(Vector3.zero, new Vector3(radius * 2f, radius * 2f, length));
		}
	}
}
