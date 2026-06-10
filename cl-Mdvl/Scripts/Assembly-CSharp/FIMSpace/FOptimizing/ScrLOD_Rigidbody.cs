using UnityEngine;

namespace FIMSpace.FOptimizing
{
	public sealed class ScrLOD_Rigidbody : ScrLOD_Base
	{
		[SerializeField]
		private LODI_Rigidbody settings;

		public override ILODInstance GetLODInstance()
		{
			return settings;
		}

		public ScrLOD_Rigidbody()
		{
			settings = new LODI_Rigidbody();
		}

		public override ScrLOD_Base GetScrLODInstance()
		{
			return ScriptableObject.CreateInstance<ScrLOD_Rigidbody>();
		}

		public override ScrLOD_Base CreateNewScrCopy()
		{
			ScrLOD_Rigidbody scrLOD_Rigidbody = ScriptableObject.CreateInstance<ScrLOD_Rigidbody>();
			scrLOD_Rigidbody.settings = settings.GetCopy() as LODI_Rigidbody;
			return scrLOD_Rigidbody;
		}

		public override ScriptableLODsController GenerateLODController(Component target, ScriptableOptimizer optimizer)
		{
			Rigidbody rigidbody = target as Rigidbody;
			if (!rigidbody)
			{
				rigidbody = target.GetComponentInChildren<Rigidbody>();
			}
			if ((bool)rigidbody && !optimizer.ContainsComponent(rigidbody))
			{
				return new ScriptableLODsController(optimizer, rigidbody, -1, "Rigidbody", this);
			}
			return null;
		}
	}
}
