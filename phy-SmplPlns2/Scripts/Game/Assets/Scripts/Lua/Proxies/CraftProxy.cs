using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using MoonSharp.Interpreter;
using UnityEngine;

namespace Assets.Scripts.Lua.Proxies
{
	[MoonSharpUserData]
	public class CraftProxy
	{
		private AircraftScript _aircraft;

		public float Altitude => _aircraft.Altitude;

		public float AltitudeAgl => _aircraft.AltitudeAgl;

		public float AngleOfAttack
		{
			get
			{
				Vector3 vector = MainCockpit.transform.InverseTransformDirection(_aircraft.Velocity - _aircraft.WindVelocity);
				return 57.29578f * Mathf.Atan2(vector.y, vector.z);
			}
		}

		public float AngleOfSlip
		{
			get
			{
				Vector3 vector = MainCockpit.transform.InverseTransformDirection(_aircraft.Velocity - _aircraft.WindVelocity);
				return 57.29578f * Mathf.Atan2(vector.x, vector.z);
			}
		}

		public Vector3 AngularVelocity => _aircraft.AngularVelocity;

		public CraftControlsProxy Controls { get; }

		public float Fuel
		{
			get
			{
				if (_aircraft.InitialFuelCapacity > 0f)
				{
					return _aircraft.Fuel / _aircraft.InitialFuelCapacity;
				}
				return 0f;
			}
		}

		public float GForce => (Physics.gravity - _aircraft.Acceleration).magnitude / 9.81f;

		public float GS => _aircraft.GetSpeed(AircraftScript.SpeedType.GS);

		public float Heading
		{
			get
			{
				Vector3 forward = MainCockpit.transform.forward;
				return Mathf.Atan2(forward.x, forward.z) * 57.29578f % 360f;
			}
		}

		public float IAS => _aircraft.GetSpeed(AircraftScript.SpeedType.IAS);

		public float Latitude => _aircraft.GlobalPosition.z;

		public float Longitude => _aircraft.GlobalPosition.x;

		public PartScript MainCockpit => _aircraft.MainCockpit;

		public float PitchAngle => Mathf.DeltaAngle(0f, Mathf.Asin(MainCockpit.transform.forward.y) * 57.29578f);

		public float PitchRate => MainCockpit.transform.InverseTransformDirection(AngularVelocity).x * 57.29578f;

		public float RollAngle => Mathf.DeltaAngle(0f, MainCockpit.transform.eulerAngles.z);

		public float RollRate => MainCockpit.transform.InverseTransformDirection(AngularVelocity).z * 57.29578f;

		public TargetingSystemProxy Targeting { get; }

		public float TAS => _aircraft.GetSpeed(AircraftScript.SpeedType.TAS);

		public float Time => UnityEngine.Time.timeSinceLevelLoad;

		public float VerticalG => Vector3.Dot(MainCockpit.transform.up, _aircraft.Acceleration - Physics.gravity) / 9.81f;

		public float YawRate => MainCockpit.transform.InverseTransformDirection(AngularVelocity).y * 57.29578f;

		[MoonSharpHidden]
		public CraftProxy(AircraftScript aircraft, ProxyFactory proxyFactory)
		{
			_aircraft = aircraft;
			Controls = proxyFactory.GetOrCreateProxy<CraftControlsProxy>(_aircraft.Controls);
			Targeting = proxyFactory.GetOrCreateProxy<TargetingSystemProxy>(_aircraft.TargetingSystem);
		}
	}
}
