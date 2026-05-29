using System;
using UnityEngine;

namespace Cinemachine
{
	[Serializable]
	[DocumentationSorting(DocumentationSortingAttribute.Level.UserRef)]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.cinemachine@2.9/manual/CinemachineBlending.html")]
	public sealed class CinemachineBlenderSettings : ScriptableObject
	{
		[Serializable]
		[DocumentationSorting(DocumentationSortingAttribute.Level.UserRef)]
		public struct CustomBlend
		{
			[Tooltip("When blending from this camera")]
			public string m_From;

			[Tooltip("When blending to this camera")]
			public string m_To;

			[CinemachineBlendDefinitionProperty]
			[Tooltip("Blend curve definition")]
			public CinemachineBlendDefinition m_Blend;
		}

		[Tooltip("The array containing explicitly defined blends between two Virtual Cameras")]
		public CustomBlend[] m_CustomBlends;

		public const string kBlendFromAnyCameraLabel = "**ANY CAMERA**";

		public CinemachineBlendDefinition GetBlendForVirtualCameras(string fromCameraName, string toCameraName, CinemachineBlendDefinition defaultBlend)
		{
			return default(CinemachineBlendDefinition);
		}
	}
}
