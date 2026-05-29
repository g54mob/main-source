using System;
using UnityEngine;

namespace CW.Common
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Camera))]
	[HelpURL("https://carloswilkes.com/Documentation/Common#CwDepthTextureMode")]
	[AddComponentMenu("Common/CW Depth Texture Mode")]
	public class CwDepthTextureMode : MonoBehaviour
	{
		[SerializeField]
		private DepthTextureMode depthMode;

		[NonSerialized]
		private Camera cachedCamera;

		public DepthTextureMode DepthMode
		{
			get
			{
				return default(DepthTextureMode);
			}
			set
			{
			}
		}

		public void UpdateDepthMode()
		{
		}

		protected virtual void Update()
		{
		}
	}
}
