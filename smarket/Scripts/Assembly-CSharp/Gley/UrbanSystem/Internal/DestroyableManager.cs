using System.Collections.Generic;

namespace Gley.UrbanSystem.Internal
{
	public class DestroyableManager
	{
		private static DestroyableManager _instance;

		private List<IDestroyable> _destroyables;

		public static DestroyableManager Instance => null;

		public void Register(IDestroyable destroyable)
		{
		}

		public void Unregister(IDestroyable destroyable)
		{
		}

		public void DestroyAll()
		{
		}
	}
}
