using Unity.Entities;

namespace Kitchen
{
	public class ManageHiddenViews : GenericSystemBase
	{
		private EntityQuery UnhiddenViews;

		protected override void Initialise()
		{
			base.Initialise();
			UnhiddenViews = GetEntityQuery(typeof(CHideView), typeof(CLinkedView));
		}

		protected override void OnUpdate()
		{
			base.EntityManager.AddComponent<CRemoveView>(UnhiddenViews);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
