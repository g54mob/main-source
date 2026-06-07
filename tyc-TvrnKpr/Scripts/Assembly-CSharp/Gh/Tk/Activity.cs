using System;
using System.Collections.Generic;

namespace Gh.Tk
{
	public class Activity : IStateProvider
	{
		public static Activity ErrorState;

		public static Activity AbortJobActivity;

		public static Activity DummyActivity;

		public ActivityState state;

		public GameObjectX actor;

		public Job parentJob;

		public Action initAction;

		public Func<ActivityState> tickAction;

		public Action finishAction;

		internal DataStore _stateData;

		private string _name;

		private List<Tuple<string, int>> _tweenKeys;

		public string Name
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public List<Tuple<string, int>> TweenKeys => null;

		public bool NeedsLogging { get; set; }

		protected Activity()
		{
		}

		public Activity(string name)
		{
		}

		public T GetStateVariable<T>(string key, T fallback)
		{
			return default(T);
		}

		public void SetStateVariable<T>(string key, T value)
		{
		}

		public T GetOrSetStateVariable<T>(string key, T fallback)
		{
			return default(T);
		}

		public virtual void Init()
		{
		}

		public virtual ActivityState Tick()
		{
			return default(ActivityState);
		}

		public virtual void Finish()
		{
		}

		public static Activity CreateLazyActivity(Func<Activity> obj)
		{
			return null;
		}

		public Activity Chain(Activity activity)
		{
			return null;
		}

		public virtual string GetLogInfo()
		{
			return null;
		}
	}
}
