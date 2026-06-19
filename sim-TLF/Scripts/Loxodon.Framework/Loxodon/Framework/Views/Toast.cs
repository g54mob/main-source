using System;
using System.Collections;
using Loxodon.Log;
using UnityEngine;

namespace Loxodon.Framework.Views
{
	public class Toast : UIBase
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(Toast));

		private const string DEFAULT_VIEW_NAME = "UI/Toast";

		private static string viewName;

		private readonly IUIViewGroup viewGroup;

		private readonly float duration;

		private readonly string text;

		private readonly ToastViewBase view;

		private readonly UILayout layout;

		private readonly Action callback;

		public static string ViewName
		{
			get
			{
				if (!string.IsNullOrEmpty(viewName))
				{
					return viewName;
				}
				return "UI/Toast";
			}
			set
			{
				viewName = value;
			}
		}

		public float Duration => duration;

		public string Text => text;

		public ToastViewBase View => view;

		public new static IUIViewGroup GetCurrentViewGroup()
		{
			return UIBase.GetCurrentViewGroup();
		}

		public static Toast Show(string text, float duration = 3f)
		{
			return Show(ViewName, null, text, duration, null, null);
		}

		public static Toast Show(string text, float duration, UILayout layout)
		{
			return Show(ViewName, null, text, duration, layout, null);
		}

		public static Toast Show(string text, float duration, UILayout layout, Action callback)
		{
			return Show(ViewName, null, text, duration, layout, callback);
		}

		public static Toast Show(IUIViewGroup viewGroup, string text, float duration = 3f)
		{
			return Show(ViewName, viewGroup, text, duration, null, null);
		}

		public static Toast Show(IUIViewGroup viewGroup, string text, float duration, UILayout layout)
		{
			return Show(ViewName, viewGroup, text, duration, layout, null);
		}

		public static Toast Show(IUIViewGroup viewGroup, string text, float duration, UILayout layout, Action callback)
		{
			return Show(ViewName, viewGroup, text, duration, layout, callback);
		}

		public static Toast Show(string viewName, IUIViewGroup viewGroup, string text, float duration, UILayout layout, Action callback)
		{
			if (string.IsNullOrEmpty(viewName))
			{
				viewName = ViewName;
			}
			ToastViewBase toastViewBase = UIBase.GetUIViewLocator().LoadView<ToastViewBase>(viewName);
			if (toastViewBase == null)
			{
				throw new NotFoundException("Not found the \"ToastView\".");
			}
			if (viewGroup == null)
			{
				viewGroup = GetCurrentViewGroup();
			}
			Toast toast = new Toast(toastViewBase, viewGroup, text, duration, layout, callback);
			toast.Show();
			return toast;
		}

		protected Toast(ToastViewBase view, IUIViewGroup viewGroup, string text, float duration)
			: this(view, viewGroup, text, duration, null, null)
		{
		}

		protected Toast(ToastViewBase view, IUIViewGroup viewGroup, string text, float duration, UILayout layout)
			: this(view, viewGroup, text, duration, layout, null)
		{
		}

		protected Toast(ToastViewBase view, IUIViewGroup viewGroup, string text, float duration, UILayout layout, Action callback)
		{
			this.view = view;
			this.viewGroup = viewGroup;
			this.text = text;
			this.duration = duration;
			this.layout = layout;
			this.callback = callback;
		}

		public void Cancel()
		{
			if (view == null || view.Owner == null)
			{
				return;
			}
			if (!view.Visibility)
			{
				UnityEngine.Object.Destroy(view.Owner);
			}
			else if (view.ExitAnimation != null)
			{
				view.ExitAnimation.OnEnd(delegate
				{
					view.Visibility = false;
					viewGroup.RemoveView(view);
					UnityEngine.Object.Destroy(view.Owner);
					DoCallback();
				}).Play();
			}
			else
			{
				view.Visibility = false;
				viewGroup.RemoveView(view);
				UnityEngine.Object.Destroy(view.Owner);
				DoCallback();
			}
		}

		public void Show()
		{
			if (!view.Visibility)
			{
				viewGroup.AddView(view, layout);
				view.Visibility = true;
				view.Content = text;
				if (view.EnterAnimation != null)
				{
					view.EnterAnimation.Play();
				}
				view.StartCoroutine(DelayDismiss(duration));
			}
		}

		protected IEnumerator DelayDismiss(float duration)
		{
			yield return new WaitForSeconds(duration);
			Cancel();
		}

		protected void DoCallback()
		{
			try
			{
				if (callback != null)
				{
					callback();
				}
			}
			catch (Exception)
			{
			}
		}
	}
}
