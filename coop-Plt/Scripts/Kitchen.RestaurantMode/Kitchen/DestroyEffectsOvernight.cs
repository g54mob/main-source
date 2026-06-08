using Unity.Entities;

namespace Kitchen
{
	public class DestroyEffectsOvernight : NightSystem
	{
		private EntityQuery Effects;

		protected override void Initialise()
		{
			base.Initialise();
			Effects = GetEntityQuery(typeof(CDestroyEffectOvernight));
		}

		protected override void OnUpdate()
		{
			base.EntityManager.DestroyEntity(Effects);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
