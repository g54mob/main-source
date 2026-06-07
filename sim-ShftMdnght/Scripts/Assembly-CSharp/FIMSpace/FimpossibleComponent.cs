using UnityEngine;

namespace FIMSpace
{
	public abstract class FimpossibleComponent : MonoBehaviour
	{
		public virtual string HeaderInfo => "";

		public virtual void OnValidate()
		{
		}
	}
}
