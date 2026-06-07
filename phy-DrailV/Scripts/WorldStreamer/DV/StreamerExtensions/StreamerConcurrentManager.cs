using System;
using UnityEngine;

namespace DV.StreamerExtensions
{
	public class StreamerConcurrentManager : MonoBehaviour
	{
		public int maxParallelSceneLoading;

		[NonSerialized]
		public int currentlySceneLoadingAll;
	}
}
