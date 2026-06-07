using System;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Framework
{
	[SpoofAOT]
	public abstract class ExposedParameter
	{
		public abstract string targetVariableID { get; }

		public abstract Type type { get; }

		public abstract object valueBoxed { get; set; }

		public abstract Variable varRefBoxed { get; }

		public abstract void Bind(IBlackboard blackboard);

		public abstract void UnBind();

		public static ExposedParameter CreateInstance(Variable target)
		{
			return null;
		}
	}
	public sealed class ExposedParameter<T> : ExposedParameter
	{
		[SerializeField]
		private string _targetVariableID;

		[SerializeField]
		private T _value;

		public Variable<T> varRef { get; private set; }

		public override string targetVariableID => null;

		public override Type type => null;

		public override object valueBoxed
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override Variable varRefBoxed => null;

		public T value
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		public ExposedParameter()
		{
		}

		public ExposedParameter(Variable target)
		{
		}

		public override void Bind(IBlackboard blackboard)
		{
		}

		public override void UnBind()
		{
		}

		private T GetRawValue()
		{
			return default(T);
		}

		private void SetRawValue(T value)
		{
		}
	}
}
