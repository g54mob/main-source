using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : ScriptableObject
{
	[Serializable]
	public class SoundGroupCategoryHDRRangeData
	{
		public eSoundGroupCategory category;

		public int HDRRange;

		public SoundGroupCategoryHDRRangeData(eSoundGroupCategory category, int hdrRange)
		{
		}
	}

	[Header("全てのSoundGroupCategoryでGlobalHDRRangeを使用する")]
	public bool isUseGlobalHDRRange;

	public int globalHDRRange;

	[Header("HDR Range")]
	public List<SoundGroupCategoryHDRRangeData> HDRRangeDatas;

	[Header("常に再生するSoundGroupCategory")]
	public List<eSoundGroupCategory> alwaysPlayCategorys;

	[Header("3Dサウンドで音を再生する最大距離")]
	public float playSoundMaxDistanceFor3D;

	[Header("BGMのデフォルトボリューム(%)")]
	public float defaultBGMVolume;
}
