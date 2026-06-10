using UnityEngine;

namespace FIMSpace.FOptimizing
{
	public abstract class ScrLOD_Base : ScriptableObject
	{
		public abstract ILODInstance GetLODInstance();

		public abstract ScrLOD_Base CreateNewScrCopy();

		public abstract ScrLOD_Base GetScrLODInstance();

		public virtual ScriptableLODsController GenerateLODController(Component target, ScriptableOptimizer optimizer)
		{
			return null;
		}
	}
}
