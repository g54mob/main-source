using CTS.Core;
using UnityEngine;

namespace CTS
{
	public abstract class GameOverListener : CTSBehaviour
	{
		[field: SerializeField]
		public GameOverUIData GameOverType { get; private set; }

		protected void StartGameOver()
		{
			if (IsGameOverValid())
			{
				CTSSingleton<GameOver>.Instance.StartGameOver(this);
			}
		}

		public abstract bool IsGameOverValid();
	}
}
