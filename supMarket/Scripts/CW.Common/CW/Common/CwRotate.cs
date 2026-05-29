using UnityEngine;

namespace CW.Common
{
	[HelpURL("https://carloswilkes.com/Documentation/Common#CwRotate")]
	[AddComponentMenu("Common/CW Rotate")]
	public class CwRotate : MonoBehaviour
	{
		[SerializeField]
		private Vector3 angularVelocity;

		[SerializeField]
		private Space relativeTo;

		public Vector3 AngularVelocity
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Space RelativeTo
		{
			get
			{
				return default(Space);
			}
			set
			{
			}
		}

		protected virtual void Update()
		{
		}
	}
}
