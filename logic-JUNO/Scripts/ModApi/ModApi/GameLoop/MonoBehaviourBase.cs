using ModApi.GameLoop.Interfaces;
using UnityEngine;

namespace ModApi.GameLoop
{
	public abstract class MonoBehaviourBase : MonoBehaviour, IGameLoopItem
	{
		bool IGameLoopItem.StartMethodCalled { get; set; }

		protected virtual void OnDisable()
		{
			Game.Loop.Unregister(this);
		}

		protected virtual void OnEnable()
		{
			Game.Loop.Register(this);
		}

		int IGameLoopItem.GetInstanceID()
		{
			return GetInstanceID();
		}
	}
}
