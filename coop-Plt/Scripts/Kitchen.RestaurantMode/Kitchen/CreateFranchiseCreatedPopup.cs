using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateInGroup(typeof(EndOfDayProgressionGroup))]
	[UpdateAfter(typeof(CreateStarIncreasePopup))]
	public class CreateFranchiseCreatedPopup : StartOfNightSystem
	{
		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SDay_46;

		protected override void OnUpdate()
		{
			if (!HasSingleton<SIsRestartedDay>() && _SingletonEntityQuery_SDay_46.GetSingleton<SDay>().Day == 15)
			{
				Entity entity = base.EntityManager.CreateEntity(typeof(CPopup), typeof(CHideView), typeof(CFranchiseCreatedPopup), typeof(CStarIncreasePopup), typeof(CRequiresView), typeof(CPosition), typeof(CCaptureInput));
				base.EntityManager.SetComponentData(entity, new CPopup
				{
					Priority = PopupPriority.FranchiseCreated
				});
				base.EntityManager.SetComponentData(entity, new CCaptureInput
				{
					AllUsers = true
				});
				base.EntityManager.SetComponentData(entity, new CStarIncreasePopup
				{
					StarCount = 5
				});
				base.EntityManager.SetComponentData(entity, new CRequiresView
				{
					Type = ViewType.FranchiseCreatedPopup,
					ViewMode = ViewMode.Screen
				});
				base.EntityManager.SetComponentData(entity, new CPosition(new Vector3(0.5f, 0.5f, 0f)));
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SDay_46 = GetEntityQuery(ComponentType.ReadOnly<SDay>());
		}
	}
}
