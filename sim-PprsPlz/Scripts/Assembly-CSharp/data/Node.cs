using haxe.ds;
using haxe.lang;

namespace data
{
	public class Node : HxObject
	{
		public Array @params;

		public List nodes;

		public Node(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Node()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_Node(Node __hx_this)
		{
		}

		public static int getTabIndent(string str)
		{
			return 0;
		}

		public virtual Node findNode(string firstParam)
		{
			return null;
		}

		public virtual void expandParams(Node rootNode)
		{
		}

		public virtual Node getExpanded(Array replacements)
		{
			return null;
		}

		public virtual int consume(Array lines, int lineIndex, object tabIndent)
		{
			return 0;
		}

		public virtual void dumpToTrace(string indent)
		{
		}

		public virtual string toString(string indent)
		{
			return null;
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
