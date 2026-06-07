using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class ValueWatcher
	{
		public enum ulKaOvHOgwRJTEgZlaWLbcFACCeuA
		{
			ValueChanged = 0
		}

		public abstract bool changed { get; }

		public abstract bool autoTriggerEvent { get; set; }

		public abstract bool Update();

		public abstract bool Use();

		public abstract bool TriggerEvent();

		public abstract void AddEventListener(ulKaOvHOgwRJTEgZlaWLbcFACCeuA eventType, Delegate listener);

		public abstract void RemoveEventListener(ulKaOvHOgwRJTEgZlaWLbcFACCeuA eventType, Delegate listener);
	}
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class ValueWatcher<T> : ValueWatcher
	{
		private static IEqualityComparer<T> VxrorDFoJmQEamHVmeWxQNXjApGh;

		private bool LADIOxPPaHOMeqkvFGZVQUQNhkuy;

		private T RgjXTgIJPflPzDCohtoXrcCgRNUO;

		private bool VisUYtMfKsmMloBmEaXKVEIZDFic;

		private Func<T> IAyJEKpdXVankqYCTIpAKAFOYHnV;

		private Action<T> QMurWniaaVNzOsAcIWLAlupzJVCs;

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

		public ValueWatcher(T P_0, bool P_1)
		{
		}

		public ValueWatcher(T P_0, Func<T> P_1, bool P_2)
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

		public override void AddEventListener(ulKaOvHOgwRJTEgZlaWLbcFACCeuA eventType, Delegate listener)
		{
		}

		public override void RemoveEventListener(ulKaOvHOgwRJTEgZlaWLbcFACCeuA eventType, Delegate listener)
		{
		}
	}
}
