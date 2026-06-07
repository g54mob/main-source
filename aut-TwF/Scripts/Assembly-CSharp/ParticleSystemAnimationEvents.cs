using UnityEngine;

public class ParticleSystemAnimationEvents : MonoBehaviour
{
	[SerializeField]
	private ParticleSystem[] ps;

	public void EmitAll()
	{
		ParticleSystem[] array = ps;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Play();
		}
	}

	public void Emit(int index)
	{
		ps[index].Play();
	}

	public void StopAlll()
	{
		ParticleSystem[] array = ps;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Stop(withChildren: false, ParticleSystemStopBehavior.StopEmitting);
		}
	}

	public void Stop(int index)
	{
		ps[index].Stop(withChildren: false, ParticleSystemStopBehavior.StopEmitting);
	}
}
