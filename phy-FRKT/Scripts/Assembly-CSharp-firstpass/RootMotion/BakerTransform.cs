using System;
using UnityEngine;

namespace RootMotion
{
	[Serializable]
	public class BakerTransform
	{
		public Transform transform;

		public AnimationCurve posX;

		public AnimationCurve posY;

		public AnimationCurve posZ;

		public AnimationCurve rotX;

		public AnimationCurve rotY;

		public AnimationCurve rotZ;

		public AnimationCurve rotW;

		private string tia;

		private bool tib;

		private Vector3 tic;

		private bool tid;

		private Quaternion tie;

		public BakerTransform(Transform transform, Transform root, bool recordPosition, bool isRootNode)
		{
		}

		public void jjt(Vector3 a, Quaternion b)
		{
		}

		public void jju(ref AnimationClip a, float b)
		{
		}

		private void jjv(ref AnimationClip a)
		{
		}

		public void jjw()
		{
		}

		public void jjx(float a)
		{
		}

		public void jjy(float a)
		{
		}

		public void jjz(float a)
		{
		}
	}
}
