using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	public class UMAMountObject : MonoBehaviour
	{
		[Serializable]
		public class mountInfo
		{
			[Tooltip("Prefab of the object that will get mounted.")]
			public GameObject objPrefab;

			[Tooltip("Name of the bone that the object will get mounted to.")]
			public string boneName;

			public Vector3 position;

			public Vector3 rotation;

			public Vector3 scale;
		}

		[Tooltip("A list of the objects that can be dynamically mounted.")]
		public mountInfo[] mountInfos;

		private UMAData _umaData;

		private Dictionary<string, int> nameMap;

		private void OnEnable()
		{
		}

		private bool IsValid()
		{
			return false;
		}

		public void ChangeMountInfo(mountInfo newInfo)
		{
		}

		public void MountObject(string name)
		{
		}

		public void MountObject(int index)
		{
		}

		public void UnMountObject(string name)
		{
		}

		public void UnMountObject(int index)
		{
		}
	}
}
