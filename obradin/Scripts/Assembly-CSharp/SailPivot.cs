using UnityEngine;

public class SailPivot : MonoBehaviour
{
	private Quaternion baseRot;

	private bool forBow;

	public bool applyRandomStartInMoment = true;

	private void Start()
	{
		baseRot = base.transform.rotation;
		forBow = base.name.ToLower().IndexOf("bow") >= 0;
	}

	private void Update()
	{
		ApplyRotation(Clock.play.time);
	}

	private void ApplyRotation(float time)
	{
		Vector3 zero = Vector3.zero;
		if (forBow)
		{
			zero.x = 5f * Mathf.Sin(time * 0.3f);
		}
		zero.y = 5f * Mathf.Cos((time * 0.5f + 0.5f * base.transform.position.y) * Util.LerpScale(base.transform.position.y, 10f, 40f, 0.5f, 1f));
		base.transform.rotation = baseRot * Quaternion.Euler(zero);
	}
}
