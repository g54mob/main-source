using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Map;
using UnityEngine;

namespace NSMedieval.Construction
{
	public class SiegeWeaponPreview : MonoBehaviour
	{
		[SerializeField]
		private BaseBuildablePreview baseBuildablePreview;

		[Space]
		[SerializeField]
		private GameObject minRangeTopXYZ;

		[SerializeField]
		private GameObject minRangeBottomXZ;

		[Space]
		[SerializeField]
		private GameObject maxRangeTopXYZ;

		[SerializeField]
		private GameObject maxRangeBottomXZ;

		[Space]
		[SerializeField]
		private GameObject minRangePrefab;

		[SerializeField]
		private GameObject maxRangePrefab;

		[Space]
		[SerializeField]
		private Transform minRangeParent;

		[SerializeField]
		private Transform maxRangeParent;

		[Space]
		[SerializeField]
		private List<GameObject> maxRanges;

		[SerializeField]
		private List<GameObject> minRanges;

		[NonSerialized]
		private SiegeWeaponComponentBlueprint blueprint;

		private void Awake()
		{
			if (baseBuildablePreview == null)
			{
				baseBuildablePreview = GetComponent<BaseBuildablePreview>();
			}
			baseBuildablePreview.InitializeEvent += OnInitialize;
		}

		private void OnDestroy()
		{
			if (baseBuildablePreview != null)
			{
				baseBuildablePreview.InitializeEvent -= OnInitialize;
			}
			foreach (GameObject maxRange in maxRanges)
			{
				UnityEngine.Object.Destroy(maxRange);
			}
			foreach (GameObject minRange in minRanges)
			{
				UnityEngine.Object.Destroy(minRange);
			}
			maxRanges.Clear();
			maxRanges = null;
			minRanges.Clear();
			minRanges = null;
		}

		private void OnInitialize(BaseBuildingBlueprint baseBuildingBlueprint)
		{
			if (string.IsNullOrEmpty(baseBuildingBlueprint?.SiegeWeaponComponentID))
			{
				return;
			}
			blueprint = Repository<SiegeWeaponComponentRepository, SiegeWeaponComponentBlueprint>.Instance.GetByID(baseBuildingBlueprint.SiegeWeaponComponentID);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(34, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Views\\SiegeWeaponPreview.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Couldn't find component blueprint ");
					messageBuilder.AppendFormatted(baseBuildingBlueprint.SiegeWeaponComponentID);
				}
				Log.Warning(messageBuilder);
			}
			else
			{
				InitializeRangeSpheres();
			}
		}

		private void InitializeRangeSpheres()
		{
			int count = blueprint.RangePerLayer.Dictionary.Count;
			for (int i = 0; i < count - 1; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(maxRangePrefab, maxRangeParent);
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localPosition = new Vector3(maxRangeParent.localPosition.x, maxRangeParent.localPosition.y - (float)(World.MapBlockHeight * (i + 1)), maxRangeParent.localPosition.z);
				maxRanges.Add(gameObject);
				gameObject.name = ((i < 10) ? $"Max_range_middle_0{i}" : $"Max_range_middle_{i}");
				GameObject gameObject2 = UnityEngine.Object.Instantiate(minRangePrefab, minRangeParent);
				gameObject2.transform.localScale = Vector3.one;
				gameObject2.transform.localPosition = new Vector3(minRangeParent.localPosition.x, minRangeParent.localPosition.y - (float)(World.MapBlockHeight * (i + 1)), minRangeParent.localPosition.z);
				minRanges.Add(gameObject2);
				gameObject2.name = ((i < 10) ? $"Min_range_middle_0{i}" : $"Min_range_middle_{i}");
			}
			minRangeBottomXZ.transform.localPosition = new Vector3(minRangeParent.localPosition.x, minRangeParent.localPosition.y - (float)(World.MapBlockHeight * count), minRangeParent.localPosition.z);
			maxRangeBottomXZ.transform.localPosition = new Vector3(maxRangeParent.localPosition.x, maxRangeParent.localPosition.y - (float)(World.MapBlockHeight * count), maxRangeParent.localPosition.z);
			KeyValuePair<float[], float[]> minMaxRanges = SiegeWeaponUtil.GetMinMaxRanges(blueprint);
			float[] key = minMaxRanges.Key;
			float[] value = minMaxRanges.Value;
			maxRangeTopXYZ.transform.localScale = Vector3.one * (blueprint.MaxRangeRadius * 2f);
			maxRangeBottomXZ.transform.localScale = new Vector3(value.Last() * 2f, maxRangeBottomXZ.transform.localScale.y, value.Last() * 2f);
			for (int j = 0; j < maxRanges.Count; j++)
			{
				maxRanges[j].transform.localScale = new Vector3(value[j] * 2f, maxRanges[j].transform.localScale.y, value[j] * 2f);
			}
			minRangeTopXYZ.transform.localScale = Vector3.one * (blueprint.MinRangeRadius * 2f);
			minRangeBottomXZ.transform.localScale = new Vector3(key.Last() * 2f, minRangeBottomXZ.transform.localScale.y, key.Last() * 2f);
			for (int k = 0; k < minRanges.Count; k++)
			{
				minRanges[k].transform.localScale = new Vector3(key[k] * 2f, minRanges[k].transform.localScale.y, key[k] * 2f);
			}
		}
	}
}
