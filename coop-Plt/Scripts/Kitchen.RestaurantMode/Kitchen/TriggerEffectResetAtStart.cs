using Unity.Entities;

namespace Kitchen
{
	[UpdateBefore(typeof(ResetEffects))]
	[UpdateInGroup(typeof(EffectsGroup), OrderFirst = true)]
	public class TriggerEffectResetAtStart : GameSystemBase
	{
		protected override void OnUpdate()
		{
			if ((HasSingleton<SIsNightTime>() || HasSingleton<SIsDayFirstUpdate>()) && !HasSingleton<SRequireEffectUpdate>())
			{
				Entity e = base.EntityManager.CreateEntity(typeof(SRequireEffectUpdate));
				GetCommandBuffer(ECB.End).DestroyEntity(e);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
