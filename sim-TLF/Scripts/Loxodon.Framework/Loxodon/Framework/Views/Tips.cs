using System.Threading.Tasks;
using Loxodon.Framework.Binding;
using Loxodon.Framework.ViewModels;
using UnityEngine;

namespace Loxodon.Framework.Views
{
	public class Tips : UIBase
	{
		private readonly IUIViewGroup viewGroup;

		private readonly UIView view;

		public UIView View => view;

		public static Tips Create(UIView view, IUIViewGroup viewGroup = null)
		{
			if (viewGroup == null)
			{
				viewGroup = UIBase.GetCurrentViewGroup();
			}
			view.Visibility = false;
			return new Tips(view, viewGroup);
		}

		public static Tips Create(string viewName, IUIViewGroup viewGroup = null)
		{
			UIView uIView = UIBase.GetUIViewLocator().LoadView<UIView>(viewName);
			if (uIView == null)
			{
				throw new NotFoundException("Not found the \"UIView\".");
			}
			if (viewGroup == null)
			{
				viewGroup = UIBase.GetCurrentViewGroup();
			}
			uIView.Visibility = false;
			return new Tips(uIView, viewGroup);
		}

		public static async Task<Tips> CreateAsync(string viewName, IUIViewGroup viewGroup = null)
		{
			UIView obj = await UIBase.GetUIViewLocator().LoadViewAsync<UIView>(viewName);
			if (obj == null)
			{
				throw new NotFoundException("Not found the \"UIView\".");
			}
			if (viewGroup == null)
			{
				viewGroup = UIBase.GetCurrentViewGroup();
			}
			obj.Visibility = false;
			return new Tips(obj, viewGroup);
		}

		protected Tips(UIView view, IUIViewGroup viewGroup)
		{
			this.view = view;
			this.viewGroup = viewGroup;
		}

		public void Show(IViewModel viewModel, UILayout layout = null)
		{
			viewGroup.AddView(view, layout);
			view.SetDataContext(viewModel);
			view.Visibility = true;
			if (view.EnterAnimation != null)
			{
				view.EnterAnimation.Play();
			}
		}

		public void Hide()
		{
			if (view == null || view.Owner == null || !view.Visibility)
			{
				return;
			}
			if (view.ExitAnimation != null)
			{
				view.ExitAnimation.OnEnd(delegate
				{
					view.Visibility = false;
				}).Play();
			}
			else
			{
				view.Visibility = false;
			}
		}

		public void Dismiss()
		{
			if (view == null || view.Owner == null)
			{
				return;
			}
			if (!view.Visibility)
			{
				Object.Destroy(view.Owner);
			}
			else if (view.ExitAnimation != null)
			{
				view.ExitAnimation.OnEnd(delegate
				{
					view.Visibility = false;
					Object.Destroy(view.Owner);
				}).Play();
			}
			else
			{
				view.Visibility = false;
				Object.Destroy(view.Owner);
			}
		}
	}
}
