using System;

namespace VampireSurvivors.Data;

[Serializable]
public class EpicGamesStoreGameData
{
	private string _ArtifactId;

	private bool _BundledDlcInBuild;

	public string ArtifactId => _ArtifactId;

	public bool BundledDlcInBuild
	{
		get
		{
			return _BundledDlcInBuild;
		}
		set
		{
			_BundledDlcInBuild = value;
		}
	}
}
