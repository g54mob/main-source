using data;
using haxe.lang;

namespace play.save
{
	public class SaveNode : HxObject
	{
		public SaveNode parent;

		public SaveHeader header;

		public Array children;

		public bool latest;

		public SaveNode(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public SaveNode(SaveHeader header_, SaveNode parent_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_save_SaveNode(SaveNode __hx_this, SaveHeader header_, SaveNode parent_)
		{
		}

		public static SaveNode fromTabNode(Node tabNode, SaveNode parent)
		{
			return null;
		}

		public virtual SaveHeader getLatestHeader()
		{
			return null;
		}

		public virtual SaveNode getLatestNode()
		{
			return null;
		}

		public virtual int getDeepestDay()
		{
			return 0;
		}

		public virtual int getNumDescendents()
		{
			return 0;
		}

		public virtual SaveNode find(string id)
		{
			return null;
		}

		public virtual void insert(SaveHeader header)
		{
		}

		public virtual SaveNode remove(string id)
		{
			return null;
		}

		public virtual string toString()
		{
			return null;
		}

		public virtual void buildStringBuf(StringBuf stringBuf, string indent)
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

		public override string ToString()
		{
			return null;
		}
	}
}
