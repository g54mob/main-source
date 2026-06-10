using System;
using System.Reflection;
using ParadoxNotion;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization.FullSerializer;
using ParadoxNotion.Services;
using UnityEngine;

namespace NodeCanvas.Framework
{
	[Serializable]
	[fsUninitialized]
	[SpoofAOT]
	public abstract class Variable
	{
		[SerializeField]
		private string _name;

		[SerializeField]
		private string _id;

		[SerializeField]
		private bool _isPublic;

		[SerializeField]
		[fsIgnoreInBuild]
		private bool _debugBoundValue;

		public string name
		{
			get
			{
				return _name;
			}
			set
			{
				if (_name != value)
				{
					_name = value;
					if (this.onNameChanged != null)
					{
						this.onNameChanged(value);
					}
				}
			}
		}

		public string ID
		{
			get
			{
				if (!string.IsNullOrEmpty(_id))
				{
					return _id;
				}
				return _id = Guid.NewGuid().ToString();
			}
		}

		public object value
		{
			get
			{
				return GetValueBoxed();
			}
			set
			{
				SetValueBoxed(value);
			}
		}

		public bool isExposedPublic
		{
			get
			{
				if (_isPublic)
				{
					return !isPropertyBound;
				}
				return false;
			}
			set
			{
				_isPublic = value;
			}
		}

		public bool debugBoundValue
		{
			get
			{
				return _debugBoundValue;
			}
			set
			{
				_debugBoundValue = value;
			}
		}

		public bool isPropertyBound => !string.IsNullOrEmpty(propertyPath);

		public abstract bool isDataBound { get; }

		public abstract Type varType { get; }

		public abstract string propertyPath { get; set; }

		public event Action<string> onNameChanged;

		public event Action<object> onValueChanged;

		public event Action onDestroy;

		public abstract void BindProperty(MemberInfo prop, GameObject target = null);

		public abstract void UnBind();

		public abstract void InitializePropertyBinding(GameObject go, bool callSetter = false);

		public abstract object GetValueBoxed();

		public abstract void SetValueBoxed(object value);

		public Variable()
		{
			_id = Guid.NewGuid().ToString();
		}

		public Variable(string name, string ID)
		{
			_name = name;
			_id = ID;
		}

		internal void OnDestroy()
		{
			if (this.onDestroy != null)
			{
				this.onDestroy();
			}
		}

		public Variable Duplicate(IBlackboard targetBB)
		{
			string text = name;
			while (targetBB.variables.ContainsKey(text))
			{
				text += ".";
			}
			Variable variable = targetBB.AddVariable(text, varType);
			if (variable != null)
			{
				variable.value = value;
				variable.propertyPath = propertyPath;
				variable.isExposedPublic = isExposedPublic;
			}
			return variable;
		}

		protected bool HasValueChangeEvent()
		{
			return this.onValueChanged != null;
		}

		protected void TryInvokeValueChangeEvent(object value)
		{
			if (this.onValueChanged != null)
			{
				this.onValueChanged(value);
			}
		}

		public bool CanConvertTo(Type toType)
		{
			return GetGetConverter(toType) != null;
		}

		public Func<object> GetGetConverter(Type toType)
		{
			if (toType.RTIsAssignableFrom(varType))
			{
				return () => value;
			}
			Func<object, object> converter = TypeConverter.Get(varType, toType);
			if (converter != null)
			{
				return () => converter(value);
			}
			return null;
		}

		public bool CanConvertFrom(Type fromType)
		{
			return GetSetConverter(fromType) != null;
		}

		public Action<object> GetSetConverter(Type fromType)
		{
			if (varType.RTIsAssignableFrom(fromType))
			{
				return delegate(object x)
				{
					value = x;
				};
			}
			Func<object, object> converter = TypeConverter.Get(fromType, varType);
			if (converter != null)
			{
				return delegate(object x)
				{
					value = converter(x);
				};
			}
			return null;
		}

		public override string ToString()
		{
			return name;
		}
	}
	public class Variable<T> : Variable
	{
		[SerializeField]
		private T _value;

		[SerializeField]
		private string _propertyPath;

		public override Type varType => typeof(T);

		public override bool isDataBound
		{
			get
			{
				if (this.getter == null)
				{
					return this.setter != null;
				}
				return true;
			}
		}

		public override string propertyPath
		{
			get
			{
				return _propertyPath;
			}
			set
			{
				_propertyPath = value;
			}
		}

		public new T value
		{
			get
			{
				if (this.getter == null)
				{
					return _value;
				}
				return this.getter();
			}
			set
			{
				if (HasValueChangeEvent())
				{
					object b = value;
					if (!ObjectUtils.AnyEquals(_value, b))
					{
						_value = value;
						if (this.setter != null)
						{
							this.setter(value);
						}
						TryInvokeValueChangeEvent(b);
					}
				}
				else
				{
					_value = value;
					if (this.setter != null)
					{
						this.setter(value);
					}
				}
			}
		}

		private event Func<T> getter;

		private event Action<T> setter;

		public Variable()
		{
		}

		public Variable(string name, string ID)
			: base(name, ID)
		{
		}

		public override object GetValueBoxed()
		{
			return value;
		}

		public override void SetValueBoxed(object newValue)
		{
			value = (T)newValue;
		}

		public T GetValue()
		{
			return value;
		}

		public void SetValue(T newValue)
		{
			value = newValue;
		}

		public override void BindProperty(MemberInfo prop, GameObject target = null)
		{
			if (prop is PropertyInfo || prop is FieldInfo)
			{
				_propertyPath = $"{prop.RTReflectedOrDeclaredType().FullName}.{prop.Name}";
				if (target != null)
				{
					InitializePropertyBinding(target);
				}
			}
		}

		public void BindGetSet(Func<T> _get, Action<T> _set)
		{
			this.getter = _get;
			this.setter = _set;
		}

		public override void UnBind()
		{
			_propertyPath = null;
			this.getter = null;
			this.setter = null;
		}

		public override void InitializePropertyBinding(GameObject go, bool callSetter = false)
		{
			if (!base.isPropertyBound || !Threader.applicationIsPlaying)
			{
				return;
			}
			this.getter = null;
			this.setter = null;
			int num = _propertyPath.LastIndexOf('.');
			string typeFullName = _propertyPath.Substring(0, num);
			string text = _propertyPath.Substring(num + 1);
			Type type = ReflectionTools.GetType(typeFullName, fallbackNoNamespace: true, typeof(Component));
			if (type == null)
			{
				return;
			}
			MemberInfo memberInfo = type.RTGetFieldOrProp(text);
			if (memberInfo is FieldInfo)
			{
				FieldInfo field = (FieldInfo)memberInfo;
				Component instance = (field.IsStatic ? null : go.GetComponent(type));
				if (instance == null && !field.IsStatic)
				{
					return;
				}
				if (field.IsConstant())
				{
					T value = (T)field.GetValue(instance);
					this.getter = () => value;
					return;
				}
				this.getter = () => (T)field.GetValue(instance);
				this.setter = delegate(T o)
				{
					field.SetValue(instance, o);
				};
			}
			else
			{
				if (!(memberInfo is PropertyInfo))
				{
					return;
				}
				PropertyInfo propertyInfo = (PropertyInfo)memberInfo;
				MethodInfo getMethod = propertyInfo.RTGetGetMethod();
				MethodInfo setMethod = propertyInfo.RTGetSetMethod();
				bool flag = (getMethod != null && getMethod.IsStatic) || (setMethod != null && setMethod.IsStatic);
				Component instance2 = (flag ? null : go.GetComponent(type));
				if (instance2 == null && !flag)
				{
					return;
				}
				if (propertyInfo.CanRead && getMethod != null)
				{
					try
					{
						this.getter = getMethod.RTCreateDelegate<Func<T>>(instance2);
					}
					catch
					{
						this.getter = () => (T)getMethod.Invoke(instance2, null);
					}
				}
				else
				{
					this.getter = () => default(T);
				}
				if (propertyInfo.CanWrite && setMethod != null)
				{
					try
					{
						this.setter = setMethod.RTCreateDelegate<Action<T>>(instance2);
					}
					catch
					{
						this.setter = delegate(T o)
						{
							setMethod.Invoke(instance2, ReflectionTools.SingleTempArgsArray(o));
						};
					}
					if (callSetter)
					{
						this.setter(_value);
					}
				}
				else
				{
					this.setter = delegate
					{
					};
				}
			}
		}
	}
}
