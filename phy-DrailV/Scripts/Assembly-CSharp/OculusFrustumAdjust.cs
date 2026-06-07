using System;
using UnityEngine;
using UnityEngine.XR;

[AddComponentMenu("DV/OculusFrustumAdjust")]
public class OculusFrustumAdjust : MonoBehaviour
{
	private Camera m_Camera;

	private Matrix4x4 projectionMatrix;

	private void OnEnable()
	{
		m_Camera = GetComponent<Camera>();
		OVRDisplay.EyeFov fullFov = OVRManager.display.GetEyeRenderDesc(XRNode.LeftEye).fullFov;
		float num = Mathf.Tan((0f - fullFov.LeftFov) * ((float)Math.PI / 180f));
		float num2 = Mathf.Tan(fullFov.RightFov * ((float)Math.PI / 180f));
		float num3 = Mathf.Tan((0f - fullFov.DownFov) * ((float)Math.PI / 180f));
		float num4 = Mathf.Tan(fullFov.UpFov * ((float)Math.PI / 180f));
		Debug.Log(string.Format("{0} projection: {1}, {2}, {3}, {4}", "OculusFrustumAdjust", num, num2, num3, num4));
		float num5 = 0f;
		Vector2 vector = new Vector2(Mathf.Max(0f - num, num2), Mathf.Max(0f - num3, num4));
		float num6 = Mathf.Atan(vector.x);
		float num7 = Mathf.Tan(num5 + num6);
		projectionMatrix.m00 = 1f / num7;
		float num8 = Mathf.Atan(0f - num);
		float num9 = vector.y * Mathf.Cos(num8) / Mathf.Cos(num8 + num5);
		projectionMatrix.m11 = 1f / num9;
		projectionMatrix.m22 = (0f - (m_Camera.farClipPlane + m_Camera.nearClipPlane)) / (m_Camera.farClipPlane - m_Camera.nearClipPlane);
		projectionMatrix.m23 = -2f * m_Camera.farClipPlane * m_Camera.nearClipPlane / (m_Camera.farClipPlane - m_Camera.nearClipPlane);
		projectionMatrix.m32 = -1f;
	}

	private void OnDisable()
	{
		m_Camera.ResetCullingMatrix();
	}

	private void OnPreCull()
	{
		m_Camera.cullingMatrix = projectionMatrix * m_Camera.worldToCameraMatrix;
	}
}
