using UnityEngine;

public class NpcHeadIk : MonoBehaviour
{
	public Animator animator;

	public Transform headIkTarget;

	public bool ikActive;

	public float ikWeight;

	public float ikSpeed = 5f;

	public Vector3 lastTargetPos;

	private void Start()
	{
		animator = GetComponent<Animator>();
	}

	private void Update()
	{
	}

	public void OnAnimatorIK()
	{
		if ((bool)animator)
		{
			float target = ((ikActive && headIkTarget != null) ? 1f : 0f);
			ikWeight = Mathf.MoveTowards(ikWeight, target, Time.deltaTime * ikSpeed);
			animator.SetLookAtWeight(ikWeight, 0.3f, 0.8f, 1f, 0.8f);
			if (ikActive && headIkTarget != null)
			{
				lastTargetPos = headIkTarget.position;
				animator.SetLookAtPosition(lastTargetPos);
			}
			else if (ikWeight > 0f)
			{
				animator.SetLookAtPosition(lastTargetPos);
			}
		}
	}

	public void GiveRocketBack()
	{
		GameManager.S.HandoverRocket();
	}
}
