using System.Collections.Generic;
using System.Linq;
using KitchenData;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class DetectSeedFunction : FranchiseSystem
	{
		private EntityQuery SeedFixers;

		private EntityQuery SaveSlots;

		private EntityQuery Players;

		private int CheatCounter;

		private bool CheatNeedsPlate;

		[ReadOnly]
		private EntityQuery _SingletonEntityQuery_SEndgameStats_0;

		private EntityQuery _SingletonEntityQuery_SEndgameStats_1;

		protected override void Initialise()
		{
			base.Initialise();
			SeedFixers = ((ComponentSystemBase)(object)this).GetEntityQuery(new ComponentType[1] { typeof(CSeededRunInfo) });
			SaveSlots = ((ComponentSystemBase)(object)this).GetEntityQuery(new ComponentType[1] { typeof(CLocationChoice) });
			Players = ((ComponentSystemBase)(object)this).GetEntityQuery(new ComponentType[2]
			{
				typeof(CPlayer),
				typeof(CItemHolder)
			});
		}

		protected override void OnUpdate()
		{
			if (SeedFixers.IsEmpty)
			{
				using (EntityLookup<CPlayer, CItemHolder, NullType> entityLookup = EntityLookup.Create<CPlayer, CItemHolder>(Players))
				{
					foreach (EntityData<CPlayer, CItemHolder, NullType> item in entityLookup.Iterate())
					{
						CItem comp;
						bool flag = ((GenericSystemBase)(object)this).Require<CItem>(item.Value2.HeldItem, out comp);
						if ((CheatNeedsPlate && comp.ID == AssetReference.Plate) || (!CheatNeedsPlate && !flag))
						{
							CheatNeedsPlate = !CheatNeedsPlate;
							CheatCounter++;
						}
						if (comp.ID != 0 && comp.ID != AssetReference.Plate)
						{
							CheatCounter = 0;
						}
					}
					if (CheatCounter > 10)
					{
						Entity entity = Create(AssetReference.SeededRunIndicator, LobbyPositionAnchors.Office + new Vector3(-2f, 0f, 0f), Vector3.forward);
						((ComponentSystemBase)(object)this).EntityManager.AddComponent<CSeededRunInfo>(entity);
					}
					return;
				}
			}
			Entity e = SeedFixers.First();
			string text = SeedFixers.First<CSeededRunInfo>().FixedSeed.Value.ToString();
			bool flag2 = ((GenericSystemBase)(object)this).Has<CShowFunctionMode>(e);
			if (text == "edcrfvtg")
			{
				((GenericSystemBase)(object)this).Set<CSeededRunInfo>(e, default(CSeededRunInfo));
				((GenericSystemBase)(object)this).Set<CShowFunctionMode>(e, default(CShowFunctionMode));
			}
			else if (flag2 && HandleEntry(text))
			{
				((GenericSystemBase)(object)this).Set<CSeededRunInfo>(e, default(CSeededRunInfo));
				((GenericSystemBase)(object)this).Set<CRequestSave>(((ComponentSystemBase)(object)this).EntityManager.CreateEntity(), new CRequestSave
				{
					SaveType = SaveType.Auto
				});
			}
		}

		public bool HandleEntry(string value)
		{
			switch (value)
			{
			case "boost":
			{
				((GenericSystemBase)(object)this).Require<SPlayerLevel>(out SPlayerLevel comp);
				if (comp.Level < 15)
				{
					comp.Level = 15;
					comp.ExpProgress = 0;
					((GenericSystemBase)(object)this).Set<SPlayerLevel>(comp);
				}
				return true;
			}
			case "log":
			{
				NetworkDebugView.Mode displayMode = ((NetworkDebugView.DisplayMode != NetworkDebugView.Mode.Debug) ? NetworkDebugView.Mode.Debug : NetworkDebugView.Mode.Off);
				NetworkDebugView.DisplayMode = displayMode;
				return true;
			}
			case "ach":
				NetworkDebugView.DisplayMode = NetworkDebugView.Mode.Achievements;
				return true;
			case "clear1":
				ClearSlot(1);
				return true;
			case "clear2":
				ClearSlot(2);
				return true;
			case "clear3":
				ClearSlot(3);
				return true;
			case "clear4":
				ClearSlot(4);
				return true;
			case "clear5":
				ClearSlot(5);
				return true;
			default:
				if (value == "franc")
				{
					LossAtDay(20, new List<Unlock>(), Enumerable.Repeat(GameData.Main.Get<Unlock>(165138001), 5).ToList(), "Franchise Test");
					return true;
				}
				return false;
			}
		}

		private void ClearSlot(int i)
		{
			Entity entity = SaveSlots.FirstMatchingEntity((CLocationChoice e) => e.Slot == i);
			if (!(entity == default(Entity)))
			{
				CLocationChoice cLocationChoice = new CLocationChoice
				{
					State = SaveState.Empty,
					Slot = i
				};
				Persistence.FullWorld.Clear(i);
				((GenericSystemBase)(object)this).Set<CLocationChoice>(entity, cLocationChoice);
				if (!((GenericSystemBase)(object)this).GetOrDefault<SSelectedLocation>().Valid)
				{
					((GenericSystemBase)(object)this).Set<SSelectedLocation>(new SSelectedLocation
					{
						Valid = true,
						Selected = cLocationChoice
					});
				}
			}
		}

		public void LossAtDay(int day, List<Unlock> franchise_unlocks, List<Unlock> unlocks, string name = "", int tier = 0)
		{
			if (((ComponentSystemBase)(object)this).HasSingleton<SEndgameStats>())
			{
				((ComponentSystemBase)(object)this).EntityManager.DestroyEntity(_SingletonEntityQuery_SEndgameStats_0.GetSingletonEntity());
			}
			Entity entity = ((ComponentSystemBase)(object)this).EntityManager.CreateEntity(typeof(SEndgameStats), typeof(CSceneChangeData), typeof(CEndgameUnlock));
			_SingletonEntityQuery_SEndgameStats_1.SetSingleton(new SEndgameStats
			{
				DayReached = day,
				IsFranchiseCreation = (day > 15),
				FranchiseTier = tier,
				Name = name
			});
			DynamicBuffer<CEndgameUnlock> buffer = ((ComponentSystemBase)(object)this).EntityManager.GetBuffer<CEndgameUnlock>(entity);
			if (franchise_unlocks != null)
			{
				foreach (Unlock franchise_unlock in franchise_unlocks)
				{
					buffer.Add(new CEndgameUnlock
					{
						UnlockID = franchise_unlock.ID,
						FromFranchise = true,
						Type = franchise_unlock.CardType
					});
				}
			}
			if (unlocks != null)
			{
				foreach (Unlock unlock in unlocks)
				{
					buffer.Add(new CEndgameUnlock
					{
						UnlockID = unlock.ID,
						Type = unlock.CardType
					});
				}
			}
			((GenericSystemBase)(object)this).StartSceneTransition(SceneType.Postgame);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_SEndgameStats_0 = ((ComponentSystemBase)(object)this).GetEntityQuery(new ComponentType[1] { ComponentType.ReadOnly<SEndgameStats>() });
			_SingletonEntityQuery_SEndgameStats_1 = ((ComponentSystemBase)(object)this).GetEntityQuery(new ComponentType[1] { ComponentType.ReadWrite<SEndgameStats>() });
		}
	}
}
