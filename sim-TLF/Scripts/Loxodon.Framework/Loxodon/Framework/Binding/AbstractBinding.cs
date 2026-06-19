using System;
using Loxodon.Framework.Binding.Contexts;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Loxodon.Framework.Binding
{
	public abstract class AbstractBinding : IBinding, IDisposable
	{
		private IBindingContext bindingContext;

		private WeakReference target;

		private object dataContext;

		public virtual IBindingContext BindingContext
		{
			get
			{
				return bindingContext;
			}
			set
			{
				bindingContext = value;
			}
		}

		public virtual object Target
		{
			get
			{
				object result = ((target != null) ? target.Target : null);
				if (!IsAlive(result))
				{
					return null;
				}
				return result;
			}
		}

		public virtual object DataContext
		{
			get
			{
				return dataContext;
			}
			set
			{
				if (dataContext != value)
				{
					dataContext = value;
					OnDataContextChanged();
				}
			}
		}

		public AbstractBinding(IBindingContext bindingContext, object dataContext, object target)
		{
			this.bindingContext = bindingContext;
			this.target = new WeakReference(target, trackResurrection: false);
			this.dataContext = dataContext;
		}

		private bool IsAlive(object target)
		{
			try
			{
				if (target is UIBehaviour)
				{
					if (((UIBehaviour)target).IsDestroyed())
					{
						return false;
					}
					return true;
				}
				if (target is UnityEngine.Object)
				{
					_ = ((UnityEngine.Object)target).name;
					return true;
				}
				return target != null;
			}
			catch (Exception)
			{
				return false;
			}
		}

		protected abstract void OnDataContextChanged();

		protected virtual void Dispose(bool disposing)
		{
			bindingContext = null;
			dataContext = null;
			target = null;
		}

		~AbstractBinding()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
