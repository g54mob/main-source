using System;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.UI;

[Serializable]
public class UIPopupLink : ScriptableObject
{
	public string PopupName;

	public GameObject Prefab;

	public void SetDirty(bool saveAssets)
	{
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public void UpdateAssetName(bool saveAsset)
	{
	}
}
