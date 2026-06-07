using UnityEngine;

namespace MagicaCloth2
{
	[AddComponentMenu("MagicaCloth2/MagicaCapsuleCollider")]
	[HelpURL("https://magicasoft.jp/en/mc2_capsulecollidercomponent/")]
	public class MagicaCapsuleCollider : ColliderComponent
	{
		public enum Direction
		{
			[InspectorName("X-Axis")]
			X = 0,
			[InspectorName("Y-Axis")]
			Y = 1,
			[InspectorName("Z-Axis")]
			Z = 2
		}

		public Direction direction;

		public bool reverseDirection;

		public bool radiusSeparation;

		public bool alignedOnCenter;

		public override ColliderManager.ColliderType GetColliderType()
		{
			return default(ColliderManager.ColliderType);
		}

		public void SetSize(float startRadius, float endRadius, float length)
		{
		}

		public override Vector3 GetSize()
		{
			return default(Vector3);
		}

		public Vector3 GetLocalDir()
		{
			return default(Vector3);
		}

		public Vector3 GetLocalUp()
		{
			return default(Vector3);
		}

		public override bool IsReverseDirection()
		{
			return false;
		}

		public override void DataValidate()
		{
		}
	}
}
