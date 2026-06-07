using System;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[Serializable]
	public class InternalMaterialLerp
	{
		public Renderer renderer;

		[ExposeScriptableAsset]
		public MaterialLerpSO materials;
	}
}
