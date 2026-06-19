using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Loxodon.Framework.Binding.Proxy.Targets
{
	public abstract class TargetProxyBase : BindingProxyBase, ITargetProxy, IBindingProxy, IDisposable
	{
		private readonly WeakReference target;

		protected TypeCode typeCode;

		protected readonly string targetName;

		public abstract Type Type { get; }

		public virtual TypeCode TypeCode
		{
			get
			{
				if (typeCode == TypeCode.Empty)
				{
					typeCode = Type.GetTypeCode(Type);
				}
				return typeCode;
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

		public virtual BindingMode DefaultMode => BindingMode.OneWay;

		public TargetProxyBase(object target)
		{
			if (target != null)
			{
				this.target = new WeakReference(target, trackResurrection: false);
				targetName = target.ToString();
			}
		}

		private bool IsAlive(object target)
		{
			try
			{
				if (target == null)
				{
					return false;
				}
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
	}
}
