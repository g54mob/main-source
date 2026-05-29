using Unity.Services.Analytics;

public class SDEventBase : Event
{
	public string steamid
	{
		set
		{
		}
	}

	public string steambuildid
	{
		set
		{
		}
	}

	public float totalplaytime
	{
		set
		{
		}
	}

	public SDEventBase(string name)
		: base(null)
	{
	}
}
