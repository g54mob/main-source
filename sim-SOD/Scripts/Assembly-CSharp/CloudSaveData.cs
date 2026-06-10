using UnityEngine;

[CreateAssetMenu(fileName = "cloudsave_data", menuName = "Database/Dev Cloud Save Data")]
public class CloudSaveData : SoCustomComparison
{
	[Header("Dev Cloud Save Path")]
	[Tooltip("Path to dropbox save folder")]
	public string path;
}
