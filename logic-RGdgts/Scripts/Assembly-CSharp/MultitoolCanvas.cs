using UnityEngine;
using UnityEngine.UI;

public class MultitoolCanvas : MonoBehaviour
{
	public enum ShaderMode
	{
		Standard = 0,
		Boost = 1
	}

	public Material renderMaterial;

	public bool noCursor;

	private Sprite cursorSprite;

	private int _resolutionMul;

	private Canvas canvas;

	private Canvas canvasRenderer;

	private CanvasScaler canvasScaler;

	private CanvasScaler canvasRendererScaler;

	private RectTransform rTransform;

	private Camera canvasCamera;

	private RawImage rawImage;

	private BoxCollider2D collider;

	private RenderTexture rt;

	private Vector2 worldCanvasSize;

	private bool init;

	public int resolutionMul
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	private void Start()
	{
	}

	private void Refresh()
	{
	}

	private void OnDestroy()
	{
	}

	public void SetShaderMode(ShaderMode shaderMode)
	{
	}

	private void Update()
	{
	}

	public void SetDefaultCursor()
	{
	}

	public void SetCursor(Sprite cursorSprite)
	{
	}
}
