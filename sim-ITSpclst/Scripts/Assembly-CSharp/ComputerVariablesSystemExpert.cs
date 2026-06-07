using UnityEngine;

public class ComputerVariablesSystemExpert : PTSMonoBehaviour
{
	public ServerVariable serverVariable;

	public string comment;

	public string userComment;

	public bool accountActive;

	public bool accountExpires;

	public bool passwordExpires;

	public bool passwordRequired;

	public bool passwordUserMayChange;

	public string workstationsAllowed;

	public string logonHoursAllowed;

	[Header("Password data")]
	public int minPasswordAge;

	public int maxPasswordAge;

	public int minPasswordLenght;

	public int lockoutDuration;

	public int passwordHistoryLenght;

	public string computerRole;

	public string computerDomainRole;
}
