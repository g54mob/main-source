using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Cinemachine
{
	[SaveDuringPlay]
	[ExecuteAlways]
	[DisallowMultipleComponent]
	public class CinemachineStoryboard : CinemachineExtension
	{
		public enum FillStrategy
		{
			BestFit = 0,
			CropImageToFit = 1,
			StretchToFit = 2
		}

		private class CanvasInfo
		{
			public GameObject mCanvas;

			public CinemachineBrain mCanvasParent;

			public RectTransform mViewport;

			public RawImage mRawImage;
		}

		public static bool s_StoryboardGlobalMute;

		public bool m_ShowImage;

		public Texture m_Image;

		public FillStrategy m_Aspect;

		public float m_Alpha;

		public Vector2 m_Center;

		public Vector3 m_Rotation;

		public Vector2 m_Scale;

		public bool m_SyncScale;

		public bool m_MuteCamera;

		public float m_SplitView;

		private List<CanvasInfo> mCanvasInfo;

		private string CanvasName => null;

		protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
		{
		}

		protected override void ConnectToVcam(bool connect)
		{
		}

		private void CameraUpdatedCallback(CinemachineBrain brain)
		{
		}

		private CanvasInfo LocateMyCanvas(CinemachineBrain parent, bool createIfNotFound)
		{
			return null;
		}

		private void CreateCanvas(CanvasInfo ci)
		{
		}

		private void DestroyCanvas()
		{
		}

		private void PlaceImage(CanvasInfo ci, float alpha)
		{
		}

		private static void StaticBlendingHandler(CinemachineBrain brain)
		{
		}

		[RuntimeInitializeOnLoadMethod]
		private static void InitializeModule()
		{
		}
	}
}
