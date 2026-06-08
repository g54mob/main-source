using UnityEngine;

public class AsciiMouseEmitterTest : MonoBehaviour
{
	private AsciiMouse mouse;

	private AsciiParticleEmitter emitter;

	private void Update()
	{
		Vector3 position = new Vector3(mouse.x, mouse.y, 0f);
		emitter.transform.position = position;
		if (Input.GetMouseButtonDown(1))
		{
			emitter.Emit();
		}
	}

	private void Start()
	{
		mouse = GetComponent<AsciiMouse>();
		emitter = GetComponent<AsciiParticleEmitter>();
	}
}
