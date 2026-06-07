using Factory;
using Factory.Pools;

namespace Server
{
	public abstract class Model<TFrame, TObserver> : IModel, IReusable, IReleasedFromScopeHandler where TFrame : IFrame, new()
	{
		[Serialize(true, typeof(ModelFrameSerializer))]
		private readonly TFrame[] _frames = new TFrame[2]
		{
			new TFrame(),
			new TFrame()
		};

		[Serialize(false, null)]
		private readonly ObserverList<TObserver> _observers;

		[Dependency]
		public Clock Clock { get; protected set; }

		protected ObserverList<TObserver> Observers => _observers;

		public TFrame CurrentFrame => _frames[Clock.ModelFrameIndex];

		public TFrame NextFrame => _frames[1 - Clock.ModelFrameIndex];

		public void Subscribe(TObserver observer)
		{
			_observers.Subscribe(observer);
		}

		public bool Unsubscribe(TObserver observer)
		{
			return _observers.Unsubscribe(observer);
		}

		protected Model(int observerCapacity = 1)
		{
			_observers = ((observerCapacity > 0) ? new ObserverList<TObserver>(observerCapacity) : null);
		}

		public virtual void OnReleasedFromScope(IScope scope)
		{
			_observers.UnsubscribeAll();
		}

		public virtual void Reset()
		{
			_frames[0].Reset();
			_frames[1].Reset();
		}
	}
}
