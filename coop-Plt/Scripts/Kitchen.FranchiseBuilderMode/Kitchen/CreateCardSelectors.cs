using System.Linq;
using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class CreateCardSelectors : FranchiseBuilderFirstFrameSystem
	{
		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SEndgameStats_0;

		public static bool ShouldCreateSelector(CEndgameUnlock unlock)
		{
			if (unlock.FromFranchise)
			{
				return false;
			}
			return unlock.Type switch
			{
				CardType.FranchiseTier => true, 
				CardType.HalloweenTrick => true, 
				CardType.Default => true, 
				_ => false, 
			};
		}

		protected override void OnUpdate()
		{
			Entity singletonEntity = _SingletonEntityQuery_SEndgameStats_0.GetSingletonEntity();
			_SingletonEntityQuery_SEndgameStats_0.GetSingleton<SEndgameStats>();
			NativeArray<CEndgameUnlock> nativeArray = GetBuffer<CEndgameUnlock>(singletonEntity).ToNativeArray(Allocator.Temp);
			int card_row_width = Mathf.Min(10, nativeArray.Count(ShouldCreateSelector));
			Vector3 vector = new Vector3(0f, 0f, 2f);
			Vector3 p0 = new Vector3(-1f, 0f, 0f) * card_row_width;
			Vector3 p1 = new Vector3(0f, 0f, 2f);
			Vector3 p2 = new Vector3(1f, 0f, 0f) * card_row_width;
			int num = 0;
			foreach (CEndgameUnlock item in nativeArray)
			{
				if (ShouldCreateSelector(item) && GameData.Main.TryGet<Unlock>(item.UnlockID, out var output) && !(output.ParentOption != null))
				{
					Vector3 vector2 = num / 10 * new Vector3(0.5f, 0f, 2f);
					int index = num % 10;
					if (is_forced_card(item))
					{
						CreateCardSource(vector + bezier(index) + vector2, item.UnlockID, selected: true, forced_card: true);
					}
					else
					{
						CreateCardSource(vector + bezier(index) + vector2, item.UnlockID, num < 3);
					}
					num++;
				}
			}
			nativeArray.Dispose();
			Vector3 bezier(int num3)
			{
				if (card_row_width == 1)
				{
					return Vector3.zero;
				}
				float num2 = (float)num3 / (float)(card_row_width - 1);
				float num4 = 1f - num2;
				return num4 * (num4 * p0 + num2 * p1) + num2 * (num4 * p1 + num2 * p2);
			}
			static bool is_forced_card(CEndgameUnlock unlock)
			{
				return unlock.Type == CardType.FranchiseTier;
			}
		}

		private void CreateCardSource(Vector3 location, int card, bool selected, bool forced_card = false)
		{
			EntityManager entityManager = base.EntityManager;
			Entity entity = entityManager.CreateEntity(typeof(CCreateAppliance), typeof(CPosition), typeof(CItemHolder), typeof(CPreventItemTransfer), typeof(CCardPedestal), typeof(CMaintainInView));
			entityManager.SetComponentData(entity, new CCreateAppliance
			{
				ID = AssetReference.CardSelector
			});
			entityManager.SetComponentData(entity, new CPosition(location));
			entityManager.SetComponentData(entity, new CMaintainInView
			{
				Radius = 3f
			});
			entityManager.SetComponentData(entity, new CCardPedestal
			{
				IsForcedCard = forced_card,
				CardID = card,
				IsSelected = selected
			});
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SEndgameStats_0 = GetEntityQuery(ComponentType.ReadOnly<SEndgameStats>());
		}
	}
}
