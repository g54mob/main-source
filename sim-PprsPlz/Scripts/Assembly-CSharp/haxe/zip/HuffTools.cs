using haxe.ds;
using haxe.lang;

namespace haxe.zip
{
	public class HuffTools : HxObject
	{
		public HuffTools(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public HuffTools()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_zip_HuffTools(HuffTools __hx_this)
		{
		}

		public virtual int treeDepth(Huffman t)
		{
			return 0;
		}

		public virtual Huffman treeCompress(Huffman t)
		{
			return null;
		}

		public virtual void treeWalk(Array table, int p, int cd, int d, Huffman t)
		{
		}

		public virtual Huffman treeMake(IntMap bits, int maxbits, int v, int len)
		{
			return null;
		}

		public virtual Huffman make(Array lengths, int pos, int nlengths, int maxbits)
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
	}
}
