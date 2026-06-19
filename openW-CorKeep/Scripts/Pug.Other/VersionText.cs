using Pug.UnityExtensions;
using UnityEngine;

public class VersionText : MonoBehaviour
{
	public PugText text;

	private const string versionTerm = "Menu/Version";

	private void Awake()
	{
		text.SetText("Menu/Version");
		text.formatFields = new string[2]
		{
			Manager.fullVersion,
			BuildDate.ToString()
		};
	}
}
