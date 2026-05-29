using UnityEngine;

[RequireComponent(typeof(Camera))]
public class LightCamera : MonoBehaviour
{
	public static LightCamera Instance { get; private set; }

	private void Awake()
	{
	}

	public void Activate()
	{
	}
}
