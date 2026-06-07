using Data.SaveData;
using UnityEngine;

namespace Logic.PersistentSO
{
	public class PersistentSOManager : MonoBehaviour
	{
		private static PersistentSOManager _instance;

		[SerializeField]
		private PersistentSOLibrary _persistentSOLibrary;

		public static PersistentSOManager Instance => _instance;

		public static PersistentSOManager InstanceSafe
		{
			get
			{
				if (_instance == null)
				{
					_instance = Object.FindFirstObjectByType<PersistentSOManager>();
					if (_instance == null)
					{
						_instance = new GameObject(typeof(PersistentSOManager).Name).AddComponent<PersistentSOManager>();
					}
				}
				return _instance;
			}
		}

		private void Awake()
		{
			if (_instance == null)
			{
				_instance = this;
			}
			if (_instance != this)
			{
				Object.Destroy(this);
			}
			else
			{
				Object.DontDestroyOnLoad(base.gameObject);
			}
		}

		private void OnDestroy()
		{
		}
	}
}
