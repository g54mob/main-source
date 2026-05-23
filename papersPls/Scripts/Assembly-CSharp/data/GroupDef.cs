using haxe.ds;
using haxe.lang;

namespace data
{
	public class GroupDef : HxObject
	{
		public string id;

		public Array paths;

		public GroupDef(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public GroupDef(string id_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_GroupDef(GroupDef __hx_this, string id_)
		{
		}

		public static GroupDef makeFromNode(Xml node, StringMap factDefs)
		{
			return null;
		}

		public static GroupDef makeFromFactGroup(FactGroup factGroup, StringMap factDefs)
		{
			return null;
		}

		public virtual void addExpandedPaths(FactGroupPath path, StringMap factDefs)
		{
		}

		public virtual FactGroup getNationalizedFactGroup(string nationality)
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
