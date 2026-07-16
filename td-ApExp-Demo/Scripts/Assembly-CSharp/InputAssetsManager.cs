using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputAssetsManager : MonoBehaviour
{
	[SerializeField]
	private SerializedDictionary<ControllerType, DeviceInputsSO> devices;

	public InputAssetsSO GetInputAssets(ControllerType controllerType, InputActionReference inputActionRef)
	{
		if (devices.TryGetValue(controllerType, out var value))
		{
			return value.GetInputAssets(inputActionRef);
		}
		return null;
	}
}
