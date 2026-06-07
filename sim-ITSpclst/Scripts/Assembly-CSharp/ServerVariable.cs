using UnityEngine;

public class ServerVariable : MonoBehaviour
{
	[Header("Unique Device ID")]
	public string deviceID;

	public bool isServerOnline;

	[Header("Password data")]
	public int logOffTime;

	public int minPasswordAge;

	public int maxPasswordAge;

	public int minPasswordLenght;

	public int lockoutDuration;

	public int lockoutThreshold;

	public int passwordHistoryLenght;

	private void OnValidate()
	{
	}
}
