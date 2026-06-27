using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class ValueWatcher
	{
		public enum vqttouEBQDAzbLQcBwajFiqscCfP
		{
			ValueChanged = 0
		}

		public abstract bool changed { get; }

		public abstract bool autoTriggerEvent { get; set; }

		public abstract bool Update();

		public abstract bool Use();

		public abstract bool TriggerEvent();

		public abstract void AddEventListener(vqttouEBQDAzbLQcBwajFiqscCfP eventType, Delegate listener);

		public abstract void RemoveEventListener(vqttouEBQDAzbLQcBwajFiqscCfP eventType, Delegate listener);
	}
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class ValueWatcher<T> : ValueWatcher
	{
		private static IEqualityComparer<T> QtYBLQIGARCRAApaGxATJhwTrAVsA = EqualityComparerNoAlloc<T>.Default;

		private bool MhiureGiSoUPAjqKtfWjxIfragpr;

		private T QfMFmrNotEbWFdQZHVKtBQrAnLPGb;

		private bool OKBDzcZyLBulDpNkswKaouhfBNIU;

		private Func<T> JPXkTaefJaqQyzhgvBiQbmWsRkIB;

		private Action<T> RNJdjoapOgvmaDlHwHhyxYIVYBFo;

		bool ValueWatcher.changed => MhiureGiSoUPAjqKtfWjxIfragpr;

		bool ValueWatcher.autoTriggerEvent
		{
			get
			{
				return OKBDzcZyLBulDpNkswKaouhfBNIU;
			}
			set
			{
				OKBDzcZyLBulDpNkswKaouhfBNIU = value;
			}
		}

		public Func<T> getValueDelegate
		{
			get
			{
				return JPXkTaefJaqQyzhgvBiQbmWsRkIB;
			}
			set
			{
				JPXkTaefJaqQyzhgvBiQbmWsRkIB = value;
			}
		}

		public T value => QfMFmrNotEbWFdQZHVKtBQrAnLPGb;

		public event Action<T> ChangedEvent
		{
			add
			{
				RNJdjoapOgvmaDlHwHhyxYIVYBFo = (Action<T>)Delegate.Combine(RNJdjoapOgvmaDlHwHhyxYIVYBFo, value);
			}
			remove
			{
				RNJdjoapOgvmaDlHwHhyxYIVYBFo = (Action<T>)Delegate.Remove(RNJdjoapOgvmaDlHwHhyxYIVYBFo, value);
			}
		}

		public ValueWatcher(T P_0, bool P_1)
		{
			QfMFmrNotEbWFdQZHVKtBQrAnLPGb = P_0;
			OKBDzcZyLBulDpNkswKaouhfBNIU = P_1;
		}

		public ValueWatcher(T P_0, Func<T> P_1, bool P_2)
			: this(P_0, P_2)
		{
			JPXkTaefJaqQyzhgvBiQbmWsRkIB = P_1;
		}

		public override bool Update()
		{
			if (JPXkTaefJaqQyzhgvBiQbmWsRkIB == null)
			{
				return false;
			}
			try
			{
				return Set(JPXkTaefJaqQyzhgvBiQbmWsRkIB());
			}
			catch (Exception ex)
			{
				Logger.LogError("An exception was thrown by getValueDelegate.\n" + ex);
				return false;
			}
		}

		public override bool Use()
		{
			if (!MhiureGiSoUPAjqKtfWjxIfragpr)
			{
				return false;
			}
			MhiureGiSoUPAjqKtfWjxIfragpr = false;
			return true;
		}

		public override bool TriggerEvent()
		{
			if (!MhiureGiSoUPAjqKtfWjxIfragpr)
			{
				return false;
			}
			if (RNJdjoapOgvmaDlHwHhyxYIVYBFo == null)
			{
				return true;
			}
			try
			{
				Use();
				RNJdjoapOgvmaDlHwHhyxYIVYBFo(QfMFmrNotEbWFdQZHVKtBQrAnLPGb);
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
			if (QtYBLQIGARCRAApaGxATJhwTrAVsA.Equals(QfMFmrNotEbWFdQZHVKtBQrAnLPGb, value))
			{
				return false;
			}
			QfMFmrNotEbWFdQZHVKtBQrAnLPGb = value;
			MhiureGiSoUPAjqKtfWjxIfragpr = true;
			if (OKBDzcZyLBulDpNkswKaouhfBNIU)
			{
				TriggerEvent();
			}
			return true;
		}

		public override void AddEventListener(vqttouEBQDAzbLQcBwajFiqscCfP eventType, Delegate listener)
		{
			if (eventType == vqttouEBQDAzbLQcBwajFiqscCfP.ValueChanged)
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

		public override void RemoveEventListener(vqttouEBQDAzbLQcBwajFiqscCfP eventType, Delegate listener)
		{
			if (eventType == vqttouEBQDAzbLQcBwajFiqscCfP.ValueChanged)
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
