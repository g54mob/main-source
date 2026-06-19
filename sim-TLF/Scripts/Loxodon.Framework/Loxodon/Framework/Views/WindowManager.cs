using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Loxodon.Framework.Asynchronous;
using Loxodon.Framework.Execution;
using UnityEngine;

namespace Loxodon.Framework.Views
{
	[DisallowMultipleComponent]
	public class WindowManager : MonoBehaviour, IWindowManager
	{
		private class InternalVisibleEnumerator : IEnumerator<IWindow>, IEnumerator, IDisposable
		{
			private List<IWindow> windows;

			private int index = -1;

			public IWindow Current
			{
				get
				{
					if (index >= 0 && index < windows.Count)
					{
						return windows[index];
					}
					return null;
				}
			}

			object IEnumerator.Current => Current;

			public InternalVisibleEnumerator(List<IWindow> list)
			{
				windows = list;
			}

			public void Dispose()
			{
				index = -1;
				windows.Clear();
			}

			public bool MoveNext()
			{
				if (index >= windows.Count - 1)
				{
					return false;
				}
				index++;
				while (index < windows.Count)
				{
					IWindow window = windows[index];
					if (window != null && window.Visibility)
					{
						return true;
					}
					index++;
				}
				return false;
			}

			public void Reset()
			{
				index = -1;
			}
		}

		private class ShowTransition : Transition
		{
			private WindowManager manager;

			public ShowTransition(WindowManager manager, IManageable window)
				: base(window)
			{
				this.manager = manager;
			}

			protected virtual ActionType Overlay(IWindow previous, IWindow current)
			{
				if (previous == null || previous.WindowType == WindowType.FULL)
				{
					return ActionType.None;
				}
				if (previous.WindowType == WindowType.POPUP)
				{
					return ActionType.Dismiss;
				}
				return ActionType.None;
			}

			protected override IEnumerator DoTransition()
			{
				IManageable current = Window;
				int num = ((Layer >= 0 && current.WindowType != WindowType.DIALOG && current.WindowType != WindowType.PROGRESS) ? Layer : 0);
				if (num > 0)
				{
					int visibleCount = manager.VisibleCount;
					if (num > visibleCount)
					{
						num = visibleCount;
					}
				}
				Layer = num;
				IManageable previous = (IManageable)manager.GetVisibleWindow(num);
				if (previous != null)
				{
					if (previous.Activated)
					{
						Loxodon.Framework.Asynchronous.IAsyncResult asyncResult = previous.Passivate(AnimationDisabled);
						yield return asyncResult.WaitForDone();
					}
					Func<IWindow, IWindow, ActionType> func = OverlayPolicy;
					if (func == null)
					{
						func = Overlay;
					}
					switch (func(previous, current))
					{
					case ActionType.Hide:
						previous.DoHide(AnimationDisabled);
						break;
					case ActionType.Dismiss:
						previous.DoHide(AnimationDisabled).Callbackable().OnCallback(delegate
						{
							previous.DoDismiss();
						});
						break;
					}
				}
				if (!current.Visibility)
				{
					Loxodon.Framework.Asynchronous.IAsyncResult asyncResult2 = current.DoShow(AnimationDisabled);
					yield return asyncResult2.WaitForDone();
				}
				if (manager.Activated && current.Equals(manager.Current))
				{
					Loxodon.Framework.Asynchronous.IAsyncResult asyncResult3 = current.Activate(AnimationDisabled);
					yield return asyncResult3.WaitForDone();
				}
			}
		}

		private class HideTransition : Transition
		{
			private WindowManager manager;

			private bool dismiss;

			public HideTransition(WindowManager manager, IManageable window, bool dismiss)
				: base(window)
			{
				this.dismiss = dismiss;
				this.manager = manager;
			}

			protected override IEnumerator DoTransition()
			{
				IManageable current = Window;
				if (manager.IndexOf(current) == 0 && current.Activated)
				{
					Loxodon.Framework.Asynchronous.IAsyncResult asyncResult = current.Passivate(AnimationDisabled);
					yield return asyncResult.WaitForDone();
				}
				if (current.Visibility)
				{
					Loxodon.Framework.Asynchronous.IAsyncResult asyncResult2 = current.DoHide(AnimationDisabled);
					yield return asyncResult2.WaitForDone();
				}
				if (dismiss)
				{
					current.DoDismiss();
				}
			}
		}

		private class BlockingCoroutineTransitionExecutor
		{
			private Loxodon.Framework.Asynchronous.IAsyncResult taskResult;

			private bool running;

			private List<Transition> transitions = new List<Transition>();

			public bool IsRunning => running;

			public int Count => transitions.Count;

			public void Execute(Transition transition)
			{
				try
				{
					if (transition is ShowTransition && transition.Window.WindowType == WindowType.QUEUED_POPUP)
					{
						int num = transitions.FindLastIndex((Transition t) => t is ShowTransition && t.Window.WindowType == WindowType.QUEUED_POPUP && t.Window.WindowManager == transition.Window.WindowManager && t.Window.WindowPriority >= transition.Window.WindowPriority);
						if (num >= 0)
						{
							transitions.Insert(num + 1, transition);
							return;
						}
						num = transitions.FindIndex((Transition t) => t is ShowTransition && t.Window.WindowType == WindowType.QUEUED_POPUP && t.Window.WindowManager == transition.Window.WindowManager && t.Window.WindowPriority < transition.Window.WindowPriority);
						if (num >= 0)
						{
							transitions.Insert(num, transition);
							return;
						}
					}
					transitions.Add(transition);
				}
				finally
				{
					if (!running)
					{
						taskResult = Executors.RunOnCoroutine(DoTask());
					}
				}
			}

			public void Shutdown()
			{
				if (taskResult != null)
				{
					taskResult.Cancel();
					running = false;
					taskResult = null;
				}
				transitions.Clear();
			}

			private bool Check(Transition transition)
			{
				if (!(transition is ShowTransition))
				{
					return true;
				}
				IManageable window = transition.Window;
				IWindow current = window.WindowManager.Current;
				if (current == null)
				{
					return true;
				}
				if (current.WindowType == WindowType.DIALOG || current.WindowType == WindowType.PROGRESS)
				{
					return false;
				}
				if (current.WindowType == WindowType.QUEUED_POPUP && window.WindowType != WindowType.DIALOG && window.WindowType != WindowType.PROGRESS)
				{
					return false;
				}
				return true;
			}

			protected virtual IEnumerator DoTask()
			{
				try
				{
					running = true;
					yield return null;
					while (transitions.Count > 0)
					{
						Transition transition = transitions.Find((Transition e) => Check(e));
						if (transition != null)
						{
							transitions.Remove(transition);
							Loxodon.Framework.Asynchronous.IAsyncResult asyncResult = Executors.RunOnCoroutine(transition.TransitionTask());
							yield return asyncResult.WaitForDone();
							IWindowManager manager = transition.Window.WindowManager;
							IWindow current = manager.Current;
							if (manager.Activated && current != null && !current.Activated && !transitions.Exists((Transition e) => e.Window.WindowManager.Equals(manager)))
							{
								Loxodon.Framework.Asynchronous.IAsyncResult asyncResult2 = (current as IManageable).Activate(transition.AnimationDisabled);
								yield return asyncResult2.WaitForDone();
							}
						}
						else
						{
							yield return null;
						}
					}
				}
				finally
				{
					BlockingCoroutineTransitionExecutor blockingCoroutineTransitionExecutor = this;
					blockingCoroutineTransitionExecutor.running = false;
					blockingCoroutineTransitionExecutor.taskResult = null;
				}
			}
		}

		private static BlockingCoroutineTransitionExecutor blockingExecutor;

		private bool lastActivated = true;

		private bool activated = true;

		private List<IWindow> windows = new List<IWindow>();

		public virtual bool Activated
		{
			get
			{
				return activated;
			}
			set
			{
				if (activated != value)
				{
					activated = value;
				}
			}
		}

		public int Count => windows.Count;

		public int VisibleCount => windows.FindAll((IWindow w) => w.Visibility).Count;

		public virtual IWindow Current
		{
			get
			{
				if (windows == null || windows.Count <= 0)
				{
					return null;
				}
				IWindow window = windows[0];
				if (window == null || !window.Visibility)
				{
					return null;
				}
				return window;
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		private static void OnInitialize()
		{
			if (blockingExecutor != null)
			{
				blockingExecutor = null;
			}
		}

		private static BlockingCoroutineTransitionExecutor GetTransitionExecutor()
		{
			if (blockingExecutor == null)
			{
				blockingExecutor = new BlockingCoroutineTransitionExecutor();
			}
			return blockingExecutor;
		}

		public virtual IWindow GetVisibleWindow(int index)
		{
			if (windows == null || windows.Count <= 1)
			{
				return null;
			}
			int num = -1;
			IEnumerator<IWindow> enumerator = Visibles();
			while (enumerator.MoveNext())
			{
				num++;
				if (num > index)
				{
					return null;
				}
				if (num == index)
				{
					return enumerator.Current;
				}
			}
			return null;
		}

		protected virtual void OnEnable()
		{
			Activated = lastActivated;
		}

		protected virtual void OnDisable()
		{
			lastActivated = Activated;
			Activated = false;
		}

		protected virtual void OnDestroy()
		{
			if (windows.Count > 0)
			{
				Clear();
			}
		}

		protected virtual void OnApplicationQuit()
		{
			if (blockingExecutor != null)
			{
				blockingExecutor.Shutdown();
				blockingExecutor = null;
			}
		}

		public virtual void Clear()
		{
			for (int i = 0; i < windows.Count; i++)
			{
				try
				{
					windows[i].Dismiss(ignoreAnimation: true);
				}
				catch (Exception)
				{
				}
			}
			windows.Clear();
		}

		public virtual bool Contains(IWindow window)
		{
			return windows.Contains(window);
		}

		public virtual int IndexOf(IWindow window)
		{
			return windows.IndexOf(window);
		}

		public virtual IWindow Get(int index)
		{
			if (index < 0 || index > windows.Count - 1)
			{
				throw new IndexOutOfRangeException();
			}
			return windows[index];
		}

		public virtual void Add(IWindow window)
		{
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}
			if (!windows.Contains(window))
			{
				windows.Add(window);
				AddChild(GetTransform(window));
			}
		}

		public virtual bool Remove(IWindow window)
		{
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}
			RemoveChild(GetTransform(window));
			return windows.Remove(window);
		}

		public virtual IWindow RemoveAt(int index)
		{
			if (index < 0 || index > windows.Count - 1)
			{
				throw new IndexOutOfRangeException();
			}
			IWindow window = windows[index];
			RemoveChild(GetTransform(window));
			windows.RemoveAt(index);
			return window;
		}

		protected virtual void MoveToLast(IWindow window)
		{
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}
			try
			{
				int num = IndexOf(window);
				if (num >= 0 && num != Count - 1)
				{
					windows.RemoveAt(num);
					windows.Add(window);
				}
			}
			finally
			{
				Transform transform = GetTransform(window);
				if (transform != null)
				{
					transform.SetAsFirstSibling();
				}
			}
		}

		protected virtual void MoveToFirst(IWindow window)
		{
			MoveToIndex(window, 0);
		}

		protected virtual void MoveToIndex(IWindow window, int index)
		{
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}
			int num = IndexOf(window);
			try
			{
				if (num >= 0 && num != index)
				{
					windows.RemoveAt(num);
					windows.Insert(index, window);
				}
			}
			finally
			{
				Transform transform = GetTransform(window);
				if (transform != null)
				{
					if (index == 0)
					{
						transform.SetAsLastSibling();
					}
					else
					{
						IWindow window2 = windows[index - 1];
						int childIndex = GetChildIndex(GetTransform(window2));
						int siblingIndex = ((num >= index) ? (childIndex - 1) : childIndex);
						transform.SetSiblingIndex(siblingIndex);
					}
				}
			}
		}

		public virtual IEnumerator<IWindow> Visibles()
		{
			return new InternalVisibleEnumerator(windows);
		}

		public virtual List<IWindow> Find(bool visible)
		{
			return windows.FindAll((IWindow w) => w.Visibility == visible);
		}

		public virtual IWindow Find(Type windowType)
		{
			if (windowType == null)
			{
				return null;
			}
			return windows.Find((IWindow w) => windowType.IsAssignableFrom(w.GetType()));
		}

		public virtual T Find<T>() where T : IWindow
		{
			return (T)windows.Find((IWindow w) => w is T);
		}

		public virtual IWindow Find(string name, Type windowType)
		{
			if (name == null || windowType == null)
			{
				return null;
			}
			return windows.Find((IWindow w) => windowType.IsAssignableFrom(w.GetType()) && w.Name.Equals(name));
		}

		public virtual T Find<T>(string name) where T : IWindow
		{
			return (T)windows.Find((IWindow w) => w is T && w.Name.Equals(name));
		}

		public virtual List<IWindow> FindAll(Type windowType)
		{
			List<IWindow> list = new List<IWindow>();
			foreach (IWindow window in windows)
			{
				if (windowType.IsAssignableFrom(window.GetType()))
				{
					list.Add(window);
				}
			}
			return list;
		}

		public virtual List<T> FindAll<T>() where T : IWindow
		{
			List<T> list = new List<T>();
			foreach (IWindow window in windows)
			{
				if (window is T)
				{
					list.Add((T)window);
				}
			}
			return list;
		}

		protected virtual Transform GetTransform(IWindow window)
		{
			try
			{
				if (window == null)
				{
					return null;
				}
				if (window is UIView)
				{
					return (window as UIView).Transform;
				}
				PropertyInfo property = window.GetType().GetProperty("Transform");
				if (property != null)
				{
					return (Transform)property.GetGetMethod().Invoke(window, null);
				}
				if (window is Component)
				{
					return (window as Component).transform;
				}
				return null;
			}
			catch (Exception)
			{
				return null;
			}
		}

		protected virtual int GetChildIndex(Transform child)
		{
			Transform transform = base.transform;
			for (int num = transform.childCount - 1; num >= 0; num--)
			{
				if (transform.GetChild(num).Equals(child))
				{
					return num;
				}
			}
			return -1;
		}

		protected virtual void AddChild(Transform child, bool worldPositionStays = false)
		{
			if (!(child == null) && !base.transform.Equals(child.parent))
			{
				child.gameObject.layer = base.gameObject.layer;
				child.SetParent(base.transform, worldPositionStays);
				child.SetAsFirstSibling();
			}
		}

		protected virtual void RemoveChild(Transform child, bool worldPositionStays = false)
		{
			if (!(child == null) && base.transform.Equals(child.parent))
			{
				child.SetParent(null, worldPositionStays);
			}
		}

		public ITransition Show(IWindow window)
		{
			ShowTransition transition = new ShowTransition(this, (IManageable)window);
			GetTransitionExecutor().Execute(transition);
			return transition.OnStateChanged(delegate(IWindow w, WindowState state)
			{
				if (state == WindowState.VISIBLE)
				{
					MoveToIndex(w, transition.Layer);
				}
			});
		}

		public ITransition Hide(IWindow window)
		{
			HideTransition hideTransition = new HideTransition(this, (IManageable)window, dismiss: false);
			GetTransitionExecutor().Execute(hideTransition);
			return hideTransition.OnStateChanged(delegate(IWindow w, WindowState state)
			{
				if (state == WindowState.INVISIBLE)
				{
					MoveToLast(w);
				}
			});
		}

		public ITransition Dismiss(IWindow window)
		{
			HideTransition hideTransition = new HideTransition(this, (IManageable)window, dismiss: true);
			GetTransitionExecutor().Execute(hideTransition);
			return hideTransition.OnStateChanged(delegate(IWindow w, WindowState state)
			{
				if (state == WindowState.INVISIBLE)
				{
					MoveToLast(w);
				}
			});
		}
	}
}
