using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class ValueWatcher
	{
		public enum ciIrZyTVgergzZytzPEVdgbKWVnc
		{
			ValueChanged = 0
		}

		public abstract bool changed { get; }

		public abstract bool autoTriggerEvent { get; set; }

		public abstract bool Update();

		public abstract bool Use();

		public abstract bool TriggerEvent();

		public abstract void AddEventListener(ciIrZyTVgergzZytzPEVdgbKWVnc eventType, Delegate listener);

		public abstract void RemoveEventListener(ciIrZyTVgergzZytzPEVdgbKWVnc eventType, Delegate listener);
	}
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class ValueWatcher<T> : ValueWatcher
	{
		private static IEqualityComparer<T> NBvLLtZnTysoLxpsijYiHQolOchm = EqualityComparerNoAlloc<T>.Default;

		private bool RLRGzXBDZTRmHsxITRWSVqdRBsHKA;

		private T JGlReIWpgpQtQCWRvsdWyXpiKHrO;

		private bool FKqnqRQLOuOwIdAuYjKNEJhJFMig;

		private Func<T> CTooSuvgsPZgRtezRyYRNPuIPTAJ;

		private Action<T> STyXlRirHXvTlnkHCIAJDsYtNJxeA;

		bool ValueWatcher.changed => RLRGzXBDZTRmHsxITRWSVqdRBsHKA;

		bool ValueWatcher.autoTriggerEvent
		{
			get
			{
				return FKqnqRQLOuOwIdAuYjKNEJhJFMig;
			}
			set
			{
				FKqnqRQLOuOwIdAuYjKNEJhJFMig = value;
			}
		}

		public Func<T> getValueDelegate
		{
			get
			{
				return CTooSuvgsPZgRtezRyYRNPuIPTAJ;
			}
			set
			{
				CTooSuvgsPZgRtezRyYRNPuIPTAJ = value;
			}
		}

		public T value => JGlReIWpgpQtQCWRvsdWyXpiKHrO;

		public event Action<T> ChangedEvent
		{
			add
			{
				STyXlRirHXvTlnkHCIAJDsYtNJxeA = (Action<T>)Delegate.Combine(STyXlRirHXvTlnkHCIAJDsYtNJxeA, value);
			}
			remove
			{
				STyXlRirHXvTlnkHCIAJDsYtNJxeA = (Action<T>)Delegate.Remove(STyXlRirHXvTlnkHCIAJDsYtNJxeA, value);
			}
		}

		public ValueWatcher(T P_0, bool P_1)
		{
			JGlReIWpgpQtQCWRvsdWyXpiKHrO = P_0;
			FKqnqRQLOuOwIdAuYjKNEJhJFMig = P_1;
		}

		public ValueWatcher(T P_0, Func<T> P_1, bool P_2)
			: this(P_0, P_2)
		{
			CTooSuvgsPZgRtezRyYRNPuIPTAJ = P_1;
		}

		public override bool Update()
		{
			if (CTooSuvgsPZgRtezRyYRNPuIPTAJ == null)
			{
				return false;
			}
			try
			{
				return Set(CTooSuvgsPZgRtezRyYRNPuIPTAJ());
			}
			catch (Exception ex)
			{
				Logger.LogError("An exception was thrown by getValueDelegate.\n" + ex);
				return false;
			}
		}

		public override bool Use()
		{
			if (!RLRGzXBDZTRmHsxITRWSVqdRBsHKA)
			{
				return false;
			}
			RLRGzXBDZTRmHsxITRWSVqdRBsHKA = false;
			return true;
		}

		public override bool TriggerEvent()
		{
			if (!RLRGzXBDZTRmHsxITRWSVqdRBsHKA)
			{
				return false;
			}
			if (STyXlRirHXvTlnkHCIAJDsYtNJxeA == null)
			{
				return true;
			}
			try
			{
				Use();
				STyXlRirHXvTlnkHCIAJDsYtNJxeA(JGlReIWpgpQtQCWRvsdWyXpiKHrO);
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
			if (NBvLLtZnTysoLxpsijYiHQolOchm.Equals(JGlReIWpgpQtQCWRvsdWyXpiKHrO, value))
			{
				return false;
			}
			JGlReIWpgpQtQCWRvsdWyXpiKHrO = value;
			RLRGzXBDZTRmHsxITRWSVqdRBsHKA = true;
			if (FKqnqRQLOuOwIdAuYjKNEJhJFMig)
			{
				TriggerEvent();
			}
			return true;
		}

		public override void AddEventListener(ciIrZyTVgergzZytzPEVdgbKWVnc eventType, Delegate listener)
		{
			if (eventType == ciIrZyTVgergzZytzPEVdgbKWVnc.ValueChanged)
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

		public override void RemoveEventListener(ciIrZyTVgergzZytzPEVdgbKWVnc eventType, Delegate listener)
		{
			if (eventType == ciIrZyTVgergzZytzPEVdgbKWVnc.ValueChanged)
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
