using System;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	public class SgtDepthTextureMode : MonoBehaviour
	{
		public DepthTextureMode DepthMode;

		[NonSerialized]
		private Camera cachedCamera;

		public void UpdateDepthMode()
		{
		}

		protected virtual void Update()
		{
		}
	}
}
