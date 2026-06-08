using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Kitchen.ChefConnector.Commands;
using KitchenData;
using Unity.Entities;
using UnityEngine;
using WebSocketSharp;

namespace Kitchen.ChefConnector
{
	[UpdateInGroup(typeof(PresentationSystemGroup))]
	public class ChefClient : GenericSystemBase
	{
		private interface IFlagManager
		{
			bool Has(ChefClient c);

			void Set(ChefClient c, bool exist);
		}

		private interface IValueManager
		{
			Func<ChefClient, int> Get { get; }

			Action<ChefClient, int> Set { get; }
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct FlagManager<T> : IFlagManager where T : struct, IComponentData
		{
			public bool Has(ChefClient c)
			{
				return c.Has<T>();
			}

			public void Set(ChefClient c, bool exist)
			{
				c.SetFlag<T>(exist);
			}
		}

		private struct ValueManager : IValueManager
		{
			public Func<ChefClient, int> Get { get; }

			public Action<ChefClient, int> Set { get; }

			public ValueManager(Func<ChefClient, int> getter, Action<ChefClient, int> setter)
			{
				Get = getter;
				Set = setter;
			}
		}

		private WebSocket WebSocket;

		private float UpdateRate = 0.5f;

		private float LastUpdate;

		private Queue<string> Messages = new Queue<string>();

		private Dictionary<string, IFlagManager> CheatFlags = new Dictionary<string, IFlagManager>
		{
			{
				"CHEAT_NO_LOSING",
				default(FlagManager<SCheatNoLosing>)
			},
			{
				"CHEAT_NO_PATIENCE",
				default(FlagManager<SCheatNoPatienceDecrease>)
			},
			{
				"CHEAT_INSTANT_PROCESSES",
				default(FlagManager<SCheatInstantProcesses>)
			},
			{
				"CHEAT_NO_BAD_PROCESSES",
				default(FlagManager<SCheatNoBadProcesses>)
			},
			{
				"CHEAT_NO_PROCESSES",
				default(FlagManager<SCheatNoProcesses>)
			}
		};

		private Dictionary<string, IValueManager> CheatValues = new Dictionary<string, IValueManager>
		{
			{
				"DAY",
				new ValueManager(delegate(ChefClient c)
				{
					c.Require<SDay>(out var comp);
					return comp.Day;
				}, delegate(ChefClient c, int v)
				{
					if (c.Has<SDay>())
					{
						c.Set(new SDay
						{
							Day = v
						});
					}
				})
			},
			{
				"MONEY",
				new ValueManager(delegate(ChefClient c)
				{
					c.Require<SMoney>(out var comp);
					return comp.Amount;
				}, delegate(ChefClient c, int v)
				{
					if (c.Has<SMoney>())
					{
						c.Set(new SMoney
						{
							Amount = v
						});
					}
				})
			},
			{
				"LEVEL",
				new ValueManager(delegate(ChefClient c)
				{
					c.Require<SPlayerLevel>(out var comp);
					return comp.Level;
				}, delegate(ChefClient c, int v)
				{
					if (c.Has<SPlayerLevel>())
					{
						c.Set(new SPlayerLevel
						{
							Level = v
						});
					}
				})
			}
		};

		private List<IChefIntegration> IntegrationHandlers = new List<IChefIntegration>();

		private EntityQuery _SingletonEntityQuery_STime_0;

		protected override void Initialise()
		{
		}

		private void Connect()
		{
			try
			{
				WebSocket = new WebSocket("ws://localhost:12392");
				WebSocket.Log.Output = delegate
				{
				};
				WebSocket.ConnectAsync();
				WebSocket.OnOpen += delegate
				{
					WebSocket.Send("UNITY_JOIN");
				};
				WebSocket.OnMessage += delegate(object sender, MessageEventArgs e)
				{
					Messages.Enqueue(e.Data);
				};
				WebSocket.OnClose += delegate
				{
					LastUpdate = UnityEngine.Time.realtimeSinceStartup + 10f;
				};
				WebSocket.OnError += delegate
				{
					LastUpdate = UnityEngine.Time.realtimeSinceStartup + 10f;
				};
			}
			catch (Exception)
			{
				LastUpdate = UnityEngine.Time.realtimeSinceStartup + 10f;
			}
		}

		private void Send(ChefUpdate message)
		{
			WebSocket.Send(JsonUtility.ToJson(message));
		}

		private void Send(string type, int message)
		{
			Send(new ChefUpdate
			{
				Type = type,
				Value = message
			});
		}

		private void Receive(string message)
		{
			if (message == "WEB_JOIN" || message == "UNITY_JOIN")
			{
				return;
			}
			try
			{
				ChefUpdate update = JsonUtility.FromJson<ChefUpdate>(message);
				if (!update.IsIntegration)
				{
					Handle(update);
					return;
				}
				ChefCommandUpdate update2 = JsonUtility.FromJson<ChefCommandUpdate>(message);
				HandleCommand(update2);
			}
			catch (Exception message2)
			{
				Debug.LogWarning("[Chef Connector] Malformed message (or failed handler): " + message);
				Debug.LogWarning(message2);
			}
		}

		protected override void OnUpdate()
		{
			while (Messages.Count > 0)
			{
				Receive(Messages.Dequeue());
			}
			bool flag = WebSocket != null && WebSocket.ReadyState == WebSocketState.Open;
			float num = (flag ? UpdateRate : 10f);
			if ((WebSocket != null && WebSocket.ReadyState == WebSocketState.Connecting) || LastUpdate > UnityEngine.Time.realtimeSinceStartup - num)
			{
				return;
			}
			LastUpdate = UnityEngine.Time.realtimeSinceStartup;
			if (!flag)
			{
				Connect();
				return;
			}
			foreach (KeyValuePair<string, IValueManager> cheatValue in CheatValues)
			{
				Send(cheatValue.Key, cheatValue.Value.Get(this));
			}
			foreach (KeyValuePair<string, IFlagManager> cheatFlag in CheatFlags)
			{
				Send(cheatFlag.Key, cheatFlag.Value.Has(this) ? 1 : 0);
			}
			UpdateCommands();
		}

		private bool HasFlag<T>() where T : struct, IComponentData
		{
			return Has<T>();
		}

		private void SetFlag<T>(bool exist) where T : struct, IComponentData
		{
			if (exist)
			{
				Set<T>();
			}
			if (!exist)
			{
				Clear<T>();
			}
		}

		public override void PostInitialisation()
		{
			IntegrationHandlers = new List<IChefIntegration>
			{
				base.EntityManager.World.GetExistingSystem<Visit>(),
				base.EntityManager.World.GetExistingSystem<Polls>()
			};
		}

		private void UpdateCommands()
		{
			foreach (IChefIntegration integrationHandler in IntegrationHandlers)
			{
				integrationHandler.SendMessages(WebSocket.Send);
			}
		}

		private void HandleCommand(ChefCommandUpdate update)
		{
			using List<IChefIntegration>.Enumerator enumerator = IntegrationHandlers.GetEnumerator();
			while (enumerator.MoveNext() && !enumerator.Current.Handle(update))
			{
			}
		}

		private void Handle(ChefUpdate update)
		{
			switch (update.Type)
			{
			case "REQUEST_DATA":
				SendDataUpdate();
				return;
			case "CREATE_APPLIANCE":
				AddAppliance(update.Value);
				return;
			case "ADD_CRATE":
				AddCrate(update.Value);
				return;
			case "ADD_BLUEPRINT":
				AddBlueprint(update.Value);
				return;
			case "CREATE_CARD":
				AddCard(update.Value);
				return;
			case "CREATE_CUSTOMERS":
				AddCustomer(update.Value);
				return;
			case "REMOVE_CUSTOMERS":
				RemoveCustomers();
				return;
			case "END_DAY":
				EndDay();
				return;
			case "SET_UI_VISIBILITY":
				LocalChefController.Main.SetUIVisibility((float)update.Value >= 0.5f);
				return;
			case "VISIT":
				return;
			}
			if (CheatValues.TryGetValue(update.Type, out var value))
			{
				value.Set(this, update.Value);
			}
			if (CheatFlags.TryGetValue(update.Type, out var value2))
			{
				value2.Set(this, update.Value == 1);
			}
		}

		private void SendDataUpdate()
		{
			ChefDataUpdate chefDataUpdate = new ChefDataUpdate
			{
				Type = "GAME_DATA",
				Appliances = new List<ChefDataValue>(),
				Cards = new List<ChefDataValue>()
			};
			foreach (Appliance item in GameData.Main.Get<Appliance>())
			{
				chefDataUpdate.Appliances.Add(new ChefDataValue
				{
					ID = item.ID,
					Name = item.Name
				});
			}
			foreach (Unlock item2 in GameData.Main.Get<Unlock>())
			{
				chefDataUpdate.Cards.Add(new ChefDataValue
				{
					ID = item2.ID,
					Name = (((UnityEngine.Object)(object)item2.Localisation != null) ? item2.Name : ((UnityEngine.Object)(object)item2).name)
				});
			}
			WebSocket.Send(JsonUtility.ToJson(chefDataUpdate));
		}

		public void AddCustomer(int n)
		{
			Entity entity = base.EntityManager.CreateEntity(typeof(CScheduledCustomer));
			base.EntityManager.AddComponentData(entity, new CScheduledCustomer
			{
				GroupSize = n,
				TimeOfDay = 0f
			});
		}

		private void AddAppliance(int id)
		{
			Entity entity = base.EntityManager.CreateEntity();
			base.EntityManager.AddComponentData(entity, new CCreateAppliance
			{
				ID = id
			});
			base.EntityManager.AddComponentData(entity, new CPosition(new Vector3(0f, 0f, 0f)));
		}

		private void AddCrate(int id)
		{
			Entity entity = base.EntityManager.CreateEntity();
			base.EntityManager.AddComponentData(entity, new CUpgrade
			{
				ID = id
			});
			base.EntityManager.AddComponentData(entity, default(CPersistThroughSceneChanges));
		}

		private void AddBlueprint(int id)
		{
			PostHelpers.CreateBlueprintLetter(base.EntityManager, PlayerTile(), id);
		}

		private void AddCard(int id)
		{
			Entity entity = base.EntityManager.CreateEntity();
			base.EntityManager.AddComponentData(entity, new CProgressionOption
			{
				ID = id,
				FromFranchise = true
			});
			base.EntityManager.AddComponent<CProgressionOption.Selected>(entity);
			base.EntityManager.AddComponent<CProgressionOption.Displayed>(entity);
		}

		private void RemoveCustomers()
		{
			EntityQuery entityQuery = GetEntityQuery(new QueryHelper().Any(typeof(CCustomer), typeof(CCustomerGroup)));
			base.EntityManager.DestroyEntity(entityQuery);
		}

		private void EndDay()
		{
			EntityQuery entityQuery = GetEntityQuery(new QueryHelper().Any(typeof(CCustomer), typeof(CCustomerGroup), typeof(CScheduledCustomer)));
			base.EntityManager.DestroyEntity(entityQuery);
			if (HasSingleton<SIsDayTime>() && TryGetSingleton<STime>(out var value))
			{
				value.TimeOfDayUnbounded = value.DayLength;
				_SingletonEntityQuery_STime_0.SetSingleton(value);
			}
		}

		private Vector3 PlayerTile()
		{
			EntityQuery entityQuery = GetEntityQuery(typeof(CPlayer), typeof(CPosition));
			if (entityQuery.IsEmpty)
			{
				return default(Vector3);
			}
			return entityQuery.First<CPosition>().Position.Rounded();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
			_SingletonEntityQuery_STime_0 = GetEntityQuery(ComponentType.ReadWrite<STime>());
		}
	}
}
