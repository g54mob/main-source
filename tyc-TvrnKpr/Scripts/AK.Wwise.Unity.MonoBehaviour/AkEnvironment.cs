using System;
using System.Collections.Generic;
using AK.Wwise;
using UnityEngine;
using UnityEngine.Serialization;

[AddComponentMenu("Wwise/AkEnvironment")]
[ExecuteInEditMode]
[RequireComponent(typeof(Collider))]
public class AkEnvironment : MonoBehaviour
{
	public class AkEnvironment_CompareByPriority : IComparer<AkEnvironment>
	{
		public virtual int Compare(AkEnvironment a, AkEnvironment b)
		{
			return 0;
		}
	}

	public class AkEnvironment_CompareBySelectionAlgorithm : AkEnvironment_CompareByPriority
	{
		public override int Compare(AkEnvironment a, AkEnvironment b)
		{
			return 0;
		}
	}

	public const int MAX_NB_ENVIRONMENTS = 4;

	public static AkEnvironment_CompareByPriority s_compareByPriority;

	public static AkEnvironment_CompareBySelectionAlgorithm s_compareBySelectionAlgorithm;

	public bool excludeOthers;

	public bool isDefault;

	public AuxBus data;

	public int priority;

	[HideInInspector]
	[SerializeField]
	[FormerlySerializedAs("m_auxBusID")]
	private int auxBusIdInternal;

	[HideInInspector]
	[SerializeField]
	[FormerlySerializedAs("valueGuid")]
	private byte[] valueGuidInternal;

	public Collider Collider { get; private set; }

	[Obsolete("This functionality is deprecated as of Wwise v2018.1.2 and will be removed in a future release.")]
	public int m_auxBusID => 0;

	[Obsolete("This functionality is deprecated as of Wwise v2018.1.6 and will be removed in a future release.")]
	public byte[] valueGuid => null;

	public void Awake()
	{
	}

	[Obsolete("This functionality is deprecated as of Wwise v2018.1.2 and will be removed in a future release.")]
	public uint GetAuxBusID()
	{
		return 0u;
	}

	[Obsolete("This functionality is deprecated as of Wwise v2018.1.6 and will be removed in a future release.")]
	public Collider GetCollider()
	{
		return null;
	}
}
