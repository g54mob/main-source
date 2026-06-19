using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleWorldSimulationSpace : MonoBehaviour
{
	private ParticleSystem _particleSystem;

	private Transform _anchor;

	private void Awake()
	{
		_particleSystem = GetComponent<ParticleSystem>();
	}

	private void OnEnable()
	{
		if (_anchor != null)
		{
			Debug.LogError("Render anchor was somehow not null!");
			return;
		}
		_anchor = Manager.camera.GetRenderAnchor();
		ParticleSystem.MainModule main = _particleSystem.main;
		main.simulationSpace = ParticleSystemSimulationSpace.Custom;
		main.customSimulationSpace = _anchor;
	}

	private void OnDisable()
	{
		if (_anchor != null)
		{
			Manager.camera.ReturnRenderAnchor(_anchor);
			_anchor = null;
		}
	}
}
