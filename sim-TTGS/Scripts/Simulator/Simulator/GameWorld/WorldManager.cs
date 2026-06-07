using UnityEngine;

namespace Simulator.GameWorld
{
	public abstract class WorldManager : MonoBehaviour
	{
		protected virtual void OnEnable()
		{
			EventManager.OnWorldEvent += OnWorldEvent;
			EventManager.OnGameEvent += OnGameEvent;
		}

		protected virtual void OnDisable()
		{
			EventManager.OnWorldEvent -= OnWorldEvent;
			EventManager.OnGameEvent -= OnGameEvent;
		}

		protected virtual void OnWorldEvent(EWorldEvent worldEvent)
		{
			if (worldEvent == EWorldEvent.WORLD_REGISTRATION)
			{
				World.RegisterSingletonStatic(this);
			}
		}

		protected virtual void OnGameEvent(EGameEvent gameEvent)
		{
		}
	}
}
