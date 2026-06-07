using Assets.Scripts.Flight.AI.ControlFunctions;

namespace Assets.Scripts.Flight.AI.ControlSystems
{
	public class AiCsFlyToLocation<T> : AiControlSystem where T : AiControlFunction, new()
	{
		public bool AutoTakeoff { get; private set; }

		public bool FollowBehind { get; set; }

		protected AiCfMaintainHeading MaintainHeadingControlFunction { get; set; }

		protected T OrientToLocationControlFunction { get; set; }

		protected AiCfTakeoff TakeoffControlFunction { get; set; }

		public AiCsFlyToLocation()
		{
			AutoTakeoff = false;
		}

		public override void Initialize(AiControlledAircraftScript aiControlledAircraft)
		{
			base.Initialize(aiControlledAircraft);
			MaintainHeadingControlFunction = new AiCfMaintainHeading();
			MaintainHeadingControlFunction.Initialize(this);
			if (OrientToLocationControlFunction == null)
			{
				OrientToLocationControlFunction = new T();
			}
			OrientToLocationControlFunction.Initialize(this);
			OrientToLocationControlFunction.ShowDebugInfo = true;
			if (AutoTakeoff && base.AiControlledAircraft.AiAircraftScript.AltitudeAgl < 10f)
			{
				TakeoffControlFunction = new AiCfTakeoff();
				TakeoffControlFunction.Initialize(this);
				SwitchActiveControlFunction(TakeoffControlFunction);
			}
			else
			{
				SwitchActiveControlFunction(OrientToLocationControlFunction);
			}
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			if (_currentControlFunction == TakeoffControlFunction && TakeoffControlFunction.TakeoffComplete)
			{
				SwitchActiveControlFunction(OrientToLocationControlFunction);
			}
		}
	}
}
