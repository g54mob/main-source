using System;
using FuryStudios.FurySDK;
using UnityEngine;

namespace Placemaker
{
	[Serializable]
	public class MetaSave : MonoBehaviour, IComparable<MetaSave>
	{
		public enum State
		{
			Unclear = 1,
			NeedsUpdating = 2,
			UpToDate = 4,
			NotYetSaved = 8,
			NewFromDuplicate = 16,
			FailedToLoad = 32,
			DidNotExistOnDisk = 64,
			Deleted = 128,
			ReturnedToPool = 256,
			BrokenMask = 480,
			InvisibleMask = 483,
			ShouldBeInPoolMask = 448
		}

		public string path;

		public string fileName;

		public bool isBin;

		public Texture2D texture;

		public long lastFileWriteTime;

		public SaveData saveData;

		public float lastDiskSyncTime;

		public float lastTextureLoadTime;

		public float lastSaveDataTime;

		public bool existsOnDisk;

		public IAsyncRequest<byte[]> loadRequest;

		public IAsyncRequest saveRequest;

		public Action onStateChange;

		public Action<int> onIndexChange;

		public State state;

		public bool isXml => false;

		public bool isSaving => false;

		public bool isLoading => false;

		public bool isBroken => false;

		public bool shouldBeVisible => false;

		public bool shouldBeInPool => false;

		private void SaveThis()
		{
		}

		int IComparable<MetaSave>.CompareTo(MetaSave other)
		{
			return 0;
		}

		public void SetPathAsName()
		{
		}

		public void ResetPooledObject()
		{
		}
	}
}
