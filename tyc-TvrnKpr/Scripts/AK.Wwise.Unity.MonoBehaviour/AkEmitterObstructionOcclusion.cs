using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Wwise/AkEmitterObstructionOcclusion")]
[RequireComponent(typeof(AkGameObj))]
public class AkEmitterObstructionOcclusion : AkObstructionOcclusion
{
	private AkGameObj m_gameObj;

	private void Awake()
	{
	}

	protected override void UpdateCurrentListenerList()
	{
	}

	protected override void SetObstructionOcclusion(KeyValuePair<AkAudioListener, ObstructionOcclusionValue> ObsOccPair)
	{
	}
}
