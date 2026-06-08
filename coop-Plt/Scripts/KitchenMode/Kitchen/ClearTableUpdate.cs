using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(TableUpdatesGroup), OrderLast = true)]
	public class ClearTableUpdate : TableUpdateSystem
	{
		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SPerformTableUpdate_10;

		protected override void OnUpdate()
		{
			Entity singletonEntity = _SingletonEntityQuery_SPerformTableUpdate_10.GetSingletonEntity();
			base.EntityManager.DestroyEntity(singletonEntity);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SPerformTableUpdate_10 = GetEntityQuery(ComponentType.ReadOnly<SPerformTableUpdate>());
		}
	}
}
