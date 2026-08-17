using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Builds;
using VampireSurvivors.Builds.Game;

namespace VampireSurvivors.Data;

[Serializable]
public class BaseGameData : ScriptableObject
{
	public static readonly string ARTIFACT_TYPE = "BaseGame";

	public readonly string _Title = ARTIFACT_TYPE;

	private BuildMeta _BuildMeta = new BuildMeta
	{
		BuildPlatform = BuildPlatform.UNKNOWN
	};

	public SteamBaseGameData _Steam = new SteamBaseGameData();

	public EpicGamesStoreGameData _EpicGamesStore = new EpicGamesStoreGameData();

	public XboxBaseGameData _Xbox = new XboxBaseGameData();

	public SwitchBaseGameData _Switch = new SwitchBaseGameData();

	public PS4BaseGameData _PS4 = new PS4BaseGameData();

	public PS5BaseGameData _PS5;

	public IOS _IOS;

	public AppleArcade _AppleArcade;

	public BuildMeta BuildMeta
	{
		get
		{
			return _BuildMeta;
		}
		set
		{
			_BuildMeta = value;
		}
	}

	public BaseGameData()
	{
		PS5BaseGameData pS5BaseGameData = new PS5BaseGameData();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C1F]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		pS5BaseGameData._MasterVersion = "01.00";
		_PS5 = pS5BaseGameData;
		_IOS = new IOS();
		_AppleArcade = new AppleArcade();
		base._002Ector();
	}
}
