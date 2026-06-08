using Unity.Entities;

namespace Kitchen
{
	[UpdateBefore(typeof(DetermineEffectsGroup))]
	[UpdateBefore(typeof(ApplyEffectsGroup))]
	[UpdateInGroup(typeof(EffectsGroup))]
	public class ActivateEffectsGroup : ComponentSystemGroup
	{
		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
