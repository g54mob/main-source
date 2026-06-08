using Unity.Entities;

namespace Kitchen
{
	[UpdateAfter(typeof(DetermineEffectsGroup))]
	[UpdateAfter(typeof(ActivateEffectsGroup))]
	[UpdateInGroup(typeof(EffectsGroup))]
	public class ApplyEffectsGroup : ComponentSystemGroup
	{
		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
