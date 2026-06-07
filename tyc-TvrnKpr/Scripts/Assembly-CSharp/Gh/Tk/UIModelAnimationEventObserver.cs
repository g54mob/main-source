using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class UIModelAnimationEventObserver : BasicAnimationEventObserver
	{
		public List<GameObject> SpawnedItems;

		public void RemoveItem(AnimationEvent value)
		{
		}

		public void SpawnItem(AnimationEvent value)
		{
		}

		public void EnableOnSpawnedItems(string transformName)
		{
		}

		public void DisableOnSpawnedItems(string transformName)
		{
		}

		public void SetBoolOnSpawnedItems(string values)
		{
		}
	}
}
