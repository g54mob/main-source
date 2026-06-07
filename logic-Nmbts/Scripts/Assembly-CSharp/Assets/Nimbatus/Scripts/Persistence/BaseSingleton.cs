using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Persistence
{
	public abstract class BaseSingleton<T> : SerializedMonoBehaviour where T : BaseSingleton<T>
	{
		public static T Instance { get; set; }

		protected virtual void Awake()
		{
			if (Instance == null)
			{
				Instance = GetComponent<T>();
			}
			else if (Instance != this)
			{
				Object.Destroy(this);
			}
		}
	}
}
