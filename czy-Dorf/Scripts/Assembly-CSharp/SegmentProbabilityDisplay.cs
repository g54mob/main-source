using System;
using System.Collections.Generic;
using System.Linq;
using Dorfromantik;
using TMPro;
using UnityEngine;

public class SegmentProbabilityDisplay : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public ElementGroupSegment segment;

		public Func<SegmentPresetInfo, bool> _003C_003E9__0;

		public Func<SegmentPresetInfo, bool> _003C_003E9__1;

		public Func<GroupTypeConfiguration, bool> _003C_003E9__2;

		public Func<SegmentPresetInfo, bool> _003C_003E9__3;

		public Func<SegmentPresetInfo, bool> _003C_003E9__4;

		public Func<GroupTypeConfiguration, bool> _003C_003E9__5;

		internal bool _003CCalculateSegmentProbabilities_003Eb__0(SegmentPresetInfo x)
		{
			return x.segmentType == segment.SegmentType;
		}

		internal bool _003CCalculateSegmentProbabilities_003Eb__1(SegmentPresetInfo x)
		{
			return x.segmentType == segment.SegmentType;
		}

		internal bool _003CCalculateSegmentProbabilities_003Eb__2(GroupTypeConfiguration x)
		{
			return x.groupType == segment.GroupType;
		}

		internal bool _003CCalculateSegmentProbabilities_003Eb__3(SegmentPresetInfo x)
		{
			return x.segmentType == segment.SegmentType;
		}

		internal bool _003CCalculateSegmentProbabilities_003Eb__4(SegmentPresetInfo x)
		{
			return x.segmentType == segment.SegmentType;
		}

		internal bool _003CCalculateSegmentProbabilities_003Eb__5(GroupTypeConfiguration x)
		{
			return x.groupType == segment.GroupType;
		}
	}

	private sealed class _003C_003Ec__DisplayClass3_1
	{
		public ElementGroupSegment hybridSegment;

		internal bool _003CCalculateSegmentProbabilities_003Eb__7(HybridSegmentVariant y)
		{
			return y.hybridType == hybridSegment.SegmentType;
		}

		internal bool _003CCalculateSegmentProbabilities_003Eb__8(HybridSegmentVariant y)
		{
			return y.hybridType == hybridSegment.SegmentType;
		}
	}

	private sealed class _003C_003Ec__DisplayClass3_2
	{
		public HybridSegmentVariant hybridVariant;

		public _003C_003Ec__DisplayClass3_1 CS_0024_003C_003E8__locals1;

		internal bool _003CCalculateSegmentProbabilities_003Eb__9(ElementGroupSegment x)
		{
			if (x.SegmentType == hybridVariant.originalType)
			{
				return x.GroupType == CS_0024_003C_003E8__locals1.hybridSegment.GroupType;
			}
			return false;
		}
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<ElementGroupSegment, bool> _003C_003E9__3_6;

		internal bool _003CCalculateSegmentProbabilities_003Eb__3_6(ElementGroupSegment x)
		{
			return x.GetComponent<HybridSegment>();
		}
	}

	[SerializeField]
	private TileGenConfiguration configuration;

	[SerializeField]
	private bool read;

	private Dictionary<ElementGroupSegment, float> probabilities;

	private void CalculateSegmentProbabilities()
	{
		probabilities = new Dictionary<ElementGroupSegment, float>();
		ElementGroupSegment[] array = UnityEngine.Object.FindObjectsOfType<ElementGroupSegment>();
		float num = 0f;
		ElementGroupSegment[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals24 = new _003C_003Ec__DisplayClass3_0();
			CS_0024_003C_003E8__locals24.segment = array2[i];
			probabilities.Add(CS_0024_003C_003E8__locals24.segment, 0f);
			foreach (TilePresetConfigurationCollection tilePresetCollection in configuration.tilePresetCollections)
			{
				if (tilePresetCollection.subCollections != null && tilePresetCollection.subCollections.Count > 0)
				{
					foreach (TilePresetConfigurationSubCollection subCollection in tilePresetCollection.subCollections)
					{
						foreach (TilePresetConfiguration tilePreset in subCollection.tilePresets)
						{
							if (Enumerable.Count(tilePreset.segmentProbabilities, (SegmentPresetInfo x) => x.segmentType == CS_0024_003C_003E8__locals24.segment.SegmentType) != 0)
							{
								SegmentPresetInfo segmentPresetInfo = Enumerable.First(tilePreset.segmentProbabilities, (SegmentPresetInfo x) => x.segmentType == CS_0024_003C_003E8__locals24.segment.SegmentType);
								probabilities[CS_0024_003C_003E8__locals24.segment] += Enumerable.First(segmentPresetInfo.possibleTypes, (GroupTypeConfiguration x) => x.groupType == CS_0024_003C_003E8__locals24.segment.GroupType).probabilityInPercent * tilePreset.tilePresetProbability;
							}
						}
					}
					continue;
				}
				foreach (TilePresetConfiguration tilePreset2 in tilePresetCollection.tilePresets)
				{
					if (Enumerable.Count(tilePreset2.segmentProbabilities, (SegmentPresetInfo x) => x.segmentType == CS_0024_003C_003E8__locals24.segment.SegmentType) != 0)
					{
						SegmentPresetInfo segmentPresetInfo2 = Enumerable.First(tilePreset2.segmentProbabilities, (SegmentPresetInfo x) => x.segmentType == CS_0024_003C_003E8__locals24.segment.SegmentType);
						probabilities[CS_0024_003C_003E8__locals24.segment] += Enumerable.First(segmentPresetInfo2.possibleTypes, (GroupTypeConfiguration x) => x.groupType == CS_0024_003C_003E8__locals24.segment.GroupType).probabilityInPercent * tilePreset2.tilePresetProbability;
					}
				}
			}
			num += probabilities[CS_0024_003C_003E8__locals24.segment];
		}
		using (IEnumerator<ElementGroupSegment> enumerator4 = Enumerable.Where(array, (ElementGroupSegment x) => x.GetComponent<HybridSegment>()).GetEnumerator())
		{
			while (enumerator4.MoveNext())
			{
				_003C_003Ec__DisplayClass3_1 _003C_003Ec__DisplayClass3_3 = new _003C_003Ec__DisplayClass3_1();
				_003C_003Ec__DisplayClass3_3.hybridSegment = enumerator4.Current;
				_003C_003Ec__DisplayClass3_2 CS_0024_003C_003E8__locals28 = new _003C_003Ec__DisplayClass3_2();
				CS_0024_003C_003E8__locals28.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass3_3;
				if (Enumerable.Count(CS_0024_003C_003E8__locals28.CS_0024_003C_003E8__locals1.hybridSegment.GroupType.hybridSegmentVariants, (HybridSegmentVariant y) => y.hybridType == CS_0024_003C_003E8__locals28.CS_0024_003C_003E8__locals1.hybridSegment.SegmentType) == 0)
				{
					Debug.LogError($"no entry for hybrid type {CS_0024_003C_003E8__locals28.CS_0024_003C_003E8__locals1.hybridSegment.SegmentType} in {CS_0024_003C_003E8__locals28.CS_0024_003C_003E8__locals1.hybridSegment.GroupType}");
					continue;
				}
				CS_0024_003C_003E8__locals28.hybridVariant = Enumerable.First(CS_0024_003C_003E8__locals28.CS_0024_003C_003E8__locals1.hybridSegment.GroupType.hybridSegmentVariants, (HybridSegmentVariant y) => y.hybridType == CS_0024_003C_003E8__locals28.CS_0024_003C_003E8__locals1.hybridSegment.SegmentType);
				ElementGroupSegment elementGroupSegment = Enumerable.First(array, (ElementGroupSegment x) => x.SegmentType == CS_0024_003C_003E8__locals28.hybridVariant.originalType && x.GroupType == CS_0024_003C_003E8__locals28.CS_0024_003C_003E8__locals1.hybridSegment.GroupType);
				Debug.Log($"setting probability of {CS_0024_003C_003E8__locals28.CS_0024_003C_003E8__locals1.hybridSegment} to {probabilities[elementGroupSegment]} * {CS_0024_003C_003E8__locals28.hybridVariant.hybridProbability}");
				Debug.Log($"setting probability of {elementGroupSegment} to {probabilities[elementGroupSegment]} * {1f - CS_0024_003C_003E8__locals28.hybridVariant.hybridProbability}");
				probabilities[CS_0024_003C_003E8__locals28.CS_0024_003C_003E8__locals1.hybridSegment] = probabilities[elementGroupSegment] * CS_0024_003C_003E8__locals28.hybridVariant.hybridProbability;
				probabilities[elementGroupSegment] *= 1f - CS_0024_003C_003E8__locals28.hybridVariant.hybridProbability;
			}
		}
		array2 = array;
		foreach (ElementGroupSegment elementGroupSegment2 in array2)
		{
			elementGroupSegment2.GetComponentInChildren<TextMeshPro>().text = (probabilities[elementGroupSegment2] / num * 100f).ToString("0.000") + "%";
		}
		Debug.Log($"Total: {num}");
	}
}
