using System.Collections.Generic;
using System.Linq;
using Dorfromantik;
using UnityEngine;
using UnityEngine.Serialization;

public class GroupType : ScriptableObject
{
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public SegmentType segmentType;

		internal bool _003CHybridSegmentForSegmentType_003Eb__0(HybridSegmentVariant x)
		{
			return x.originalType == segmentType;
		}

		internal bool _003CHybridSegmentForSegmentType_003Eb__1(HybridSegmentVariant x)
		{
			return x.originalType == segmentType;
		}
	}

	public GroupTypeId id;

	public Color color;

	public CustomRuleType customRuleType;

	[FormerlySerializedAs("adaptive")]
	public bool constraining;

	public ElementGroupSegment[] overwriteVisuals = new ElementGroupSegment[13];

	public ElementType primaryElementType;

	[SerializeField]
	public List<HybridSegmentVariant> hybridSegmentVariants;

	public ElementSubType SegmentGroundSubType;

	public string localizationKey_singular;

	public string localizationKey_plural;

	private void OnValidate()
	{
		localizationKey_plural = localizationKey_singular.Replace("_", "s_");
	}

	public HybridSegmentVariant HybridSegmentForSegmentType(SegmentType segmentType)
	{
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass11_0();
		CS_0024_003C_003E8__locals3.segmentType = segmentType;
		if (Enumerable.Count(hybridSegmentVariants, (HybridSegmentVariant x) => x.originalType == CS_0024_003C_003E8__locals3.segmentType) > 0)
		{
			return Enumerable.First(hybridSegmentVariants, (HybridSegmentVariant x) => x.originalType == CS_0024_003C_003E8__locals3.segmentType);
		}
		return null;
	}
}
