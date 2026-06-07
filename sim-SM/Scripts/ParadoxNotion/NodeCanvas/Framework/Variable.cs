using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization.FullSerializer;
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
				return null;
			}
			set
			{
			}
		}

		public string ID => null;

		public object value
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool isExposedPublic
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool debugBoundValue
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool isPropertyBound => false;

		public abstract bool isDataBound { get; }

		public abstract Type varType { get; }

		public abstract string propertyPath { get; set; }

		public event Action<string> onNameChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<object> onValueChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action onDestroy
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public abstract void BindProperty(MemberInfo prop, GameObject target = null);

		public abstract void UnBind();

		public abstract void InitializePropertyBinding(GameObject go, bool callSetter = false);

		public abstract object GetValueBoxed();

		public abstract void SetValueBoxed(object value);

		public Variable()
		{
		}

		public Variable(string name, string ID)
		{
		}

		internal void OnDestroy()
		{
		}

		public Variable Duplicate(IBlackboard targetBB)
		{
			return null;
		}

		protected bool HasValueChangeEvent()
		{
			return false;
		}

		protected void TryInvokeValueChangeEvent(object value)
		{
		}

		public bool CanConvertTo(Type toType)
		{
			return false;
		}

		public Func<object> GetGetConverter(Type toType)
		{
			return null;
		}

		public bool CanConvertFrom(Type fromType)
		{
			return false;
		}

		public Action<object> GetSetConverter(Type fromType)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
	public class Variable<T> : Variable
	{
		[SerializeField]
		private T _value;

		[SerializeField]
		private string _propertyPath;

		public override Type varType => null;

		public override bool isDataBound => false;

		public override string propertyPath
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public new T value
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		private event Func<T> getter
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private event Action<T> setter
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public Variable()
		{
		}

		public Variable(string name, string ID)
		{
		}

		public override object GetValueBoxed()
		{
			return null;
		}

		public override void SetValueBoxed(object newValue)
		{
		}

		public T GetValue()
		{
			return default(T);
		}

		public void SetValue(T newValue)
		{
		}

		public override void BindProperty(MemberInfo prop, GameObject target = null)
		{
		}

		public void BindGetSet(Func<T> _get, Action<T> _set)
		{
		}

		public override void UnBind()
		{
		}

		public override void InitializePropertyBinding(GameObject go, bool callSetter = false)
		{
		}
	}
}
