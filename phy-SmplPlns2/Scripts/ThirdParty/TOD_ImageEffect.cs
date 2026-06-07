using System;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public abstract class TOD_ImageEffect : MonoBehaviour
{
	public TOD_Sky sky;

	protected Camera cam;

	protected Material CreateMaterial(Shader shader)
	{
		if (!shader)
		{
			Debug.Log("Missing shader in " + ToString());
			base.enabled = false;
			return null;
		}
		if (!shader.isSupported)
		{
			Debug.LogError("The shader " + shader.ToString() + " on effect " + ToString() + " is not supported on this platform!");
			base.enabled = false;
			return null;
		}
		return new Material(shader)
		{
			hideFlags = HideFlags.DontSave
		};
	}

	protected void Awake()
	{
		if (!cam)
		{
			cam = GetComponent<Camera>();
		}
		if (!sky)
		{
			sky = UnityEngine.Object.FindFirstObjectByType(typeof(TOD_Sky)) as TOD_Sky;
		}
	}

	protected bool CheckSupport(bool needDepth = false, bool needHdr = false)
	{
		if (!cam)
		{
			return false;
		}
		if (!sky || !sky.Initialized)
		{
			return false;
		}
		if (needDepth && !SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.Depth))
		{
			Debug.LogWarning("The image effect " + ToString() + " has been disabled as it requires a depth texture.");
			base.enabled = false;
			return false;
		}
		if (needHdr && !SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGBHalf))
		{
			Debug.LogWarning("The image effect " + ToString() + " has been disabled as it requires HDR.");
			base.enabled = false;
			return false;
		}
		if (needDepth)
		{
			cam.depthTextureMode |= DepthTextureMode.Depth;
		}
		if (needHdr)
		{
			cam.allowHDR = true;
		}
		return true;
	}

	protected void DrawBorder(RenderTexture dest, Material material)
	{
		RenderTexture.active = dest;
		bool flag = true;
		GL.PushMatrix();
		GL.LoadOrtho();
		for (int i = 0; i < material.passCount; i++)
		{
			material.SetPass(i);
			float y;
			float y2;
			if (flag)
			{
				y = 1f;
				y2 = 0f;
			}
			else
			{
				y = 0f;
				y2 = 1f;
			}
			float x = 0f + 1f / ((float)dest.width * 1f);
			float y3 = 0f;
			float y4 = 1f;
			GL.Begin(7);
			GL.TexCoord2(0f, y);
			GL.Vertex3(0f, y3, 0.1f);
			GL.TexCoord2(1f, y);
			GL.Vertex3(x, y3, 0.1f);
			GL.TexCoord2(1f, y2);
			GL.Vertex3(x, y4, 0.1f);
			GL.TexCoord2(0f, y2);
			GL.Vertex3(0f, y4, 0.1f);
			float x2 = 1f - 1f / ((float)dest.width * 1f);
			x = 1f;
			y3 = 0f;
			y4 = 1f;
			GL.TexCoord2(0f, y);
			GL.Vertex3(x2, y3, 0.1f);
			GL.TexCoord2(1f, y);
			GL.Vertex3(x, y3, 0.1f);
			GL.TexCoord2(1f, y2);
			GL.Vertex3(x, y4, 0.1f);
			GL.TexCoord2(0f, y2);
			GL.Vertex3(x2, y4, 0.1f);
			x = 1f;
			y3 = 0f;
			y4 = 0f + 1f / ((float)dest.height * 1f);
			GL.TexCoord2(0f, y);
			GL.Vertex3(0f, y3, 0.1f);
			GL.TexCoord2(1f, y);
			GL.Vertex3(x, y3, 0.1f);
			GL.TexCoord2(1f, y2);
			GL.Vertex3(x, y4, 0.1f);
			GL.TexCoord2(0f, y2);
			GL.Vertex3(0f, y4, 0.1f);
			x = 1f;
			y3 = 1f - 1f / ((float)dest.height * 1f);
			y4 = 1f;
			GL.TexCoord2(0f, y);
			GL.Vertex3(0f, y3, 0.1f);
			GL.TexCoord2(1f, y);
			GL.Vertex3(x, y3, 0.1f);
			GL.TexCoord2(1f, y2);
			GL.Vertex3(x, y4, 0.1f);
			GL.TexCoord2(0f, y2);
			GL.Vertex3(0f, y4, 0.1f);
			GL.End();
		}
		GL.PopMatrix();
	}

	protected void CustomBlit(RenderTexture source, RenderTexture dest, Material fxMaterial, int passNr = 0)
	{
		RenderTexture.active = dest;
		fxMaterial.SetTexture("_MainTex", source);
		GL.PushMatrix();
		GL.LoadOrtho();
		fxMaterial.SetPass(passNr);
		GL.Begin(7);
		GL.MultiTexCoord2(0, 0f, 0f);
		GL.Vertex3(0f, 0f, 3f);
		GL.MultiTexCoord2(0, 1f, 0f);
		GL.Vertex3(1f, 0f, 2f);
		GL.MultiTexCoord2(0, 1f, 1f);
		GL.Vertex3(1f, 1f, 1f);
		GL.MultiTexCoord2(0, 0f, 1f);
		GL.Vertex3(0f, 1f, 0f);
		GL.End();
		GL.PopMatrix();
	}

	protected Matrix4x4 FrustumCorners()
	{
		float nearClipPlane = cam.nearClipPlane;
		float farClipPlane = cam.farClipPlane;
		float fieldOfView = cam.fieldOfView;
		float aspect = cam.aspect;
		Vector3 forward = cam.transform.forward;
		Vector3 right = cam.transform.right;
		Vector3 up = cam.transform.up;
		Matrix4x4 identity = Matrix4x4.identity;
		float num = fieldOfView * 0.5f;
		Vector3 vector = right * nearClipPlane * Mathf.Tan(num * (MathF.PI / 180f)) * aspect;
		Vector3 vector2 = up * nearClipPlane * Mathf.Tan(num * (MathF.PI / 180f));
		Vector3 vector3 = forward * nearClipPlane - vector + vector2;
		float num2 = vector3.magnitude * farClipPlane / nearClipPlane;
		vector3.Normalize();
		vector3 *= num2;
		Vector3 vector4 = forward * nearClipPlane + vector + vector2;
		vector4.Normalize();
		vector4 *= num2;
		Vector3 vector5 = forward * nearClipPlane + vector - vector2;
		vector5.Normalize();
		vector5 *= num2;
		Vector3 vector6 = forward * nearClipPlane - vector - vector2;
		vector6.Normalize();
		vector6 *= num2;
		identity.SetRow(0, vector3);
		identity.SetRow(1, vector4);
		identity.SetRow(2, vector5);
		identity.SetRow(3, vector6);
		return identity;
	}
}
