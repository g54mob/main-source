using System.Collections.Generic;
using UnityEngine;

public class RenderTargetManager : MonoBehaviour
{
	public static RenderTargetManager Instance;

	private Dictionary<string, RenderTarget> _targetList = new Dictionary<string, RenderTarget>();

	private Camera _mainCamera;

	private int _oldWidth;

	private int _oldHeight;

	private void Awake()
	{
		Instance = this;
		Instance._mainCamera = Instance.transform.GetComponent<Camera>();
	}

	private void Initialize()
	{
		_oldWidth = Screen.width;
		_oldHeight = Screen.height;
	}

	private void Update()
	{
		foreach (KeyValuePair<string, RenderTarget> target in _targetList)
		{
			target.Value.Update();
		}
		if (_oldWidth != Screen.width || _oldHeight != Screen.height)
		{
			foreach (KeyValuePair<string, RenderTarget> target2 in _targetList)
			{
				target2.Value.ReSize();
			}
		}
		_oldWidth = Screen.width;
		_oldHeight = Screen.height;
	}

	public static RenderTarget AllocateRenderTarget(string name, int renderedLayers = -1, bool orthographicCamera = false, int depth = 0, RenderTargetDownSample downSampled = RenderTargetDownSample.FULL)
	{
		if (!Instance._targetList.ContainsKey(name))
		{
			if (Instance._mainCamera == null)
			{
				Instance._mainCamera = Instance.transform.GetComponent<Camera>();
			}
			RenderTarget value = new RenderTarget(name, downSampled, renderedLayers, orthographicCamera, depth, Instance._mainCamera);
			Instance._targetList.Add(name, value);
		}
		return Instance._targetList[name];
	}

	public static RenderTarget GetRenderTarget(string name)
	{
		if (Instance._targetList.ContainsKey(name))
		{
			return Instance._targetList[name];
		}
		return null;
	}

	public static void SetSampling(string name, RenderTargetDownSample downSampled)
	{
		Instance._targetList[name].DownSampled = downSampled;
	}
}
