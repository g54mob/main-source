using UnityEngine;

namespace MoreMountains.Tools
{
	public class MMReferencedScriptableObject<T> : ScriptableObject where T : ScriptableObject
	{
		private MMReferenceHolder<T> _instances;

		private T _typed;

		protected virtual T Typed
		{
			get
			{
				T obj = _typed ?? (this as T);
				T result = obj;
				_typed = obj;
				return result;
			}
		}

		protected virtual void OnReferenced()
		{
		}

		protected virtual void OnEnable()
		{
			_instances.Reference(Typed);
			OnReferenced();
		}

		protected virtual void OnDisposed()
		{
		}

		protected virtual void OnDisable()
		{
			_instances.Dispose();
			OnDisposed();
		}
	}
}
