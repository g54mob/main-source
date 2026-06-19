using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class ValueWatcher
	{
		public enum kisFeNcVmMRMjfczTFUNAMvWanlr
		{
			PwQCOffCpwnDYEuFcoWNeRpRFfC = 0
		}

		public abstract bool changed { get; }

		public abstract bool autoTriggerEvent { get; set; }

		public abstract bool Update();

		public abstract bool Use();

		public abstract bool TriggerEvent();

		public abstract void AddEventListener(kisFeNcVmMRMjfczTFUNAMvWanlr eventType, Delegate listener);

		public abstract void RemoveEventListener(kisFeNcVmMRMjfczTFUNAMvWanlr eventType, Delegate listener);
	}
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class ValueWatcher<T> : ValueWatcher
	{
		private static IEqualityComparer<T> HpxhUmCuUDtnUrKRQMGldqrTgUVb = EqualityComparerNoAlloc<T>.Default;

		private bool tJYagkGQVnLkOmWxwVTxoaaXOAat;

		private T BUlTlwnOYIYrMrbKigONinVIGlB;

		private bool LLnrSHqgGYIKTSGaLKRdgvsDzvZ;

		private Func<T> wkGzazliBvLdFdElaLyPQKXJFWA;

		private Action<T> uBeSkujJtmdPgoDsqlnuJjnXHVVc;

		public override bool changed => tJYagkGQVnLkOmWxwVTxoaaXOAat;

		public override bool autoTriggerEvent
		{
			get
			{
				return LLnrSHqgGYIKTSGaLKRdgvsDzvZ;
			}
			set
			{
				LLnrSHqgGYIKTSGaLKRdgvsDzvZ = value;
			}
		}

		public Func<T> getValueDelegate
		{
			get
			{
				return wkGzazliBvLdFdElaLyPQKXJFWA;
			}
			set
			{
				wkGzazliBvLdFdElaLyPQKXJFWA = value;
			}
		}

		public T value => BUlTlwnOYIYrMrbKigONinVIGlB;

		public event Action<T> ChangedEvent
		{
			add
			{
				uBeSkujJtmdPgoDsqlnuJjnXHVVc = (Action<T>)Delegate.Combine(uBeSkujJtmdPgoDsqlnuJjnXHVVc, value);
			}
			remove
			{
				uBeSkujJtmdPgoDsqlnuJjnXHVVc = (Action<T>)Delegate.Remove(uBeSkujJtmdPgoDsqlnuJjnXHVVc, value);
			}
		}

		public ValueWatcher(T initialValue, bool autoTriggerEvent)
		{
			BUlTlwnOYIYrMrbKigONinVIGlB = initialValue;
			LLnrSHqgGYIKTSGaLKRdgvsDzvZ = autoTriggerEvent;
		}

		public ValueWatcher(T initialValue, Func<T> getValueDelegate, bool autoTriggerEvent)
			: this(initialValue, autoTriggerEvent)
		{
			wkGzazliBvLdFdElaLyPQKXJFWA = getValueDelegate;
		}

		public override bool Update()
		{
			if (wkGzazliBvLdFdElaLyPQKXJFWA == null)
			{
				return false;
			}
			try
			{
				return Set(wkGzazliBvLdFdElaLyPQKXJFWA());
			}
			catch (Exception ex)
			{
				Logger.LogError("An exception was thrown by getValueDelegate.\n" + ex);
				return false;
			}
		}

		public override bool Use()
		{
			if (!tJYagkGQVnLkOmWxwVTxoaaXOAat)
			{
				return false;
			}
			tJYagkGQVnLkOmWxwVTxoaaXOAat = false;
			return true;
		}

		public override bool TriggerEvent()
		{
			if (!tJYagkGQVnLkOmWxwVTxoaaXOAat)
			{
				return false;
			}
			if (uBeSkujJtmdPgoDsqlnuJjnXHVVc == null)
			{
				return true;
			}
			try
			{
				Use();
				uBeSkujJtmdPgoDsqlnuJjnXHVVc(BUlTlwnOYIYrMrbKigONinVIGlB);
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
			if (HpxhUmCuUDtnUrKRQMGldqrTgUVb.Equals(BUlTlwnOYIYrMrbKigONinVIGlB, value))
			{
				return false;
			}
			BUlTlwnOYIYrMrbKigONinVIGlB = value;
			tJYagkGQVnLkOmWxwVTxoaaXOAat = true;
			if (LLnrSHqgGYIKTSGaLKRdgvsDzvZ)
			{
				TriggerEvent();
			}
			return true;
		}

		public override void AddEventListener(kisFeNcVmMRMjfczTFUNAMvWanlr eventType, Delegate listener)
		{
			if (eventType == kisFeNcVmMRMjfczTFUNAMvWanlr.PwQCOffCpwnDYEuFcoWNeRpRFfC)
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

		public override void RemoveEventListener(kisFeNcVmMRMjfczTFUNAMvWanlr eventType, Delegate listener)
		{
			if (eventType == kisFeNcVmMRMjfczTFUNAMvWanlr.PwQCOffCpwnDYEuFcoWNeRpRFfC)
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
