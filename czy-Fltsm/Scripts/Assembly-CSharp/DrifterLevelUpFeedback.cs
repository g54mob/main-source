using UnityEngine;

public class DrifterLevelUpFeedback : SceneBehaviour
{
	[SerializeField]
	private Agent _agent;

	[SerializeField]
	private ParticleSystem _particleSystem;

	private void Start()
	{
		_agent.Attributes.LevelIncreasedEvent.AddListener(OnLevelUp);
		_agent.OnDeath.AddListener(OnDrifterDeath);
	}

	private void OnDestroy()
	{
		_agent.Attributes.LevelIncreasedEvent.RemoveListener(OnLevelUp);
		_agent.OnDeath.RemoveListener(OnDrifterDeath);
	}

	private void OnDrifterDeath()
	{
		Object.Destroy(this);
	}

	private void OnLevelUp()
	{
		_particleSystem.Play();
	}
}
