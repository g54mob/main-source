using QFSW.MOP2;
using UnityEngine;

namespace VampireSurvivors.Framework.Phaser
{
	public class PoolablePhaserSprite : PhaserSprite, IPoolable
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
