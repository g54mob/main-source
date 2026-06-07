using Assets.Scripts.Flight;
using UnityEngine;

namespace Assets.Scripts.Levels
{
	public class GameObjectPoolItemScript : MonoBehaviour
	{
		private float _time;

		public GameObject GameObject { get; set; }

		public float LifeTime { get; set; }

		public void Restart()
		{
			_time = LifeTime;
			if (GameObject.activeSelf)
			{
				GameObject.SetActive(value: false);
			}
			GameObject.SetActive(value: true);
		}

		protected virtual void Update()
		{
			if (!PauseManager.Paused)
			{
				_time -= Time.deltaTime;
				if (_time <= 0f)
				{
					GameObject.SetActive(value: false);
				}
			}
		}
	}
}
