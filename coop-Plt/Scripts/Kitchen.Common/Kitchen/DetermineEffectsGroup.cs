using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(EffectsGroup))]
	[UpdateBefore(typeof(ApplyEffectsGroup))]
	[UpdateAfter(typeof(ActivateEffectsGroup))]
	public class DetermineEffectsGroup : ComponentSystemGroup
	{
		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
