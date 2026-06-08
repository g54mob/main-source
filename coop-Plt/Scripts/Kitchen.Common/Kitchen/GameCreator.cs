using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinemachine;
using Controllers;
using JetBrains.Annotations;
using Kitchen.NetworkSupport;
using KitchenData;
using KitchenMods;
using Platforms;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class GameCreator : MonoBehaviour
	{
		[SerializeField]
		[UsedImplicitly]
		private string DebugCommandLine = "";

		[SerializeField]
		private MainMenuView MainMenu;

		[SerializeField]
		private AssetDirectory Directory;

		[SerializeField]
		private ModuleDirectory ModuleDirectory;

		[SerializeField]
		private CinemachineTargetGroup TargetGroup;

		[SerializeField]
		private GameDataConstructor Data;

		[SerializeField]
		private CinemachineVirtualCamera CinemachineCamera;

		[SerializeField]
		public Camera UICamera;

		[SerializeField]
		private Transform UIContainer;

		[SerializeField]
		public InputSource InputSource;

		private ModLoader ModLoader;

		private GameData GameData;

		private bool HasQueuedJoinRequest;

		public bool RequestAllowNetworking;

		private GameSetupMode RequestJoinMode;

		private INetworkTarget RequestJoinTarget;

		private List<NetworkTargetDescription> _RemoteUserCache = new List<NetworkTargetDescription>();

		[HideInInspector]
		public World CurrentWorld { get; private set; }

		public void JoinOwnWorld(bool networked = true)
		{
			QueueJoin(GameSetupMode.Server, networked, NonNetworkedTarget.Host);
		}

		public void JoinOtherWorld(INetworkTarget target)
		{
			QueueJoin(GameSetupMode.Client, networked: true, target);
		}

		private void QueueJoin(GameSetupMode mode, bool networked, INetworkTarget target)
		{
			RequestJoinMode = mode;
			RequestJoinTarget = target;
			RequestAllowNetworking = networked;
			HasQueuedJoinRequest = true;
		}

		private async void InitialiseGame()
		{
			while (Platform.Current == null)
			{
				await Task.Delay(100);
			}
			string[] args = ((PlatformSettings.IsEditor && DebugCommandLine != "") ? DebugCommandLine.Split(' ') : null);
			GameInfo.CurrentScene = SceneType.Null;
			ModuleDirectory.Main = ModuleDirectory;
			Preferences.Load();
			if (Localisation.CurrentLocale == Locale.Default || !PlatformSettings.SupportsLanguageSelection)
			{
				try
				{
					Localisation.CurrentLocale = HandleCommandLine.ParseForLocale(args);
				}
				catch
				{
					Localisation.CurrentLocale = Locale.English;
				}
			}
			PerformInitialSetup();
			if (!ShowErrorIfAnyFailedMods())
			{
				FindInitialEntrypoint(args);
			}
		}

		private void Start()
		{
			InitialiseGame();
		}

		private async void FindInitialEntrypoint(string[] args)
		{
			try
			{
				INetworkTarget networkTarget = await HandleCommandLine.ParseForConnectionTarget(args);
				if (networkTarget != null && !networkTarget.IsHostMode)
				{
					Session.JoinGame(networkTarget);
				}
				else
				{
					MainMenu.BeginSplash();
				}
			}
			catch (Exception message)
			{
				Debug.LogError(message);
				MainMenu.BeginSplash();
			}
		}

		private void PerformInitialSetup()
		{
			Debug.Log("Initialising PlateUp! " + Application.version);
			Session.GameCreator = this;
			InputSource = new InputSource();
			InputSource.Setup();
			ProfileStore.Main.Load();
			Players.Main = new Players();
			ModLoader = new ModLoader();
			if (Application.isEditor)
			{
				Data.Populate();
			}
			GameData = Data.BuildGameData();
			GameData.Main = GameData;
			CinemachineFramingTransposer cinemachineFramingTransposer = CinemachineCamera.AddCinemachineComponent<CinemachineFramingTransposer>();
			cinemachineFramingTransposer.m_AdjustmentMode = CinemachineFramingTransposer.AdjustmentMode.DollyThenZoom;
			cinemachineFramingTransposer.m_GroupFramingSize = 1.2f;
			cinemachineFramingTransposer.m_MinimumDistance = 30f;
			cinemachineFramingTransposer.m_MaximumDistance = 40f;
			cinemachineFramingTransposer.m_MinimumFOV = 10f;
			cinemachineFramingTransposer.m_MaximumFOV = 25f;
		}

		private bool ShowErrorIfAnyFailedMods()
		{
			List<Mod> failed = ModLoader.GetFailedMods();
			if (failed.Count == 0)
			{
				return false;
			}
			string loc = GameData.Main.GlobalLocalisation["ERROR_FAILED_TO_LOAD_MODS"];
			ModLoader.PopulateNames(failed).ContinueWith(delegate(Task<List<Mod>> x)
			{
				List<string> values = ((x.Status == TaskStatus.RanToCompletion) ? x.Result : failed).Select(delegate(Mod mod)
				{
					string text2 = ((mod.ID == 0L) ? "local" : mod.ID.ToString());
					return mod.Name + " (" + text2 + ")";
				}).ToList();
				string arg = "\n- " + string.Join("\n- ", values);
				string text = string.Format(loc, arg);
				MainMenu.BeginError(text);
			});
			return true;
		}

		private void InjectMods(World world)
		{
			ModInjectionContext modInjectionContext = new ModInjectionContext
			{
				World = world,
				Constructor = Data
			};
			ModLoader.InjectMods(modInjectionContext);
			GameData main = modInjectionContext.Constructor.BuildGameData();
			if (GameData.Main != null)
			{
				GameData.Main.Dispose();
			}
			GameData.Main = main;
		}

		private async void CreateGameWorld(GameSetupMode mode, INetworkTarget target)
		{
			if (CurrentWorld != null && CurrentWorld.IsCreated)
			{
				try
				{
					CurrentWorld.Dispose();
				}
				catch (Exception)
				{
				}
			}
			World createdWorld = new WorldBootstrapper("Game", mode).CreatedWorld;
			InjectMods(createdWorld);
			World.DefaultGameObjectInjectionWorld = createdWorld;
			EntityManager entityManager = createdWorld.EntityManager;
			Entity entity = entityManager.CreateEntity(typeof(CPersistThroughSceneChanges), typeof(SAssetDirectory), typeof(CDoNotPersist));
			entityManager.AddSharedComponentData(entity, new CViewDirectory
			{
				Directory = Directory,
				UIContainer = UIContainer,
				UIBounds = ViewHelpers.GetOrthoCameraBounds(UICamera),
				UICamera = UICamera
			});
			RouterManager existingSystem = createdWorld.GetExistingSystem<RouterManager>();
			existingSystem.SetViewBoundsMaintainer(new ViewBoundsMaintainer(TargetGroup));
			existingSystem.AddInputSource(InputSource);
			existingSystem.SetupRouters(target, RequestAllowNetworking);
			if (mode == GameSetupMode.Server)
			{
				Persistence.Progress.Load(createdWorld.EntityManager);
				bool flag = Session.RetainedPlayers.Any((RetainedPlayer p) => !ProfileStore.Main.TryGetProfile(p.PlayerProfile, out var profile) || profile.RequiresTutorial);
				InstantJoinDefaultPlayers(createdWorld);
				Entity entity2 = entityManager.CreateEntity(typeof(SPerformSceneTransition));
				entityManager.AddComponentData(entity2, new SPerformSceneTransition
				{
					NextScene = ((!flag) ? SceneType.Franchise : SceneType.Tutorial)
				});
			}
			foreach (RetainedPlayer retainedPlayer in Session.RetainedPlayers)
			{
				ProfileIdentifier playerProfile = retainedPlayer.PlayerProfile;
				ProfileAccessor.SetNeedsTutorial(playerProfile, needs_tutorial: false);
				Players.Main.AddLocalPlayer(retainedPlayer.InputPlayerID, playerProfile);
			}
			Session.NetworkedPlayState = ((mode == GameSetupMode.Client) ? NetworkedPlayState.Client : ((!RequestAllowNetworking) ? NetworkedPlayState.NotNetworked : NetworkedPlayState.Host));
			CurrentWorld = createdWorld;
		}

		public void InstantJoinDefaultPlayers(World world)
		{
			foreach (RetainedPlayer retainedPlayer in Session.RetainedPlayers)
			{
				if (world.GetExistingSystem<PlayerManager>().GetPlayer(retainedPlayer.InputPlayerID, out var _, create_if_missing: true, InputSourceIdentifier.Identifier))
				{
					InstantJoinPlayer(retainedPlayer.InputPlayerID, retainedPlayer.PlayerProfile);
				}
			}
		}

		public void InstantJoinPlayer(int player_id, ProfileIdentifier profile)
		{
			InputSource.MakeRequest(player_id, GameStateRequest.InstantJoin);
		}

		private void Update()
		{
			InputSource?.Update();
			if (Platform.Current != null)
			{
				Platform.Current.Update();
				Platform.Current.UpdateUsers(Players.Main.LocalUsers);
				NetworkInviteData invite = Session.GetInvite();
				Platform.Current.CurrentInvitation = invite;
				Platform.Current.NetworkPlayState = Session.NetworkedPlayState;
				Session.GetConnectedPlayers(ref _RemoteUserCache);
				Platform.Current.RemotePeerCount = _RemoteUserCache.Count;
				foreach (PlatformUser item in Platform.Current.GetUsersToRemove())
				{
					InputSourceIdentifier.Default.MakeRequest(item, GameStateRequest.Disconnect);
				}
			}
			Session.CheckForPlatformConnectionRequest();
			if (HasQueuedJoinRequest)
			{
				HasQueuedJoinRequest = false;
				CreateGameWorld(RequestJoinMode, RequestJoinTarget);
			}
		}

		private void OnDestroy()
		{
			InputSource?.Destroy();
			GameData?.Dispose();
			ModLoader?.Dispose();
			Session.CleanUp();
			Preferences.CleanUp();
		}
	}
}
