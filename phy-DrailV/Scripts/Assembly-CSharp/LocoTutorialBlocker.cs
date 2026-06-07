using System.Collections;
using DV.Localization;
using DV.Simulation.Cars;
using DV.Utils;
using UnityEngine;

public class LocoTutorialBlocker : ZoneBlocker
{
	public CabTeleportDestination cab;

	private TrainCar train;

	private BaseControlsOverrider ctrl;

	private void Awake()
	{
		train = TrainCar.Resolve(base.gameObject);
		ctrl = train.SimController?.controlsOverrider;
		if (train == null || ctrl == null)
		{
			Debug.LogError("Couldn't find TrainCar, BaseControlsOverrider! Destroying blocker");
			Object.Destroy(base.gameObject);
			return;
		}
		cab = train.gameObject.GetComponentInChildren<CabTeleportDestination>();
		train.blockInteriorLoading = true;
		if (cab != null)
		{
			cab.gameObject.SetActive(value: false);
		}
		SingletonBehaviour<CoroutineManager>.Instance.Run(SetBrakeValuesCoro());
	}

	private void Start()
	{
		base.transform.SetParent(train.interior);
		base.transform.localPosition = Vector3.zero;
		base.transform.localRotation = Quaternion.identity;
	}

	public override string GetHoverText()
	{
		return LocalizationAPI.L("interaction/loco_tutorial_block");
	}

	protected override string GetHoverTooltipMessage()
	{
		return string.Empty;
	}

	protected override Transform GetHoverTooltipAnchor()
	{
		return train.transform;
	}

	protected override Vector3 GetHoverTooltipOffset()
	{
		return Vector3.up;
	}

	private IEnumerator SetBrakeValuesCoro()
	{
		yield return WaitFor.EndOfFrame;
		SetBrakeValues();
	}

	private void SetBrakeValues()
	{
		ctrl.Brake?.Set(0f);
		ctrl.IndependentBrake?.Set(0f);
		ctrl.Handbrake?.Set(0.25f);
		ctrl.Throttle?.Set(0f);
		ctrl.Reverser?.Set(0.5f);
	}

	private void Update()
	{
		if (PlayerManager.Car == train)
		{
			SetBrakeValues();
		}
		if ((base.transform.position - train.transform.position).sqrMagnitude >= 0.04f)
		{
			Debug.LogWarning(string.Format("Fixing {0} position on '{1}', dist was {2}", "LocoZoneBlocker", train.name, (base.transform.position - train.transform.position).magnitude), this);
			base.transform.SetPositionAndRotation(train.transform.position, train.transform.rotation);
		}
	}

	public void UnblockLoco()
	{
		train.blockInteriorLoading = false;
		DestroyBlockers();
		if (cab != null)
		{
			cab.gameObject.SetActive(value: true);
		}
		Object.Destroy(base.gameObject);
	}
}
