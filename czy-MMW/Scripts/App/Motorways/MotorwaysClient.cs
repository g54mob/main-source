using Client;
using Factory;
using FixMath;
using Motorways.Models;
using Motorways.Views;
using Motorways.Views.Boats;
using Motorways.Views.MeshGeneration;
using Motorways.Views.Trains;
using Server;

namespace Motorways
{
	public class MotorwaysClient : ViewClient
	{
		public class UpgradeDatabaseConnector : IViewBuilder
		{
			private MotorwaysClient _client;

			public UpgradeDatabaseConnector(MotorwaysClient client)
			{
				_client = client;
			}

			public void CreateView(ViewClient client, ISimulation simulation, IModel model, Fix64 timestamp)
			{
				_client._upgradeDatabase.Initialize(model as UpgradeDatabaseModel);
			}
		}

		private CombinedMeshThemeComponent _combinedMeshThemeComponent;

		private ClientUpgradeDatabase _upgradeDatabase;

		[Dependency]
		protected IInGameDevToolsRegistry _devToolsRegistry;

		[Dependency]
		private MotorwaysGame _motorwaysGame;

		public override void Start()
		{
			base.Start();
			if (FeatureToggle.IsFeatureEnabled(Feature.InGameDevTools) && _motorwaysGame.StartedWithGameMode != GameMode.Background)
			{
				_devToolsRegistry.RegisterTools();
			}
			RegisterViewBuilder<TilemapModel>(new TilemapView.Builder());
			RegisterViewBuilder<ClockModel>(new ClockView.Builder());
			RegisterViewBuilder<ScoreModel>(new ScoreView.Builder());
			RegisterViewBuilder<VehicleModel>(new VehicleView.Builder());
			RegisterViewBuilder<HouseModel>(new HouseView.Builder());
			RegisterViewBuilder<TreeModel>(new TreeView.Builder());
			RegisterViewBuilder<DestinationModel>(new DestinationView.Builder());
			RegisterViewBuilder<CarparkModel>(new CarparkView.Builder());
			RegisterViewBuilder<RailTileModel>(new RailView.Builder());
			RegisterViewBuilder<TrainModel>(new TrainView.Builder());
			RegisterViewBuilder<TrainCrossingModel>(new TrainCrossingView.Builder());
			RegisterViewBuilder<BoatPathTileModel>(new BoatPathView.Builder());
			RegisterViewBuilder<BoatModel>(new BoatView.Builder());
			RegisterViewBuilder<AnchoredMessageModel>(new AnchoredMessageView.Builder());
			_upgradeDatabase = base.Scope.Get<ClientUpgradeDatabase>();
			RegisterViewBuilder<UpgradeDatabaseModel>(new UpgradeDatabaseConnector(this));
			AddView(base.Scope.Get<CameraView>());
			AddView(base.Scope.Get<NotificationView>());
			AddView(base.Scope.Get<ChallengeView>());
			AddView(base.Scope.Get<BuildingsIndicatorView>());
			AddView(base.Scope.Get<CombinedMeshView>());
			AddView(base.Scope.Get<CitySpawningView>());
			_combinedMeshThemeComponent = base.Scope.Get<CombinedMeshThemeComponent>();
			AddThemeComponent(_combinedMeshThemeComponent);
		}

		public override void Tick(TimeInterval timeInterval, float stepAlpha)
		{
			base.Tick(timeInterval, stepAlpha);
			_devToolsRegistry.RespondToInGameToolUse();
		}

		public override void OnReleasedFromScope(IScope scope)
		{
			if (_upgradeDatabase != null)
			{
				base.Scope.Release(_upgradeDatabase);
				_upgradeDatabase = null;
			}
			if (_combinedMeshThemeComponent != null)
			{
				base.Scope.Release(_combinedMeshThemeComponent);
				_combinedMeshThemeComponent = null;
			}
			base.OnReleasedFromScope(scope);
		}
	}
}
