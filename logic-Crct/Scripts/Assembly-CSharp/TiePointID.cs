using System;

[Serializable]
public class TiePointID
{
	public int id;

	public Guid parentIdentifier;

	public TiePointID(TiePoint tp)
	{
	}

	public TiePointID()
	{
	}
}
