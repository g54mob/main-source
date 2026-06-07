using System;
using UnityEngine;

namespace CW.Common
{
	[AddComponentMenu("Common/CW Depth Texture Mode")]
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	[DisallowMultipleComponent]
	[HelpURL("https://carloswilkes.com/Documentation/Common#CwDepthTextureMode")]
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
