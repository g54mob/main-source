using System;
using UnityEngine;

namespace Cinemachine
{
	[Serializable]
	public sealed class CinemachineBlenderSettings : ScriptableObject
	{
		[Serializable]
		public struct CustomBlend
		{
			public string m_From;

			public string m_To;

			[CinemachineBlendDefinitionProperty]
			public CinemachineBlendDefinition m_Blend;
		}

		public CustomBlend[] m_CustomBlends;

		public const string kBlendFromAnyCameraLabel = "**ANY CAMERA**";

		public CinemachineBlendDefinition GetBlendForVirtualCameras(string fromCameraName, string toCameraName, CinemachineBlendDefinition defaultBlend)
		{
			return default(CinemachineBlendDefinition);
		}
	}
}
