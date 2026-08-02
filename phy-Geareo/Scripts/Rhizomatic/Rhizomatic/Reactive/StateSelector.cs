using System;
using System.Collections.Generic;

namespace Rhizomatic.Reactive
{
	public class StateSelector : State
	{
		private Func<object> selector;

		private object selectorValue;

		private bool dirty;

		private State[] dependencies;

		public override object valueObj
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void Create(Func<object> selector, params State[] dependencies)
		{
		}

		public override void Changed()
		{
		}

		public void Dispose()
		{
		}

		public void SetTarget(State state)
		{
		}

		public void SetDependencies(params State[] dependencies)
		{
		}

		public StateSelector(Func<object> selector, params State[] dependencies)
		{
		}

		public StateSelector(params State[] dependencies)
		{
		}

		public StateSelector(State state)
		{
		}

		public static StateSelector<List<TView>> MakeList<TModel, TView>(Func<List<TModel>> selector, Func<TView, TModel> getModel, Func<TModel, TView> getView, Action<TView> disposeView, params State[] dependencies)
		{
			return null;
		}

		public static StateSelector<List<TView>> MakeList<TModel, TView>(StateSelector<List<TModel>> selector, Func<TView, TModel> getModel, Func<TModel, TView> getView)
		{
			return null;
		}

		public static StateSelector<List<TView>> MakeList<TModel, TView>(StateSelector<List<TModel>> selector, Func<TModel, TView> getView) where TView : IListItemView<TModel>
		{
			return null;
		}
	}
	public class StateSelector<T> : StateSelector
	{
		public T value => default(T);

		public StateSelector(Func<T> selector, params State[] dependencies)
			: base((Func<object>)null, (State[])null)
		{
		}

		public StateSelector(State<T> state)
			: base((Func<object>)null, (State[])null)
		{
		}

		public StateSelector(StateSelector<T> state)
			: base((Func<object>)null, (State[])null)
		{
		}

		public static implicit operator T(StateSelector<T> state)
		{
			return default(T);
		}
	}
}
