using Dreamteck.Splines;
using UnityEngine;

public class TrailerSplineController : MonoBehaviour
{
	public AnimationCurve speedCurve;

	private SplineFollower follower;

	public float defaultSpeed;

	public float speedCurveTotalTime;

	private float timer;

	private void Start()
	{
		follower = GetComponent<SplineFollower>();
	}

	private void Update()
	{
		timer += Time.deltaTime;
		follower.followSpeed = defaultSpeed * speedCurve.Evaluate((float)follower.result.percent);
		Debug.Log(speedCurve.Evaluate((float)follower.result.percent));
	}
}
