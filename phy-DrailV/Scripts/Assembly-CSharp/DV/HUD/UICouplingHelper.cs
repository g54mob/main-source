using System;
using DV.MultipleUnit;

namespace DV.HUD
{
	public class UICouplingHelper
	{
		public TrainCar trainCar;

		public Func<bool> shouldAutoHandbrake;

		private Coupler couplerFront;

		private Coupler couplerRear;

		private bool muRear;

		private bool muFront;

		private bool airRear;

		private bool airFront;

		private bool inRangeRear;

		private bool inRangeFront;

		public bool IsAirConnected(bool front)
		{
			if (!front)
			{
				return airRear;
			}
			return airFront;
		}

		public bool IsMUConnected(bool front)
		{
			if (!front)
			{
				return muRear;
			}
			return muFront;
		}

		public bool IsInRange(bool front)
		{
			if (!front)
			{
				return inRangeRear;
			}
			return inRangeFront;
		}

		public void CacheValues()
		{
			muFront = MultipleUnitModule.IsMultipleUnitCableConnected(trainCar, couplerFront.isFrontCoupler);
			muRear = MultipleUnitModule.IsMultipleUnitCableConnected(trainCar, couplerRear.isFrontCoupler);
			airFront = couplerFront.GetAirHoseConnectedTo();
			airRear = couplerRear.GetAirHoseConnectedTo();
			Coupler firstCouplerInRange = couplerFront.GetFirstCouplerInRange();
			inRangeFront = (bool)firstCouplerInRange && (bool)couplerFront.visualCoupler && (bool)firstCouplerInRange.visualCoupler;
			firstCouplerInRange = couplerRear.GetFirstCouplerInRange();
			inRangeRear = (bool)firstCouplerInRange && (bool)couplerRear.visualCoupler && (bool)firstCouplerInRange.visualCoupler;
		}

		public void HandleBrakeHose(bool front)
		{
			Coupler coupler = (front ? couplerFront : couplerRear);
			if (front ? airFront : airRear)
			{
				Coupler airHoseConnectedTo = coupler.GetAirHoseConnectedTo();
				coupler.DisconnectAirHose(playAudio: true);
				coupler.IsCockOpen = false;
				airHoseConnectedTo.IsCockOpen = false;
				return;
			}
			Coupler coupledToOrWithinBreakDistance = coupler.CoupledToOrWithinBreakDistance;
			coupler.ConnectAirHose(coupledToOrWithinBreakDistance, playAudio: true);
			Coupler airHoseConnectedTo2 = coupler.GetAirHoseConnectedTo();
			if ((bool)airHoseConnectedTo2)
			{
				coupler.IsCockOpen = true;
				airHoseConnectedTo2.IsCockOpen = true;
			}
			else
			{
				coupler.IsCockOpen = !coupler.IsCockOpen;
			}
		}

		public void HandleCoupling(Coupler coupler, bool advanced)
		{
			bool front = coupler == couplerFront;
			if (!coupler.visualCoupler || (coupler.IsCoupled() && !coupler.coupledTo.visualCoupler))
			{
				return;
			}
			if (advanced ? IsFullyCoupled(front) : coupler.IsCoupled())
			{
				CouplerLogic.Uncouple(coupler, shouldAutoHandbrake(), !advanced);
				MultipleUnitModule.DisconnectCablesIfMultipleUnitSupported(coupler.train, coupler.isFrontCoupler, !coupler.isFrontCoupler);
				return;
			}
			CouplerLogic.CoupleFirstInRange(coupler, 1.5f, shouldAutoHandbrake(), !advanced);
			if (advanced && coupler.IsCoupled())
			{
				MultipleUnitModule.ConnectCablesOfConnectedCouplersIfMultipleUnitSupported(coupler, coupler.coupledTo);
				if (!coupler.hoseAndCock.IsHoseConnected)
				{
					coupler.ConnectAirHose(coupler.coupledTo, playAudio: true);
				}
				if (!coupler.IsCockOpen)
				{
					coupler.IsCockOpen = true;
				}
				if (!coupler.coupledTo.IsCockOpen)
				{
					coupler.coupledTo.IsCockOpen = true;
				}
			}
		}

		public void DoMU(Coupler coupler)
		{
			if (MultipleUnitModule.IsMultipleUnitCableConnected(coupler.train, coupler.isFrontCoupler))
			{
				MultipleUnitModule.DisconnectCablesIfMultipleUnitSupported(coupler.train, coupler.isFrontCoupler, !coupler.isFrontCoupler);
			}
			else if (coupler.IsCoupled())
			{
				MultipleUnitModule.ConnectCablesOfConnectedCouplersIfMultipleUnitSupported(coupler, coupler.coupledTo);
			}
		}

		public bool IsFullyCoupled(bool front)
		{
			Coupler coupler = GetCoupler(front);
			if (coupler.IsCoupled() && (bool)coupler.GetAirHoseConnectedTo() && coupler.IsCockOpen)
			{
				return coupler.coupledTo.IsCockOpen;
			}
			return false;
		}

		public Coupler GetCoupler(bool front)
		{
			if (!front)
			{
				return couplerRear;
			}
			return couplerFront;
		}

		public void SetCoupler(Coupler coupler, bool front)
		{
			if (front)
			{
				couplerFront = coupler;
			}
			else
			{
				couplerRear = coupler;
			}
		}
	}
}
