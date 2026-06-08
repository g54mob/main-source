using System.Collections.Generic;
using Controllers;
using Kitchen.NetworkSupport;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class Player : ILiveness
	{
		private readonly World World;

		public Entity Entity;

		public InputIdentifier Identifier;

		public PlayerState State;

		public readonly InputQueue InputQueue;

		public int Index;

		public float DeactivationProgress;

		public float JoiningProgress;

		private EntityManager EntMan => World.EntityManager;

		public bool IsLive
		{
			get
			{
				if (State != PlayerState.Null)
				{
					return DeactivationProgress < 15f;
				}
				return false;
			}
		}

		public bool IsGoodQuality => DeactivationProgress < 0.5f;

		public Player(World world, InputIdentifier id, int index, bool is_connected = false)
		{
			World = world;
			Identifier = id;
			Index = index;
			State = PlayerState.Null;
			InputQueue = new InputQueue();
			StartJoining();
			if (is_connected)
			{
				CompleteJoining();
			}
		}

		public Player(World world, Entity entity)
		{
			World = world;
			Entity = entity;
			CreateFromEntity();
		}

		public void Update(float dt)
		{
			InputQueue.ApplyUpdates();
			UpdateProgression(dt);
			UpdateToEntity();
		}

		public void ReportNewInput(InputState input)
		{
			InputQueue.Enqueue(input);
			RefreshLiveness();
		}

		public void Disconnect()
		{
			Entity entity = EntMan.CreateEntity(typeof(CDisconnectPlayerEvent));
			EntMan.SetComponentData(entity, new CDisconnectPlayerEvent
			{
				Player = Entity
			});
		}

		private void UpdateProgression(float dt)
		{
			switch (State)
			{
			case PlayerState.Null:
				break;
			case PlayerState.Joining:
				CheckProgression();
				if (InputQueue.State.IsAnyButtonHeldOrPressed)
				{
					JoiningProgress += dt;
				}
				else
				{
					JoiningProgress -= dt * 0.2f;
				}
				break;
			case PlayerState.Active:
				DeactivationProgress += dt;
				break;
			}
		}

		private void CheckProgression()
		{
			if (State == PlayerState.Joining)
			{
				if (JoiningProgress > 1f)
				{
					DeactivationProgress = 0f;
					CompleteJoining();
				}
				else if (JoiningProgress < 0f)
				{
					Disconnect();
				}
			}
		}

		public void RefreshLiveness()
		{
			DeactivationProgress = 0f;
		}

		public void UpdateToEntity()
		{
			if (State != PlayerState.Null)
			{
				if (EntMan.RequireComponent<CInputData>(Entity, out var _))
				{
					EntMan.SetComponentData(Entity, new CInputData
					{
						State = InputQueue.State
					});
				}
				if (EntMan.RequireComponent<CJoiningPlayer>(Entity, out var component2))
				{
					component2.Progress = JoiningProgress;
					EntMan.SetComponentData(Entity, component2);
				}
			}
		}

		public bool IsEntityValid()
		{
			if (Entity != default(Entity))
			{
				return EntMan.HasComponent<CPlayer>(Entity);
			}
			return false;
		}

		private void CreateFromEntity()
		{
			if (!IsEntityValid())
			{
				State = PlayerState.Null;
				return;
			}
			CPlayer componentData = EntMan.GetComponentData<CPlayer>(Entity);
			Identifier = new InputIdentifier(componentData.InputSource, componentData.ID);
			if (EntMan.RequireComponent<CJoiningPlayer>(Entity, out var component))
			{
				State = PlayerState.Joining;
				JoiningProgress = component.Progress;
			}
			else
			{
				State = PlayerState.Active;
				JoiningProgress = 0f;
			}
		}

		private Color PickOptimalColour()
		{
			List<PlayerInfo> list = Players.Main.All();
			int num = 4;
			for (int i = 0; i < num; i++)
			{
				bool flag = false;
				float num2 = (float)i / (float)num;
				foreach (PlayerInfo item in list)
				{
					Color.RGBToHSV(item.Profile.Colour, out var H, out var _, out var _);
					if (Mathf.Abs(num2 - H) < 1f / (float)num * 0.5f || Mathf.Abs(num2 - 1f - H) < 1f / (float)num * 0.5f)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return Color.HSVToRGB(num2, 0.75f, 0.75f);
				}
			}
			return Color.HSVToRGB(0f, 0.75f, 0.75f);
		}

		private void StartJoining()
		{
			if (State == PlayerState.Null)
			{
				Entity = EntMan.CreateEntity(typeof(CJoiningPlayer), typeof(CPlayer), typeof(CPersistThroughSceneChanges));
				EntMan.AddComponentData(Entity, new CPlayerColour
				{
					Color = PickOptimalColour()
				});
				EntMan.AddComponentData(Entity, new CPlayer
				{
					ID = Identifier.PlayerID,
					Index = Index,
					InputSource = Identifier.InputSource
				});
				State = PlayerState.Joining;
			}
		}

		public void CompleteJoining()
		{
			if (State == PlayerState.Joining)
			{
				EntMan.RemoveComponent<CJoiningPlayer>(Entity);
				EntMan.AddComponent<CPersistThroughSceneChanges>(Entity);
				EntMan.AddComponent<CPlayerCosmetics>(Entity);
				EntMan.AddComponent<CShoeEffect>(Entity);
				EntMan.AddComponent<CInputData>(Entity);
				EntMan.AddComponent<CToolUser>(Entity);
				EntMan.AddComponent<CUnplacedPlayer>(Entity);
				EntMan.AddComponentData(Entity, CPosition.Hidden);
				EntMan.AddComponentData(Entity, new CItemHolderFilter
				{
					AllowAny = true
				});
				EntMan.AddComponentData(Entity, new CInputDevice
				{
					User = Identifier.PlayerID
				});
				EntMan.AddComponentData(Entity, new CRequiresView
				{
					Type = ViewType.Player,
					PhysicsDriven = false
				});
				EntMan.AddComponentData(Entity, new CIsInteractor
				{
					InteractionOffset = 0.7f,
					InteractionRadius = 0.7f,
					Mode = InteractionMode.Items
				});
				EntMan.AddComponentData(Entity, new CMaintainWhenOutOfBounds
				{
					Radius = 2f
				});
				EntMan.AddComponentData(Entity, default(CItemHolder));
				State = PlayerState.Active;
			}
		}
	}
}
