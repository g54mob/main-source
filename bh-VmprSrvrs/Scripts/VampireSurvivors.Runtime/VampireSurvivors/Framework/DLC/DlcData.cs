using System;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.DLC
{
	[Serializable]
	[CreateAssetMenu(fileName = "DlcData", menuName = "VampireSurvivors/New DlcData")]
	public class DlcData : ScriptableObject
	{
		public string _Title;

		public string _TitleLocKey;

		public DlcType _DlcType;

		public Sprite _DlcIcon;

		public ContentGroupType _ContentGroupType;

		[SerializeField]
		public string _ExpectedVersion;

		[Tooltip("Defines whether this DLC has been released on the stores yet. Used when checking whether to patch a DLC.")]
		[SerializeField]
		public bool _HasBeenReleased;

		[SerializeField]
		public ReleaseDateData _ReleaseDate;

		[SerializeField]
		public SteamDlcData _Steam;

		[SerializeField]
		public EpicGamesStoreData _EpicGamesesStore;

		[SerializeField]
		public XboxDlcData _Xbox;

		[SerializeField]
		public SwitchDlcData _Switch;

		[SerializeField]
		public PlayStationDlcData _PS5;

		[SerializeField]
		public PlayStationDlcData _PS4;

		[SerializeField]
		public MobileDlcData _Mobile;

		[Tooltip("If enabled this DLC will be bundled and made available locally for testing on the selected platforms.")]
		[SerializeField]
		public BundleDlcData _BundleDlc;

		public bool DoNotAutoInclude;

		[Tooltip("If ticked this DLC will be not be built at all. It will only be available in editor.")]
		[SerializeField]
		public bool _DoNotBuild;
	}
}
