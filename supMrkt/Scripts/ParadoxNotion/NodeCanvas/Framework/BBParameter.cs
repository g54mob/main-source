using System;
using System.Runtime.CompilerServices;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;

namespace NodeCanvas.Framework
{
	[Serializable]
	[SpoofAOT]
	[fsAutoInstance(true)]
	[fsUninitialized]
	public abstract class BBParameter : ISerializationCollectable, ISerializationCallbackReceiver
	{
		[SerializeField]
		private string _name;

		[SerializeField]
		private string _targetVariableID;

		private IBlackboard _bb;

		private Variable _varRef;

		public string targetVariableID
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

		public Variable varRef
		{
			get
			{
				return null;
			}
			protected set
			{
			}
		}

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

		public IBlackboard bb
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool useBlackboard
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool isPresumedDynamic => false;

		public bool isNone => false;

		public bool isNull => false;

		public bool isNoneOrNull => false;

		public bool isDefined => false;

		public Type refType => null;

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

		public abstract Type varType { get; }

		public event Action<Variable> onVariableReferenceChanged
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

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		public BBParameter()
		{
		}

		public static BBParameter CreateInstance(Type t, IBlackboard bb)
		{
			return null;
		}

		public static void SetBBFields(object target, IBlackboard bb)
		{
		}

		protected abstract void SetDefaultValue();

		protected abstract void Bind(Variable data);

		public abstract object GetValueBoxed();

		public abstract void SetValueBoxed(object value);

		public void SetTargetVariable(IBlackboard targetBB, Variable targetVariable)
		{
		}

		private Variable ResolveReference(IBlackboard targetBlackboard, bool useID)
		{
			return null;
		}

		public Variable PromoteToVariable(IBlackboard targetBB)
		{
			return null;
		}

		public sealed override string ToString()
		{
			return null;
		}
	}
	[Serializable]
	public class BBParameter<T> : BBParameter
	{
		[SerializeField]
		protected T _value;

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

		public override Type varType => null;

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

		public BBParameter()
		{
		}

		public BBParameter(T value)
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

		public void SetValue(T value)
		{
		}

		protected override void SetDefaultValue()
		{
		}

		protected override void Bind(Variable variable)
		{
		}

		private bool BindGetter(Variable variable)
		{
			return false;
		}

		private bool BindSetter(Variable variable)
		{
			return false;
		}

		public static implicit operator BBParameter<T>(T value)
		{
			return null;
		}
	}
}
