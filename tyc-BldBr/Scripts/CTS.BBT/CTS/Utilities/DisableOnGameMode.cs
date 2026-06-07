using CTS.Core;
using UnityEngine;

namespace CTS.Utilities
{
	public class DisableOnGameMode : CTSBehaviour
	{
		[SerializeField]
		private EGameMode _gameMode;

		[SerializeField]
		private GameObject[] _objectsToDisable;

		protected override void OnAwake()
		{
			base.OnAwake();
			if (CTSSingleton<GameMode>.TryGetInstance(out var _) && GameMode.StartMode == _gameMode)
			{
				GameObject[] objectsToDisable = _objectsToDisable;
				for (int i = 0; i < objectsToDisable.Length; i++)
				{
					objectsToDisable[i].SetActive(value: false);
				}
			}
		}
	}
}
