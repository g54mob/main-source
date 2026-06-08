using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateAfter(typeof(FindNewUnlocks))]
	[UpdateInGroup(typeof(EndOfDayProgressionGroup))]
	public class CreateStarIncreasePopup : StartOfNightSystem
	{
		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SDay_47;

		protected override void OnUpdate()
		{
			if (!HasSingleton<SIsRestartedDay>())
			{
				int day = _SingletonEntityQuery_SDay_47.GetSingleton<SDay>().Day;
				if (day % 3 == 0 && day < 15)
				{
					Entity entity = base.EntityManager.CreateEntity(typeof(CPopup), typeof(CHideView), typeof(CStarIncreasePopup), typeof(CRequiresView), typeof(CPosition), typeof(CCaptureInput));
					base.EntityManager.SetComponentData(entity, new CPopup
					{
						Priority = PopupPriority.StarIncrease
					});
					base.EntityManager.SetComponentData(entity, new CStarIncreasePopup
					{
						StarCount = Mathf.FloorToInt(day / 3)
					});
					base.EntityManager.SetComponentData(entity, new CCaptureInput
					{
						AllUsers = true
					});
					base.EntityManager.SetComponentData(entity, new CRequiresView
					{
						Type = ViewType.StarUnlockPopup,
						ViewMode = ViewMode.Screen
					});
					base.EntityManager.SetComponentData(entity, new CPosition(new Vector3(0.5f, 0.5f, 0f)));
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SDay_47 = GetEntityQuery(ComponentType.ReadOnly<SDay>());
		}
	}
}
