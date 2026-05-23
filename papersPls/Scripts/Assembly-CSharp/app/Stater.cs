using haxe.ds;
using haxe.lang;

namespace app
{
	public class Stater : HxObject
	{
		public static bool enableDebugTrace;

		public StringMap states;

		public State curState;

		public double transitionInterp;

		public Array transitionSnapshot;

		public string debugName;

		public double interpCountdown;

		static Stater()
		{
		}

		public Stater(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Stater(object posInfos)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_Stater(Stater __hx_this, object posInfos)
		{
		}

		public virtual State addState(string name)
		{
			return null;
		}

		public virtual State getState(string name)
		{
			return null;
		}

		public virtual void go(string name, object instant)
		{
		}

		public virtual void step(double dt)
		{
		}

		public bool isInState(string name)
		{
			return false;
		}

		public virtual double get_stateTime()
		{
			return 0.0;
		}

		public virtual bool autoIsInterpolating()
		{
			return false;
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
