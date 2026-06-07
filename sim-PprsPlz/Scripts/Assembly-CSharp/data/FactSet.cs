using haxe.ds;
using haxe.lang;

namespace data
{
	public class FactSet : HxObject
	{
		public StringMap facts;

		public FactSet(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public FactSet()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_FactSet(FactSet __hx_this)
		{
		}

		public static FactSet combine(FactSet a, FactSet b)
		{
			return null;
		}

		public static FactSet fromXmlDoc(Xml xml)
		{
			return null;
		}

		public virtual Fact get(string path, object createIfNotFound)
		{
			return null;
		}

		public virtual Fact set(string path, FactValue value)
		{
			return null;
		}

		public virtual bool has(string path)
		{
			return false;
		}

		public virtual FactValue getValue(string path)
		{
			return null;
		}

		public virtual string getValueText(string path, string def)
		{
			return null;
		}

		public virtual string getValueLocalizedText(string path, string def)
		{
			return null;
		}

		public virtual int getValueInt(string path, object def)
		{
			return 0;
		}

		public virtual double getValueFloat(string path, object def)
		{
			return 0.0;
		}

		public virtual Array getValueStringArray(string path, string sep)
		{
			return null;
		}

		public virtual Fact setValueText(string path, string value)
		{
			return null;
		}

		public virtual Fact setValueInt(string path, int value)
		{
			return null;
		}

		public virtual Fact setValueFloat(string path, double value)
		{
			return null;
		}

		public virtual Fact setValueStringArray(string path, Array value, string sep)
		{
			return null;
		}

		public virtual void incInt(string path, object delta)
		{
		}

		public virtual void add(Fact fact)
		{
		}

		public virtual FactSet clone()
		{
			return null;
		}

		public object iterator()
		{
			return null;
		}

		public virtual string getHash()
		{
			return null;
		}

		public virtual Xml toXmlDoc()
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
