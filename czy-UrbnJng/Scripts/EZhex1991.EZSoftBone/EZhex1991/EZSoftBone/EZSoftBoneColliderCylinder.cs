using UnityEngine;

namespace EZhex1991.EZSoftBone
{
	public class EZSoftBoneColliderCylinder : EZSoftBoneColliderBase
	{
		[SerializeField]
		private float m_Margin;

		[SerializeField]
		private bool m_InsideMode;

		public float margin
		{
			get
			{
				return m_Margin;
			}
			set
			{
				m_Margin = value;
			}
		}

		public bool insideMode
		{
			get
			{
				return m_InsideMode;
			}
			set
			{
				m_InsideMode = value;
			}
		}

		public override void Collide(ref Vector3 position, float spacing)
		{
			if (insideMode)
			{
				EZSoftBoneUtility.PointInsideCylinder(ref position, base.transform, spacing + margin);
			}
			else
			{
				EZSoftBoneUtility.PointOutsideCylinder(ref position, base.transform, spacing + margin);
			}
		}
	}
}
