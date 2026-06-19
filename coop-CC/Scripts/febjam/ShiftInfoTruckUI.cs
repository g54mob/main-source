using System.Collections;
using Aggro.Core;
using UnityEngine;

public class ShiftInfoTruckUI : EntityBehaviourBase
{
	public Transform container;

	public GameObject checkMark;

	public GameObject xMark;

	public AnimationCurve curve;

	public float animationTime = 0.5f;

	public IEnumerator BlorbleCo()
	{
		float time = 0f;
		base.transform.localScale = Vector3.one * curve.Evaluate(0f);
		while (time < animationTime)
		{
			time += Time.deltaTime;
			float time2 = time / animationTime;
			base.transform.localScale = Vector3.one * curve.Evaluate(time2);
			yield return null;
		}
		base.transform.localScale = Vector3.one * curve.Evaluate(1f);
	}
}
