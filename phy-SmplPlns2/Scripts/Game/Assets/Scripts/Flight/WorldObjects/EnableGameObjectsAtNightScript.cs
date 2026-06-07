using System;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects
{
	public class EnableGameObjectsAtNightScript : MonoBehaviour
	{
		[Serializable]
		public class GameObjectTarget
		{
			public bool enabledAtNight;

			public GameObject gameObject;
		}

		[SerializeField]
		private GameObjectTarget[] _gameObjects;

		private bool _night;

		protected virtual void Start()
		{
			UpdateGameObjects(FlightSceneScript.Instance.Environment.IsNight);
		}

		protected virtual void Update()
		{
			if (_night != FlightSceneScript.Instance.Environment.IsNight)
			{
				UpdateGameObjects(FlightSceneScript.Instance.Environment.IsNight);
			}
		}

		private void UpdateGameObjects(bool nightState)
		{
			_night = nightState;
			GameObjectTarget[] gameObjects = _gameObjects;
			foreach (GameObjectTarget gameObjectTarget in gameObjects)
			{
				gameObjectTarget.gameObject.SetActive(nightState ? gameObjectTarget.enabledAtNight : (!gameObjectTarget.enabledAtNight));
			}
		}
	}
}
