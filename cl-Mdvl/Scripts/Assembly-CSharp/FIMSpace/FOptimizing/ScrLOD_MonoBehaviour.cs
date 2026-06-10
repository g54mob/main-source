using UnityEngine;

namespace FIMSpace.FOptimizing
{
	public sealed class ScrLOD_MonoBehaviour : ScrLOD_Base
	{
		[SerializeField]
		private LODI_MonoBehaviour settings;

		public override ILODInstance GetLODInstance()
		{
			return settings;
		}

		public ScrLOD_MonoBehaviour()
		{
			settings = new LODI_MonoBehaviour();
		}

		public override ScrLOD_Base GetScrLODInstance()
		{
			return ScriptableObject.CreateInstance<ScrLOD_MonoBehaviour>();
		}

		public override ScrLOD_Base CreateNewScrCopy()
		{
			ScrLOD_MonoBehaviour scrLOD_MonoBehaviour = ScriptableObject.CreateInstance<ScrLOD_MonoBehaviour>();
			scrLOD_MonoBehaviour.settings = settings.GetCopy() as LODI_MonoBehaviour;
			return scrLOD_MonoBehaviour;
		}

		public override ScriptableLODsController GenerateLODController(Component target, ScriptableOptimizer optimizer)
		{
			MonoBehaviour monoBehaviour = target as MonoBehaviour;
			if (!monoBehaviour)
			{
				monoBehaviour = target.GetComponentInChildren<MonoBehaviour>();
			}
			if ((bool)monoBehaviour && !optimizer.ContainsComponent(monoBehaviour))
			{
				return new ScriptableLODsController(optimizer, monoBehaviour, -1, "Custom Component", this);
			}
			return null;
		}
	}
}
