using Assets.Scripts.Flight.AI.ControlFunctions;
using UnityEngine;

namespace Assets.Scripts.Flight.AI.ControlSystems
{
	public class AicsFlyToLocationAndFollow : AiCsFlyToLocation<AiCfFlyToLocation>
	{
		private float? _startingClosingSpeed;

		public override float GetThrottle()
		{
			if (base.AiControlledAircraft.DistanceToTarget < 1000f)
			{
				if (base.AiControlledAircraft.BehindTarget)
				{
					if (!_startingClosingSpeed.HasValue)
					{
						_startingClosingSpeed = base.AiControlledAircraft.ClosingSpeed;
					}
					float num = (float)((base.AiControlledAircraft.DistanceToTarget / 1000f * _startingClosingSpeed.Value > base.AiControlledAircraft.ClosingSpeed) ? 1 : (-1)) * Time.deltaTime;
					return base.AiControlledAircraft.AiAircraftScript.Controls.Throttle = Mathf.Clamp01(base.AiControlledAircraft.AiAircraftScript.Controls.Throttle + num);
				}
				_startingClosingSpeed = null;
				return base.GetThrottle();
			}
			_startingClosingSpeed = null;
			return base.GetThrottle();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
		}
	}
}
