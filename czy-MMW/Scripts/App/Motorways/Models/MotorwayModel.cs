using Factory;
using Factory.Pools;
using FixMath;
using Server;

namespace Motorways.Models
{
	public class MotorwayModel : Motorway, IModel, IReusable
	{
		public RoadChunkModel roadChunk;

		public LaneModel startToEndLane;

		public LaneModel endToStartLane;

		public bool hasConsumedUpgrade;

		public bool isHighBuildPriority;

		[Dependency]
		private Scope _scope;

		[Dependency]
		private ISimulation _simulation;

		[Dependency]
		private TilemapModel _tilemapModel;

		public TileModel StartTile => _tilemapModel.GetTileModel(base.StartCoordinates);

		public TileModel EndTile => _tilemapModel.GetTileModel(base.EndCoordinates);

		public override bool Initialize(ITilemap tilemap, int id, int number, RoadState roadState = RoadState.None)
		{
			roadChunk = _scope.Get<RoadChunkModel>();
			_simulation.AddModel(roadChunk);
			hasConsumedUpgrade = false;
			return base.Initialize(tilemap, id, number, roadState);
		}

		public bool CanSetMotorwayAndNodeState(RoadState newState)
		{
			if (!CanSetState(newState))
			{
				return false;
			}
			if (Diagnostics.Verify(StartTile != null && EndTile != null, "Motorway is missing a tile."))
			{
				if (StartTile.Tile.CanSetNodeState(new RoadTileNode(base.StartDirection, RoadType.Motorway, base.Id), newState))
				{
					return EndTile.Tile.CanSetNodeState(new RoadTileNode(base.EndDirection, RoadType.Motorway, base.Id), newState);
				}
				return false;
			}
			return false;
		}

		public bool CanBeReplacedByActivatingMothballedMotorway(out MotorwayModel mothballedReplacement)
		{
			if (base.State != RoadState.Planned)
			{
				mothballedReplacement = null;
				return false;
			}
			ModelListEnumerator<MotorwayModel> enumerator = _simulation.GetModels<MotorwayModel>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				MotorwayModel current = enumerator.Current;
				if (current.Number == base.Number && current.State == RoadState.Mothballed && ((current.StartTile == StartTile && current.EndTile == EndTile) || (current.StartTile == EndTile && current.EndTile == StartTile)))
				{
					mothballedReplacement = current;
					return true;
				}
			}
			mothballedReplacement = null;
			return false;
		}

		public void SetMotorwayAndNodeState(RoadState newState)
		{
			if (Diagnostics.Verify(StartTile != null && EndTile != null, "Motorway is missing a tile."))
			{
				Diagnostics.Verify(StartTile.Tile.SetNodeState(new RoadTileNode(base.StartDirection, RoadType.Motorway, base.Id), newState), "Failed to set node state {0} on motorway {1}'s start tile.", newState, base.Id);
				Diagnostics.Verify(EndTile.Tile.SetNodeState(new RoadTileNode(base.EndDirection, RoadType.Motorway, base.Id), newState), "Failed to set node state {0} on motorway {1}'s end tile.", newState, base.Id);
			}
			Diagnostics.Verify(SetState(newState), "Failed to set state {0} on motorway {1}.", newState, base.Id);
		}

		public void IncrementPermanence(Fix64 permanenceProgress, RoadState states = RoadState.Active)
		{
			if (base.State.HasFlag(states) && !base.IsPermanent)
			{
				base.PermanenceProgress += permanenceProgress;
			}
		}

		public override void Reset()
		{
			base.Reset();
			roadChunk = null;
			startToEndLane = null;
			endToStartLane = null;
			hasConsumedUpgrade = false;
			isHighBuildPriority = false;
		}

		public override void OnReleasedFromScope(IScope scope)
		{
			base.OnReleasedFromScope(scope);
			if (roadChunk != null)
			{
				_simulation.RemoveModel(roadChunk);
				roadChunk = null;
			}
		}

		public override string ToString()
		{
			return $"[MotorwayModel Id={base.Id}]";
		}
	}
}
