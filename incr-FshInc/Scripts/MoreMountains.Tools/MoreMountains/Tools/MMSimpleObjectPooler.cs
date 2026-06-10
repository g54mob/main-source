using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MoreMountains.Tools
{
	[AddComponentMenu("More Mountains/Tools/Object Pool/MM Simple Object Pooler")]
	public class MMSimpleObjectPooler : MMObjectPooler
	{
		public GameObject GameObjectToPool;

		public int PoolSize = 20;

		public bool PoolCanExpand = true;

		public virtual List<MMSimpleObjectPooler> Owner { get; set; }

		private void OnDestroy()
		{
			Owner?.Remove(this);
		}

		public override void FillObjectPool()
		{
			if (!(GameObjectToPool == null) && (!(_objectPool != null) || _objectPool.PooledGameObjects.Count <= PoolSize))
			{
				CreateWaitingPool();
				int num = PoolSize;
				if (_objectPool != null)
				{
					num -= _objectPool.PooledGameObjects.Count;
				}
				for (int i = 0; i < num; i++)
				{
					AddOneObjectToThePool();
				}
			}
		}

		protected override string DetermineObjectPoolName()
		{
			return "[SimpleObjectPooler] " + GameObjectToPool.name;
		}

		public override GameObject GetPooledGameObject()
		{
			for (int i = 0; i < _objectPool.PooledGameObjects.Count; i++)
			{
				if (!_objectPool.PooledGameObjects[i].gameObject.activeInHierarchy)
				{
					return _objectPool.PooledGameObjects[i];
				}
			}
			if (PoolCanExpand)
			{
				return AddOneObjectToThePool();
			}
			return null;
		}

		protected virtual GameObject AddOneObjectToThePool()
		{
			if (GameObjectToPool == null)
			{
				Debug.LogWarning("The " + base.gameObject.name + " ObjectPooler doesn't have any GameObjectToPool defined.", base.gameObject);
				return null;
			}
			GameObject gameObject = MMGameObjectExtensions.MMInstantiateDisabled(GameObjectToPool);
			SceneManager.MoveGameObjectToScene(gameObject, base.gameObject.scene);
			if (NestWaitingPool)
			{
				gameObject.transform.SetParent(_waitingPool.transform);
			}
			gameObject.name = GameObjectToPool.name + "-" + _objectPool.PooledGameObjects.Count;
			_objectPool.PooledGameObjects.Add(gameObject);
			return gameObject;
		}
	}
}
