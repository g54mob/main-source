using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.Helpers
{
	public class KeepRotation : MonoBehaviour
	{
		public Quaternion Rotation;

		public void Awake()
		{
			Rotation = base.transform.rotation;
		}

		public void LateUpdate()
		{
			base.transform.rotation = Rotation;
		}
	}
}
