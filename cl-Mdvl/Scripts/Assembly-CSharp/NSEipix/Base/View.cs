using Controller;
using UnityEngine;

namespace NSEipix.Base
{
	public class View : MonoBehaviour, IPauseGame
	{
		public virtual string GetID()
		{
			return string.Empty;
		}
	}
}
