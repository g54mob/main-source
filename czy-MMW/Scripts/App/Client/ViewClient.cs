using System;
using System.Collections.Generic;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;
using Motorways.Views;
using Motorways.Views.Trains;
using Server;
using UnityEngine;

namespace Client
{
	public class ViewClient : IClient, ISimulationObserver, IReusable, IReleasedFromScopeHandler
	{
		[Dependency]
		private IThemeDatabase _themeDatabase;

		[Dependency]
		private IDebugRenderSetManager _debugRenderSetManager;

		private bool _onFirstFrame;

		private readonly Dictionary<Type, ObserverList<IViewBuilder>> _builders = new Dictionary<Type, ObserverList<IViewBuilder>>();

		private readonly List<IView> _views = new List<IView>();

		private readonly List<IView> _tickingViews = new List<IView>();

		private readonly List<IViewLateTick> _lateTickingViews = new List<IViewLateTick>();

		private readonly List<IView> _viewsPendingRemoval = new List<IView>();

		private readonly List<IThemeComponent> _themeComponents = new List<IThemeComponent>();

		private readonly ObserverList<IViewClientObserver> _observers = new ObserverList<IViewClientObserver>();

		[Dependency]
		private CameraView _cameraView;

		[Dependency]
		public Scope Scope { get; private set; }

		public bool OnFirstFrame => _onFirstFrame;

		public CameraView CameraView => _cameraView;

		public virtual void Start()
		{
			_onFirstFrame = true;
		}

		public virtual void Tick(TimeInterval timeInterval, float stepAlpha)
		{
			foreach (IView item2 in _viewsPendingRemoval)
			{
				RemoveView(item2);
			}
			_viewsPendingRemoval.Clear();
			int num = 0;
			while (num < _tickingViews.Count)
			{
				IView view = _tickingViews[num];
				switch (view.Tick(timeInterval, stepAlpha))
				{
				case TickResult.ContinueTicking:
					num++;
					break;
				case TickResult.StopTicking:
					_tickingViews.RemoveAt(num);
					if (view is IViewLateTick item)
					{
						_lateTickingViews.Remove(item);
					}
					break;
				default:
					RemoveView(view);
					break;
				}
			}
			foreach (IViewLateTick lateTickingView in _lateTickingViews)
			{
				lateTickingView.LateTick(timeInterval, stepAlpha);
			}
			_onFirstFrame = false;
		}

		protected void AddThemeComponent(IThemeComponent component)
		{
			_themeComponents.Add(component);
			component.InitializeTheme(_themeDatabase);
			if (_themeDatabase != null && _themeDatabase.GetTheme() != null)
			{
				component.ApplyTheme(_themeDatabase.GetTheme());
			}
		}

		public void AddView(IView view)
		{
			_views.Add(view);
			_tickingViews.Add(view);
			_debugRenderSetManager.RegisterView(view);
			if (view is IViewLateTick item)
			{
				_lateTickingViews.Add(item);
			}
			if (view is IThemeComponent component)
			{
				AddThemeComponent(component);
			}
			ObserverList<IViewClientObserver>.Enumerator enumerator = _observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnViewAdded(this, view);
			}
		}

		public void ResumeTickingView(IView view)
		{
			_tickingViews.Add(view);
			if (view is IViewLateTick item)
			{
				_lateTickingViews.Add(item);
			}
		}

		public void SetAllGameObjectsEnabled(bool enabled)
		{
			foreach (IView item in new List<IView>(_views))
			{
				item.SetGameobjectActive(enabled);
			}
		}

		private void RemoveView(IView view)
		{
			int num = _views.IndexOf(view);
			if (Diagnostics.Verify(num != -1, "We are trying to remove a view that hasn't been added to this client yet!"))
			{
				ObserverList<IViewClientObserver>.Enumerator enumerator = _observers.GetEnumerator();
				while (enumerator.MoveNext())
				{
					enumerator.Current.OnViewRemoved(this, view);
				}
				Scope.Release(view);
				_views.RemoveAt(num);
				_tickingViews.Remove(view);
				_debugRenderSetManager.UnregisterView(view);
				if (view is IViewLateTick item)
				{
					_lateTickingViews.Remove(item);
				}
				if (view is IThemeComponent themeComponent)
				{
					themeComponent.ReleaseTheme(_themeDatabase);
					_themeComponents.Remove(themeComponent);
				}
			}
		}

		public void MarkViewForRemoval(IView view)
		{
			_viewsPendingRemoval.Add(view);
		}

		public void RegisterViewBuilder<T>(IViewBuilder builder)
		{
			Type typeFromHandle = typeof(T);
			if (!_builders.TryGetValue(typeFromHandle, out var value))
			{
				value = new ObserverList<IViewBuilder>();
				_builders[typeFromHandle] = value;
			}
			value.Subscribe(builder);
		}

		public void OnModelAdded(ISimulation simulation, IModel model, Fix64 timestamp)
		{
			if (_builders.TryGetValue(model.GetType(), out var value))
			{
				ObserverList<IViewBuilder>.Enumerator enumerator = value.GetEnumerator();
				while (enumerator.MoveNext())
				{
					enumerator.Current.CreateView(this, simulation, model, timestamp);
				}
			}
		}

		public void OnModelRemoved(ISimulation simulation, IModel model, Fix64 timestamp)
		{
			if (!(model is TrainCrossingModel trainCrossingModel))
			{
				return;
			}
			foreach (IView view in _views)
			{
				if (view is TrainCrossingView trainCrossingView && trainCrossingView.Model == trainCrossingModel)
				{
					MarkViewForRemoval(view);
				}
			}
		}

		public List<T> GetViews<T>() where T : class, IView
		{
			List<T> list = new List<T>();
			foreach (IView view in _views)
			{
				if (view is T)
				{
					list.Add(view as T);
				}
			}
			return list;
		}

		public void Subscribe(IViewClientObserver observer)
		{
			_observers.Subscribe(observer);
		}

		public bool Unsubscribe(IViewClientObserver observer)
		{
			return _observers.Unsubscribe(observer);
		}

		public virtual void OnReleasedFromScope(IScope scope)
		{
			while (_views.Count > 0)
			{
				RemoveView(_views[0]);
			}
		}

		public void Reset()
		{
			_views.Clear();
			_tickingViews.Clear();
			_lateTickingViews.Clear();
			_builders.Clear();
			_themeComponents.Clear();
		}

		public void ApplyTheme(ITheme theme)
		{
			foreach (IThemeComponent themeComponent in _themeComponents)
			{
				themeComponent.ApplyTheme(theme);
			}
		}

		public void ApplyBlendedTheme(ITheme oldTheme, ITheme newTheme, float progress)
		{
			foreach (IThemeComponent themeComponent in _themeComponents)
			{
				themeComponent.ApplyBlendedTheme(oldTheme, newTheme, progress);
			}
		}

		public CarparkView GetCarparkWithEmptySpace(Vector2 position)
		{
			foreach (CarparkView view in GetViews<CarparkView>())
			{
				CarparkModel model = view.Model;
				if (model != null && model.SupportsTwoDestinations && model.destinationOffsets.Count > model.destinations.Count)
				{
					Bounds emptyDestinationSlotBounds = view.GetEmptyDestinationSlotBounds();
					if (emptyDestinationSlotBounds.Contains(new Vector3(position.x, position.y, emptyDestinationSlotBounds.min.z)))
					{
						return view;
					}
				}
			}
			return null;
		}

		public CarparkView GetCarparkViewFromModel(CarparkModel model)
		{
			foreach (CarparkView view in GetViews<CarparkView>())
			{
				if (view.Model == model)
				{
					return view;
				}
			}
			return null;
		}
	}
}
