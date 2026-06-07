using UnityEngine;

namespace OneUseScripts
{
	public class FixedLabel : MonoBehaviour
	{
		private Transform parent;

		private Vector3 initialPosition;

		private void Start()
		{
			parent = base.transform.parent;
			initialPosition = base.transform.localPosition;
		}

		private void Update()
		{
			Vector3 localScale = parent.localScale;
			base.transform.localScale = new Vector3(1f / localScale.x, 1f / localScale.y, 1f / localScale.z);
			base.transform.localPosition = Quaternion.Inverse(parent.rotation) * initialPosition;
			base.transform.localEulerAngles = -parent.localEulerAngles;
		}
	}
}
