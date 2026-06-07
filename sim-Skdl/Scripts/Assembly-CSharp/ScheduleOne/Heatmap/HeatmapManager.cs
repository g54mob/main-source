using System;
using System.Collections.Generic;
using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using ScheduleOne.Property;
using ScheduleOne.Temperature;
using UnityEngine;

namespace ScheduleOne.Heatmap
{
	public class HeatmapManager : Singleton<HeatmapManager>
	{
		[Serializable]
		public class PropertyData
		{
			public int[] MaskData;

			public Matrix4x4[] Matrices;

			public List<HeatmapRegion> Regions;

			public ScheduleOne.Property.Property Property;

			public bool InitialDispatched;
		}

		private struct PropertyRegionReference
		{
			public string PropertyCode;

			public int RegionAmount;
		}

		public Action<ScheduleOne.Property.Property, bool> onHeatmapVisibilityChanged;

		[SerializeField]
		[Header("Components")]
		private ComputeShader _shader;

		[SerializeField]
		private RenderTexture _heatmaps;

		[SerializeField]
		private HeatmapRegion _heatmapRegionPrefab;

		[SerializeField]
		private Material _heatmapMat;

		[Header("Settings")]
		[SerializeField]
		private Texture2D _gradientTexture;

		[Header("Debugging & Testing")]
		[SerializeField]
		private string _propertyCodeToTest;

		private Dictionary<string, PropertyData> _propertyGridMasks;

		private List<PropertyRegionReference> _propertyRegionReferences;

		private int _kernal;

		private int _textureDepth;

		public const int TEXTURE_SIZE = 128;

		public const int MAX_REGIONS = 16;

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		private void Initialise()
		{
		}

		private void SetShader()
		{
		}

		private void SetPropertyData()
		{
		}

		private void OnEmitterUpdate(string propertyCode, TemperatureEmitterInfo[] emitterInfos)
		{
		}

		private void DispatchHeatmap(string propertyCode, TemperatureEmitterInfo[] emitterInfos)
		{
		}

		private Vector2Int GetPropertyRegionStartAndEndIndex(string propertyCode)
		{
			return default(Vector2Int);
		}

		public void SetHeatmapActive(string propertyCode, bool isActive)
		{
		}

		public void SetHeatmapActive(ScheduleOne.Property.Property property, bool isActive)
		{
		}

		public void ToggleHeatmapActive(ScheduleOne.Property.Property property)
		{
		}

		public void SetAllHeatmapsActive(bool isActive)
		{
		}

		public bool IsHeatmapActive(ScheduleOne.Property.Property property)
		{
			return false;
		}

		protected override void OnDestroy()
		{
		}

		[Button]
		public void TurnOnAllHeatmaps()
		{
		}

		[Button]
		public void TurnOffAllHeatmaps()
		{
		}

		[Button]
		public void RunDispatchHeatmap()
		{
		}
	}
}
