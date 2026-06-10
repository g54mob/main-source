using UnityEngine;

namespace FIMSpace.FOptimizing
{
	public sealed class ScrLOD_Light : ScrLOD_Base
	{
		[SerializeField]
		private LODI_Light settings;

		public override ILODInstance GetLODInstance()
		{
			return settings;
		}

		public ScrLOD_Light()
		{
			settings = new LODI_Light();
		}

		public override ScrLOD_Base GetScrLODInstance()
		{
			return ScriptableObject.CreateInstance<ScrLOD_Light>();
		}

		public override ScrLOD_Base CreateNewScrCopy()
		{
			ScrLOD_Light scrLOD_Light = ScriptableObject.CreateInstance<ScrLOD_Light>();
			scrLOD_Light.settings = settings.GetCopy() as LODI_Light;
			return scrLOD_Light;
		}

		public override ScriptableLODsController GenerateLODController(Component target, ScriptableOptimizer optimizer)
		{
			Light light = target as Light;
			if (!light)
			{
				light = target.gameObject.GetComponentInChildren<Light>();
			}
			if ((bool)light && !optimizer.ContainsComponent(light))
			{
				return new ScriptableLODsController(optimizer, light, -1, "Light Properties", this);
			}
			return null;
		}
	}
}
