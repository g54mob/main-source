using Factory;
using FixMath;
using Server;

namespace Motorways.Models
{
	public class CityModel : Model<EmptyModelFrame, CityModel.IObserver>
	{
		public interface IObserver
		{
			void OnLanesAdded();

			void OnLanesReleased();

			void OnCarparkAdded(CarparkModel carparkModel);
		}

		public string cityName;

		public PseudorandomGenerator pseudorandomGenerator;

		public Vector3Fixed startOffset;

		public int latestLaneChangeFrame;

		[Dependency]
		private Clock _clock;

		[Serialize(true, null)]
		public GameMode Mode { get; private set; }

		[Serialize(true, null)]
		public GameMode InitialMode { get; private set; }

		[Serialize(false, null)]
		public GameRules Rules { get; private set; }

		public override void Reset()
		{
			Mode = GameMode.Normal;
			startOffset = Vector3Fixed.zero;
			latestLaneChangeFrame = -1;
			InitialMode = GameMode.Normal;
			Rules = null;
		}

		public override void OnReleasedFromScope(IScope scope)
		{
			if (pseudorandomGenerator != null)
			{
				scope.Release(pseudorandomGenerator);
				pseudorandomGenerator = null;
			}
		}

		public void SetGameMode(GameMode mode, GameRules rules)
		{
			Mode = mode;
			Rules = rules;
		}

		public void StartGameInMode(GameMode mode, GameRules rules)
		{
			Mode = mode;
			Rules = rules;
			InitialMode = mode;
		}

		public void OnLanesAdded()
		{
			ObserverList<IObserver>.Enumerator enumerator = base.Observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnLanesAdded();
			}
			latestLaneChangeFrame = _clock.FrameCount;
		}

		public void OnLanesReleased()
		{
			ObserverList<IObserver>.Enumerator enumerator = base.Observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnLanesReleased();
			}
		}

		public void OnCarparkAdded(CarparkModel carparkModel)
		{
			ObserverList<IObserver>.Enumerator enumerator = base.Observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnCarparkAdded(carparkModel);
			}
		}

		public CityModel()
			: base(1)
		{
		}
	}
}
