using System;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
[CreateAssetMenu(fileName = "SoundAssetData_", menuName = "SoundAssetData", order = 1)]
public class SoundAssetData : ScriptableObject
{
	public enum SOUND_TYPE
	{
		NONE = 0,
		SOUND = 1,
		BGM = 2,
		VOCAL = 3
	}

	[Header("自己取的檔案名稱")]
	public string DataName;

	[Header("播放時使用的key")]
	public string DataKey;

	public AudioMixer AudioMixer;

	public SoundEntry[] SoundFile;

	public void AddSoundEntry(SoundEntry entry)
	{
	}
}
