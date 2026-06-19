using UnityEngine;

namespace PugMod
{
	public interface IMod
	{
		void EarlyInit();

		void Init();

		void Shutdown();

		void ModObjectLoaded(Object obj);

		bool CanBeUnloaded()
		{
			return false;
		}

		void Update();
	}
}
