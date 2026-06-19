using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class ValueWatcher
	{
		public enum kUCGvcnFtRciofGYbZAWRvhqZvWfA
		{
			ValueChanged = 0
		}

		public abstract bool changed { get; }

		public abstract bool autoTriggerEvent { get; set; }

		public abstract bool Update();

		public abstract bool Use();

		public abstract bool TriggerEvent();

		public abstract void AddEventListener(kUCGvcnFtRciofGYbZAWRvhqZvWfA eventType, Delegate listener);

		public abstract void RemoveEventListener(kUCGvcnFtRciofGYbZAWRvhqZvWfA eventType, Delegate listener);
	}
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class ValueWatcher<T> : ValueWatcher
	{
		private static IEqualityComparer<T> LIrxBUdklTxdPmhWyiqyZabJIdeaA = EqualityComparerNoAlloc<T>.Default;

		private bool VfDavapcnuafTfgoXtDGFVuhTBKwA;

		private T PZfqudsENYoSGZdOzoBGigTOqQcD;

		private bool LXuwneioaZjBIjoYIcsNWOanYkzAA;

		private Func<T> AFmMwRTDOamYJmrFPjsNNBtqhwTS;

		private Action<T> StslwaWdtkQFzklvMXtVkZQFigqf;

		bool ValueWatcher.changed => VfDavapcnuafTfgoXtDGFVuhTBKwA;

		bool ValueWatcher.autoTriggerEvent
		{
			get
			{
				return LXuwneioaZjBIjoYIcsNWOanYkzAA;
			}
			set
			{
				LXuwneioaZjBIjoYIcsNWOanYkzAA = value;
			}
		}

		public Func<T> getValueDelegate
		{
			get
			{
				return AFmMwRTDOamYJmrFPjsNNBtqhwTS;
			}
			set
			{
				AFmMwRTDOamYJmrFPjsNNBtqhwTS = value;
			}
		}

		public T value => PZfqudsENYoSGZdOzoBGigTOqQcD;

		public event Action<T> ChangedEvent
		{
			add
			{
				StslwaWdtkQFzklvMXtVkZQFigqf = (Action<T>)Delegate.Combine(StslwaWdtkQFzklvMXtVkZQFigqf, value);
			}
			remove
			{
				StslwaWdtkQFzklvMXtVkZQFigqf = (Action<T>)Delegate.Remove(StslwaWdtkQFzklvMXtVkZQFigqf, value);
			}
		}

		public ValueWatcher(T P_0, bool P_1)
		{
			PZfqudsENYoSGZdOzoBGigTOqQcD = P_0;
			LXuwneioaZjBIjoYIcsNWOanYkzAA = P_1;
		}

		public ValueWatcher(T P_0, Func<T> P_1, bool P_2)
			: this(P_0, P_2)
		{
			AFmMwRTDOamYJmrFPjsNNBtqhwTS = P_1;
		}

		public override bool Update()
		{
			if (AFmMwRTDOamYJmrFPjsNNBtqhwTS == null)
			{
				return false;
			}
			try
			{
				return Set(AFmMwRTDOamYJmrFPjsNNBtqhwTS());
			}
			catch (Exception ex)
			{
				Logger.LogError("An exception was thrown by getValueDelegate.\n" + ex);
				return false;
			}
		}

		public override bool Use()
		{
			if (!VfDavapcnuafTfgoXtDGFVuhTBKwA)
			{
				return false;
			}
			VfDavapcnuafTfgoXtDGFVuhTBKwA = false;
			return true;
		}

		public override bool TriggerEvent()
		{
			if (!VfDavapcnuafTfgoXtDGFVuhTBKwA)
			{
				return false;
			}
			if (StslwaWdtkQFzklvMXtVkZQFigqf == null)
			{
				return true;
			}
			try
			{
				Use();
				StslwaWdtkQFzklvMXtVkZQFigqf(PZfqudsENYoSGZdOzoBGigTOqQcD);
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
			if (LIrxBUdklTxdPmhWyiqyZabJIdeaA.Equals(PZfqudsENYoSGZdOzoBGigTOqQcD, value))
			{
				return false;
			}
			PZfqudsENYoSGZdOzoBGigTOqQcD = value;
			VfDavapcnuafTfgoXtDGFVuhTBKwA = true;
			if (LXuwneioaZjBIjoYIcsNWOanYkzAA)
			{
				TriggerEvent();
			}
			return true;
		}

		public override void AddEventListener(kUCGvcnFtRciofGYbZAWRvhqZvWfA eventType, Delegate listener)
		{
			if (eventType == kUCGvcnFtRciofGYbZAWRvhqZvWfA.ValueChanged)
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

		public override void RemoveEventListener(kUCGvcnFtRciofGYbZAWRvhqZvWfA eventType, Delegate listener)
		{
			if (eventType == kUCGvcnFtRciofGYbZAWRvhqZvWfA.ValueChanged)
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
