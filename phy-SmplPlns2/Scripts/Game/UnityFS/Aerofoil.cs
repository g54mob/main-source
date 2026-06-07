using UnityEngine;

namespace UnityFS
{
	[AddComponentMenu("UnityFS/Dynamics/Aerofoil")]
	public class Aerofoil : MonoBehaviour
	{
		public AnimationCurve CD;

		public AnimationCurve CL;

		public AnimationCurve CM;
	}
}
