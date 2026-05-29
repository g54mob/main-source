public class ObjectInfo
{
	public enum Type
	{
		Normal = 0,
		Container = 1,
		Bot = 2,
		Folk = 3,
		Total = 4
	}

	public Type m_Type;

	public ObjectType m_ObjectType;

	public ObjectType m_Extra;

	public ObjectInfo(Type NewType, ObjectType NewObjectType, ObjectType Extra)
	{
		m_Type = NewType;
		m_ObjectType = NewObjectType;
		m_Extra = Extra;
	}
}
