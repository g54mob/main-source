using KitchenData;
using Platforms;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[UpdateInGroup(typeof(EndOfDayProgressionGroup))]
	public class CreateEndOfDayPopup : StartOfNightSystem
	{
		private EntityQuery Players;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SDay_8;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SMoney_9;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SMoneyEarningsTracker_10;

		protected override void Initialise()
		{
			base.Initialise();
			Players = GetEntityQuery(typeof(CPlayer));
		}

		protected override void OnUpdate()
		{
			if (!HasSingleton<SIsRestartedDay>() && _SingletonEntityQuery_SDay_8.GetSingleton<SDay>().Day != 0)
			{
				SMoney singleton = _SingletonEntityQuery_SMoney_9.GetSingleton<SMoney>();
				int oldAmount = _SingletonEntityQuery_SMoneyEarningsTracker_10.GetSingleton<SMoneyEarningsTracker>().OldAmount;
				int num = (int)singleton - oldAmount;
				float num2 = DifficultyHelpers.MoneyRewardPlayerModifier(Players.CalculateEntityCount());
				int num3 = Mathf.CeilToInt((float)num * (num2 - 1f));
				singleton.Amount += num3;
				Set(singleton);
				if (PlatformSettings.IsDemoMode && _SingletonEntityQuery_SDay_8.GetSingleton<SDay>().Day >= 6)
				{
					base.PopupUtilities.RequestManagedPopup(PopupType.EndDemoPopup);
					return;
				}
				base.PopupUtilities.RequestManagedPopup(PopupType.EndDayPopup, new CPopupEndDayData
				{
					Base = num,
					PlayerBonus = num3
				});
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SDay_8 = GetEntityQuery(ComponentType.ReadOnly<SDay>());
			_SingletonEntityQuery_SMoney_9 = GetEntityQuery(ComponentType.ReadOnly<SMoney>());
			_SingletonEntityQuery_SMoneyEarningsTracker_10 = GetEntityQuery(ComponentType.ReadOnly<SMoneyEarningsTracker>());
		}
	}
}
