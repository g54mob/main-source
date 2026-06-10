using UnityEngine;

namespace FIMSpace.FOptimizing
{
	public sealed class ScrLOD_UnityLODGroup : ScrLOD_Base
	{
		[SerializeField]
		private LODI_UnityLOD settings;

		public override ILODInstance GetLODInstance()
		{
			return settings;
		}

		public ScrLOD_UnityLODGroup()
		{
			settings = new LODI_UnityLOD();
		}

		public override ScrLOD_Base GetScrLODInstance()
		{
			return ScriptableObject.CreateInstance<ScrLOD_UnityLODGroup>();
		}

		public override ScrLOD_Base CreateNewScrCopy()
		{
			ScrLOD_UnityLODGroup scrLOD_UnityLODGroup = ScriptableObject.CreateInstance<ScrLOD_UnityLODGroup>();
			scrLOD_UnityLODGroup.settings = settings.GetCopy() as LODI_UnityLOD;
			return scrLOD_UnityLODGroup;
		}

		public override ScriptableLODsController GenerateLODController(Component target, ScriptableOptimizer optimizer)
		{
			LODGroup lODGroup = target as LODGroup;
			if (!lODGroup)
			{
				lODGroup = target.GetComponent<LODGroup>();
			}
			if ((bool)lODGroup && !optimizer.ContainsComponent(lODGroup))
			{
				return new ScriptableLODsController(optimizer, lODGroup, -1, "UnityLODGroup", this);
			}
			return null;
		}
	}
}
