using System.Collections;
using UnityEngine;

public class GuessButtonBar : MonoBehaviour
{
	public AnimationCurve growIncreaseCurve;

	public AnimationCurve growDecreaseCurve;

	public IEnumerator GrowIncreaseBar()
	{
		float growSeconds = 0f;
		while (base.transform.localScale.y < growIncreaseCurve[growIncreaseCurve.length - 1].value)
		{
			base.transform.localScale = new Vector3(base.transform.localScale.x, growIncreaseCurve.Evaluate(growSeconds), base.transform.localScale.z);
			growSeconds += Time.deltaTime;
			yield return null;
		}
	}

	public IEnumerator GrowDecreaseBar()
	{
		float growSeconds = 0f;
		while (base.transform.localScale.y > growDecreaseCurve[growDecreaseCurve.length - 1].value)
		{
			base.transform.localScale = new Vector3(base.transform.localScale.x, growDecreaseCurve.Evaluate(growSeconds), base.transform.localScale.z);
			growSeconds += Time.deltaTime;
			yield return null;
		}
	}
}
