using System.Collections;
using UnityEngine;

public class ObjectGrow : MonoBehaviour
{
	public AnimationCurve growCurve;

	public IEnumerator Grow()
	{
		float growSeconds = 0f;
		while (growSeconds < growCurve[growCurve.length - 1].time)
		{
			base.transform.localScale = new Vector3(growCurve.Evaluate(growSeconds), growCurve.Evaluate(growSeconds), base.transform.localScale.z);
			growSeconds += Time.deltaTime;
			yield return null;
		}
	}
}
