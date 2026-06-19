using System.Collections.Generic;
using UnityEngine;

namespace Aggro.Core
{
	public class TemplatePool : MonoBehaviour, IGameObjectPool
	{
		private Stack<GameObject> _pool = new Stack<GameObject>();

		public void Populate(int count)
		{
			while (_pool.Count < count)
			{
				GameObject gameObject = Object.Instantiate(base.gameObject, base.transform.parent);
				gameObject.SetActive(value: false);
				Object.Destroy(gameObject.GetComponent<TemplatePool>());
				_pool.Push(gameObject);
			}
		}

		public PoolableReference Get()
		{
			if (_pool.Count == 0)
			{
				Populate(1);
			}
			GameObject gameObject = _pool.Pop();
			gameObject.SetActive(value: true);
			gameObject.transform.SetAsLastSibling();
			return new PoolableReference
			{
				obj = gameObject,
				pool = this
			};
		}

		public void Release(GameObject obj)
		{
			obj.SetActive(value: false);
			_pool.Push(obj);
		}
	}
}
