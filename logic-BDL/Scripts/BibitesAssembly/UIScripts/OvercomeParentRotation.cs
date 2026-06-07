using UnityEngine;

namespace UIScripts
{
	public class OvercomeParentRotation : MonoBehaviour
	{
		public float targetAngle;

		private Transform parent;

		private void Awake()
		{
			parent = base.transform.parent;
			base.transform.rotation = Quaternion.Euler(0f, 0f, targetAngle - parent.rotation.eulerAngles.z);
		}

		private void Update()
		{
			base.transform.rotation = Quaternion.Euler(0f, 0f, targetAngle - parent.rotation.eulerAngles.z);
		}
	}
}
