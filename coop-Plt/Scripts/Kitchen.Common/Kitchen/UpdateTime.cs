using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateInGroup(typeof(InitializationSystemGroup))]
	public class UpdateTime : GenericSystemBase
	{
		private EntityQuery PauseRequests;

		private EntityQuery PauseBlocks;

		protected override void Initialise()
		{
			base.Initialise();
			EntityContext ctx = new EntityContext(base.EntityManager);
			EnsureGameTime(ctx);
			EnsureGameTimePrecise(ctx);
			PauseRequests = GetEntityQuery(typeof(CGamePauseRequest));
			PauseBlocks = GetEntityQuery(typeof(CGamePauseBlock));
		}

		protected override void OnUpdate()
		{
			EntityContext ctx = new EntityContext(base.EntityManager);
			SGameTime data = EnsureGameTime(ctx, warn_if_missing: true);
			SGameTimePrecise data2 = EnsureGameTimePrecise(ctx);
			float num = Mathf.Clamp(UnityEngine.Time.unscaledDeltaTime, 0f, 0.25f);
			bool flag = (data.IsPaused = !PauseRequests.IsEmpty && PauseBlocks.IsEmpty);
			UnityEngine.Time.timeScale = ((!flag) ? 1 : 0);
			if (!flag)
			{
				data.DeltaTime = num * data.GameSpeed;
				data2.TotalTime += data.DeltaTime;
				data.TotalTime = (float)data2.TotalTime;
			}
			else
			{
				data.DeltaTime = 0f;
			}
			data.RealDeltaTime = num;
			data.RealTotalTime += data.RealDeltaTime;
			ctx.Set(data);
			ctx.Set(data2);
		}

		private static SGameTime EnsureGameTime(EntityContext ctx, bool warn_if_missing = false)
		{
			if (ctx.Require<SGameTime>(out var comp))
			{
				return comp;
			}
			if (warn_if_missing)
			{
				Debug.LogWarning("Had to recreate SGameTime, you may have loaded a corrupted save. Other things might not work");
			}
			Entity entity = ctx.CreateEntity();
			ctx.Add<CPersistThroughSceneChanges>(entity);
			comp = SGameTime.New();
			ctx.Set(entity, comp);
			return comp;
		}

		private SGameTimePrecise EnsureGameTimePrecise(EntityContext ctx)
		{
			if (ctx.Require<SGameTimePrecise>(out var comp))
			{
				return comp;
			}
			Entity entity = ctx.CreateEntity();
			ctx.Add<CPersistThroughSceneChanges>(entity);
			comp = default(SGameTimePrecise);
			if (ctx.Require<SGameTime>(out var comp2))
			{
				comp.TotalTime = comp2.TotalTime;
			}
			ctx.Set(entity, comp);
			return comp;
		}

		public static void Reset(EntityContext ctx)
		{
			ctx.Set(SGameTime.New());
			ctx.Set(default(SGameTimePrecise));
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
