using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class PreventPausesAtNight : RestaurantSystem
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct SPreventNightPause : IComponentData
		{
		}

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SPreventNightPause_17;

		protected override void OnUpdate()
		{
			if (!HasSingleton<SPreventNightPause>())
			{
				base.EntityManager.CreateEntity(typeof(SPreventNightPause));
			}
			Entity singletonEntity = _SingletonEntityQuery_SPreventNightPause_17.GetSingletonEntity();
			bool flag = HasSingleton<SIsNightTime>();
			if (flag && !HasComponent<CGamePauseBlock>(singletonEntity))
			{
				base.EntityManager.AddComponent<CGamePauseBlock>(singletonEntity);
			}
			else if (!flag && HasComponent<CGamePauseBlock>(singletonEntity))
			{
				base.EntityManager.RemoveComponent<CGamePauseBlock>(singletonEntity);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SPreventNightPause_17 = GetEntityQuery(ComponentType.ReadOnly<SPreventNightPause>());
		}
	}
}
