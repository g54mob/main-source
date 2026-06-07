using System;
using AK.Wwise;
using UnityEngine;
using UnityEngine.Serialization;

[AddComponentMenu("Wwise/AkState")]
[ExecuteInEditMode]
[DefaultExecutionOrder(-20)]
public class AkState : AkDragDropTriggerHandler
{
	public State data;

	[HideInInspector]
	[SerializeField]
	[FormerlySerializedAs("valueID")]
	private int valueIdInternal;

	[HideInInspector]
	[SerializeField]
	[FormerlySerializedAs("groupID")]
	private int groupIdInternal;

	[HideInInspector]
	[SerializeField]
	[FormerlySerializedAs("valueGuid")]
	private byte[] valueGuidInternal;

	[HideInInspector]
	[SerializeField]
	[FormerlySerializedAs("groupGuid")]
	private byte[] groupGuidInternal;

	protected override BaseType WwiseType => null;

	[Obsolete("This functionality is deprecated as of Wwise v2018.1.6 and will be removed in a future release.")]
	public int valueID => 0;

	[Obsolete("This functionality is deprecated as of Wwise v2018.1.6 and will be removed in a future release.")]
	public int groupID => 0;

	[Obsolete("This functionality is deprecated as of Wwise v2018.1.6 and will be removed in a future release.")]
	public byte[] valueGuid => null;

	[Obsolete("This functionality is deprecated as of Wwise v2018.1.6 and will be removed in a future release.")]
	public byte[] groupGuid => null;

	protected override void Awake()
	{
	}

	public override void HandleEvent(GameObject in_gameObject)
	{
	}
}
