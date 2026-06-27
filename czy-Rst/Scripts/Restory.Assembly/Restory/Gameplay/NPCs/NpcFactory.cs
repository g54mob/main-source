using Restory.Gameplay.Common;
using Zenject;

namespace Restory.Gameplay.NPCs
{
	public class NpcFactory : GameObjectsFactoryBase
	{
		public NpcFactory(DiContainer diContainer)
			: base(diContainer)
		{
		}
	}
}
