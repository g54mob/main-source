using UnityEngine;

public class BabyBallsSharedParticles : MonoBehaviour
{
	[SerializeField]
	private ParticleSystem particleSystem;

	public PartSys PartSys;

	private ParticleSystem.EmitParams emitParams;

	public void EmitAt(Vector3 position)
	{
	}
}
