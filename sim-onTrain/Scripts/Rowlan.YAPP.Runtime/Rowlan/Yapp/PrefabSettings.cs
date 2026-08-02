using System;
using UnityEngine;

namespace Rowlan.Yapp
{
	[Serializable]
	public class PrefabSettings
	{
		public enum RotationRange
		{
			[InspectorName("0..360")]
			Base_360 = 0,
			[InspectorName("-180..180")]
			Base_180 = 1
		}

		public string templateName;

		[HideInInspector]
		public GameObject prefab;

		public bool active = true;

		public float probability = 1f;

		public Vector3 positionOffset;

		public Vector3 rotationOffset;

		public bool randomRotation;

		public RotationRange rotationRange;

		public float rotationMinX;

		public float rotationMaxX = 360f;

		public float rotationMinY;

		public float rotationMaxY = 360f;

		public float rotationMinZ;

		public float rotationMaxZ = 360f;

		public bool changeScale;

		public float scaleMin = 0.5f;

		public float scaleMax = 1.5f;

		[HideInInspector]
		public string assetGUID;

		[HideInInspector]
		public string vspro_VegetationItemID;

		public Quaternion instanceRotation = Quaternion.identity;

		public float brushOffsetUp;

		public void ApplyTemplate(PrefabSettingsTemplate template)
		{
			active = template.active;
			probability = template.probability;
			positionOffset = template.positionOffset;
			rotationOffset = template.rotationOffset;
			randomRotation = template.randomRotation;
			rotationMinX = template.rotationMinX;
			rotationMaxX = template.rotationMaxX;
			rotationMinY = template.rotationMinY;
			rotationMaxY = template.rotationMaxY;
			rotationMinZ = template.rotationMinZ;
			rotationMaxZ = template.rotationMaxZ;
			changeScale = template.changeScale;
			scaleMin = template.scaleMin;
			scaleMax = template.scaleMax;
			UpdateInstanceData();
		}

		public void Apply(PrefabSettings template)
		{
			active = template.active;
			probability = template.probability;
			positionOffset = template.positionOffset;
			rotationOffset = template.rotationOffset;
			randomRotation = template.randomRotation;
			rotationRange = template.rotationRange;
			rotationMinX = template.rotationMinX;
			rotationMaxX = template.rotationMaxX;
			rotationMinY = template.rotationMinY;
			rotationMaxY = template.rotationMaxY;
			rotationMinZ = template.rotationMinZ;
			rotationMaxZ = template.rotationMaxZ;
			changeScale = template.changeScale;
			scaleMin = template.scaleMin;
			scaleMax = template.scaleMax;
			UpdateInstanceData();
		}

		public PrefabSettings Clone()
		{
			return (PrefabSettings)MemberwiseClone();
		}

		public void UpdateInstanceData()
		{
			float x = UnityEngine.Random.Range(rotationMinX, rotationMaxX);
			float y = UnityEngine.Random.Range(rotationMinY, rotationMaxY);
			float z = UnityEngine.Random.Range(rotationMinZ, rotationMaxZ);
			instanceRotation = Quaternion.Euler(x, y, z);
			brushOffsetUp = 0f;
		}
	}
}
