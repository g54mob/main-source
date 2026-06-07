using System.Collections;
using DV.ThingTypes;
using UnityEngine;

public class TenderCouplerJointEnstronger : MonoBehaviour
{
	private const float DISTANCE_BETWEEN_STEAM_LOCO_AND_TENDER = 0.8f;

	private Coupler rearCoupler;

	private Coroutine enstrongCoro;

	private void Start()
	{
		rearCoupler = base.transform.Find("[coupler rear]").GetComponent<Coupler>();
		if (!rearCoupler)
		{
			Debug.LogError("TenderCouplerJointEnstronger couldn't find Coupler component during init", this);
		}
		else
		{
			SetupListeners(on: true);
		}
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			rearCoupler.Coupled += OnCoupled;
			rearCoupler.Uncoupled += OnUncouple;
		}
		else
		{
			rearCoupler.Coupled -= OnCoupled;
			rearCoupler.Uncoupled += OnUncouple;
		}
	}

	private void OnUncouple(object _, UncoupleEventArgs e)
	{
		if (enstrongCoro != null)
		{
			StopCoroutine(enstrongCoro);
		}
		enstrongCoro = null;
	}

	private void OnCoupled(object _, CoupleEventArgs e)
	{
		if (e.otherCoupler.train.carType != TrainCarType.Tender)
		{
			return;
		}
		Coupler coupler = ((e.thisCoupler.rigidCJ != null) ? e.thisCoupler : e.otherCoupler);
		if (coupler == null)
		{
			Debug.LogError("TenderCouplerJointEnstronger couldn't find Coupler component during coupling", this);
			return;
		}
		if (coupler.rigidCJ == null)
		{
			Debug.LogError("TenderCouplerJointEnstronger couldn't find the ConfigurableJoint during coupling", this);
			return;
		}
		if (enstrongCoro != null)
		{
			StopCoroutine(enstrongCoro);
		}
		enstrongCoro = StartCoroutine(EnstrongJoints(coupler));
	}

	private IEnumerator EnstrongJoints(Coupler coupler)
	{
		while (coupler.IsJointAdaptationActive)
		{
			yield return WaitFor.Seconds(0.5f);
		}
		coupler.rigidCJ.xMotion = ConfigurableJointMotion.Locked;
		coupler.rigidCJ.yMotion = ConfigurableJointMotion.Locked;
		coupler.rigidCJ.zMotion = ConfigurableJointMotion.Locked;
		coupler.rigidCJ.autoConfigureConnectedAnchor = true;
	}
}
