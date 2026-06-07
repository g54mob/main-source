using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public abstract class TCopyRunner : MonoBehaviour
	{
		public abstract T GetRunner<T>();
	}
}
