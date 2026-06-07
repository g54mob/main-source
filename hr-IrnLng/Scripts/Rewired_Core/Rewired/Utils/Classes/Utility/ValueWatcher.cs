using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class ValueWatcher
	{
		public enum UOOTRzTlDFFdtgyXUOOEDGYyHzXJ
		{
			dmkzQJAfxnQGEPeSrBaMqketnLa = 0
		}

		public abstract bool changed { get; }

		public abstract bool autoTriggerEvent { get; set; }

		public abstract bool Update();

		public abstract bool Use();

		public abstract bool TriggerEvent();

		public abstract void AddEventListener(UOOTRzTlDFFdtgyXUOOEDGYyHzXJ eventType, Delegate listener);

		public abstract void RemoveEventListener(UOOTRzTlDFFdtgyXUOOEDGYyHzXJ eventType, Delegate listener);
	}
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class ValueWatcher<T> : ValueWatcher
	{
		private static IEqualityComparer<T> bBLxvYnojCxUGgNnVoSujVYrEGj = EqualityComparerNoAlloc<T>.Default;

		private bool RxylNCxQamBVELXVnXDusmFvjSA;

		private T rDXFGACXzNvmEuFurHYAqqwyQzh;

		private bool ncFfWnDhrHnxFZWICWwusxFvput;

		private Func<T> QAsMKDYGNskwLcVghuDGGkxtzBa;

		private Action<T> EOMFFWcAEdXcoNjYrKlbCZGvaBfI;

		public override bool changed => RxylNCxQamBVELXVnXDusmFvjSA;

		public override bool autoTriggerEvent
		{
			get
			{
				return ncFfWnDhrHnxFZWICWwusxFvput;
			}
			set
			{
				ncFfWnDhrHnxFZWICWwusxFvput = value;
			}
		}

		public Func<T> getValueDelegate
		{
			get
			{
				return QAsMKDYGNskwLcVghuDGGkxtzBa;
			}
			set
			{
				QAsMKDYGNskwLcVghuDGGkxtzBa = value;
			}
		}

		public T value => rDXFGACXzNvmEuFurHYAqqwyQzh;

		public event Action<T> ChangedEvent
		{
			add
			{
				EOMFFWcAEdXcoNjYrKlbCZGvaBfI = (Action<T>)Delegate.Combine(EOMFFWcAEdXcoNjYrKlbCZGvaBfI, value);
			}
			remove
			{
				EOMFFWcAEdXcoNjYrKlbCZGvaBfI = (Action<T>)Delegate.Remove(EOMFFWcAEdXcoNjYrKlbCZGvaBfI, value);
			}
		}

		public ValueWatcher(T initialValue, bool autoTriggerEvent)
		{
			rDXFGACXzNvmEuFurHYAqqwyQzh = initialValue;
			ncFfWnDhrHnxFZWICWwusxFvput = autoTriggerEvent;
		}

		public ValueWatcher(T initialValue, Func<T> getValueDelegate, bool autoTriggerEvent)
			: this(initialValue, autoTriggerEvent)
		{
			QAsMKDYGNskwLcVghuDGGkxtzBa = getValueDelegate;
		}

		public override bool Update()
		{
			if (QAsMKDYGNskwLcVghuDGGkxtzBa == null)
			{
				return false;
			}
			try
			{
				return Set(QAsMKDYGNskwLcVghuDGGkxtzBa());
			}
			catch (Exception ex)
			{
				Logger.LogError("An exception was thrown by getValueDelegate.\n" + ex);
				return false;
			}
		}

		public override bool Use()
		{
			if (!RxylNCxQamBVELXVnXDusmFvjSA)
			{
				return false;
			}
			RxylNCxQamBVELXVnXDusmFvjSA = false;
			return true;
		}

		public override bool TriggerEvent()
		{
			if (!RxylNCxQamBVELXVnXDusmFvjSA)
			{
				return false;
			}
			if (EOMFFWcAEdXcoNjYrKlbCZGvaBfI == null)
			{
				return true;
			}
			try
			{
				Use();
				EOMFFWcAEdXcoNjYrKlbCZGvaBfI(rDXFGACXzNvmEuFurHYAqqwyQzh);
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
			if (bBLxvYnojCxUGgNnVoSujVYrEGj.Equals(rDXFGACXzNvmEuFurHYAqqwyQzh, value))
			{
				return false;
			}
			rDXFGACXzNvmEuFurHYAqqwyQzh = value;
			RxylNCxQamBVELXVnXDusmFvjSA = true;
			if (ncFfWnDhrHnxFZWICWwusxFvput)
			{
				TriggerEvent();
			}
			return true;
		}

		public override void AddEventListener(UOOTRzTlDFFdtgyXUOOEDGYyHzXJ eventType, Delegate listener)
		{
			if (eventType == UOOTRzTlDFFdtgyXUOOEDGYyHzXJ.dmkzQJAfxnQGEPeSrBaMqketnLa)
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

		public override void RemoveEventListener(UOOTRzTlDFFdtgyXUOOEDGYyHzXJ eventType, Delegate listener)
		{
			if (eventType == UOOTRzTlDFFdtgyXUOOEDGYyHzXJ.dmkzQJAfxnQGEPeSrBaMqketnLa)
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
