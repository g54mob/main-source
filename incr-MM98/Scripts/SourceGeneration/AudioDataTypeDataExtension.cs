using System.Collections.Generic;
using UnityEngine;

public static class AudioDataTypeDataExtension
{
	private static readonly Dictionary<AudioDataType, AudioClip> data;

	static AudioDataTypeDataExtension()
	{
		data = new Dictionary<AudioDataType, AudioClip>();
		ScriptableAssetEnum scriptableAssetEnum = Resources.Load<ScriptableAssetEnum>("Enums/AudioDataType");
		data.Add(AudioDataType.ClickSfx, (AudioClip)scriptableAssetEnum.Data[0].Value);
		data.Add(AudioDataType.FailSfx, (AudioClip)scriptableAssetEnum.Data[1].Value);
		data.Add(AudioDataType.TypewriterCarriageReturn, (AudioClip)scriptableAssetEnum.Data[2].Value);
		data.Add(AudioDataType.CheckboxChecked, (AudioClip)scriptableAssetEnum.Data[3].Value);
		data.Add(AudioDataType.CheckboxUnchecked, (AudioClip)scriptableAssetEnum.Data[4].Value);
		data.Add(AudioDataType.ServersOverloaded, (AudioClip)scriptableAssetEnum.Data[5].Value);
		data.Add(AudioDataType.ServerReprovisionBase, (AudioClip)scriptableAssetEnum.Data[6].Value);
		data.Add(AudioDataType.PowerUp, (AudioClip)scriptableAssetEnum.Data[7].Value);
		data.Add(AudioDataType.MinesweeperGameover, (AudioClip)scriptableAssetEnum.Data[8].Value);
		data.Add(AudioDataType.MinesweeperNewGame, (AudioClip)scriptableAssetEnum.Data[9].Value);
		data.Add(AudioDataType.MinesweeperVictory, (AudioClip)scriptableAssetEnum.Data[10].Value);
		data.Add(AudioDataType.BugSquash, (AudioClip)scriptableAssetEnum.Data[11].Value);
		data.Add(AudioDataType.BugStagingFull, (AudioClip)scriptableAssetEnum.Data[12].Value);
		data.Add(AudioDataType.TaskbarComplete, (AudioClip)scriptableAssetEnum.Data[13].Value);
		data.Add(AudioDataType.DevelopmentComplete, (AudioClip)scriptableAssetEnum.Data[14].Value);
		data.Add(AudioDataType.SequelDevRoundComplete, (AudioClip)scriptableAssetEnum.Data[15].Value);
		data.Add(AudioDataType.AutomatedDebuggerSendToStaging, (AudioClip)scriptableAssetEnum.Data[16].Value);
		data.Add(AudioDataType.AuctionWithdraw, (AudioClip)scriptableAssetEnum.Data[17].Value);
		data.Add(AudioDataType.DatacenterConstructed, (AudioClip)scriptableAssetEnum.Data[18].Value);
		data.Add(AudioDataType.DatacenterRestored, (AudioClip)scriptableAssetEnum.Data[19].Value);
	}

	public static AudioClip Value(this AudioDataType key)
	{
		return data[key];
	}
}
