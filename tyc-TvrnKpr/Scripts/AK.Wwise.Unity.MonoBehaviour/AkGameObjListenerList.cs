using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AkGameObjListenerList : AkAudioListener.BaseListenerList
{
	[NonSerialized]
	private AkGameObj akGameObj;

	[SerializeField]
	public List<AkAudioListener> initialListenerList;

	[SerializeField]
	public bool useDefaultListeners;

	public void SetUseDefaultListeners(bool useDefault)
	{
	}

	public void Init(AkGameObj akGameObj)
	{
	}

	public override bool Add(AkAudioListener listener)
	{
		return false;
	}

	public override bool Remove(AkAudioListener listener)
	{
		return false;
	}
}
