using System;
using UnityEngine.Localization;

[Serializable]
public struct GnormanFluffActionLine
{
	public LocalizedString message;

	public GnormanAnimation animation;

	public bool playSfx;

	public AudioDataType sfx;
}
