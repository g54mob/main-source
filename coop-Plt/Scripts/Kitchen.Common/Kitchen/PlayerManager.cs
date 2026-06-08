using System.Collections.Generic;
using System.Linq;
using Controllers;
using Kitchen.NetworkSupport;
using KitchenData;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	[UpdateInGroup(typeof(SimulationSystemGroup), OrderFirst = true)]
	public class PlayerManager : GenericSystemBase
	{
		private struct SavedPlayer
		{
			public InputIdentifier Identifier;

			public CPlayerColour Colour;

			public CPlayerCosmetics Cosmetics;

			public int Index;

			public CPosition Position;
		}

		public readonly float MaxDisconnectTime = 5f;

		public readonly int MaxPlayers = 4;

		private EntityQuery AllPlayers;

		private EntityQuery ActivePlayers;

		private EntityQuery SavePlayers;

		private Dictionary<InputIdentifier, Player> Players;

		private readonly HashSet<Player> TempPlayerList = new HashSet<Player>();

		private List<SavedPlayer> SavedPlayers = new List<SavedPlayer>();

		private bool HasPreservePlayerPositionFlag;

		protected override void Initialise()
		{
			base.Initialise();
			AllPlayers = GetEntityQuery(typeof(CPlayer));
			ActivePlayers = GetEntityQuery(typeof(CPlayer), typeof(CInputData));
			SavePlayers = GetEntityQuery(new QueryHelper().All(typeof(CPlayer), typeof(CPlayerColour), typeof(CPlayerCosmetics)).None(typeof(CJoiningPlayer)));
			Players = new Dictionary<InputIdentifier, Player>();
		}

		public override void BeforeLoading(SaveSystemType system_type)
		{
			base.BeforeLoading(system_type);
			if (system_type != SaveSystemType.FullWorld)
			{
				return;
			}
			HasPreservePlayerPositionFlag = Has<CPreservePlayerPositionFlag>();
			NativeArray<Entity> nativeArray = SavePlayers.ToEntityArray(Allocator.Temp);
			SavedPlayers.Clear();
			foreach (Entity item in nativeArray)
			{
				CPlayer component = GetComponent<CPlayer>(item);
				SavedPlayers.Add(new SavedPlayer
				{
					Identifier = component,
					Colour = GetComponent<CPlayerColour>(item),
					Cosmetics = GetComponent<CPlayerCosmetics>(item),
					Index = component.Index,
					Position = GetComponent<CPosition>(item)
				});
			}
			nativeArray.Dispose();
		}

		public override void AfterLoading(SaveSystemType system_type)
		{
			base.AfterLoading(system_type);
			if (system_type != SaveSystemType.FullWorld)
			{
				return;
			}
			base.EntityManager.DestroyEntity(AllPlayers);
			Players.Clear();
			foreach (SavedPlayer savedPlayer in SavedPlayers)
			{
				Player player = new Player(base.World, savedPlayer.Identifier, savedPlayer.Index, is_connected: true);
				SetComponent(player.Entity, savedPlayer.Colour);
				CPlayerCosmetics cosmetics = savedPlayer.Cosmetics;
				cosmetics.Shoe = PlayerShoe.None;
				SetComponent(player.Entity, cosmetics);
				if (HasPreservePlayerPositionFlag)
				{
					base.EntityManager.RemoveComponent<CUnplacedPlayer>(player.Entity);
					SetComponent(player.Entity, savedPlayer.Position);
				}
				Players.Add(player.Identifier, player);
			}
		}

		public bool GetPlayer(int id, out Player player, bool create_if_missing = true, SourceIdentifier source = default(SourceIdentifier))
		{
			player = Players.FirstOrDefault((KeyValuePair<InputIdentifier, Player> p) => p.Key.PlayerID == id).Value;
			if (player == null)
			{
				if (!create_if_missing)
				{
					return false;
				}
				int leastUnusedIndex = GetLeastUnusedIndex();
				if (leastUnusedIndex < 0)
				{
					return false;
				}
				InputIdentifier inputIdentifier = new InputIdentifier(source, id);
				Players[inputIdentifier] = new Player(base.World, inputIdentifier, leastUnusedIndex);
				player = Players[inputIdentifier];
			}
			return true;
		}

		protected override void OnUpdate()
		{
			TempPlayerList.Clear();
			foreach (KeyValuePair<InputIdentifier, Player> player in Players)
			{
				Player value = player.Value;
				if (!value.IsEntityValid())
				{
					value.Entity = GetPlayerEntity(value);
					if (!value.IsEntityValid())
					{
						EventLog.Session.Report(SessionEvent.PlayerEntityInvalid, $"{player.Key.PlayerID} ({value.Index})");
						TempPlayerList.Add(value);
						continue;
					}
				}
				value.Update(base.Time.RealDeltaTime);
				if (!value.IsLive)
				{
					EventLog.Session.Report(SessionEvent.PlayerNotLive, $"{player.Key.PlayerID} ({value.Index})");
					TempPlayerList.Add(value);
				}
			}
			foreach (Player tempPlayer in TempPlayerList)
			{
				DisconnectPlayer(tempPlayer);
			}
		}

		public void HandleNewInputData(UserInputUpdate update)
		{
			if (GetPlayer(new InputIdentifier(update.SourceIdentifier, update.Data.User).PlayerID, out var player, update.Data.State.IsAnyButtonHeldOrPressed, update.SourceIdentifier))
			{
				HandleRequest(player, update.Data.State.Request);
				player.ReportNewInput(update.Data.State);
			}
			else
			{
				HandleRequest(null, update.Data.State.Request);
			}
		}

		private void HandleRequest(Player player, GameStateRequest request)
		{
			switch (request)
			{
			case GameStateRequest.None:
				if (player != null && HasComponent<CPlayer>(player.Entity) && HasComponent<CGamePauseRequest>(player.Entity))
				{
					base.EntityManager.RemoveComponent<CGamePauseRequest>(player.Entity);
				}
				break;
			case GameStateRequest.Disconnect:
				if (player != null)
				{
					EventLog.Session.Report(SessionEvent.DisconnectingPlayer, $"{player.Identifier.PlayerID}");
					DisconnectPlayer(player);
				}
				break;
			case GameStateRequest.QuitToLobby:
			{
				EntityContext entityContext = new EntityContext(base.World.EntityManager);
				if (!entityContext.Has<SPreventSaving>())
				{
					Persistence.FullWorld.Save(base.World.EntityManager, entityContext.Get<SSelectedLocation>().Selected.Slot);
				}
				base.PopupUtilities.RequestManagedPopup(PopupType.QuitToLobby);
				break;
			}
			case GameStateRequest.QuitSection:
				base.PopupUtilities.RequestManagedPopup((GameInfo.CurrentScene == SceneType.Tutorial) ? PopupType.LeaveTutorial : PopupType.AbandonRestaurant);
				break;
			case GameStateRequest.InLocalMenu:
				if (player != null && HasComponent<CPlayer>(player.Entity) && !HasComponent<CGamePauseRequest>(player.Entity))
				{
					base.EntityManager.AddComponent<CGamePauseRequest>(player.Entity);
				}
				break;
			case GameStateRequest.InstantJoin:
				if (player != null && player.State == PlayerState.Joining)
				{
					player.CompleteJoining();
				}
				break;
			case GameStateRequest.StartPractice:
				if (player != null)
				{
					Set<CRequestPracticeMode>();
				}
				break;
			case GameStateRequest.KickUser:
				break;
			}
		}

		private void DisconnectPlayer(Player player)
		{
			player.Disconnect();
			Players.Remove(player.Identifier);
		}

		public void DisconnectPlayersOfSource(SourceIdentifier source)
		{
			EventLog.Session.Report(SessionEvent.DisconnectingPlayersOfSource, $"{source.Value}");
			TempPlayerList.Clear();
			foreach (KeyValuePair<InputIdentifier, Player> player in Players)
			{
				if (player.Key.InputSource == source)
				{
					player.Value.Disconnect();
					TempPlayerList.Add(player.Value);
				}
			}
			foreach (Player tempPlayer in TempPlayerList)
			{
				DisconnectPlayer(tempPlayer);
			}
		}

		private Entity GetPlayerEntity(Player player)
		{
			NativeArray<Entity> nativeArray = AllPlayers.ToEntityArray(Allocator.Temp);
			NativeArray<CPlayer> nativeArray2 = AllPlayers.ToComponentDataArray<CPlayer>(Allocator.Temp);
			try
			{
				for (int i = 0; i < nativeArray.Length; i++)
				{
					Entity result = nativeArray[i];
					if (nativeArray2[i].ID == player.Identifier.PlayerID)
					{
						return result;
					}
				}
			}
			finally
			{
				nativeArray.Dispose();
				nativeArray2.Dispose();
			}
			return default(Entity);
		}

		private int GetLeastUnusedIndex()
		{
			for (int i = 0; i < MaxPlayers; i++)
			{
				bool flag = false;
				foreach (KeyValuePair<InputIdentifier, Player> player in Players)
				{
					if (player.Value.Index == i)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return i;
				}
			}
			return -1;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
