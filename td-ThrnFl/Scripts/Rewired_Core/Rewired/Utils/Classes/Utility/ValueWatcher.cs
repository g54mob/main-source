using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class ValueWatcher
	{
		public enum JeojSDdJARPbPEKvQdpKZyChHuTaA
		{
			ValueChanged = 0
		}

		public abstract bool changed { get; }

		public abstract bool autoTriggerEvent { get; set; }

		public abstract bool Update();

		public abstract bool Use();

		public abstract bool TriggerEvent();

		public abstract void AddEventListener(JeojSDdJARPbPEKvQdpKZyChHuTaA eventType, Delegate listener);

		public abstract void RemoveEventListener(JeojSDdJARPbPEKvQdpKZyChHuTaA eventType, Delegate listener);
	}
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class ValueWatcher<T> : ValueWatcher
	{
		private static IEqualityComparer<T> cLVRibFROLTkkwJnROBeUjMKZcxV = EqualityComparerNoAlloc<T>.Default;

		private bool ilMSTcHAuDiydqZBsiGKAXTeWLob;

		private T wMRZzGYbbQhIlZYOIFGWtrJRbLxE;

		private bool sWYQGFWGVXjSbcqhnHJBDkNoJlyU;

		private Func<T> xnKVXylDpuGRsiaaeZIPhKQtxtAnA;

		private Action<T> jYCGwBwQNsBDCsIixmbLjkKArxrd;

		bool ValueWatcher.changed => ilMSTcHAuDiydqZBsiGKAXTeWLob;

		bool ValueWatcher.autoTriggerEvent
		{
			get
			{
				return sWYQGFWGVXjSbcqhnHJBDkNoJlyU;
			}
			set
			{
				sWYQGFWGVXjSbcqhnHJBDkNoJlyU = value;
			}
		}

		public Func<T> getValueDelegate
		{
			get
			{
				return xnKVXylDpuGRsiaaeZIPhKQtxtAnA;
			}
			set
			{
				xnKVXylDpuGRsiaaeZIPhKQtxtAnA = value;
			}
		}

		public T value => wMRZzGYbbQhIlZYOIFGWtrJRbLxE;

		public event Action<T> ChangedEvent
		{
			add
			{
				jYCGwBwQNsBDCsIixmbLjkKArxrd = (Action<T>)Delegate.Combine(jYCGwBwQNsBDCsIixmbLjkKArxrd, value);
			}
			remove
			{
				jYCGwBwQNsBDCsIixmbLjkKArxrd = (Action<T>)Delegate.Remove(jYCGwBwQNsBDCsIixmbLjkKArxrd, value);
			}
		}

		public ValueWatcher(T P_0, bool P_1)
		{
			wMRZzGYbbQhIlZYOIFGWtrJRbLxE = P_0;
			sWYQGFWGVXjSbcqhnHJBDkNoJlyU = P_1;
		}

		public ValueWatcher(T P_0, Func<T> P_1, bool P_2)
			: this(P_0, P_2)
		{
			xnKVXylDpuGRsiaaeZIPhKQtxtAnA = P_1;
		}

		public override bool Update()
		{
			if (xnKVXylDpuGRsiaaeZIPhKQtxtAnA == null)
			{
				return false;
			}
			try
			{
				return Set(xnKVXylDpuGRsiaaeZIPhKQtxtAnA());
			}
			catch (Exception ex)
			{
				Logger.LogError("An exception was thrown by getValueDelegate.\n" + ex);
				return false;
			}
		}

		public override bool Use()
		{
			if (!ilMSTcHAuDiydqZBsiGKAXTeWLob)
			{
				return false;
			}
			ilMSTcHAuDiydqZBsiGKAXTeWLob = false;
			return true;
		}

		public override bool TriggerEvent()
		{
			if (!ilMSTcHAuDiydqZBsiGKAXTeWLob)
			{
				return false;
			}
			if (jYCGwBwQNsBDCsIixmbLjkKArxrd == null)
			{
				return true;
			}
			try
			{
				Use();
				jYCGwBwQNsBDCsIixmbLjkKArxrd(wMRZzGYbbQhIlZYOIFGWtrJRbLxE);
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
			if (cLVRibFROLTkkwJnROBeUjMKZcxV.Equals(wMRZzGYbbQhIlZYOIFGWtrJRbLxE, value))
			{
				return false;
			}
			wMRZzGYbbQhIlZYOIFGWtrJRbLxE = value;
			ilMSTcHAuDiydqZBsiGKAXTeWLob = true;
			if (sWYQGFWGVXjSbcqhnHJBDkNoJlyU)
			{
				TriggerEvent();
			}
			return true;
		}

		public override void AddEventListener(JeojSDdJARPbPEKvQdpKZyChHuTaA eventType, Delegate listener)
		{
			if (eventType == JeojSDdJARPbPEKvQdpKZyChHuTaA.ValueChanged)
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

		public override void RemoveEventListener(JeojSDdJARPbPEKvQdpKZyChHuTaA eventType, Delegate listener)
		{
			if (eventType == JeojSDdJARPbPEKvQdpKZyChHuTaA.ValueChanged)
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
