using haxe.ds;
using haxe.lang;

namespace data
{
	public class Error : HxObject
	{
		public string id;

		public Array ops;

		public List requiredPaperIds;

		public string groupId;

		public Error(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Error(string id_, string groupId_, Op rootOp)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_Error(Error __hx_this, string id_, string groupId_, Op rootOp)
		{
		}

		public virtual void dumpToTrace(object posInfos)
		{
		}

		public virtual void validate(Db db)
		{
		}

		public virtual string getHiddenPaperId()
		{
			return null;
		}

		public virtual bool isSpeechError()
		{
			return false;
		}

		public virtual bool getMatchesContext(ErrorContext context)
		{
			return false;
		}

		public virtual void collectPaperIds(Op op)
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
