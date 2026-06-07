using QFSW.MOP2;
using UnityEngine;

namespace VampireSurvivors.Objects
{
	public class BasePoolableSpriteBehaviour : ArcadeSprite, IPoolable
	{
		[SerializeField]
		[HideInInspector]
		private ObjectPool _ParentPool;

		public bool PoolReady => false;

		void IPoolable.InitializeTemplate(ObjectPool pool)
		{
		}

		public void Release()
		{
		}
	}
}
