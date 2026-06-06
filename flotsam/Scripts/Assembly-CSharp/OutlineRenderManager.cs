using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class OutlineRenderManager : MonoBehaviour
{
	private static OutlineRenderManager _instance;

	public static bool ApplicationQuitting;

	protected List<Renderer> _outlineRenderers = new List<Renderer>();

	protected List<OutlineRenderController> _outlineRendereControllers = new List<OutlineRenderController>();

	private const string cString_OutlineColor = "_Color";

	public static OutlineRenderManager Instance
	{
		get
		{
			if (_instance == null && !ApplicationQuitting)
			{
				_instance = Object.FindAnyObjectByType<OutlineRenderManager>();
				if (_instance == null)
				{
					_instance = new GameObject
					{
						name = "_OUTLINERENDERMANAGER",
						hideFlags = HideFlags.NotEditable
					}.AddComponent<OutlineRenderManager>();
					Debug.Log("=====OutlineRenderManager Created=====");
				}
			}
			return _instance;
		}
	}

	public static OutlineRenderManager CreateInstance()
	{
		return Instance;
	}

	public void OnApplicationQuit()
	{
		ApplicationQuitting = true;
	}

	private void Awake()
	{
		Object.DontDestroyOnLoad(base.gameObject);
		if (_instance == null)
		{
			_instance = this;
		}
		else if (_instance != this)
		{
			Object.Destroy(base.gameObject);
		}
	}

	public void RegisterOutlineRenderer(Renderer newRenderer)
	{
		_outlineRenderers.Add(newRenderer);
	}

	public void UnregisterOutlineRenderer(Renderer newRenderer)
	{
		_outlineRenderers.Remove(newRenderer);
	}

	public void RegisterOutlineRenderController(OutlineRenderController outlineRenderController)
	{
		_outlineRendereControllers.AddUnique(outlineRenderController);
	}

	public void UnregisterOutlineRenderController(OutlineRenderController outlineRenderController)
	{
		_outlineRendereControllers.Remove(outlineRenderController);
	}

	public void FillBuffer(OutlinePass outlinePass, bool isHighlight, RasterCommandBuffer targetCommandBuffer)
	{
		int count = _outlineRenderers.Count;
		if (!isHighlight && (bool)outlinePass.NoHighlightMaterial)
		{
			for (int i = 0; i < count; i++)
			{
				Renderer renderer = _outlineRenderers[i];
				if (renderer.isVisible)
				{
					targetCommandBuffer.DrawRenderer(renderer, outlinePass.NoHighlightMaterial);
				}
			}
		}
		foreach (OutlineRenderController outlineRendereController in _outlineRendereControllers)
		{
			outlineRendereController.FillBuffer(outlinePass, isHighlight, targetCommandBuffer);
		}
	}
}
