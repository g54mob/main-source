using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class ValueWatcher
	{
		public enum yTMbhxiPVJNqGVrgasRlirvBBwYeA
		{
			ValueChanged = 0
		}

		public abstract bool changed { get; }

		public abstract bool autoTriggerEvent { get; set; }

		public abstract bool Update();

		public abstract bool Use();

		public abstract bool TriggerEvent();

		public abstract void AddEventListener(yTMbhxiPVJNqGVrgasRlirvBBwYeA eventType, Delegate listener);

		public abstract void RemoveEventListener(yTMbhxiPVJNqGVrgasRlirvBBwYeA eventType, Delegate listener);
	}
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class ValueWatcher<T> : ValueWatcher
	{
		private static IEqualityComparer<T> PkrmHBFaDDXfdPTwtnKTEazohcuM = EqualityComparerNoAlloc<T>.Default;

		private bool FZDralJBVsxnnNOdCMqdKoOMGFWC;

		private T FYfewcERaIgusqIFyphdfHyxbowj;

		private bool JSulvfQPUTuDoVZgJVtcZVeIDlfn;

		private Func<T> MeeXmWrRiaMwpTYjSwooUEvPlnZJ;

		private Action<T> CWwddxsABmGQVNTTDQpenjHmdqog;

		bool ValueWatcher.changed => FZDralJBVsxnnNOdCMqdKoOMGFWC;

		bool ValueWatcher.autoTriggerEvent
		{
			get
			{
				return JSulvfQPUTuDoVZgJVtcZVeIDlfn;
			}
			set
			{
				JSulvfQPUTuDoVZgJVtcZVeIDlfn = value;
			}
		}

		public Func<T> getValueDelegate
		{
			get
			{
				return MeeXmWrRiaMwpTYjSwooUEvPlnZJ;
			}
			set
			{
				MeeXmWrRiaMwpTYjSwooUEvPlnZJ = value;
			}
		}

		public T value => FYfewcERaIgusqIFyphdfHyxbowj;

		public event Action<T> ChangedEvent
		{
			add
			{
				CWwddxsABmGQVNTTDQpenjHmdqog = (Action<T>)Delegate.Combine(CWwddxsABmGQVNTTDQpenjHmdqog, value);
			}
			remove
			{
				CWwddxsABmGQVNTTDQpenjHmdqog = (Action<T>)Delegate.Remove(CWwddxsABmGQVNTTDQpenjHmdqog, value);
			}
		}

		public ValueWatcher(T P_0, bool P_1)
		{
			FYfewcERaIgusqIFyphdfHyxbowj = P_0;
			JSulvfQPUTuDoVZgJVtcZVeIDlfn = P_1;
		}

		public ValueWatcher(T P_0, Func<T> P_1, bool P_2)
			: this(P_0, P_2)
		{
			MeeXmWrRiaMwpTYjSwooUEvPlnZJ = P_1;
		}

		public override bool Update()
		{
			if (MeeXmWrRiaMwpTYjSwooUEvPlnZJ == null)
			{
				return false;
			}
			try
			{
				return Set(MeeXmWrRiaMwpTYjSwooUEvPlnZJ());
			}
			catch (Exception ex)
			{
				Logger.LogError("An exception was thrown by getValueDelegate.\n" + ex);
				return false;
			}
		}

		public override bool Use()
		{
			if (!FZDralJBVsxnnNOdCMqdKoOMGFWC)
			{
				return false;
			}
			FZDralJBVsxnnNOdCMqdKoOMGFWC = false;
			return true;
		}

		public override bool TriggerEvent()
		{
			if (!FZDralJBVsxnnNOdCMqdKoOMGFWC)
			{
				return false;
			}
			if (CWwddxsABmGQVNTTDQpenjHmdqog == null)
			{
				return true;
			}
			try
			{
				Use();
				CWwddxsABmGQVNTTDQpenjHmdqog(FYfewcERaIgusqIFyphdfHyxbowj);
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("An exception was thrown by ValueChangedEvent handler.\n" + ex);
				return false;
			}
		}

		public bool Set(T value)
		{
			if (PkrmHBFaDDXfdPTwtnKTEazohcuM.Equals(FYfewcERaIgusqIFyphdfHyxbowj, value))
			{
				return false;
			}
			FYfewcERaIgusqIFyphdfHyxbowj = value;
			FZDralJBVsxnnNOdCMqdKoOMGFWC = true;
			if (JSulvfQPUTuDoVZgJVtcZVeIDlfn)
			{
				TriggerEvent();
			}
			return true;
		}

		public override void AddEventListener(yTMbhxiPVJNqGVrgasRlirvBBwYeA eventType, Delegate listener)
		{
			if (eventType == yTMbhxiPVJNqGVrgasRlirvBBwYeA.ValueChanged)
			{
				if (!(listener is Action<T>))
				{
					throw new ArgumentException("listener must be of type Action<" + typeof(T).Name + ">");
				}
				ChangedEvent += (Action<T>)listener;
				return;
			}
			throw new NotImplementedException();
		}

		public override void RemoveEventListener(yTMbhxiPVJNqGVrgasRlirvBBwYeA eventType, Delegate listener)
		{
			if (eventType == yTMbhxiPVJNqGVrgasRlirvBBwYeA.ValueChanged)
			{
				if (!(listener is Action<T>))
				{
					throw new ArgumentException("listener must be of type Action<" + typeof(T).Name + ">");
				}
				ChangedEvent -= (Action<T>)listener;
				return;
			}
			throw new NotImplementedException();
		}
	}
}
