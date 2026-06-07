using haxe.ds;
using haxe.lang;

public class Xml : HxObject
{
	public static int Element;

	public static int PCData;

	public static int CData;

	public static int Comment;

	public static int DocType;

	public static int ProcessingInstruction;

	public static int Document;

	public int nodeType;

	public string nodeName;

	public string nodeValue;

	public Xml parent;

	public Array children;

	public StringMap attributeMap;

	static Xml()
	{
	}

	public Xml(EmptyObject empty)
		: base(default(EmptyObject))
	{
	}

	public Xml(int nodeType)
		: base(default(EmptyObject))
	{
	}

	protected static void __hx_ctor__Xml(Xml __hx_this, int nodeType)
	{
	}

	public static Xml parse(string str)
	{
		return null;
	}

	public static Xml createElement(string name)
	{
		return null;
	}

	public static Xml createPCData(string data)
	{
		return null;
	}

	public static Xml createCData(string data)
	{
		return null;
	}

	public static Xml createComment(string data)
	{
		return null;
	}

	public static Xml createDocType(string data)
	{
		return null;
	}

	public static Xml createProcessingInstruction(string data)
	{
		return null;
	}

	public static Xml createDocument()
	{
		return null;
	}

	public string get_nodeName()
	{
		return null;
	}

	public string set_nodeName(string v)
	{
		return null;
	}

	public string get_nodeValue()
	{
		return null;
	}

	public string set_nodeValue(string v)
	{
		return null;
	}

	public virtual string get(string att)
	{
		return null;
	}

	public virtual void set(string att, string value)
	{
	}

	public virtual void remove(string att)
	{
	}

	public virtual bool exists(string att)
	{
		return false;
	}

	public virtual object attributes()
	{
		return null;
	}

	public object iterator()
	{
		return null;
	}

	public virtual object elements()
	{
		return null;
	}

	public virtual object elementsNamed(string name)
	{
		return null;
	}

	public Xml firstChild()
	{
		return null;
	}

	public virtual Xml firstElement()
	{
		return null;
	}

	public virtual void addChild(Xml x)
	{
	}

	public virtual bool removeChild(Xml x)
	{
		return false;
	}

	public virtual void insertChild(Xml x, int pos)
	{
	}

	public string toString()
	{
		return null;
	}

	public void ensureElementType()
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

	public override string ToString()
	{
		return null;
	}
}
