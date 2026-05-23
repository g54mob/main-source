using haxe.lang;

namespace haxe.ds
{
	public class TreeNode : HxObject
	{
		public TreeNode left;

		public TreeNode right;

		public object key;

		public object value;

		public int _height;

		public TreeNode(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public TreeNode(TreeNode l, object k, object v, TreeNode r, object h)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_ds_TreeNode(TreeNode __hx_this, TreeNode l, object k, object v, TreeNode r, object h)
		{
		}

		public virtual string toString()
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

		public override string ToString()
		{
			return null;
		}
	}
}
