using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(CreationGroup))]
	public class ResetGameTime : RestaurantInitialisationSystem
	{
		protected override void OnUpdate()
		{
			UpdateTime.Reset(base.EntityManager);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
