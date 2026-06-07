using PajamaLlama.Math;
using UnityEngine;

public class Desalinator : MonoBehaviour
{
	[SerializeField]
	private Producer _producer;

	[SerializeField]
	private float _pollutionRadius = 15f;

	[SerializeField]
	private ParticleSystem _particleSystem;

	private float _pollutionPerSecond;

	private void Awake()
	{
		if (!(_producer == null))
		{
			_producer.OnStartProducing.AddListener(OnProductionStarted);
			_producer.OnStopProducing.AddListener(OnProductionStopped);
		}
	}

	private void LateUpdate()
	{
		if (_pollutionPerSecond <= 0f)
		{
			return;
		}
		Vector3 position = base.transform.position;
		foreach (Agent agent in Community.PlayerCommunity.Agents)
		{
			if (agent.transform.position.IsInRangeXZ(position, _pollutionRadius))
			{
				agent.Vitals.Pollution.Increase(_pollutionPerSecond * TimeManager.GetDeltaTime());
			}
		}
	}

	private void OnDestroy()
	{
		if (!(_producer == null))
		{
			_producer.OnStartProducing.RemoveListener(OnProductionStarted);
			_producer.OnStopProducing.RemoveListener(OnProductionStopped);
		}
	}

	private void OnProductionStarted(Buildable buildable)
	{
		GameEventDispatcher.AddListener(GameEventType.TownheartMoved, UpdatePollutionPerSecond);
		UpdatePollutionPerSecond();
	}

	private void OnProductionStopped(Buildable buildable)
	{
		GameEventDispatcher.RemoveListener(GameEventType.TownheartMoved, UpdatePollutionPerSecond);
		_pollutionPerSecond = 0f;
		if ((bool)_particleSystem)
		{
			_particleSystem.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmitting);
		}
	}

	private void UpdatePollutionPerSecond(GameEvent gameEvent = null)
	{
		_pollutionPerSecond = ReturnPollutionPerSecond();
		if (0f < _pollutionPerSecond && (bool)_particleSystem)
		{
			_particleSystem.Play();
		}
	}

	private float ReturnPollutionPerSecond()
	{
		if (GameManager.WorldManager.CurrentRegion.PollutionLevel == PollutionLevels.None)
		{
			return 0f;
		}
		foreach (QueuedRecipe queuedRecipe in _producer.QueuedRecipes)
		{
			if (queuedRecipe.RecipeStage == QueuedRecipe.Stage.Producing)
			{
				return queuedRecipe.Pollution / queuedRecipe.ProductionTime;
			}
		}
		return 0f;
	}
}
