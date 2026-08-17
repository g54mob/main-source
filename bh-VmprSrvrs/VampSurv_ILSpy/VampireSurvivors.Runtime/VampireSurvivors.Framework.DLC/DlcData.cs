using System;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.DLC;

[Serializable]
public class DlcData : ScriptableObject
{
	public string _Title;

	public string _TitleLocKey;

	public DlcType _DlcType;

	public Sprite _DlcIcon;

	public ContentGroupType _ContentGroupType;

	public string _ExpectedVersion;

	public bool _HasBeenReleased;

	public ReleaseDateData _ReleaseDate;

	public SteamDlcData _Steam;

	public EpicGamesStoreData _EpicGamesesStore;

	public XboxDlcData _Xbox;

	public SwitchDlcData _Switch;

	public PlayStationDlcData _PS5;

	public PlayStationDlcData _PS4;

	public MobileDlcData _Mobile;

	public BundleDlcData _BundleDlc;

	public bool DoNotAutoInclude;

	public bool _DoNotBuild;

	public DlcData()
	{
		SteamDlcData steam = new SteamDlcData();
		_Steam = steam;
		_EpicGamesesStore = new EpicGamesStoreData();
		_Xbox = new XboxDlcData();
		_Switch = new SwitchDlcData();
		_PS5 = new PlayStationDlcData();
		_PS4 = new PlayStationDlcData();
		_Mobile = new MobileDlcData();
		_BundleDlc = new BundleDlcData();
		base._002Ector();
	}
}
