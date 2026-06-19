using UnityEngine;
using Vehicles;

public class DrivableVehicle : MonoBehaviour
{
	private VehiclePlace[] _places;

	public VehiclePlace[] Places
	{
		get
		{
			if (_places == null || _places.Length == 0)
			{
				_places = GetComponentsInChildren<VehiclePlace>();
			}
			return _places;
		}
	}

	public virtual void EnterVehicle()
	{
		Debug.Log("Enabling vehicle control");
	}

	public virtual void ExitVehicle()
	{
		Debug.Log("Disabling vehicle control");
	}
}
