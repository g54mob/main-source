using Unity.Entities;

namespace Kitchen.ShopBuilder
{
	[UpdateInGroup(typeof(ShopOptionGroup))]
	public abstract class ShopBuilderFilter : GameSystemBase
	{
		private bool RequireRebuild;

		protected abstract void Filter();

		protected virtual void BeforeRun()
		{
		}

		protected virtual void AfterRun()
		{
		}

		protected virtual void OnStartOfDay()
		{
		}

		protected override void OnUpdate()
		{
			if (Has<SIsDayFirstUpdate>() || RequireRebuild)
			{
				OnStartOfDay();
				RequireRebuild = false;
			}
			BeforeRun();
			Filter();
			AfterRun();
		}

		public override void AfterLoading(SaveSystemType system_type)
		{
			RequireRebuild = true;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
