using System;
using System.Collections.Generic;
using AK.Wwise;
using UnityEngine;
using UnityEngine.Serialization;

[AddComponentMenu("Wwise/AkBank")]
[ExecuteInEditMode]
[DefaultExecutionOrder(-75)]
public class AkBank : AkTriggerHandler
{
	public Bank data;

	public bool decodeBank;

	public bool overrideLoadSetting;

	public bool loadAsynchronous;

	public bool saveDecodedBank;

	public List<int> unloadTriggerList;

	[HideInInspector]
	[SerializeField]
	[FormerlySerializedAs("bankName")]
	private string bankNameInternal;

	[HideInInspector]
	[SerializeField]
	[FormerlySerializedAs("valueGuid")]
	private byte[] valueGuidInternal;

	[Obsolete("This functionality is deprecated as of Wwise v2018.1.6 and will be removed in a future release.")]
	public string bankName => null;

	[Obsolete("This functionality is deprecated as of Wwise v2018.1.6 and will be removed in a future release.")]
	public byte[] valueGuid => null;

	protected override void Awake()
	{
	}

	protected override void Start()
	{
	}

	public override void HandleEvent(GameObject in_gameObject)
	{
	}

	private void HandleEvent()
	{
	}

	public void UnloadBank(GameObject in_gameObject)
	{
	}

	protected override void OnDestroy()
	{
	}
}
