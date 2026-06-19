using UnityEngine;

namespace Aggro.Core
{
	internal interface IGameObjectPool
	{
		void Release(GameObject obj);
	}
}
