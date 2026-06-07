using UnityEngine;

namespace UMA
{
	public class UMASavedItem
	{
		public string ParentBoneName;

		public int ParentBoneNameHash;

		public Transform Object;

		public Quaternion rotation;

		public Vector3 position;

		public Vector3 scale;

		public bool replaceExisting;

		public UMASavedItem(string boneName, int hash, Transform obj, bool replaceExisting)
		{
		}
	}
}
