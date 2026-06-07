using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class PooledParticle : MonoBehaviour
{
	private PooledParticleParent parent;

	public ParticleSystem particles;

	public void InitFromParent(PooledParticleParent p)
	{
		particles.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
		ParticleSystem.MainModule main = particles.main;
		main.stopAction = ParticleSystemStopAction.Callback;
		main.loop = false;
		parent = p;
	}

	private void OnParticleSystemStopped()
	{
		parent.OnChildStopped(this);
	}
}
