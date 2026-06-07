using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class ValueWatcher
	{
		public enum fIcJyKiwKrkVmcflAIjcgnvbprPIA
		{
			ValueChanged = 0
		}

		public abstract bool changed { get; }

		public abstract bool autoTriggerEvent { get; set; }

		public abstract bool Update();

		public abstract bool Use();

		public abstract bool TriggerEvent();

		public abstract void AddEventListener(fIcJyKiwKrkVmcflAIjcgnvbprPIA eventType, Delegate listener);

		public abstract void RemoveEventListener(fIcJyKiwKrkVmcflAIjcgnvbprPIA eventType, Delegate listener);
	}
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class ValueWatcher<T> : ValueWatcher
	{
		private static IEqualityComparer<T> IPjICzSigkGqBycVPWxUKUluMtll = EqualityComparerNoAlloc<T>.Default;

		private bool eeGGaxeEvUfrVaVbEruOrLmLqWGtb;

		private T YZxUdzxmklZNPuQQfDdyVZJzmbxt;

		private bool UgdnZCoaybTNEXmHAxjAPaYopgfE;

		private Func<T> nDUnuFzGkUMAbyKKbyuRzSgVPmEb;

		private Action<T> fGuOcdjHTZWGthiilEuPuDrwaHjM;

		public override bool changed => eeGGaxeEvUfrVaVbEruOrLmLqWGtb;

		public override bool autoTriggerEvent
		{
			get
			{
				return UgdnZCoaybTNEXmHAxjAPaYopgfE;
			}
			set
			{
				UgdnZCoaybTNEXmHAxjAPaYopgfE = value;
			}
		}

		public Func<T> getValueDelegate
		{
			get
			{
				return nDUnuFzGkUMAbyKKbyuRzSgVPmEb;
			}
			set
			{
				nDUnuFzGkUMAbyKKbyuRzSgVPmEb = value;
			}
		}

		public T value => YZxUdzxmklZNPuQQfDdyVZJzmbxt;

		public event Action<T> ChangedEvent
		{
			add
			{
				fGuOcdjHTZWGthiilEuPuDrwaHjM = (Action<T>)Delegate.Combine(fGuOcdjHTZWGthiilEuPuDrwaHjM, value);
			}
			remove
			{
				fGuOcdjHTZWGthiilEuPuDrwaHjM = (Action<T>)Delegate.Remove(fGuOcdjHTZWGthiilEuPuDrwaHjM, value);
			}
		}

		public ValueWatcher(T P_0, bool P_1)
		{
			YZxUdzxmklZNPuQQfDdyVZJzmbxt = P_0;
			UgdnZCoaybTNEXmHAxjAPaYopgfE = P_1;
		}

		public ValueWatcher(T P_0, Func<T> P_1, bool P_2)
			: this(P_0, P_2)
		{
			nDUnuFzGkUMAbyKKbyuRzSgVPmEb = P_1;
		}

		public override bool Update()
		{
			if (nDUnuFzGkUMAbyKKbyuRzSgVPmEb == null)
			{
				return false;
			}
			try
			{
				return Set(nDUnuFzGkUMAbyKKbyuRzSgVPmEb());
			}
			catch (Exception ex)
			{
				Logger.LogError("An exception was thrown by getValueDelegate.\n" + ex);
				return false;
			}
		}

		public override bool Use()
		{
			if (!eeGGaxeEvUfrVaVbEruOrLmLqWGtb)
			{
				return false;
			}
			eeGGaxeEvUfrVaVbEruOrLmLqWGtb = false;
			return true;
		}

		public override bool TriggerEvent()
		{
			if (!eeGGaxeEvUfrVaVbEruOrLmLqWGtb)
			{
				return false;
			}
			if (fGuOcdjHTZWGthiilEuPuDrwaHjM == null)
			{
				return true;
			}
			try
			{
				Use();
				fGuOcdjHTZWGthiilEuPuDrwaHjM(YZxUdzxmklZNPuQQfDdyVZJzmbxt);
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
			if (IPjICzSigkGqBycVPWxUKUluMtll.Equals(YZxUdzxmklZNPuQQfDdyVZJzmbxt, value))
			{
				return false;
			}
			YZxUdzxmklZNPuQQfDdyVZJzmbxt = value;
			eeGGaxeEvUfrVaVbEruOrLmLqWGtb = true;
			if (UgdnZCoaybTNEXmHAxjAPaYopgfE)
			{
				TriggerEvent();
			}
			return true;
		}

		public override void AddEventListener(fIcJyKiwKrkVmcflAIjcgnvbprPIA eventType, Delegate listener)
		{
			if (eventType == fIcJyKiwKrkVmcflAIjcgnvbprPIA.ValueChanged)
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

		public override void RemoveEventListener(fIcJyKiwKrkVmcflAIjcgnvbprPIA eventType, Delegate listener)
		{
			if (eventType == fIcJyKiwKrkVmcflAIjcgnvbprPIA.ValueChanged)
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
