using System;
using ParadoxNotion;
using ParadoxNotion.Design;

namespace NodeCanvas.Framework.Internal
{
	[Serializable]
	[SpoofAOT]
	public class ReflectedFunction<TResult> : ReflectedFunctionWrapper
	{
		private FunctionCall<TResult> call;

		[BlackboardOnly]
		public BBParameter<TResult> result;

		public override BBParameter[] GetVariables()
		{
			return null;
		}

		public override void Init(object instance)
		{
		}

		public override object Call()
		{
			return null;
		}
	}
	[Serializable]
	public class ReflectedFunction<TResult, T1> : ReflectedFunctionWrapper
	{
		private FunctionCall<T1, TResult> call;

		public BBParameter<T1> p1;

		[BlackboardOnly]
		public BBParameter<TResult> result;

		public override BBParameter[] GetVariables()
		{
			return null;
		}

		public override void Init(object instance)
		{
		}

		public override object Call()
		{
			return null;
		}
	}
	[Serializable]
	public class ReflectedFunction<TResult, T1, T2> : ReflectedFunctionWrapper
	{
		private FunctionCall<T1, T2, TResult> call;

		public BBParameter<T1> p1;

		public BBParameter<T2> p2;

		[BlackboardOnly]
		public BBParameter<TResult> result;

		public override BBParameter[] GetVariables()
		{
			return null;
		}

		public override void Init(object instance)
		{
		}

		public override object Call()
		{
			return null;
		}
	}
	[Serializable]
	public class ReflectedFunction<TResult, T1, T2, T3> : ReflectedFunctionWrapper
	{
		private FunctionCall<T1, T2, T3, TResult> call;

		public BBParameter<T1> p1;

		public BBParameter<T2> p2;

		public BBParameter<T3> p3;

		[BlackboardOnly]
		public BBParameter<TResult> result;

		public override BBParameter[] GetVariables()
		{
			return null;
		}

		public override void Init(object instance)
		{
		}

		public override object Call()
		{
			return null;
		}
	}
	[Serializable]
	public class ReflectedFunction<TResult, T1, T2, T3, T4> : ReflectedFunctionWrapper
	{
		private FunctionCall<T1, T2, T3, T4, TResult> call;

		public BBParameter<T1> p1;

		public BBParameter<T2> p2;

		public BBParameter<T3> p3;

		public BBParameter<T4> p4;

		[BlackboardOnly]
		public BBParameter<TResult> result;

		public override BBParameter[] GetVariables()
		{
			return null;
		}

		public override void Init(object instance)
		{
		}

		public override object Call()
		{
			return null;
		}
	}
	[Serializable]
	public class ReflectedFunction<TResult, T1, T2, T3, T4, T5> : ReflectedFunctionWrapper
	{
		private FunctionCall<T1, T2, T3, T4, T5, TResult> call;

		public BBParameter<T1> p1;

		public BBParameter<T2> p2;

		public BBParameter<T3> p3;

		public BBParameter<T4> p4;

		public BBParameter<T5> p5;

		[BlackboardOnly]
		public BBParameter<TResult> result;

		public override BBParameter[] GetVariables()
		{
			return null;
		}

		public override void Init(object instance)
		{
		}

		public override object Call()
		{
			return null;
		}
	}
	[Serializable]
	public class ReflectedFunction<TResult, T1, T2, T3, T4, T5, T6> : ReflectedFunctionWrapper
	{
		private FunctionCall<T1, T2, T3, T4, T5, T6, TResult> call;

		public BBParameter<T1> p1;

		public BBParameter<T2> p2;

		public BBParameter<T3> p3;

		public BBParameter<T4> p4;

		public BBParameter<T5> p5;

		public BBParameter<T6> p6;

		[BlackboardOnly]
		public BBParameter<TResult> result;

		public override BBParameter[] GetVariables()
		{
			return null;
		}

		public override void Init(object instance)
		{
		}

		public override object Call()
		{
			return null;
		}
	}
}
