using System;
using System.Collections.Generic;
using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using ToolBuddy.Pooling.Collections;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[HelpURL("https://curvyeditor.com/doclink/cgvolumespots")]
	[ModuleInfo("Build/Volume Spots", ModuleName = "Volume Spots", Description = "Generate spots along a path/volume", UsesRandom = true)]
	public class BuildVolumeSpots : CGModule, ISerializationCallbackReceiver
	{
		private struct EditorData : IEquatable<EditorData>
		{
			public int SpotsCount { get; }

			public bool InputIsAVolume { get; }

			[ItemNotNull]
			[NotNull]
			public string[] BoundsNames { get; }

			public EditorData([NotNull] IReadOnlyList<CGBounds> bounds, bool inputIsAVolume, int spotsCount)
			{
				SpotsCount = 0;
				InputIsAVolume = false;
				BoundsNames = null;
			}

			[NotNull]
			[Pure]
			private static string[] GetBoundsNames([NotNull] IReadOnlyList<CGBounds> bounds)
			{
				return null;
			}

			public bool Equals(EditorData other)
			{
				return false;
			}

			public override bool Equals(object obj)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}

			public static bool operator ==(EditorData left, EditorData right)
			{
				return false;
			}

			public static bool operator !=(EditorData left, EditorData right)
			{
				return false;
			}
		}

		private sealed class EndGroupData : IDisposable
		{
			private bool disposed;

			internal CGBoundsGroup BoundsGroup { get; }

			internal SubArray<int> ItemIndices { get; }

			internal float GroupDepth { get; }

			internal CGBounds[] ItemBounds { get; }

			internal float SpaceBefore { get; }

			internal float SpaceAfter { get; }

			internal EndGroupData(CGBoundsGroup boundsGroup, SubArray<int> itemIndices, float groupDepth, CGBounds[] itemBounds, float spaceBefore, float spaceAfter)
			{
			}

			private bool Dispose(bool disposing)
			{
				return false;
			}

			public void Dispose()
			{
			}

			~EndGroupData()
			{
			}
		}

		private const int MinCrossBase = -1;

		private const int MaxCrossBase = 1;

		private const int MinRange = 0;

		private const int MaxRange = 1;

		[InputSlotInfo(new Type[] { typeof(CGPath) }, Name = "Path/Volume", DisplayName = "Volume/Rasterized Path")]
		[HideInInspector]
		public CGModuleInputSlot InPath;

		[InputSlotInfo(new Type[] { typeof(CGBounds) }, Array = true)]
		[HideInInspector]
		public CGModuleInputSlot InBounds;

		[OutputSlotInfo(typeof(CGSpots))]
		[HideInInspector]
		public CGModuleOutputSlot OutSpots;

		[HideInInspector]
		[SerializeField]
		private bool m_WasUpgraded;

		[FloatRegion(RegionOptionsPropertyName = "RangeOptions", Precision = 4)]
		[Section("Default/General/Volume Path", true, false, 100)]
		[Tab("General")]
		[SerializeField]
		private FloatRegion m_Range;

		[SerializeField]
		[Section("Default/General/Volume Cross", true, false, 100)]
		[Label("Use Volume's Surface", null)]
		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[Tooltip("When the source is a Volume, you can choose if you want to use it's path or the volume")]
		private bool m_UseVolume;

		[Tooltip("Shifts the Cross origin value by constant value")]
		[RangeEx(-1f, 1f, null, null)]
		[SerializeField]
		private float m_CrossBase;

		[Tooltip("Shifts the Cross origin value by a value that varies along the Volume's length. The Curve's X axis has values between 0 (start of the Range) and 1 (its end)")]
		[SerializeField]
		[Label("Cross Base Variation", null)]
		private AnimationCurve m_CrossCurve;

		[Section("Default/General/Advanced Settings", false, false, 100)]
		[Tooltip("Check to run a dry run without actually creating spots")]
		[SerializeField]
		private bool m_Simulate;

		[Tooltip("Until version 6.3.1, this module had a bug in the computation of the randomized values. Enable this value to keep that bugged behaviour if your project depends on it")]
		[SerializeField]
		private bool m_UseBuggedRNG;

		[SerializeField]
		[ArrayEx(Space = 10)]
		[Tab("Groups")]
		private List<CGBoundsGroup> m_Groups;

		[SerializeField]
		[IntRegion(UseSlider = false, RegionOptionsPropertyName = "RepeatingGroupsOptions", Options = AttributeOptionsFlags.Compact)]
		[Tooltip("The range of groups that will be placed repetitively along the volume. Groups that are not in this range will be placed only once")]
		private IntRegion m_RepeatingGroups;

		[SerializeField]
		private CurvyRepeatingOrderEnum m_RepeatingOrder;

		[FieldCondition(/*Could not decode attribute arguments.*/)]
		[Label("Fits The End", null)]
		[SerializeField]
		[Tooltip("If checked, the last non repeating group is placed exactly at the end of the volume used for spots. If not, the last group is placed at the first available spot, which might leave some space between it and the end of the volume")]
		private bool m_FitEnd;

		public CGSpots SimulatedSpots;

		private EditorData editorData;

		public FloatRegion Range
		{
			get
			{
				return default(FloatRegion);
			}
			set
			{
			}
		}

		public bool UseVolume
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Simulate
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool UseBuggedRng
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float CrossBase
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public AnimationCurve CrossCurve
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public List<CGBoundsGroup> Groups
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CurvyRepeatingOrderEnum RepeatingOrder
		{
			get
			{
				return default(CurvyRepeatingOrderEnum);
			}
			set
			{
			}
		}

		public int FirstRepeating
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int LastRepeating
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool FitEnd
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int GroupCount => 0;

		[UsedImplicitly]
		[Obsolete("Will become an editor only method")]
		public GUIContent[] BoundsNames => null;

		[UsedImplicitly]
		[Obsolete]
		public int[] BoundsIndices => null;

		public int Count => 0;

		private int LastGroupIndex => 0;

		private RegionOptions<float> RangeOptions => default(RegionOptions<float>);

		private RegionOptions<int> RepeatingGroupsOptions => default(RegionOptions<int>);

		private bool ShowFitEnd => false;

		private bool IsInputAVolume()
		{
			return false;
		}

		protected override void OnEnable()
		{
		}

		public override void Reset()
		{
		}

		public override void OnStateChange()
		{
		}

		public void Clear()
		{
		}

		public override void Refresh()
		{
		}

		public CGBoundsGroup AddGroup(string name)
		{
			return null;
		}

		public void RemoveGroup(CGBoundsGroup group)
		{
		}

		private static SubArray<int> GetGroupItemIndices(CGBoundsGroup boundsGroup, WeightedRandom<int> groupItemBag)
		{
			return default(SubArray<int>);
		}

		private static float GetGroupDepth(List<CGBounds> bounds, SubArray<int> groupItemIndices, float spaceBefore, float spaceAfter, out CGBounds[] itemsBounds)
		{
			itemsBounds = null;
			return 0f;
		}

		private bool AddGroupItems(List<CGBounds> bounds, CGPath path, int groupIndex, ref SubArrayList<CGSpot> spots, float remainingLength, float startDistance, ref float currentDistance, out bool failedAddingAllItems, Dictionary<CGBoundsGroup, WeightedRandom<int>> itemsBagDictionary, int MaxSpotsCount)
		{
			failedAddingAllItems = default(bool);
			return false;
		}

		private void AddGroupItems(CGPath path, CGBoundsGroup group, ref SubArrayList<CGSpot> spots, float remainingLength, float startDistance, ref float currentDistance, out bool failedAddingAllItems, SubArray<int> itemIndices, float groupDepth, CGBounds[] itemBounds, float spaceBefore, float spaceAfter)
		{
			failedAddingAllItems = default(bool);
		}

		private CGSpot GetSpot(CGPath path, int itemID, CGBoundsGroup boundsGroup, CGBounds bounds, float currentDistance, float startDistance)
		{
			return default(CGSpot);
		}

		private static float GetRegionNextValue(FloatRegion floatRegion)
		{
			return 0f;
		}

		private void GetTRS(CGBoundsGroup boundsGroup, Vector3 tangent, Vector3 up, out Quaternion rotation, out Vector3 translation, out Vector3 scale)
		{
			rotation = default(Quaternion);
			translation = default(Vector3);
			scale = default(Vector3);
		}

		private void GetTRS630(CGBoundsGroup boundsGroup, Vector3 tangent, Vector3 up, out Quaternion rotation, out Vector3 translation, out Vector3 scale)
		{
			rotation = default(Quaternion);
			translation = default(Vector3);
			scale = default(Vector3);
		}

		private Dictionary<CGBoundsGroup, WeightedRandom<int>> Prepare(out WeightedRandom<int> groupBag)
		{
			groupBag = null;
			return null;
		}

		protected override void ResetOnEnable()
		{
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
