using Assets.Scripts.Craft.Parts.Modifiers.Powertrain;
using NWH.VehiclePhysics2;
using NWH.VehiclePhysics2.Powertrain;
using UnityEngine;

namespace Assets.Scripts.Craft
{
	public class CraftPowertrainScript : MonoBehaviour
	{
		private AircraftScript _craft;

		private VehicleController _vehicle;

		public IPowertrain PrimaryPowertrain { get; private set; }

		public static CraftPowertrainScript Create(AircraftScript craft)
		{
			CraftPowertrainScript craftPowertrainScript = craft.gameObject.AddComponent<CraftPowertrainScript>();
			craftPowertrainScript._craft = craft;
			if (craft.LoadContext == CraftLoadContext.Flight)
			{
				GameObject gameObject = Game.Instance.ResourceLoader.InstantiatePrefab("Craft/NWHVehicleController");
				gameObject.name = "RootNWHVehicleController";
				gameObject.transform.SetParent(craft.transform);
				craftPowertrainScript._vehicle = gameObject.GetComponent<VehicleController>();
				craftPowertrainScript._vehicle.enabled = true;
			}
			CraftSkidmarkManagerScript.InitializeManager();
			return craftPowertrainScript;
		}

		public void RegisterPowertrain(IPowertrain powertrain)
		{
			if (PrimaryPowertrain == null)
			{
				PrimaryPowertrain = powertrain;
			}
			powertrain.Powertrain.vehicleController.parentVehicleController = _vehicle;
		}

		public void RegisterWheel(WheelComponent wheelComponent)
		{
			_vehicle.powertrain.wheels.Add(wheelComponent);
		}

		public void SetParentTransform(Transform transform)
		{
			_vehicle.transform.SetParent(transform);
			_vehicle.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
		}

		protected void Start()
		{
			if (_craft.LoadContext == CraftLoadContext.Flight)
			{
				_craft.OnAircraftStructureChanged += OnAircraftStructureChanged;
				_vehicle.vehicleRigidbody = _craft.Bodies[0].RigidBody.PhysxRigidBody;
			}
		}

		private void OnAircraftStructureChanged()
		{
			_vehicle.vehicleRigidbody = _craft.Bodies[0].RigidBody.PhysxRigidBody;
		}
	}
}
