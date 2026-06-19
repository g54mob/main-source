using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Loxodon.Framework.Utilities
{
	public abstract class WeakBase<TDelegate> : IExecute where TDelegate : class
	{
		private readonly bool isStatic;

		private int hashCode;

		protected TDelegate del;

		protected WeakReference targetReference;

		protected MethodInfo targetMethod;

		protected bool IsStatic => isStatic;

		public bool IsAlive
		{
			get
			{
				if (del != null)
				{
					if (targetReference != null && !targetReference.IsAlive)
					{
						targetReference = null;
						del = null;
						return false;
					}
					return true;
				}
				if (targetReference != null)
				{
					return targetReference.IsAlive;
				}
				return false;
			}
		}

		public WeakBase(TDelegate del)
			: this((object)null, del)
		{
		}

		public WeakBase(object target, TDelegate del)
		{
			hashCode = del.GetHashCode();
			Delegate obj = del as Delegate;
			isStatic = obj.Method.IsStatic;
			if (isStatic || (target != null && !target.Equals(obj.Target)) || IsClosure(obj))
			{
				this.del = del;
				if (target != null)
				{
					targetReference = new WeakReference(target);
				}
			}
			else
			{
				targetMethod = obj.Method;
				targetReference = new WeakReference(obj.Target);
			}
		}

		protected bool IsClosure(Delegate del)
		{
			if ((object)del == null || del.Method.IsStatic || del.Target == null)
			{
				return false;
			}
			Type type = del.Target.GetType();
			bool flag = !type.IsVisible;
			bool flag2 = type.GetCustomAttributes(typeof(CompilerGeneratedAttribute), inherit: false).Length != 0;
			return type.IsNested && type.MemberType == MemberTypes.NestedType && flag2 && flag;
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			if (obj == null || !(obj is WeakBase<TDelegate>))
			{
				return false;
			}
			WeakBase<TDelegate> weakBase = (WeakBase<TDelegate>)obj;
			if (isStatic != weakBase.isStatic)
			{
				return false;
			}
			if (del != null)
			{
				if ((targetReference == null && weakBase.targetReference == null) || (targetReference != null && weakBase.targetReference != null && targetReference.Target == weakBase.targetReference.Target))
				{
					return del.Equals(weakBase.del);
				}
				return false;
			}
			if (targetMethod.Equals(weakBase.targetMethod))
			{
				return targetReference.Target == weakBase.targetReference.Target;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return hashCode;
		}

		public abstract object Execute(params object[] parameters);
	}
}
