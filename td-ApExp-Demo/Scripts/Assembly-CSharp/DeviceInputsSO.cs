using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "DeviceInputsSO", menuName = "Device Inputs SO")]
public class DeviceInputsSO : ScriptableObject
{
	[SerializeField]
	private SerializedDictionary<InputActionReference, InputAssetsSO> inputs;

	public InputAssetsSO GetInputAssets(InputActionReference inputActionRef)
	{
		if (inputActionRef != null && inputs.TryGetValue(inputActionRef, out var value))
		{
			return value;
		}
		return null;
	}
}
