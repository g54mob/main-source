using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class CustomSceneAddInitialItemsAuthoring : MonoBehaviour
{
	[Serializable]
	public struct InitialInventoryItem
	{
		public OptionalValue<DataBlockRef<ContentBundleDataBlock>> requiredContentBundle;

		public ObjectData item;
	}

	public List<InitialInventoryItem> items;
}
