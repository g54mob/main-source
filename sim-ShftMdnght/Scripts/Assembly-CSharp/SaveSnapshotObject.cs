using Mirror;

public class SaveSnapshotObject : NetworkBehaviour
{
	public int instantiableID;

	public bool dontKeepOnNewDay;

	public string associatedString;

	public int shiftsAlive;

	public int maxShiftsAlive = -1;

	public void CheckShiftsAlive(int shiftsAlive_)
	{
		shiftsAlive = shiftsAlive_;
		if (maxShiftsAlive > 0 && shiftsAlive >= maxShiftsAlive)
		{
			NetworkServer.Destroy(base.gameObject);
		}
	}

	public override bool Weaved()
	{
		return true;
	}
}
