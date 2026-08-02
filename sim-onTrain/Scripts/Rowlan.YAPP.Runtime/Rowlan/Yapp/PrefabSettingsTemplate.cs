using System;
using UnityEngine;

namespace Rowlan.Yapp
{
	[Serializable]
	[CreateAssetMenu(fileName = "Prefab Settings", menuName = "Yapp/Templates/Prefabs/Settings")]
	public class PrefabSettingsTemplate : ScriptableObject
	{
		public string templateName;

		public bool active = true;

		public float probability = 1f;

		public Vector3 positionOffset;

		public Vector3 rotationOffset;

		public bool randomRotation;

		public float rotationMinX;

		public float rotationMaxX = 360f;

		public float rotationMinY;

		public float rotationMaxY = 360f;

		public float rotationMinZ;

		public float rotationMaxZ = 360f;

		public bool changeScale;

		public float scaleMin = 0.5f;

		public float scaleMax = 1.5f;
	}
}
