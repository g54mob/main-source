using Platforms;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(EndOfDayProgressionGroup))]
	[UpdateAfter(typeof(CreateStarIncreasePopup))]
	public class CreateUnlockChoicePopup : NightSystem
	{
		private EntityQuery ProgressionOption;

		private EntityQuery UnlockPopups;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SDay_48;

		protected override void Initialise()
		{
			base.Initialise();
			ProgressionOption = GetEntityQuery(new QueryHelper().All(typeof(CProgressionOption)).None(typeof(CProgressionOption.Displayed)));
			UnlockPopups = GetEntityQuery(typeof(CUnlockSelectPopup));
		}

		protected override void OnUpdate()
		{
			if (!UnlockPopups.IsEmpty || ProgressionOption.IsEmpty || (PlatformSettings.IsDemoMode && _SingletonEntityQuery_SDay_48.GetSingleton<SDay>().Day >= 6))
			{
				return;
			}
			NativeArray<CProgressionOption> nativeArray = ProgressionOption.ToComponentDataArray<CProgressionOption>(Allocator.Temp);
			NativeArray<Entity> nativeArray2 = ProgressionOption.ToEntityArray(Allocator.Temp);
			Entity entity = base.EntityManager.CreateEntity(typeof(CPopup), typeof(CHideView), typeof(CUnlockSelectPopup), typeof(CRequiresView), typeof(CCaptureInput));
			base.EntityManager.SetComponentData(entity, new CPopup
			{
				Priority = PopupPriority.UnlockChoice
			});
			base.EntityManager.SetComponentData(entity, new CCaptureInput
			{
				AllUsers = true
			});
			base.EntityManager.SetComponentData(entity, new CRequiresView
			{
				ViewMode = ViewMode.Screen,
				Type = ViewType.UnlockSelectionPopup
			});
			DynamicBuffer<CUnlockSelectPopupOption> dynamicBuffer = base.EntityManager.AddBuffer<CUnlockSelectPopupOption>(entity);
			UnlockRewardType rewardType = UnlockRewardType.Standard;
			for (int i = 0; i < nativeArray.Length; i++)
			{
				CProgressionOption cProgressionOption = nativeArray[i];
				dynamicBuffer.Add(new CUnlockSelectPopupOption
				{
					ID = cProgressionOption.ID,
					Entity = nativeArray2[i]
				});
				if (Require<CUnlockSelectPopupType>(nativeArray2[i], out CUnlockSelectPopupType comp))
				{
					rewardType = comp.RewardType;
				}
			}
			Set(entity, new CUnlockSelectPopupType
			{
				RewardType = rewardType
			});
			base.EntityManager.AddComponent<CProgressionOption.Displayed>(ProgressionOption);
			nativeArray.Dispose();
			nativeArray2.Dispose();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SDay_48 = GetEntityQuery(ComponentType.ReadOnly<SDay>());
		}
	}
}
