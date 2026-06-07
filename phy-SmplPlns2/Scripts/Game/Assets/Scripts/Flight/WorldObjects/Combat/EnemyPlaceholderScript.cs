using Assets.Scripts.Levels;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Combat
{
	public class EnemyPlaceholderScript : MonoBehaviour
	{
		[SerializeField]
		private bool _loadAtStartup = true;

		[SerializeField]
		private GameObject _prefab;

		public GameObject Instance { get; private set; }

		public bool Loaded { get; private set; }

		public void LoadEnemy()
		{
			if (!Loaded)
			{
				Loaded = true;
				if (_prefab == null)
				{
					Debug.LogError("The enemy placeholder prefab is null");
					return;
				}
				GameObject gameObject = Object.Instantiate(_prefab);
				gameObject.transform.parent = LevelBase.CurrentLevel.WorldRigidbodiesContainer;
				gameObject.transform.SetPositionAndRotation(base.transform.position, base.transform.rotation);
				Instance = gameObject;
			}
		}

		protected virtual void Start()
		{
			if (_loadAtStartup)
			{
				LoadEnemy();
			}
		}
	}
}
