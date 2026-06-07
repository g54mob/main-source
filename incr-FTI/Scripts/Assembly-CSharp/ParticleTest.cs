using Coffee.UIExtensions;
using UnityEngine;

public class ParticleTest : MonoBehaviour
{
	public ParticleSystem particleSystem;

	public UIParticle uiParticle;

	private void Start()
	{
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			uiParticle.Stop();
			uiParticle.Play();
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			uiParticle.StopEmission();
		}
		if (Input.GetKeyDown(KeyCode.C))
		{
			uiParticle.Clear();
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			uiParticle.StartEmission();
		}
		if (Input.GetKeyDown(KeyCode.F))
		{
			uiParticle.Stop();
		}
		if (Input.GetKeyDown(KeyCode.G))
		{
			uiParticle.Play();
		}
	}

	private void RunTest()
	{
		particleSystem.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
		particleSystem.Play();
	}
}
