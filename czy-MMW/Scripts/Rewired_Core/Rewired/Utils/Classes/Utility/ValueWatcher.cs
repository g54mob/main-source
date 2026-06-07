using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class ValueWatcher
	{
		public enum qoDePNMoOIGVxRbnJchLTcSPwLjm
		{
			ValueChanged = 0
		}

		public abstract bool changed { get; }

		public abstract bool autoTriggerEvent { get; set; }

		public abstract bool Update();

		public abstract bool Use();

		public abstract bool TriggerEvent();

		public abstract void AddEventListener(qoDePNMoOIGVxRbnJchLTcSPwLjm eventType, Delegate listener);

		public abstract void RemoveEventListener(qoDePNMoOIGVxRbnJchLTcSPwLjm eventType, Delegate listener);
	}
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class ValueWatcher<T> : ValueWatcher
	{
		private static IEqualityComparer<T> VmAEjXWKQpHGMblIwEtNvScJmBRA = EqualityComparerNoAlloc<T>.Default;

		private bool JfAqaZMjEhkHUnHVtavXlhFGgQhCA;

		private T VdgflMAXfTbMZOGMFWMHUKVjIhHjA;

		private bool XDvgBKVVGMbTtnhisCMNeFUKrQqb;

		private Func<T> KafefsoyrprsUhYmjaTSvrWVClqN;

		private Action<T> OnnkkDnmArhuucnEokpQfMwykjBXA;

		bool ValueWatcher.changed => JfAqaZMjEhkHUnHVtavXlhFGgQhCA;

		bool ValueWatcher.autoTriggerEvent
		{
			get
			{
				return XDvgBKVVGMbTtnhisCMNeFUKrQqb;
			}
			set
			{
				XDvgBKVVGMbTtnhisCMNeFUKrQqb = value;
			}
		}

		public Func<T> getValueDelegate
		{
			get
			{
				return KafefsoyrprsUhYmjaTSvrWVClqN;
			}
			set
			{
				KafefsoyrprsUhYmjaTSvrWVClqN = value;
			}
		}

		public T value => VdgflMAXfTbMZOGMFWMHUKVjIhHjA;

		public event Action<T> ChangedEvent
		{
			add
			{
				OnnkkDnmArhuucnEokpQfMwykjBXA = (Action<T>)Delegate.Combine(OnnkkDnmArhuucnEokpQfMwykjBXA, value);
			}
			remove
			{
				OnnkkDnmArhuucnEokpQfMwykjBXA = (Action<T>)Delegate.Remove(OnnkkDnmArhuucnEokpQfMwykjBXA, value);
			}
		}

		public ValueWatcher(T P_0, bool P_1)
		{
			VdgflMAXfTbMZOGMFWMHUKVjIhHjA = P_0;
			XDvgBKVVGMbTtnhisCMNeFUKrQqb = P_1;
		}

		public ValueWatcher(T P_0, Func<T> P_1, bool P_2)
			: this(P_0, P_2)
		{
			KafefsoyrprsUhYmjaTSvrWVClqN = P_1;
		}

		public override bool Update()
		{
			if (KafefsoyrprsUhYmjaTSvrWVClqN == null)
			{
				return false;
			}
			try
			{
				return Set(KafefsoyrprsUhYmjaTSvrWVClqN());
			}
			catch (Exception ex)
			{
				Logger.LogError("An exception was thrown by getValueDelegate.\n" + ex);
				return false;
			}
		}

		public override bool Use()
		{
			if (!JfAqaZMjEhkHUnHVtavXlhFGgQhCA)
			{
				return false;
			}
			JfAqaZMjEhkHUnHVtavXlhFGgQhCA = false;
			return true;
		}

		public override bool TriggerEvent()
		{
			if (!JfAqaZMjEhkHUnHVtavXlhFGgQhCA)
			{
				return false;
			}
			if (OnnkkDnmArhuucnEokpQfMwykjBXA == null)
			{
				return true;
			}
			try
			{
				Use();
				OnnkkDnmArhuucnEokpQfMwykjBXA(VdgflMAXfTbMZOGMFWMHUKVjIhHjA);
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
			if (VmAEjXWKQpHGMblIwEtNvScJmBRA.Equals(VdgflMAXfTbMZOGMFWMHUKVjIhHjA, value))
			{
				return false;
			}
			VdgflMAXfTbMZOGMFWMHUKVjIhHjA = value;
			JfAqaZMjEhkHUnHVtavXlhFGgQhCA = true;
			if (XDvgBKVVGMbTtnhisCMNeFUKrQqb)
			{
				TriggerEvent();
			}
			return true;
		}

		public override void AddEventListener(qoDePNMoOIGVxRbnJchLTcSPwLjm eventType, Delegate listener)
		{
			if (eventType == qoDePNMoOIGVxRbnJchLTcSPwLjm.ValueChanged)
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

		public override void RemoveEventListener(qoDePNMoOIGVxRbnJchLTcSPwLjm eventType, Delegate listener)
		{
			if (eventType == qoDePNMoOIGVxRbnJchLTcSPwLjm.ValueChanged)
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
