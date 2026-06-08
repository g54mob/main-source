using Unity.Entities;

namespace Kitchen
{
	public class CleanDecorationEvents : GameSystemBase
	{
		private EntityQuery UpdateDecorationEvents;

		protected override void Initialise()
		{
			base.Initialise();
			UpdateDecorationEvents = GetEntityQuery(typeof(CChangeDecorEvent));
		}

		protected override void OnUpdate()
		{
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
