using UnityEngine;

public class LerpMove : MonoBehaviour
{
	public Vector3[] Positions;

	public Vector3[] Rotations;

	public float[] Far;

	public float[] Times;

	public AnimationCurve AC;

	public float next;

	public int index;

	private void Start()
	{
		base.transform.SetPositionAndRotation(Positions[index], Quaternion.Euler(Rotations[index]));
		GetComponent<Camera>().farClipPlane = Far[index];
		next = Times[index];
		index = 0;
	}

	private void Update()
	{
		if (index != Positions.Length - 1)
		{
			float t = AC.Evaluate(1f - next / Times[index]);
			base.transform.SetPositionAndRotation(Vector3.Lerp(Positions[index], Positions[index + 1], t), Quaternion.Lerp(Quaternion.Euler(Rotations[index]), Quaternion.Euler(Rotations[index + 1]), t));
			GetComponent<Camera>().farClipPlane = Mathf.Lerp(Far[index], Far[index + 1], t);
			next -= Time.deltaTime;
			if (next <= 0f)
			{
				index++;
				base.transform.SetPositionAndRotation(Positions[index], Quaternion.Euler(Rotations[index]));
				GetComponent<Camera>().farClipPlane = Far[index];
				next = Times[index];
			}
		}
	}
}
