using haxe.io;
using haxe.lang;
using haxe.zip._InflateImpl;

namespace haxe.zip
{
	public class InflateImpl : HxObject
	{
		public static Array LEN_EXTRA_BITS_TBL;

		public static Array LEN_BASE_VAL_TBL;

		public static Array DIST_EXTRA_BITS_TBL;

		public static Array DIST_BASE_VAL_TBL;

		public static Array CODE_LENGTHS_POS;

		public static Huffman FIXED_HUFFMAN;

		public int nbits;

		public int bits;

		public State state;

		public bool isFinal;

		public Huffman huffman;

		public Huffman huffdist;

		public HuffTools htools;

		public int len;

		public int dist;

		public int needed;

		public Bytes output;

		public int outpos;

		public Input input;

		public Array lengths;

		public Window window;

		static InflateImpl()
		{
		}

		public InflateImpl(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public InflateImpl(Input i, object header, object crc)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_zip_InflateImpl(InflateImpl __hx_this, Input i, object header, object crc)
		{
		}

		public static Bytes run(Input i, object bufsize)
		{
			return null;
		}

		public virtual Huffman buildFixedHuffman()
		{
			return null;
		}

		public virtual int readBytes(Bytes b, int pos, int len)
		{
			return 0;
		}

		public virtual int getBits(int n)
		{
			return 0;
		}

		public virtual bool getBit()
		{
			return false;
		}

		public virtual int getRevBits(int n)
		{
			return 0;
		}

		public virtual void resetBits()
		{
		}

		public virtual void addBytes(Bytes b, int p, int len)
		{
		}

		public virtual void addByte(int b)
		{
		}

		public virtual void addDistOne(int n)
		{
		}

		public virtual void addDist(int d, int len)
		{
		}

		public virtual int applyHuffman(Huffman h)
		{
			return 0;
		}

		public virtual void inflateLengths(Array a, int max)
		{
		}

		public virtual bool inflateLoop()
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
