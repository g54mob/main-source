using UnityEngine;

namespace FIMSpace.FOptimizing
{
	public sealed class ScrLOD_Renderer : ScrLOD_Base
	{
		[SerializeField]
		private LODI_Renderer settings;

		public override ILODInstance GetLODInstance()
		{
			return settings;
		}

		public ScrLOD_Renderer()
		{
			settings = new LODI_Renderer();
		}

		public override ScrLOD_Base GetScrLODInstance()
		{
			return ScriptableObject.CreateInstance<ScrLOD_Renderer>();
		}

		public override ScrLOD_Base CreateNewScrCopy()
		{
			ScrLOD_Renderer scrLOD_Renderer = ScriptableObject.CreateInstance<ScrLOD_Renderer>();
			scrLOD_Renderer.settings = settings.GetCopy() as LODI_Renderer;
			return scrLOD_Renderer;
		}

		public override ScriptableLODsController GenerateLODController(Component target, ScriptableOptimizer optimizer)
		{
			Renderer renderer = target as Renderer;
			if (!renderer)
			{
				renderer = target.GetComponent<Renderer>();
			}
			if ((bool)renderer && !optimizer.ContainsComponent(renderer))
			{
				return new ScriptableLODsController(optimizer, renderer, -1, "MeshRenderer", this);
			}
			return null;
		}
	}
}
