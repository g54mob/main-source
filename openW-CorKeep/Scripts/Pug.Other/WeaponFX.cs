using UnityEngine;

public abstract class WeaponFX : MonoBehaviour
{
	[Header("State")]
	public bool isOn;

	public bool isConnected;

	public Vector3 originPointWorld;

	public Vector3 endPointWorld;

	public abstract void UpdatePosition();
}
