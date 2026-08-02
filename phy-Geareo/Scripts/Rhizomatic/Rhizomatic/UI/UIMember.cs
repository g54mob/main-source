using System;
using Rhizomatic.MemberBinding;
using Rhizomatic.Reactive;

namespace Rhizomatic.UI
{
	public class UIMember<TValue> : UIMember<TValue, UIAdapter<TValue>>
	{
	}
	public class UIMember<TValue, TAdapter> : Member<TAdapter>, ICrewRenderer, ICrewView where TAdapter : UIAdapter<TValue>
	{
		private TValue _value;

		private Action<TValue> setter;

		public TValue value
		{
			get
			{
				return default(TValue);
			}
			set
			{
			}
		}

		public void SetValue(TValue value)
		{
		}

		public void SetValueWithoutNotify(TValue value)
		{
		}

		public virtual void CrewRender(object value)
		{
		}

		public void CrewOpen(State state)
		{
		}

		public void CrewClose(State state)
		{
		}
	}
}
