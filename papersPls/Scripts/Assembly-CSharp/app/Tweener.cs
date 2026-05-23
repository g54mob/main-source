using haxe.ds;
using haxe.lang;

namespace app
{
	public class Tweener : HxObject
	{
		public List allTweens;

		public Tweener(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Tweener()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_Tweener(Tweener __hx_this)
		{
		}

		public virtual Tween add(Tween tween)
		{
			return null;
		}

		public virtual Tween tween(Function tweenHandler, double duration)
		{
			return null;
		}

		public virtual Tween timer(Function completeHandler, double duration)
		{
			return null;
		}

		public virtual void stepAll(Clock clock)
		{
		}

		public virtual void stopAll()
		{
		}

		public virtual void stop(object handler)
		{
		}

		public override object __hx_setField(string field, int hash, object value, bool handleProperties)
		{
			return null;
		}

		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
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
