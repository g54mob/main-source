using UnityEngine;

public class MouthScript : MonoBehaviour
{
	public float Satisfaction;

	public float range = 0.3f;

	public bool talk;

	public bool MainMenu;

	private float TalkTime;

	public Transform[] Joints;

	private void Start()
	{
	}

	private void Update()
	{
		if (MainMenu)
		{
			Satisfaction = Mathf.Max(Satisfaction - Time.deltaTime / 120f, 0f);
		}
		float num = Satisfaction * 2f - 1f;
		SetJointY(Joints[0], num * range);
		SetJointY(Joints[1], num * range / 2f);
		SetJointY(Joints[Joints.Length - 2], num * range / 2f);
		SetJointY(Joints[Joints.Length - 1], num * range);
		if (talk)
		{
			float num2 = TalkTime;
			if (num2 > 1f)
			{
				num2 = 2f - num2;
			}
			Joints[2].localScale = new Vector3(1f, 1f + num2, 1f);
		}
		else
		{
			Joints[2].localScale = new Vector3(1f, 1f, 1f);
		}
		TalkTime = (TalkTime + Time.deltaTime * 6f) % 2f;
	}

	public void SetJointY(Transform joint, float y)
	{
		joint.localPosition = new Vector3(joint.localPosition.x, y, joint.localPosition.z);
	}
}
