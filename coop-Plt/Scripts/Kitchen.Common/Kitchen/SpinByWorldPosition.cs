using UnityEngine;

namespace Kitchen
{
	public class SpinByWorldPosition : Spin
	{
		public float MaxDistancePerSecond = 0.1f;

		public float GrowRate = 0.1f;

		public float DecayRate = 0.05f;

		private Vector3 LastUpdatePosition;

		private float Speed;

		protected override void Update()
		{
			Vector3 vector = base.transform.position - LastUpdatePosition;
			LastUpdatePosition = base.transform.position;
			if (vector.sqrMagnitude > MaxDistancePerSecond * Time.deltaTime)
			{
				Speed += GrowRate * Time.deltaTime;
			}
			else
			{
				Speed -= DecayRate * Time.deltaTime;
			}
			Speed = Mathf.Clamp(Speed, 0f, 2f);
			float spinRate = SpinRate;
			SpinRate *= Speed;
			base.Update();
			SpinRate = spinRate;
		}
	}
}
