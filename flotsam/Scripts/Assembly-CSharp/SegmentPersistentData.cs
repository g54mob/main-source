using System;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
public class SegmentPersistentData : BuildableExtendablePersistentData<WalkwaySegment>
{
	public float ScaledLength;

	public Vector3 StartPosition;

	public Vector3 EndPosition;

	[OptionalField(VersionAdded = 2)]
	public PersistentReference<Hookable>.Reference StartHookable;

	[OptionalField(VersionAdded = 2)]
	public PersistentReference<Hookable>.Reference EndHookable;

	public PersistentReference<Construction>.Reference StartConstruction;

	public PersistentReference<Construction>.Reference EndConstruction;

	public SegmentPersistentData(WalkwaySegment segment, float scaledLength)
		: base(segment)
	{
		ScaledLength = scaledLength;
		StartPosition = segment.StartPosition;
		EndPosition = segment.EndPosition;
	}

	public override void RestoreData(Buildable buildable)
	{
		if (buildable.TryGetComponent<WalkwaySegment>(out var component))
		{
			base.Instance = component;
			base.Instance.Restore(this);
		}
	}

	public override void RestoreReferences()
	{
		if (base.Instance != null)
		{
			base.Instance.RestoreReferences(this);
		}
	}

	public override void PopulateReferences()
	{
		base.Instance.PopulateReferences(this);
	}
}
