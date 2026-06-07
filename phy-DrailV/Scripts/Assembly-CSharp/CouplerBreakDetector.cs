using System.Collections;
using UnityEngine;

public class CouplerBreakDetector : MonoBehaviour
{
	public delegate void CoupleBroken(Coupler brokenCoupler);

	public Coupler motherCoupler;

	public static event CoupleBroken OnCoupleBreak;

	private void OnJointBreak(float breakForce)
	{
		StartCoroutine(WaitFrame());
	}

	private IEnumerator WaitFrame()
	{
		yield return null;
		if (motherCoupler.IsCoupled() && motherCoupler.rigidCJ == null)
		{
			Debug.LogWarning("Broken coupler on " + base.name + " - " + motherCoupler.name, motherCoupler);
			Anal.CoupleBroken(motherCoupler);
			CouplerBreakDetector.OnCoupleBreak?.Invoke(motherCoupler);
			motherCoupler.Uncouple(playAudio: true, calledOnOtherCoupler: false, dueToBrokenCouple: true);
		}
	}
}
