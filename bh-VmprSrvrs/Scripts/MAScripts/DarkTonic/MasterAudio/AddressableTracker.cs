using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace DarkTonic.MasterAudio
{
	public class AddressableTracker<T>
	{
		public AsyncOperationHandle<T> AssetHandle { get; private set; }

		public int UnusedSecondsLifespan { get; private set; }

		public List<AudioSource> AudiosSourcesUsingReference { get; }

		public AddressableTracker(AsyncOperationHandle<T> assetHandle, int unusedSecondsLifespan)
		{
		}
	}
}
