using DV.Simulation.Cars;
using DV.ThingTypes;

namespace DV.Simulation.Controllers
{
	public class S282VirtualHandbrake : HandbrakeControl
	{
		private TrainCar tender;

		public override float Value
		{
			get
			{
				if (!tender)
				{
					return 0f;
				}
				return tender.brakeSystem.handbrakePosition;
			}
		}

		protected override bool canExistWithoutHandbrake => true;

		public S282VirtualHandbrake(TrainCar car)
			: base(car, null)
		{
			car.rearCoupler.Coupled += RearCouplerOnCoupled;
			car.rearCoupler.Uncoupled += RearCouplerOnUncoupled;
			if ((bool)car.rearCoupler.coupledTo)
			{
				RearCouplerOnCoupled(this, new CoupleEventArgs(car.rearCoupler, car.rearCoupler.coupledTo, viaChainInteraction: false));
			}
		}

		public override void Set(float value)
		{
			if ((bool)tender)
			{
				tender.brakeSystem.SetHandbrakePosition(value);
			}
		}

		private void RearCouplerOnUncoupled(object sender, UncoupleEventArgs e)
		{
			if ((bool)e.otherCoupler && CarTypes.IsTender(e.otherCoupler.train.carLivery) && tender == e.otherCoupler.train)
			{
				tender.brakeSystem.HandbrakePositionChanged -= base.OnControlUpdated;
				tender = null;
				base.IsNotched = false;
				base.NotchCount = 1f;
			}
		}

		private void RearCouplerOnCoupled(object sender, CoupleEventArgs e)
		{
			if ((bool)e.otherCoupler && CarTypes.IsTender(e.otherCoupler.train.carLivery))
			{
				tender = e.otherCoupler.train;
				tender.brakeSystem.HandbrakePositionChanged += base.OnControlUpdated;
				if (tender.TryGetComponent<BaseControlsOverrider>(out var component) && component.Handbrake != null)
				{
					base.IsNotched = component.Handbrake.IsNotched;
					base.NotchCount = component.Handbrake.NotchCount;
				}
			}
		}
	}
}
