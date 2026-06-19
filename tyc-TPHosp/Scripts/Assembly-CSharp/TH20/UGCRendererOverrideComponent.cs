using System;
using UnityEngine;

namespace TH20
{
	public class UGCRendererOverrideComponent : MonoBehaviour
	{
		[Serializable]
		public struct OverrideDefinition
		{
			public Renderer Renderer;

			public int MaterialIndex;
		}

		public OverrideDefinition[] OverrideDefinitions = new OverrideDefinition[0];
	}
}
