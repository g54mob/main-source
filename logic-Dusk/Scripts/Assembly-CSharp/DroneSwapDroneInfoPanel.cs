using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DroneSwapDroneInfoPanel : MonoBehaviour
{
	private const int NUM_DRONE_VISUALS = 6;

	private DroneStateImages[] _droneStateImages = new DroneStateImages[6];

	private Text _droneNumber;

	private Text _droneName;

	private Drone _drone;

	private bool _initialized;

	private Color _aliveColor;

	private Color _disabledColor;

	private Color _destroyedColor;

	private Color _disabledNumberColor;

	private Color _destroyedNumberColor;

	public Drone Drone
	{
		get
		{
			return _drone;
		}
	}

	private void Awake()
	{
		if (!_initialized)
		{
			Initialize();
		}
	}

	private void OnDestroy()
	{
		_droneStateImages = null;
		_droneNumber = null;
		_droneName = null;
	}

	private void Initialize()
	{
		Transform transform = base.transform.FindChild("DroneNumber");
		if (transform != null)
		{
			_droneNumber = transform.gameObject.GetComponent<Text>();
		}
		transform = base.transform.FindChild("DroneName");
		if (transform != null)
		{
			_droneName = transform.gameObject.GetComponent<Text>();
		}
		for (int i = 0; i < 6; i++)
		{
			DroneStateImages droneStateImages = new DroneStateImages();
			_droneStateImages[i] = droneStateImages;
			transform = base.transform.FindChild(string.Format("Drone{0}Alive", i + 1));
			if (transform != null)
			{
				droneStateImages.Alive = transform.gameObject.GetComponent<Image>();
			}
			transform = base.transform.FindChild(string.Format("Drone{0}Disabled", i + 1));
			if (transform != null)
			{
				droneStateImages.Disabled = transform.gameObject.GetComponent<Image>();
			}
			transform = base.transform.FindChild(string.Format("Drone{0}Destroyed", i + 1));
			if (transform != null)
			{
				droneStateImages.Destroyed = transform.gameObject.GetComponent<Image>();
			}
		}
		if (_droneNumber == null || _droneName == null || _droneStateImages.Any((DroneStateImages x) => x.Alive == null || x.Disabled == null || x.Destroyed == null))
		{
			Debug.LogError("DroneSwapDroneInfoPanel did not resolve all fields properly");
		}
		_initialized = true;
	}

	public void SetColors(Color alive, Color disabled, Color destroyed, Color disabledNumber, Color destroyedNumber)
	{
		_aliveColor = alive;
		_disabledColor = disabled;
		_destroyedColor = destroyed;
		_disabledNumberColor = disabledNumber;
		_destroyedNumberColor = destroyedNumber;
	}

	public void SetDrone(Drone drone)
	{
		if (!_initialized)
		{
			Initialize();
		}
		_drone = drone;
		DroneStateImages[] droneStateImages = _droneStateImages;
		foreach (DroneStateImages droneStateImages2 in droneStateImages)
		{
			droneStateImages2.Alive.gameObject.SetActive(false);
			droneStateImages2.Disabled.gameObject.SetActive(false);
			droneStateImages2.Destroyed.gameObject.SetActive(false);
		}
		if (drone.DroneVisualIndex >= 0 && drone.DroneVisualIndex < 6)
		{
			if (!drone.IsDead)
			{
				_droneStateImages[drone.DroneVisualIndex].Alive.gameObject.SetActive(true);
				_droneStateImages[drone.DroneVisualIndex].Alive.color = _aliveColor;
				_droneNumber.color = _aliveColor;
				_droneNumber.enabled = true;
			}
			else
			{
				if (drone.CanBeFullyRepaired)
				{
					_droneStateImages[drone.DroneVisualIndex].Disabled.gameObject.SetActive(true);
					_droneStateImages[drone.DroneVisualIndex].Disabled.color = _disabledColor;
					_droneNumber.color = _disabledNumberColor;
				}
				else
				{
					_droneStateImages[drone.DroneVisualIndex].Destroyed.gameObject.SetActive(true);
					_droneStateImages[drone.DroneVisualIndex].Destroyed.color = _destroyedColor;
					_droneNumber.color = _destroyedNumberColor;
				}
				if (!DroneManager.Instance.dronesList.Contains(drone))
				{
					_droneNumber.enabled = false;
				}
			}
		}
		else
		{
			Debug.LogWarning("bad visual drone index " + drone.DroneVisualIndex);
		}
		_droneName.text = drone.DroneName;
		_droneNumber.text = drone.DroneNumber.ToString("00");
	}
}
