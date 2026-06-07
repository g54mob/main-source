using NWH.VehiclePhysics2;
using NWH.VehiclePhysics2.Powertrain;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain
{
	public class JVehicleController : VehicleController
	{
		private bool _remoteIsRunning;

		public bool RemoteCraft { get; set; }

		public override void FixedUpdate()
		{
			if (!RemoteCraft)
			{
				base.FixedUpdate();
			}
		}

		public override void Update()
		{
			base.Update();
			if (RemoteCraft)
			{
				EngineComponent engine = powertrain.engine;
				float num = Mathf.Max(100f, engine.idleRPM * 0.5f);
				float num2 = Mathf.Abs(engine.OutputRPM);
				if (!_remoteIsRunning && num2 > num)
				{
					_remoteIsRunning = true;
					engine.StartEngine();
				}
				else if (_remoteIsRunning && num2 < num * 0.6f)
				{
					_remoteIsRunning = false;
					engine.StopEngine();
				}
			}
		}
	}
}
