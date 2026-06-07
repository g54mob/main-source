using System;
using UnityEngine;
using UnityEngine.UI;

public class ImageInspector : MonoBehaviour
{
	public GUIWindow Window;

	public InspectorRenderer RendererPrefab;

	public RawImage Image;

	public AspectRatioFitter Fitter;

	public Material DefaultMat;

	public Mesh SphereMesh;

	public Text Label;

	[NonSerialized]
	private bool _dragging;

	[NonSerialized]
	private Vector3 _lastMousePos;

	[NonSerialized]
	private InspectorRenderer _renderer;

	public void Show(Texture tex, GUIWindow from)
	{
		Image.texture = tex;
		Label.text = tex.width + "x" + tex.height;
		Texture2D texture2D;
		RenderTexture renderTexture;
		if ((object)(texture2D = tex as Texture2D) != null)
		{
			Text label = Label;
			label.text = label.text + " " + texture2D.format;
		}
		else if ((object)(renderTexture = tex as RenderTexture) != null)
		{
			Text label2 = Label;
			label2.text = label2.text + " " + renderTexture.format;
		}
		Fitter.aspectRatio = (float)tex.width / (float)tex.height;
		Window.SetParentWindow(from);
		Window.Show();
	}

	public void Show(Sprite sp, GUIWindow from)
	{
		Image.texture = sp.texture;
		Label.text = sp.textureRect.width + "x" + sp.textureRect.height + " " + sp.texture.format;
		Image.uvRect = sp.GetAtlasRect();
		Fitter.aspectRatio = sp.textureRect.width / sp.textureRect.height;
		Window.SetParentWindow(from);
		Window.Show();
	}

	public void Show(Mesh m, GUIWindow from)
	{
		_renderer = InspectorRenderer.GetInstance(RendererPrefab);
		_renderer.StartRendering(m, DefaultMat);
		Label.text = "Vertices: " + m.vertexCount + " - Triangles: " + m.triangles.Length;
		Fitter.aspectRatio = 1f;
		Window.SetParentWindow(from);
		Window.Show();
	}

	public void Show(Material m, GUIWindow from)
	{
		DefaultMat = m;
		Show(SphereMesh, from);
		Label.text = "Shader: " + m.shader.name;
	}

	public void MoveStart()
	{
		_dragging = true;
		_lastMousePos = Input.mousePosition;
	}

	private void Update()
	{
		if (_renderer != null && _dragging)
		{
			Vector3 vector = Input.mousePosition - _lastMousePos;
			_lastMousePos = Input.mousePosition;
			_renderer.Pivot.rotation = Quaternion.Euler(vector.y, 0f - vector.x, 0f) * _renderer.Pivot.rotation;
			if (!Input.GetMouseButton(0))
			{
				_dragging = false;
			}
		}
	}

	private void OnDestroy()
	{
		if (_renderer != null)
		{
			_renderer.StopRendering();
		}
	}
}
