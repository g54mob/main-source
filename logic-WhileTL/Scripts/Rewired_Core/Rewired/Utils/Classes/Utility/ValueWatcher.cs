using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class ValueWatcher
	{
		public enum EzsdjXWySloNQPPjxRsIcKcyvoLC
		{
			ValueChanged = 0
		}

		public abstract bool changed { get; }

		public abstract bool autoTriggerEvent { get; set; }

		public abstract bool Update();

		public abstract bool Use();

		public abstract bool TriggerEvent();

		public abstract void AddEventListener(EzsdjXWySloNQPPjxRsIcKcyvoLC eventType, Delegate listener);

		public abstract void RemoveEventListener(EzsdjXWySloNQPPjxRsIcKcyvoLC eventType, Delegate listener);
	}
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class ValueWatcher<T> : ValueWatcher
	{
		private static IEqualityComparer<T> pSxHwMkSSeTtETbYsNiqDSllClqb = EqualityComparerNoAlloc<T>.Default;

		private bool JUYBrggtRMFIjgeDCjMydMJzXGAPA;

		private T zqlmAmRAWxhuzRtcELHICvssAvpy;

		private bool nPrMmXCWQbKiyukMfgXghOBfilteb;

		private Func<T> InODohJgmOnloZBuCoOIuxhhGRop;

		private Action<T> KJcpmuJnyZppLYIhEyRdfAhlRilf;

		public override bool changed => JUYBrggtRMFIjgeDCjMydMJzXGAPA;

		public override bool autoTriggerEvent
		{
			get
			{
				return nPrMmXCWQbKiyukMfgXghOBfilteb;
			}
			set
			{
				nPrMmXCWQbKiyukMfgXghOBfilteb = value;
			}
		}

		public Func<T> getValueDelegate
		{
			get
			{
				return InODohJgmOnloZBuCoOIuxhhGRop;
			}
			set
			{
				InODohJgmOnloZBuCoOIuxhhGRop = value;
			}
		}

		public T value => zqlmAmRAWxhuzRtcELHICvssAvpy;

		public event Action<T> ChangedEvent
		{
			add
			{
				KJcpmuJnyZppLYIhEyRdfAhlRilf = (Action<T>)Delegate.Combine(KJcpmuJnyZppLYIhEyRdfAhlRilf, value);
			}
			remove
			{
				KJcpmuJnyZppLYIhEyRdfAhlRilf = (Action<T>)Delegate.Remove(KJcpmuJnyZppLYIhEyRdfAhlRilf, value);
			}
		}

		public ValueWatcher(T P_0, bool P_1)
		{
			zqlmAmRAWxhuzRtcELHICvssAvpy = P_0;
			nPrMmXCWQbKiyukMfgXghOBfilteb = P_1;
		}

		public ValueWatcher(T P_0, Func<T> P_1, bool P_2)
			: this(P_0, P_2)
		{
			InODohJgmOnloZBuCoOIuxhhGRop = P_1;
		}

		public override bool Update()
		{
			if (InODohJgmOnloZBuCoOIuxhhGRop == null)
			{
				return false;
			}
			try
			{
				return Set(InODohJgmOnloZBuCoOIuxhhGRop());
			}
			catch (Exception ex)
			{
				Logger.LogError("An exception was thrown by getValueDelegate.\n" + ex);
				return false;
			}
		}

		public override bool Use()
		{
			if (!JUYBrggtRMFIjgeDCjMydMJzXGAPA)
			{
				return false;
			}
			JUYBrggtRMFIjgeDCjMydMJzXGAPA = false;
			return true;
		}

		public override bool TriggerEvent()
		{
			if (!JUYBrggtRMFIjgeDCjMydMJzXGAPA)
			{
				return false;
			}
			if (KJcpmuJnyZppLYIhEyRdfAhlRilf == null)
			{
				return true;
			}
			try
			{
				Use();
				KJcpmuJnyZppLYIhEyRdfAhlRilf(zqlmAmRAWxhuzRtcELHICvssAvpy);
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
			if (pSxHwMkSSeTtETbYsNiqDSllClqb.Equals(zqlmAmRAWxhuzRtcELHICvssAvpy, value))
			{
				return false;
			}
			zqlmAmRAWxhuzRtcELHICvssAvpy = value;
			JUYBrggtRMFIjgeDCjMydMJzXGAPA = true;
			if (nPrMmXCWQbKiyukMfgXghOBfilteb)
			{
				TriggerEvent();
			}
			return true;
		}

		public override void AddEventListener(EzsdjXWySloNQPPjxRsIcKcyvoLC eventType, Delegate listener)
		{
			if (eventType == EzsdjXWySloNQPPjxRsIcKcyvoLC.ValueChanged)
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

		public override void RemoveEventListener(EzsdjXWySloNQPPjxRsIcKcyvoLC eventType, Delegate listener)
		{
			if (eventType == EzsdjXWySloNQPPjxRsIcKcyvoLC.ValueChanged)
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
