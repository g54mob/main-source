using System.Collections.Generic;
using UnityEngine;

public class SoundAssetDataLoader : MonoBehaviour
{
	[SerializeField]
	[Header("把要載入的聲音設定檔放在這邊")]
	private List<SoundAssetData> list_SoundAssetDatas;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}
}
