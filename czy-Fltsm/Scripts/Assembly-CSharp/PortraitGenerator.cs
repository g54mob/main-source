using System.Collections;
using System.Collections.Generic;
using PajamaLlama.Debugs;
using UnityEngine;

public class PortraitGenerator : MonoBehaviour
{
	[Header("Dynamic")]
	[SerializeField]
	private Camera _dynamicPortraitCamera;

	[SerializeField]
	private PortraitDrifter _dynamicPortraitDrifter;

	[Tooltip("The render texture to where the camera renders the portraits.")]
	[SerializeField]
	private RenderTexture _dynamicPortraitRenderTexture;

	[Header("Static")]
	[SerializeField]
	private Camera _staticPortraitCamera;

	[SerializeField]
	private PortraitDrifter _staticPortraitDrifter;

	[Tooltip("The render texture to where the camera renders the portraits.")]
	[SerializeField]
	private RenderTexture _staticPortraitRenderTexture;

	private static PortraitGenerator _instance;

	private static readonly Queue<AgentDescriptor> _portraitGenerationQueue = new Queue<AgentDescriptor>();

	private readonly Dictionary<AgentDescriptor, Texture2D> _portraits = new Dictionary<AgentDescriptor, Texture2D>();

	private void Awake()
	{
		if (_instance == null || _instance == this)
		{
			_instance = this;
			_dynamicPortraitCamera.enabled = false;
			_staticPortraitCamera.enabled = false;
		}
		else
		{
			Debug.LogError("Multiple PortraitManager instances detected in scene!");
			Object.Destroy(base.gameObject);
		}
	}

	private void OnDisable()
	{
		_dynamicPortraitRenderTexture.Release();
		_staticPortraitRenderTexture.Release();
	}

	private void OnDestroy()
	{
		_portraits.Clear();
		_portraitGenerationQueue.Clear();
	}

	private void Update()
	{
		if (_portraitGenerationQueue.Count > 0 && Time.frameCount > 1 && _portraitGenerationQueue.TryDequeue(out var result))
		{
			StartCoroutine(GenerateStaticPortraitCoroutine(result));
		}
	}

	public static void EnableDynamicPortraitDrifter(AgentDescriptor descriptor, Activity activity = Activity.DynamicPortrait)
	{
		if ((bool)_instance)
		{
			_instance._dynamicPortraitCamera.enabled = true;
			_instance._dynamicPortraitDrifter.Enable(descriptor, DrifterLookCamera.DynamicPortrait, activity);
		}
	}

	public static bool DisableDynamicPortraitDrifter(AgentDescriptor descriptor)
	{
		if (_instance == null || descriptor == null || (_instance._dynamicPortraitDrifter.CurrentAgent == descriptor && _instance._dynamicPortraitDrifter.Disable()))
		{
			_instance._dynamicPortraitCamera.enabled = false;
			return true;
		}
		return false;
	}

	public static bool IsDynamicPortraitDrifterEnabled()
	{
		return _instance._dynamicPortraitDrifter.IsEnabled();
	}

	public static void SetDynamicPortraitActivity(Activity activity)
	{
		_instance._dynamicPortraitDrifter.SetPortraitActivity(activity);
	}

	public static Texture2D ReturnStaticPortrait(AgentDescriptor descriptor)
	{
		if ((bool)_instance && _instance.TryReturnPortrait(descriptor, out var portrait))
		{
			return portrait;
		}
		Debugger.Error("No character portrait found for " + descriptor.Name + ".");
		return null;
	}

	public static bool HasStaticPortrait(AgentDescriptor descriptor)
	{
		Texture2D portrait;
		if ((bool)_instance)
		{
			return _instance.TryReturnPortrait(descriptor, out portrait);
		}
		return false;
	}

	public static void GeneratePortrait(AgentDescriptor descriptor)
	{
		if (!_portraitGenerationQueue.Contains(descriptor))
		{
			_portraitGenerationQueue.Enqueue(descriptor);
		}
	}

	public static void RemovePortrait(AgentDescriptor descriptor)
	{
		if (_instance != null)
		{
			_instance.I_RemovePortrait(descriptor);
		}
	}

	private bool TryReturnPortrait(AgentDescriptor descriptor, out Texture2D portrait)
	{
		return _portraits.TryGetValue(descriptor, out portrait);
	}

	private void I_RemovePortrait(AgentDescriptor descriptor)
	{
		if (_dynamicPortraitDrifter.CurrentAgent == descriptor)
		{
			_dynamicPortraitDrifter.Disable();
		}
		_portraits.Remove(descriptor);
		_portraitGenerationQueue.Remove(descriptor);
	}

	private IEnumerator GenerateStaticPortraitCoroutine(AgentDescriptor descriptor)
	{
		_staticPortraitCamera.enabled = true;
		_staticPortraitDrifter.Enable(descriptor, DrifterLookCamera.StaticPortrait);
		yield return new WaitForEndOfFrame();
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = _staticPortraitRenderTexture;
		Texture2D texture2D = ReturnPortraitTexture(descriptor);
		texture2D.ReadPixels(new Rect(0f, 0f, _staticPortraitRenderTexture.width, _staticPortraitRenderTexture.height), 0, 0);
		texture2D.Apply();
		RenderTexture.active = active;
		_staticPortraitRenderTexture.Release();
		AgentEvent.Dispatch(GameEventType.AgentPortraitGenerated, descriptor);
		if (_staticPortraitDrifter.Disable())
		{
			_staticPortraitCamera.enabled = false;
		}
	}

	private Texture2D ReturnPortraitTexture(AgentDescriptor descriptor)
	{
		if (_portraits.TryGetValue(descriptor, out var value))
		{
			return value;
		}
		value = new Texture2D(_staticPortraitRenderTexture.width, _staticPortraitRenderTexture.height, TextureFormat.RGBA32, mipChain: true, linear: true)
		{
			anisoLevel = 1
		};
		_portraits.Add(descriptor, value);
		return value;
	}
}
