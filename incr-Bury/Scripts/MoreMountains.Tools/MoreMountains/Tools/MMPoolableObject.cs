using UnityEngine;
using UnityEngine.Events;

namespace MoreMountains.Tools
{
	[AddComponentMenu("More Mountains/Tools/Object Pool/MM Poolable Object")]
	public class MMPoolableObject : MMObjectBounds
	{
		public delegate void Events();

		[Header("Events")]
		public UnityEvent ExecuteOnEnable;

		public UnityEvent ExecuteOnDisable;

		[Header("Poolable Object")]
		public float LifeTime;

		public event Events OnSpawnComplete;

		public virtual void Destroy()
		{
			base.gameObject.SetActive(value: false);
		}

		protected virtual void Update()
		{
		}

		protected virtual void OnEnable()
		{
			Size = GetBounds().extents * 2f;
			if (LifeTime > 0f)
			{
				Invoke("Destroy", LifeTime);
			}
			ExecuteOnEnable?.Invoke();
		}

		protected virtual void OnDisable()
		{
			ExecuteOnDisable?.Invoke();
			CancelInvoke();
		}

		public virtual void TriggerOnSpawnComplete()
		{
			this.OnSpawnComplete?.Invoke();
		}
	}
}
