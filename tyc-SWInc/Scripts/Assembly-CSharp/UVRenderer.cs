using UnityEngine;
using UnityEngine.UI;

public class UVRenderer : MonoBehaviour
{
	private RenderTexture _tex;

	public Material Mat;

	public int Size = 512;

	public RawImage BaseImage;

	private bool _initialized;

	public void SetMesh(Mesh m)
	{
		RenderUV(m);
	}

	public void SetAtlasParams(Vector2 atlasOffset, int atlasCount)
	{
		int childCount = base.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			Object.Destroy(base.transform.GetChild(i).gameObject);
		}
		for (int j = 0; j < atlasCount; j++)
		{
			GameObject obj = new GameObject("UV" + j);
			RawImage rawImage = obj.AddComponent<RawImage>();
			rawImage.texture = _tex;
			rawImage.uvRect = new Rect(new Vector2(0f - atlasOffset.x, atlasOffset.y) * j, Vector2.one);
			rawImage.color = Utilities.HSVToRGB((float)j / ((float)atlasCount + 1f) * 360f, 1f, 1f).ToVector4(1f);
			obj.transform.SetParent(base.transform, false);
			RectTransform component = obj.GetComponent<RectTransform>();
			component.anchorMin = new Vector2(0f, 0f);
			component.anchorMax = new Vector2(1f, 1f);
			component.offsetMin = Vector2.zero;
			component.offsetMax = Vector2.zero;
		}
	}

	private void Start()
	{
		Initialize();
	}

	private void Initialize()
	{
		if (!_initialized)
		{
			_tex = new RenderTexture(Size, Size, 0);
			_tex.wrapMode = TextureWrapMode.Repeat;
			_initialized = true;
		}
	}

	private void OnDestroy()
	{
		if (_initialized)
		{
			Object.Destroy(_tex);
		}
	}

	private void RenderUV(Mesh m)
	{
		Initialize();
		Vector2[] uv = m.uv;
		int[] triangles = m.triangles;
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = _tex;
		Mat.SetPass(0);
		GL.Clear(false, true, Color.clear);
		GL.Begin(1);
		GL.Color(Color.white);
		GL.PushMatrix();
		GL.LoadPixelMatrix(0f, 1f, 0f, 1f);
		for (int i = 0; i < triangles.Length; i += 3)
		{
			Vector2 vector = uv[triangles[i]];
			Vector2 vector2 = uv[triangles[i + 1]];
			Vector2 vector3 = uv[triangles[i + 2]];
			GL.Vertex(vector);
			GL.Vertex(vector2);
			GL.Vertex(vector2);
			GL.Vertex(vector3);
			GL.Vertex(vector3);
			GL.Vertex(vector);
		}
		GL.End();
		GL.PopMatrix();
		RenderTexture.active = active;
	}
}
