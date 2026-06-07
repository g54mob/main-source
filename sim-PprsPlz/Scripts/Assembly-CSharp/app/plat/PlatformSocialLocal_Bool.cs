using haxe.ds;
using haxe.lang;

namespace app.plat
{
	public class PlatformSocialLocal_Bool : HxObject
	{
		public string name;

		public StringMap values;

		public double retryPullTime;

		public string retryPullReason;

		public int retryPullCount;

		public double lastPullRefreshTime;

		public List retryPushQueue;

		public Array ids;

		public int idWidthMax;

		public int kSameReasonRetryCountMax;

		public int generation;

		public int idCount;

		public PlatformSocialLocal_Bool(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public PlatformSocialLocal_Bool(string name_, Array ids_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_plat_PlatformSocialLocal_Bool(PlatformSocialLocal_Bool __hx_this, string name_, Array ids_)
		{
		}

		public double get_time()
		{
			return 0.0;
		}

		public string idAt(int index)
		{
			return null;
		}

		public virtual void processRetries()
		{
		}

		public virtual bool has(string id)
		{
			return false;
		}

		public virtual object get(string id)
		{
			return null;
		}

		public virtual void setFromPull(string id, bool value)
		{
		}

		public virtual void setFromPush(string id, bool value)
		{
		}

		public virtual void set(string id, bool value, bool fromPush)
		{
		}

		public virtual void setEmptyFromPull(string id)
		{
		}

		public virtual void retryPush(string reason, string id, bool value)
		{
		}

		public virtual void retryPull(string reason, string id, double delay)
		{
		}

		public virtual void pull()
		{
		}

		public virtual void push(string id, bool value)
		{
		}

		public virtual bool matches(bool a, bool b)
		{
			return false;
		}

		public virtual void error(string id, string message)
		{
		}

		public virtual void log(string category, string id, object message0, object message1)
		{
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
