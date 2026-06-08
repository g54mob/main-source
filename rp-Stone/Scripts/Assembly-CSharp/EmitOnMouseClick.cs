using UnityEngine;

[RequireComponent(typeof(AsciiParticleEmitter))]
public class EmitOnMouseClick : MonoBehaviour
{
	private AsciiParticleEmitter myEmitter;

	private void Awake()
	{
		myEmitter = GetComponent<AsciiParticleEmitter>();
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			myEmitter.Emit();
		}
	}
}
