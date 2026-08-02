using System;
using UnityEngine;

namespace GPUInstancerPro.PrefabModule
{
	[Serializable]
	public struct GPUIMVDefinitionItem
	{
		public string propertyName;

		public GPUIMaterialVariationType variationType;

		public Vector4 defaultValue;
	}
}
