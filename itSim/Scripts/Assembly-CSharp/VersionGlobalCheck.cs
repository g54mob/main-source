using UnityEngine;

public class VersionGlobalCheck : MonoBehaviour
{
	public static VersionGlobalCheck Instance;

	[Header("Printer")]
	public string _printerVersion;

	[HideInInspector]
	public string _printerVersionWeight;

	[HideInInspector]
	public string _printerVersionDescription;

	[Header("OScypek")]
	public string _oscypekVersion;

	[HideInInspector]
	public string _oscypekVersionWeight;

	[HideInInspector]
	public string _oscypekVersionDescription;

	public bool _oscypekMustRestartSystem;

	public void Awake()
	{
	}
}
