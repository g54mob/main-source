using Factory;
using FixMath;
using Server;

namespace Motorways.Models
{
	public class BoatModel : Model<BoatModel.Frame, BoatModel.IObserver>
	{
		public enum BoatDirection
		{
			Forwards = 0,
			Backwards = 1
		}

		public enum BehaviorState
		{
			Sailing = 0,
			ApproachingTerminal = 1,
			Stopping = 2,
			Stopped = 3,
			Undocking = 4,
			TurningAtTerminal = 5,
			TurningAtEndOfLine = 6
		}

		public class Frame : IFrame
		{
			public BoatPathTileModel tile;

			public Fix64 DistanceAlongPathSegment;

			public Fix64 speed;

			public BoatDirection direction;

			public void Reset()
			{
				tile = null;
				DistanceAlongPathSegment = Fix64.Zero;
				speed = Fix64.Zero;
			}

			public bool CloneInto(IFrame cloneFrame, IScope scope)
			{
				Frame obj = (Frame)cloneFrame;
				obj.tile = tile;
				obj.DistanceAlongPathSegment = DistanceAlongPathSegment;
				obj.speed = speed;
				obj.direction = direction;
				return true;
			}
		}

		public interface IObserver
		{
			void OnTargetTerminalSet(CarparkModel targetTerminal);
		}

		public BehaviorState state;

		public BoatPathTileModel targetBoatPath;

		public Fix64 stoppingDistanceAlongTargetPathSegment = Fix64.Zero;

		public Fix64 distanceTraveledSinceLastTarget = Fix64.Zero;

		public bool HasPendingDemand;

		[Dependency]
		private SimulationConstantsData _simulationConstants;

		public Fix64 DelayBeforeStarting = Fix64.Zero;

		private CarparkModel _targetTerminal;

		public Fix64 DistanceToTarget
		{
			get
			{
				if (targetBoatPath == null)
				{
					return BoatPathTileModel.InvalidDistance;
				}
				Fix64 fix = base.CurrentFrame.tile.DistanceTo(base.CurrentFrame.DistanceAlongPathSegment, targetBoatPath, stoppingDistanceAlongTargetPathSegment, base.CurrentFrame.direction);
				if (fix == BoatPathTileModel.InvalidDistance && base.CurrentFrame.tile == targetBoatPath)
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

		public void SetTargetTerminal(CarparkModel carparkModel)
		{
			_targetTerminal = carparkModel;
			ObserverList<IObserver>.Enumerator enumerator = base.Observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnTargetTerminalSet(carparkModel);
			}
		}

		public CarparkModel GetTargetTerminal()
		{
			return _targetTerminal;
		}

		public override void Reset()
		{
			base.Reset();
			state = BehaviorState.Stopped;
			targetBoatPath = null;
			_targetTerminal = null;
			stoppingDistanceAlongTargetPathSegment = Fix64.Zero;
			distanceTraveledSinceLastTarget = Fix64.Zero;
			DelayBeforeStarting = Fix64.Zero;
		}

		public BoatModel()
			: base(1)
		{
		}
	}
}
