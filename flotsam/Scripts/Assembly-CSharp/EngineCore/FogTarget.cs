using UnityEngine;

namespace EngineCore
{
	public abstract class FogTarget : MonoBehaviour
	{
		public virtual GlobalFogDefinition GetCurrentFogDefinition()
		{
			return null;
		}
	}
}
