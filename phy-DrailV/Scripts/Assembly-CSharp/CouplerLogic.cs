using System.Collections.Generic;
using UnityEngine;

public static class CouplerLogic
{
	public static Coupler CoupleFirstInRange(TrainCar startCar, float range, bool releaseHandbrakesOnCoupledCars = false)
	{
		Coupler coupler = null;
		List<TrainCar> list = null;
		var (coupler2, coupler3) = GetFrontAndRearCouplerInRange(startCar, range);
		if ((bool)coupler2)
		{
			if (releaseHandbrakesOnCoupledCars)
			{
				list = new List<TrainCar>(coupler2.train.trainset.cars);
			}
			coupler2.TryCouple();
			Anal.Coupled();
			if (coupler2.IsCoupled())
			{
				coupler = coupler2;
			}
		}
		else if ((bool)coupler3)
		{
			if (releaseHandbrakesOnCoupledCars)
			{
				list = new List<TrainCar>(coupler3.train.trainset.cars);
			}
			coupler3.TryCouple();
			Anal.Coupled();
			if (coupler3.IsCoupled())
			{
				coupler = coupler3;
			}
		}
		if (coupler != null && releaseHandbrakesOnCoupledCars)
		{
			foreach (TrainCar item in list)
			{
				item.brakeSystem.SetHandbrakePosition(0f);
			}
		}
		return coupler;
	}

	public static void CoupleFirstInRange(Coupler coupler, float range, bool releaseHandbrakesOnCoupledCars = false, bool viaChainInteraction = false, bool playAudio = true)
	{
		if (coupler.IsCoupled())
		{
			return;
		}
		if (coupler.train.preventCouple)
		{
			Debug.LogWarning("Attempted to couple car with preventCouple flag set! Ignoring request");
			return;
		}
		Coupler firstCouplerInRange = coupler.GetFirstCouplerInRange(range);
		if (!firstCouplerInRange)
		{
			return;
		}
		List<TrainCar> list = (releaseHandbrakesOnCoupledCars ? new List<TrainCar>(firstCouplerInRange.train.trainset.cars) : null);
		coupler.CoupleTo(firstCouplerInRange, playAudio, viaChainInteraction);
		Anal.Coupled();
		if (!(firstCouplerInRange.IsCoupled() && releaseHandbrakesOnCoupledCars))
		{
			return;
		}
		foreach (TrainCar item in list)
		{
			item.brakeSystem.SetHandbrakePosition(0f);
		}
	}

	public static Coupler UncoupleNth(TrainCar startCar, int selectedCoupler, bool applyHandbrakeToUncoupledCar = false)
	{
		if (selectedCoupler == 0)
		{
			return null;
		}
		Coupler nthCouplerFrom = GetNthCouplerFrom((selectedCoupler > 0) ? startCar.frontCoupler : startCar.rearCoupler, Mathf.Abs(selectedCoupler) - 1);
		if (nthCouplerFrom == null)
		{
			Debug.LogError($"Unexpected state: {selectedCoupler}. coupler from {startCar.ID} is null");
			return null;
		}
		Coupler coupledTo = nthCouplerFrom.coupledTo;
		if (coupledTo == null)
		{
			return null;
		}
		nthCouplerFrom.Uncouple();
		Anal.Decoupled();
		if (applyHandbrakeToUncoupledCar)
		{
			coupledTo.train.brakeSystem.SetHandbrakePosition(1f);
		}
		return coupledTo;
	}

	public static void Uncouple(Coupler coupler, bool applyHandbrakeToUncoupledCar = false, bool viaChainInteraction = false, bool playAudio = true)
	{
		Coupler coupledTo = coupler.coupledTo;
		if (!(coupledTo == null))
		{
			coupler.Uncouple(playAudio, calledOnOtherCoupler: false, dueToBrokenCouple: false, viaChainInteraction);
			Anal.Decoupled();
			if (applyHandbrakeToUncoupledCar)
			{
				coupledTo.train.brakeSystem.SetHandbrakePosition(1f);
			}
		}
	}

	public static bool AnyCouplerInRange(TrainCar car, float range)
	{
		var (coupler, coupler2) = GetFrontAndRearCouplerInRange(car, range);
		if (!(coupler != null))
		{
			return coupler2 != null;
		}
		return true;
	}

	public static (Coupler, Coupler) GetFrontAndRearCouplerInRange(TrainCar car, float range)
	{
		Coupler lastCoupler = GetLastCoupler(car.frontCoupler);
		Coupler lastCoupler2 = GetLastCoupler(car.rearCoupler);
		Coupler firstCouplerInRange = lastCoupler.GetFirstCouplerInRange(range);
		Coupler firstCouplerInRange2 = lastCoupler2.GetFirstCouplerInRange(range);
		return (firstCouplerInRange, firstCouplerInRange2);
	}

	public static Coupler GetLastCoupler(Coupler start)
	{
		Coupler result = start;
		while (start != null)
		{
			start = start.GetCoupled();
			if ((bool)start)
			{
				start = start.GetOppositeCoupler();
				result = start;
			}
		}
		return result;
	}

	public static Coupler GetNthCouplerFrom(Coupler start, int distanceToOtherCoupler)
	{
		while (distanceToOtherCoupler > 0 && start != null)
		{
			distanceToOtherCoupler--;
			start = start.GetCoupled();
			if ((bool)start)
			{
				start = start.GetOppositeCoupler();
			}
		}
		return start;
	}

	public static IEnumerable<TrainCar> GetCoupledCars(Coupler start, bool requireTightened)
	{
		while (start != null)
		{
			Coupler coupled = start.GetCoupled();
			if (coupled == null || (requireTightened && !start.IsTightened() && !coupled.IsTightened()))
			{
				break;
			}
			start = coupled.GetOppositeCoupler();
			yield return start.train;
		}
	}
}
