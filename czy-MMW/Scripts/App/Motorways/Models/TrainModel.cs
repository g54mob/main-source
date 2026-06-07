using Factory;
using FixMath;
using Server;

namespace Motorways.Models
{
	public class TrainModel : Model<TrainModel.Frame, TrainModel.IObserver>
	{
		public enum BehaviorState
		{
			Driving = 0,
			ApproachingDestination = 1,
			Stopping = 2,
			Stopped = 3
		}

		public class Frame : IFrame
		{
			public RailTileModel tile;

			public Fix64 distanceAlongTrack;

			public Fix64 speed;

			public RailDirection direction;

			public void Reset()
			{
				tile = null;
				distanceAlongTrack = Fix64.Zero;
				speed = Fix64.Zero;
				direction = RailDirection.Forwards;
			}

			public bool CloneInto(IFrame cloneFrame, IScope scope)
			{
				Frame obj = (Frame)cloneFrame;
				obj.tile = tile;
				obj.distanceAlongTrack = distanceAlongTrack;
				obj.speed = speed;
				obj.direction = direction;
				return true;
			}
		}

		public interface IObserver
		{
		}

		public BehaviorState state = BehaviorState.Stopped;

		public RailTileModel targetTrack;

		public CarparkModel targetStation;

		public Fix64 stoppingDistanceAlongTargetTrack = Fix64.Zero;

		public Fix64 distanceTraveledSinceLastStation = Fix64.Zero;

		public bool HasPendingDemand;

		[Dependency]
		private SimulationConstantsData _simulationConstants;

		public Fix64 DelayBeforeStarting = Fix64.Zero;

		public Fix64 DistanceToTarget
		{
			get
			{
				if (targetTrack == null)
				{
					return RailTileModel.InvalidDistance;
				}
				Fix64 fix = base.CurrentFrame.tile.DistanceTo(base.CurrentFrame.distanceAlongTrack, targetTrack, stoppingDistanceAlongTargetTrack, base.CurrentFrame.direction);
				if (fix == RailTileModel.InvalidDistance && base.CurrentFrame.tile == targetTrack)
				{
					fix = Fix64.Zero;
				}
				return fix;
			}
		}

		public Fix64 StoppingDistance => GetBrakingDistance(Fix64.Zero);

		public Fix64 GetBrakingDistance(Fix64 targetSpeed)
		{
			Fix64 speed = base.CurrentFrame.speed;
			if (speed <= targetSpeed)
			{
				return Fix64.Zero;
			}
			return (targetSpeed * targetSpeed - speed * speed) / (Fix64Consts.Two * -_simulationConstants.trainDeceleration);
		}

		public override void Reset()
		{
			base.Reset();
			state = BehaviorState.Stopped;
			targetTrack = null;
			targetStation = null;
			stoppingDistanceAlongTargetTrack = Fix64.Zero;
			distanceTraveledSinceLastStation = Fix64.Zero;
			DelayBeforeStarting = Fix64.Zero;
		}

		public TrainModel()
			: base(1)
		{
		}
	}
}
