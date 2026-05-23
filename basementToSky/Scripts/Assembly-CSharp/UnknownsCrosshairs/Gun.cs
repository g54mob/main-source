using UnityEngine;

namespace UnknownsCrosshairs
{
	public class Gun : MonoBehaviour
	{
		public Crosshair crosshair;

		public float gunRecoil;

		public float settleSpeed;

		public float shotsPerSecond;

		private float shotRate;

		private float nextShotTime;

		private void Start()
		{
			crosshair.SetShrinkSpeed(settleSpeed);
			shotRate = 1f / shotsPerSecond;
		}

		private void Update()
		{
			if (Input.GetButton("Fire1"))
			{
				Shoot();
			}
		}

		private void Shoot()
		{
			if (nextShotTime < Time.time)
			{
				crosshair.Expand(gunRecoil);
				nextShotTime = Time.time + shotRate;
			}
		}
	}
}
