using Factory;
using Server;

namespace Motorways.Models
{
	public class TreeModel : Model<EmptyModelFrame, TreeModel.IObserver>
	{
		public interface IObserver
		{
			void OnBulldozed();
		}

		[Dependency]
		private ISimulation simulation;

		[Dependency]
		private ActivePlayer _player;

		[Dependency]
		private City _city;

		[Serialize(true, null)]
		public int PrefabIndex { get; private set; }

		[Serialize(true, null)]
		public TileModel TileModel { get; private set; }

		public void Bulldoze()
		{
			ObserverList<IObserver>.Enumerator enumerator = base.Observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnBulldozed();
			}
			TileModel.Tile.SetContentType(TileContentType.None, null);
			simulation.RemoveModel(this);
			if (_city.Rules.RecordsGameStatistics())
			{
				_player.AchievementStatistics.OnTreeBulldozed(_player.Scope.Get<IAchievementHandler>());
			}
		}

		public virtual void Initialize(int prefabIndex, TileModel tileModel)
		{
			PrefabIndex = prefabIndex;
			TileModel = tileModel;
			TileModel.Tile.SetContentType(TileContentType.Tree, this);
		}

		public override void Reset()
		{
			base.Reset();
			TileModel = null;
			PrefabIndex = 0;
		}

		public TreeModel()
			: base(1)
		{
		}
	}
}
