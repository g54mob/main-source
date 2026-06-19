using System.Collections.Generic;
using UnityEngine;

public class TransformSnapper : MonoBehaviour
{
	public Animator animator;

	public List<Transform> snapTargets;

	public float angleStep = 5f;

	private void LateUpdate()
	{
		if (animator != null)
		{
			AnimatorStateInfo currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
			if ((!currentAnimatorStateInfo.loop && currentAnimatorStateInfo.normalizedTime >= 1f) || currentAnimatorStateInfo.length == 0f)
			{
				return;
			}
		}
		float num = 16f;
		foreach (Transform snapTarget in snapTargets)
		{
			if ((bool)snapTarget)
			{
				Vector3 position = snapTarget.position;
				position.x = Mathf.Round(position.x * num) / num;
				position.y = Mathf.Round(position.y * num) / num;
				position.z = Mathf.Round(position.z * num) / num;
				snapTarget.position = position;
				Vector3 eulerAngles = snapTarget.eulerAngles;
				eulerAngles.x = Mathf.Round(eulerAngles.x / angleStep) * angleStep;
				eulerAngles.y = Mathf.Round(eulerAngles.y / angleStep) * angleStep;
				eulerAngles.z = Mathf.Round(eulerAngles.z / angleStep) * angleStep;
				snapTarget.eulerAngles = eulerAngles;
			}
		}
	}
}
