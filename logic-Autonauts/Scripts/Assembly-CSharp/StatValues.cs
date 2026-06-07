using SimpleJSON;

public class StatValues
{
	public enum Type
	{
		Count = 0,
		Rate = 1,
		Time = 2,
		Total = 3
	}

	public StatsManager.Stat m_ID;

	public Type m_Type;

	public StatValues(StatsManager.Stat ID, Type NewType)
	{
		m_ID = ID;
		m_Type = NewType;
	}

	public virtual string GetAsString()
	{
		return "";
	}

	public virtual void Add()
	{
	}

	public virtual void Save(JSONNode Node)
	{
	}

	public virtual void Load(JSONNode Node)
	{
	}

	public virtual void Update()
	{
	}
}
