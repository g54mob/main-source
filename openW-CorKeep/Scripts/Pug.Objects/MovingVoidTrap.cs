using System.Collections;
using UnityEngine;

public class MovingVoidTrap : EntityMonoBehaviour
{
	public float duration = 2f;

	public bool scalingDone;

	public AnimationCurve scaleCurve = AnimationCurve.Linear(0f, 0f, 1f, 5f);

	private float elapsedTime;

	public override void OnOccupied()
	{
		StartCoroutine(DelayedSfx());
		base.OnOccupied();
		scalingDone = false;
		elapsedTime = 0f;
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (!scalingDone)
		{
			elapsedTime += Time.deltaTime;
			float time = Mathf.Clamp01(elapsedTime / duration);
			float num = scaleCurve.Evaluate(time);
			XScaler.localScale = Vector3.one * num;
			if (elapsedTime >= duration)
			{
				scalingDone = true;
			}
		}
	}

	private IEnumerator DelayedSfx()
	{
		yield return new WaitForSeconds(0f);
		AudioManager.SfxFollowTransform(SfxTableID.voidRift2Sfx, base.transform);
	}
}
