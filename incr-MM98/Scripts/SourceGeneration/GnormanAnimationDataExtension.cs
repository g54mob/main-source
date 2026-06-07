using System.Collections.Generic;
using UnityEngine;

public static class GnormanAnimationDataExtension
{
	private static readonly Dictionary<GnormanAnimation, AnimationClip> data;

	static GnormanAnimationDataExtension()
	{
		data = new Dictionary<GnormanAnimation, AnimationClip>();
		ScriptableAssetEnum scriptableAssetEnum = Resources.Load<ScriptableAssetEnum>("Enums/GnormanAnimation");
		data.Add(GnormanAnimation.None, (AnimationClip)scriptableAssetEnum.Data[0].Value);
		data.Add(GnormanAnimation.Idle, (AnimationClip)scriptableAssetEnum.Data[1].Value);
		data.Add(GnormanAnimation.Dance, (AnimationClip)scriptableAssetEnum.Data[2].Value);
		data.Add(GnormanAnimation.Jump, (AnimationClip)scriptableAssetEnum.Data[3].Value);
		data.Add(GnormanAnimation.Sad, (AnimationClip)scriptableAssetEnum.Data[4].Value);
	}

	public static AnimationClip Value(this GnormanAnimation key)
	{
		return data[key];
	}
}
