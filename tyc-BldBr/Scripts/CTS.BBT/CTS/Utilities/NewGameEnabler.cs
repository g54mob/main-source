using CTS.Core;
using UnityEngine;

namespace CTS.Utilities
{
	public class NewGameEnabler : CTSBehaviour
	{
		[SerializeField]
		private GameObject[] _gameObjects;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			if (GameMode.IsNewGame)
			{
				GameObject[] gameObjects = _gameObjects;
				for (int i = 0; i < gameObjects.Length; i++)
				{
					gameObjects[i].SetActive(value: true);
				}
			}
		}
	}
}
