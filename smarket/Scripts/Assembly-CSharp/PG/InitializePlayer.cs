using UnityEngine;

namespace PG
{
	public class InitializePlayer : MonoBehaviour
	{
		[SerializeField]
		protected VehicleController TargetVehicle;

		public CarController Car;

		public VehicleController Vehicle { get; private set; }

		public bool IsInitialized { get; private set; }

		protected GameController GameController => null;

		protected virtual void Start()
		{
		}

		public virtual bool Initialize(VehicleController vehicle)
		{
			return false;
		}

		public virtual void Uninitialize()
		{
		}
	}
}
