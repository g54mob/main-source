using Assets.Nimbatus.Scripts.Common.MiniMap;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects;

namespace Assets.Nimbatus.Scripts.Characters.Player
{
	public class NimbatusSpaceShip : NimbatusWorldObject
	{
		public static NimbatusSpaceShip Instance;

		protected override void Awake()
		{
			base.Awake();
			Instance = this;
			if (BaseSingleton<Minimap>.Instance != null)
			{
				BaseSingleton<Minimap>.Instance.MaxWorldSize = base.transform.position.y * 1.2f;
			}
		}
	}
}
