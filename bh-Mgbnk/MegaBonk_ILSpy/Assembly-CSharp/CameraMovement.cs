using MilkShake;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public Shaker shaker;

	public ShakePreset preset;

	private void Start()
	{
		//IL_0016: Expected O, but got I4
		ShakeInstance shakeInstance = shaker.Shake(preset, (int?)(object)0);
	}
}
