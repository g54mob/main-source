using haxe.ds;
using haxe.lang;

namespace app
{
	public class State : HxObject
	{
		public string name;

		public double interpDuration;

		public double duration;

		public string afterStateName;

		public bool needsStep;

		public double stepTime;

		public Array funcs;

		public Array targets;

		public Array snapshot;

		public State(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public State(string name_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_State(State __hx_this, string name_)
		{
		}

		public static object extractTargetValue(object val)
		{
			return null;
		}

		public static object findSnapshotValue(Array snapshot, object targetObj, string propName, object defaultVal)
		{
			return null;
		}

		public virtual State addFunc(TimedFunc time, object func)
		{
			return null;
		}

		public virtual State addTarget(object targetObj, StringMap props)
		{
			return null;
		}

		public virtual State setInterpDuration(double interpDuration_)
		{
			return null;
		}

		public virtual State setDuration(double duration_, string afterStateName_)
		{
			return null;
		}

		public virtual void enter(Array snapshot)
		{
		}

		public virtual void step(double dt)
		{
		}

		public virtual void exit()
		{
		}

		public virtual void runInterpFuncs(double interp)
		{
		}

		public virtual void apply(Array snapshot, object interp)
		{
		}

		public virtual Array getSnapshot()
		{
			return null;
		}

		public override double __hx_setField_f(string field, int hash, double value, bool handleProperties)
		{
			return 0.0;
		}

		public override object __hx_setField(string field, int hash, object value, bool handleProperties)
		{
			return null;
		}

		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
		}

		public override double __hx_getField_f(string field, int hash, bool throwErrors, bool handleProperties)
		{
			return 0.0;
		}

		public override object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
