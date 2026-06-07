using UnityEngine;

namespace VoxelBusters.CoreLibrary
{
	public abstract class SingletonBehaviour<T> : PrivateSingletonBehaviour<T> where T : MonoBehaviour
	{
		public static T Instance => null;
	}
}
