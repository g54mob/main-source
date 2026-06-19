using UnityEngine;
using UnityEngine.Rendering;

namespace Pug.RP
{
	public class PlanarReflectionsRenderFeature : RenderFeature
	{
		private static GlobalKeyword s_planarReflectionsKeyword = GlobalKeyword.Create("RENDER_PLANAR_REFLECTIONS");

		private static string s_screenTextureName = "Planar Reflection";

		private RenderTexture m_screenTexture;

		private GBufferData m_gbuffer;

		private Camera m_internalCamera;

		private Vector4 m_plane;

		public override bool usesCulling => true;

		public override string sampleName => "Planar Reflections";

		public override RenderPipelineStage executionStage => RenderPipelineStage.BeforeGeometry;

		public PlanarReflectionsRenderFeature()
		{
			m_gbuffer = new GBufferData();
		}

		public override void ValidateFrame(PugRPContext context)
		{
			base.isValid = context.camera != null && context.pugCamera != null && context.pugCamera.reflections == ReflectionsType.Planar && context.pugCamera.reflectionsPlanarAnchor != null && context.pugCamera.enableDeferredPass;
		}

		public override void OnBeginValidFrame(PugRPContext context)
		{
			if (m_internalCamera == null)
			{
				m_internalCamera = PugRPUtils.GetUtilityCamera("_PLANAR_REFLECTIONS_CAMERA");
			}
			m_gbuffer.Setup(context.pixelWidth, context.pixelHeight);
			PugRPUtils.Setup(desc: new RenderTextureDescriptor(context.pixelWidth, context.pixelHeight, PugRPUtils.floatNoAlphaFormat, PugRPUtils.depthBits), rt: ref m_screenTexture, name: s_screenTextureName);
		}

		public override void Cull(PugRPContext context)
		{
			ConfigureCamera(context);
			Cull(context, m_internalCamera);
		}

		public override void Execute(PugRPContext context, CommandBuffer cmd)
		{
			if (GetCullingResults(out var cullingResults))
			{
				PugRP.SetupCameraProperties(context, cmd, m_internalCamera, forceSkew: true);
				cmd.SetInvertCulling(invertCulling: true);
				cmd.SetKeyword(in s_planarReflectionsKeyword, value: true);
				m_gbuffer.Draw(context.srp, cmd, m_internalCamera, cullingResults, GBufferData.DrawType.Reflection);
				Color cameraClearColor = PugRP.GetCameraClearColor(context.camera);
				cmd.SetRenderTarget(m_screenTexture);
				cmd.ClearRenderTarget(clearDepth: true, clearColor: true, cameraClearColor);
				PugRP.DrawDeferredLight(cmd);
				PugRP.DrawForwardOpaque(context, cmd, m_internalCamera, cullingResults);
				PugRP.PostProcessOpaque(context, cmd, m_screenTexture, m_gbuffer.depth, m_screenTexture.descriptor);
				PugRP.DrawForwardTransparent(context, cmd, m_internalCamera, cullingResults);
				cmd.SetKeyword(in s_planarReflectionsKeyword, value: false);
				cmd.SetInvertCulling(invertCulling: false);
				cmd.SetGlobalTexture(ShaderIDs.PlanarReflection, m_screenTexture);
				cmd.SetGlobalVector(ShaderIDs.PlanarReflectionPlane, m_plane);
			}
		}

		public override void ExecuteDisabled(PugRPContext context, CommandBuffer cmd)
		{
			cmd.SetGlobalTexture(ShaderIDs.PlanarReflection, Texture2D.blackTexture);
		}

		protected override void DisposeInternal()
		{
			m_gbuffer.Dispose();
			PugRPUtils.Release(ref m_screenTexture);
		}

		private void ConfigureCamera(PugRPContext context)
		{
			Vector3 position = context.pugCamera.reflectionsPlanarAnchor.position;
			Vector3 forward = context.pugCamera.reflectionsPlanarAnchor.forward;
			m_internalCamera.CopyFrom(context.camera);
			m_internalCamera.targetTexture = null;
			float w = 0f - Vector3.Dot(forward, position);
			m_plane = new Vector4(forward.x, forward.y, forward.z, w);
			Vector4 plane = m_plane;
			plane.w -= context.pugCamera.reflectionsPlanarOffset;
			Matrix4x4 reflectionMat = Matrix4x4.identity;
			reflectionMat *= Matrix4x4.Scale(new Vector3(1f, -1f, 1f));
			CalculateReflectionMatrix(ref reflectionMat, plane);
			Vector3 position2 = ReflectPosition(context.camera.transform.position - new Vector3(0f, position.y * 2f, 0f));
			m_internalCamera.transform.forward = Vector3.Scale(context.camera.transform.forward, new Vector3(1f, -1f, 1f));
			m_internalCamera.worldToCameraMatrix = context.camera.worldToCameraMatrix * reflectionMat;
			Vector4 clipPlane = CameraSpacePlane(m_internalCamera, position - Vector3.up * 0.1f, forward, 1f, context.pugCamera.reflectionsPlanarOffset);
			Matrix4x4 projectionMatrix = context.camera.CalculateObliqueMatrix(clipPlane);
			m_internalCamera.projectionMatrix = projectionMatrix;
			m_internalCamera.cullingMask = context.pugCamera.reflectionsLayers;
			m_internalCamera.transform.position = position2;
		}

		private static void CalculateReflectionMatrix(ref Matrix4x4 reflectionMat, Vector4 plane)
		{
			reflectionMat.m00 = 1f - 2f * plane[0] * plane[0];
			reflectionMat.m01 = -2f * plane[0] * plane[1];
			reflectionMat.m02 = -2f * plane[0] * plane[2];
			reflectionMat.m03 = -2f * plane[3] * plane[0];
			reflectionMat.m10 = -2f * plane[1] * plane[0];
			reflectionMat.m11 = 1f - 2f * plane[1] * plane[1];
			reflectionMat.m12 = -2f * plane[1] * plane[2];
			reflectionMat.m13 = -2f * plane[3] * plane[1];
			reflectionMat.m20 = -2f * plane[2] * plane[0];
			reflectionMat.m21 = -2f * plane[2] * plane[1];
			reflectionMat.m22 = 1f - 2f * plane[2] * plane[2];
			reflectionMat.m23 = -2f * plane[3] * plane[2];
			reflectionMat.m30 = 0f;
			reflectionMat.m31 = 0f;
			reflectionMat.m32 = 0f;
			reflectionMat.m33 = 1f;
		}

		private static Vector3 ReflectPosition(Vector3 pos)
		{
			return new Vector3(pos.x, 0f - pos.y, pos.z);
		}

		private Vector4 CameraSpacePlane(Camera cam, Vector3 pos, Vector3 normal, float sideSign, float clipPlaneOffset)
		{
			Vector3 point = pos + normal * clipPlaneOffset;
			Matrix4x4 worldToCameraMatrix = cam.worldToCameraMatrix;
			Vector3 lhs = worldToCameraMatrix.MultiplyPoint(point);
			Vector3 rhs = worldToCameraMatrix.MultiplyVector(normal).normalized * sideSign;
			return new Vector4(rhs.x, rhs.y, rhs.z, 0f - Vector3.Dot(lhs, rhs));
		}
	}
}
