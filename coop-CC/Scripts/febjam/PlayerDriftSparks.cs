using Aggro.Core;
using UnityEngine;

public class PlayerDriftSparks : EntityBehaviourBase
{
	private float tick;

	public float tickTime = 0.25f;

	public float scale = 0.25f;

	public float scaleOffset = 0.25f;

	protected override void OnUpdatePresentation()
	{
		tick -= Time.deltaTime;
		if (tick <= 0f)
		{
			base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, Random.value * 360f);
			float value = Random.value;
			float num = 1f - scale;
			base.transform.localScale = new Vector3(1f + value * scaleOffset, 1f + num * scaleOffset, 1f + value * scaleOffset) * scale;
			tick = tickTime;
		}
	}
}
