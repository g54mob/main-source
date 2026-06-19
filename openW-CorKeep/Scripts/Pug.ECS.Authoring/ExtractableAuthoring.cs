using System;
using System.Collections.Generic;
using UnityEngine;

public class ExtractableAuthoring : MonoBehaviour
{
	[Serializable]
	public struct ExtractableOutput
	{
		public ObjectID objectID;

		public int variation;

		public Vector2 minMaxRandomAmountOverride;
	}

	public List<ExtractableOutput> extractedObject = new List<ExtractableOutput>();

	public int craftingTimeOverride;
}
