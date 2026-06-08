using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public class ActivateBeginSelector : FranchiseSystem
	{
		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SLoadoutStatus_11;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SBeginGameSelector_12;

		protected override void OnUpdate()
		{
			if (!Has<SBeginGameSelector>())
			{
				return;
			}
			bool isReady = _SingletonEntityQuery_SLoadoutStatus_11.GetSingleton<SLoadoutStatus>().IsReady;
			Entity singletonEntity = _SingletonEntityQuery_SBeginGameSelector_12.GetSingletonEntity();
			if (HasComponent<CSelectorEnabled>(singletonEntity))
			{
				if (!isReady)
				{
					base.EntityManager.RemoveComponent<CSelectorEnabled>(singletonEntity);
				}
			}
			else if (isReady)
			{
				base.EntityManager.AddComponent<CSelectorEnabled>(singletonEntity);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SLoadoutStatus_11 = GetEntityQuery(ComponentType.ReadOnly<SLoadoutStatus>());
			_SingletonEntityQuery_SBeginGameSelector_12 = GetEntityQuery(ComponentType.ReadOnly<SBeginGameSelector>());
		}
	}
}
