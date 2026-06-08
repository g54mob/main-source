using UnityEngine;

[RequireComponent(typeof(AsciiParticleEmitter))]
public class FollowMouseEmitter : MonoBehaviour
{
	private AsciiParticleEmitter myEmitter;

	private void Awake()
	{
		myEmitter = GetComponent<AsciiParticleEmitter>();
	}

	private void Update()
	{
		AsciiMouse asciiMouse = Object.FindObjectOfType<AsciiMouse>();
		if (asciiMouse != null)
		{
			Vector3 pos = new Vector3(asciiMouse.x, asciiMouse.y, 0f);
			myEmitter.MoveTo(pos);
		}
	}
}
