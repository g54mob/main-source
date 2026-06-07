using UnityEngine;

namespace Assets.Nimbatus.Scripts.Animations
{
	public class FixRotation : MonoBehaviour
	{
		private float _fixedAngle;

		private void Start()
		{
			_fixedAngle = base.transform.eulerAngles.z;
		}

		private void Update()
		{
			base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, base.transform.eulerAngles.y, _fixedAngle);
		}
	}
}
