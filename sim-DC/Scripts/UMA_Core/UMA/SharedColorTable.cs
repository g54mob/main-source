using System;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class SharedColorTable : ScriptableObject, ISerializationCallbackReceiver
	{
		public int channelCount;

		public string sharedColorName;

		[NonReorderable]
		public OverlayColorData[] colors;

		public void OnAfterDeserialize()
		{
		}

		public void OnBeforeSerialize()
		{
		}
	}
}
