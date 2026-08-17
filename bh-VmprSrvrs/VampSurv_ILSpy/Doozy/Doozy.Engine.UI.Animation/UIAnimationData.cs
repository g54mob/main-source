using System;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.UI.Animation;

[Serializable]
public class UIAnimationData : ScriptableObject
{
	public UIAnimation Animation;

	public string Category;

	public string Name;

	public void SetDirty(bool saveAssets)
	{
		DoozyUtils.SetDirty(this, saveAssets);
	}
}
