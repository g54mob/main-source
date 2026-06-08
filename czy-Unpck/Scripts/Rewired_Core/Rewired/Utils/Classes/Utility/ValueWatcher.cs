using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class ValueWatcher
	{
		public enum wqhclsbcPsIiJhOFFohEksltQEip
		{
			DmPTLOtlpUHkafFKTAVEGfHLbuR = 0
		}

		public abstract bool changed { get; }

		public abstract bool autoTriggerEvent { get; set; }

		public abstract bool Update();

		public abstract bool Use();

		public abstract bool TriggerEvent();

		public abstract void AddEventListener(wqhclsbcPsIiJhOFFohEksltQEip eventType, Delegate listener);

		public abstract void RemoveEventListener(wqhclsbcPsIiJhOFFohEksltQEip eventType, Delegate listener);
	}
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class ValueWatcher<T> : ValueWatcher
	{
		private static IEqualityComparer<T> RBgDVXQRhbyXaEdllztaBpdPjvKc = EqualityComparerNoAlloc<T>.Default;

		private bool fwXejRIYiBhYylWFZciuWMcLTfz;

		private T HewmgBxnlqheeaCyBbxCmITSoEAX;

		private bool NccmOoyddqjcvtvUyCtaUsgLiWWb;

		private Func<T> gbPDaGjyXRjKfIzuXktAcUGDsrN;

		private Action<T> cnvxhVvFAChlIPsUDXQblktLEuKd;

		public override bool changed => fwXejRIYiBhYylWFZciuWMcLTfz;

		public override bool autoTriggerEvent
		{
			get
			{
				return NccmOoyddqjcvtvUyCtaUsgLiWWb;
			}
			set
			{
				NccmOoyddqjcvtvUyCtaUsgLiWWb = value;
			}
		}

		public Func<T> getValueDelegate
		{
			get
			{
				return gbPDaGjyXRjKfIzuXktAcUGDsrN;
			}
			set
			{
				gbPDaGjyXRjKfIzuXktAcUGDsrN = value;
			}
		}

		public T value => HewmgBxnlqheeaCyBbxCmITSoEAX;

		public event Action<T> ChangedEvent
		{
			add
			{
				cnvxhVvFAChlIPsUDXQblktLEuKd = (Action<T>)Delegate.Combine(cnvxhVvFAChlIPsUDXQblktLEuKd, value);
			}
			remove
			{
				cnvxhVvFAChlIPsUDXQblktLEuKd = (Action<T>)Delegate.Remove(cnvxhVvFAChlIPsUDXQblktLEuKd, value);
			}
		}

		public ValueWatcher(T initialValue, bool autoTriggerEvent)
		{
			HewmgBxnlqheeaCyBbxCmITSoEAX = initialValue;
			NccmOoyddqjcvtvUyCtaUsgLiWWb = autoTriggerEvent;
		}

		public ValueWatcher(T initialValue, Func<T> getValueDelegate, bool autoTriggerEvent)
			: this(initialValue, autoTriggerEvent)
		{
			gbPDaGjyXRjKfIzuXktAcUGDsrN = getValueDelegate;
		}

		public override bool Update()
		{
			if (gbPDaGjyXRjKfIzuXktAcUGDsrN == null)
			{
				return false;
			}
			try
			{
				return Set(gbPDaGjyXRjKfIzuXktAcUGDsrN());
			}
			catch (Exception ex)
			{
				Logger.LogError("An exception was thrown by getValueDelegate.\n" + ex);
				return false;
			}
		}

		public override bool Use()
		{
			if (!fwXejRIYiBhYylWFZciuWMcLTfz)
			{
				return false;
			}
			fwXejRIYiBhYylWFZciuWMcLTfz = false;
			return true;
		}

		public override bool TriggerEvent()
		{
			if (!fwXejRIYiBhYylWFZciuWMcLTfz)
			{
				return false;
			}
			if (cnvxhVvFAChlIPsUDXQblktLEuKd == null)
			{
				return true;
			}
			try
			{
				Use();
				cnvxhVvFAChlIPsUDXQblktLEuKd(HewmgBxnlqheeaCyBbxCmITSoEAX);
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
			if (RBgDVXQRhbyXaEdllztaBpdPjvKc.Equals(HewmgBxnlqheeaCyBbxCmITSoEAX, value))
			{
				return false;
			}
			HewmgBxnlqheeaCyBbxCmITSoEAX = value;
			fwXejRIYiBhYylWFZciuWMcLTfz = true;
			if (NccmOoyddqjcvtvUyCtaUsgLiWWb)
			{
				TriggerEvent();
			}
			return true;
		}

		public override void AddEventListener(wqhclsbcPsIiJhOFFohEksltQEip eventType, Delegate listener)
		{
			if (eventType == wqhclsbcPsIiJhOFFohEksltQEip.DmPTLOtlpUHkafFKTAVEGfHLbuR)
			{
				if (!(listener is Action<T>))
				{
					while (true)
					{
						switch (-24886489 ^ -24886491)
						{
						case 0:
							break;
						case 2:
							throw new ArgumentException("listener must be of type Action<" + typeof(T).Name + ">");
						case 3:
							goto end_IL_000e;
						default:
							goto IL_006f;
						}
						continue;
						end_IL_000e:
						break;
					}
				}
				ChangedEvent += (Action<T>)listener;
				return;
			}
			goto IL_006f;
			IL_006f:
			throw new NotImplementedException();
		}

		public override void RemoveEventListener(wqhclsbcPsIiJhOFFohEksltQEip eventType, Delegate listener)
		{
			while (true)
			{
				switch (0xF1EDDA ^ 0xF1EDD9)
				{
				case 0:
					continue;
				case 3:
					if (eventType != wqhclsbcPsIiJhOFFohEksltQEip.DmPTLOtlpUHkafFKTAVEGfHLbuR)
					{
						break;
					}
					if (!(listener is Action<T>))
					{
						throw new ArgumentException("listener must be of type Action<" + typeof(T).Name + ">");
					}
					goto case 1;
				case 1:
					ChangedEvent -= (Action<T>)listener;
					return;
				}
				break;
			}
			throw new NotImplementedException();
		}
	}
}
