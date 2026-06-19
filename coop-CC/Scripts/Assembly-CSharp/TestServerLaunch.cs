using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestServerLaunch : MonoBehaviour
{
	public float vel = 10f;

	public float rot = 30f;

	public Rigidbody[] rbs;

	private void Update()
	{
		if (NetworkServer.active && Keyboard.current.yKey.wasPressedThisFrame)
		{
			for (int i = 0; i < rbs.Length; i++)
			{
				Rigidbody obj = rbs[i];
				obj.velocity = new Vector3(1f, 1f, 0f).normalized * vel;
				obj.angularVelocity = new Vector3(0f, 0f, rot);
			}
		}
	}
}
