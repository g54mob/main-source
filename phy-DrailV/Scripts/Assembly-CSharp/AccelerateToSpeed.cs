using UnityEngine;

[DisallowMultipleComponent]
public class AccelerateToSpeed : MonoBehaviour
{
	public bool directionToggle;

	public bool disableOnReachTarget;

	public float force = 100000f;

	public float targetSpeedKMH = 40f;

	public float waitBeforeStartSeconds;

	private TrainCar train;

	private void Awake()
	{
		if (Time.timeSinceLevelLoad > 1f)
		{
			base.enabled = false;
		}
		train = GetComponent<TrainCar>();
		train.OnDerailed += delegate
		{
			base.enabled = false;
		};
	}

	private void FixedUpdate()
	{
		bool flag = Time.timeSinceLevelLoad > waitBeforeStartSeconds;
		bool flag2 = train.GetAbsSpeed() * 3.6f >= targetSpeedKMH;
		if (flag2 && disableOnReachTarget)
		{
			base.enabled = false;
		}
		else if (!(!flag || flag2))
		{
			float inputForce = (float)((!directionToggle) ? 1 : (-1)) * force;
			Bogie[] bogies = train.Bogies;
			for (int i = 0; i < bogies.Length; i++)
			{
				bogies[i].ApplyForce(inputForce);
			}
		}
	}
}
