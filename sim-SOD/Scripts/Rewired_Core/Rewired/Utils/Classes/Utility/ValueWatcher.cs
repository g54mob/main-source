using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class ValueWatcher
	{
		public enum MniqWQSasBeusRopevtBwxdbKOU
		{
			dSMUOcBaMxLBVuuuNVUNQXZeeeb = 0
		}

		public abstract bool changed { get; }

		public abstract bool autoTriggerEvent { get; set; }

		public abstract bool Update();

		public abstract bool Use();

		public abstract bool TriggerEvent();

		public abstract void AddEventListener(MniqWQSasBeusRopevtBwxdbKOU eventType, Delegate listener);

		public abstract void RemoveEventListener(MniqWQSasBeusRopevtBwxdbKOU eventType, Delegate listener);
	}
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class ValueWatcher<T> : ValueWatcher
	{
		private static IEqualityComparer<T> jinAGlsBSOHFZTtZxjrvJgtkppo;

		private bool XfWkfZiNtkSXHkvoBsbvUyDupJx;

		private T pCzpvrDEhJkiZFEUDtfBShXbIag;

		private bool hddylWSoWZwqWgCeworfIkwqNIa;

		private Func<T> QdWFlsjBowQlCWTUDDwXVkGkuslP;

		private Action<T> GYyglrXNhxtGzUriHKPmjDncgay;

		public override bool changed => false;

		public override bool autoTriggerEvent
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Func<T> getValueDelegate
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public T value => default(T);

		public event Action<T> ChangedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public ValueWatcher(T initialValue, bool autoTriggerEvent)
		{
		}

		public ValueWatcher(T initialValue, Func<T> getValueDelegate, bool autoTriggerEvent)
		{
		}

		public override bool Update()
		{
			return false;
		}

		public override bool Use()
		{
			return false;
		}

		public override bool TriggerEvent()
		{
			return false;
		}

		public bool Set(T value)
		{
			return false;
		}

		public override void AddEventListener(MniqWQSasBeusRopevtBwxdbKOU eventType, Delegate listener)
		{
		}

		public override void RemoveEventListener(MniqWQSasBeusRopevtBwxdbKOU eventType, Delegate listener)
		{
		}
	}
}
