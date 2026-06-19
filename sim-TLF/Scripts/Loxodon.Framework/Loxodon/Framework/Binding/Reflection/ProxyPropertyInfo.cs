using System;
using System.Reflection;
using Loxodon.Log;

namespace Loxodon.Framework.Binding.Reflection
{
	public class ProxyPropertyInfo : IProxyPropertyInfo, IProxyMemberInfo
	{
		private readonly bool isValueType;

		private TypeCode typeCode;

		protected PropertyInfo propertyInfo;

		protected MethodInfo getMethod;

		protected MethodInfo setMethod;

		public virtual bool IsValueType => isValueType;

		public virtual Type ValueType => propertyInfo.PropertyType;

		public TypeCode ValueTypeCode
		{
			get
			{
				if (typeCode == TypeCode.Empty)
				{
					typeCode = Type.GetTypeCode(ValueType);
				}
				return typeCode;
			}
		}

		public virtual Type DeclaringType => propertyInfo.DeclaringType;

		public virtual string Name => propertyInfo.Name;

		public virtual bool IsStatic => propertyInfo.IsStatic();

		public ProxyPropertyInfo(PropertyInfo propertyInfo)
		{
			if (propertyInfo == null)
			{
				throw new ArgumentNullException("propertyInfo");
			}
			this.propertyInfo = propertyInfo;
			isValueType = this.propertyInfo.DeclaringType.IsValueType;
			if (this.propertyInfo.CanRead)
			{
				getMethod = propertyInfo.GetGetMethod();
			}
			if (this.propertyInfo.CanWrite && !isValueType)
			{
				setMethod = propertyInfo.GetSetMethod();
			}
		}

		public virtual object GetValue(object target)
		{
			if (getMethod == null)
			{
				throw new MemberAccessException($"The property \"{propertyInfo.DeclaringType}.{Name}\" is not public");
			}
			return getMethod.Invoke(target, null);
		}

		public virtual void SetValue(object target, object value)
		{
			if (!propertyInfo.CanWrite)
			{
				throw new MemberAccessException($"The property \"{propertyInfo.DeclaringType}.{Name}\" is read-only.");
			}
			if (IsValueType)
			{
				throw new NotSupportedException($"The type \"{propertyInfo.DeclaringType}\" is a value type, and non-reference types cannot support assignment operations.");
			}
			if (setMethod == null)
			{
				throw new MemberAccessException($"The property \"{propertyInfo.DeclaringType}.{Name}\" is not public");
			}
			setMethod.Invoke(target, new object[1] { value });
		}
	}
	public class ProxyPropertyInfo<T, TValue> : ProxyPropertyInfo, IProxyPropertyInfo<T, TValue>, IProxyPropertyInfo<TValue>, IProxyPropertyInfo, IProxyMemberInfo
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(ProxyPropertyInfo<T, TValue>));

		private Func<T, TValue> getter;

		private Action<T, TValue> setter;

		public override Type DeclaringType => typeof(T);

		public ProxyPropertyInfo(string propertyName)
			: this(typeof(T).GetProperty(propertyName))
		{
		}

		public ProxyPropertyInfo(PropertyInfo propertyInfo)
			: base(propertyInfo)
		{
			if (!typeof(TValue).Equals(base.propertyInfo.PropertyType) || !propertyInfo.DeclaringType.IsAssignableFrom(typeof(T)))
			{
				throw new ArgumentException("The property types do not match!");
			}
			if (IsStatic)
			{
				throw new ArgumentException($"The property \"{propertyInfo.DeclaringType}.{Name}\" is static.");
			}
			getter = MakeGetter(propertyInfo);
			setter = MakeSetter(propertyInfo);
		}

		public ProxyPropertyInfo(string propertyName, Func<T, TValue> getter, Action<T, TValue> setter)
			: this(typeof(T).GetProperty(propertyName), getter, setter)
		{
		}

		public ProxyPropertyInfo(PropertyInfo propertyInfo, Func<T, TValue> getter, Action<T, TValue> setter)
			: base(propertyInfo)
		{
			if (!typeof(TValue).Equals(base.propertyInfo.PropertyType) || !propertyInfo.DeclaringType.IsAssignableFrom(typeof(T)))
			{
				throw new ArgumentException("The property types do not match!");
			}
			if (IsStatic)
			{
				throw new ArgumentException($"The property \"{propertyInfo.DeclaringType}.{Name}\" is static.");
			}
			this.getter = getter;
			this.setter = setter;
		}

		private Action<T, TValue> MakeSetter(PropertyInfo propertyInfo)
		{
			try
			{
				if (IsValueType)
				{
					return null;
				}
				MethodInfo methodInfo = propertyInfo.GetSetMethod();
				if (methodInfo == null)
				{
					return null;
				}
				return (Action<T, TValue>)methodInfo.CreateDelegate(typeof(Action<T, TValue>));
			}
			catch (Exception ex)
			{
				if (log.IsWarnEnabled)
				{
					log.WarnFormat("{0}", ex);
				}
			}
			return null;
		}

		private Func<T, TValue> MakeGetter(PropertyInfo propertyInfo)
		{
			try
			{
				if (IsValueType)
				{
					return null;
				}
				MethodInfo methodInfo = propertyInfo.GetGetMethod();
				if (methodInfo == null)
				{
					return null;
				}
				return (Func<T, TValue>)methodInfo.CreateDelegate(typeof(Func<T, TValue>));
			}
			catch (Exception ex)
			{
				if (log.IsWarnEnabled)
				{
					log.WarnFormat("{0}", ex);
				}
			}
			return null;
		}

		public TValue GetValue(T target)
		{
			if (getter != null)
			{
				return getter(target);
			}
			return (TValue)base.GetValue(target);
		}

		TValue IProxyPropertyInfo<TValue>.GetValue(object target)
		{
			return GetValue((T)target);
		}

		public override object GetValue(object target)
		{
			if (getter != null)
			{
				return getter((T)target);
			}
			return base.GetValue(target);
		}

		public void SetValue(T target, TValue value)
		{
			if (IsValueType)
			{
				throw new NotSupportedException($"The type \"{propertyInfo.DeclaringType}\" is a value type, and non-reference types cannot support assignment operations.");
			}
			if (setter != null)
			{
				setter(target, value);
			}
			else
			{
				base.SetValue(target, value);
			}
		}

		public void SetValue(object target, TValue value)
		{
			SetValue((T)target, value);
		}

		public override void SetValue(object target, object value)
		{
			if (IsValueType)
			{
				throw new NotSupportedException($"The type \"{propertyInfo.DeclaringType}\" is a value type, and non-reference types cannot support assignment operations.");
			}
			if (setter != null)
			{
				setter((T)target, (TValue)value);
			}
			else
			{
				base.SetValue(target, value);
			}
		}
	}
}
