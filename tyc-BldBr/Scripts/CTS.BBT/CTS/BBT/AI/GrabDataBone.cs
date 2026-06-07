using UnityEngine;

namespace CTS.BBT.AI
{
	public class GrabDataBone : GrabData
	{
		public EBone BoneTarget;

		public Vector3 PositionOffset;

		public Vector3 RotationOffset;

		public bool ElbowAnchor;

		public Vector3 ElbowPositionOffset;
	}
}
