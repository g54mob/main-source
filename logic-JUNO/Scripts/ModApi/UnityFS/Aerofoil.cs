using UnityEngine;

namespace UnityFS
{
	public class Aerofoil : MonoBehaviour
	{
		public AnimationCurve CD;

		public AnimationCurve CL;

		public AnimationCurve CM;

		public float ThicknessDelta = 0.1f;

		public float ThicknessOffset;

		public float LeadingBulge = 1f;
	}
}
