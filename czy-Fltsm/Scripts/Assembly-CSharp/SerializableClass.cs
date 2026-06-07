public class SerializableClass : SerializableBase
{
	public byte Byte;

	public bool Bool;

	public int Int;

	public float Float;

	public string String;

	public SerializableSubclass _subclass1;

	public SerializableSubclass _subclass2;

	public override SerializationMarkers Marker => SerializationMarkers.SerializableClass;

	public SerializableClass()
	{
	}

	public SerializableClass(byte bt, bool bl, string s, int i, float f)
	{
		Byte = bt;
		Bool = bl;
		String = s;
		Int = i;
		Float = f;
		_subclass1 = new SerializableSubclass("Hello Subclass!");
		_subclass2 = new SerializableSubclass("Bye Subclass!");
	}

	protected override void InternalSerialize()
	{
		WriteByte("byte", Byte);
		WriteBool("bool", Bool);
		WriteString("string", String);
		WriteInt("int", Int);
		WriteFloat("float", Float);
		WriteSerializable("sc1", _subclass1);
		WriteSerializable("sc2", _subclass2);
	}

	protected override void InternalDeserialize()
	{
		Byte = ReadByte("byte", 0);
		Bool = ReadBool("bool");
		String = ReadString("string");
		Int = ReadInt("int");
		Float = ReadFloat("float");
		_subclass1 = ReadSerializable<SerializableSubclass>("sc1");
		_subclass2 = ReadSerializable<SerializableSubclass>("sc2");
	}
}
