using UnityEngine;

namespace Kitchen.Conversions
{
	public class ConvertStatus : GameSystemBase
	{
		protected override void OnUpdate()
		{
		}

		public override void AfterLoading(SaveSystemType system_type)
		{
			base.AfterLoading(system_type);
			if (Require<SGlobalStatus>(out var comp) && RequireEntity<SGlobalStatus>(out var comp2))
			{
				Debug.LogWarning("Detected old status save, converting to new format");
				Set(new SGlobalStatusList(comp));
				base.EntityManager.DestroyEntity(comp2);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
