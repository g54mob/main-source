using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

[RequireComponent(typeof(SpriteRenderer))]
[ExecuteInEditMode]
public class SpriteSheetSkin : MonoBehaviour
{
	private readonly int _ReplacementTex = Shader.PropertyToID("_ReplacementTex");

	private readonly int _UseReplacementTex = Shader.PropertyToID("_UseReplacementTex");

	private static readonly int EmissiveTex = Shader.PropertyToID("_EmissiveTex");

	public Texture2D skin;

	private Texture2D _emissiveSkin;

	private List<Texture2D> m_previousSkins = new List<Texture2D>();

	private SpriteRenderer m_renderer;

	private int _pendingLoadCount;

	private AsyncOperationHandle<Texture2D> _currentlyLoadedSkin;

	private AsyncOperationHandle<Texture2D> _pendingSkinLoadRequest;

	private AsyncOperationHandle<Texture2D> _currentlyLoadedEmissiveSkin;

	private AsyncOperationHandle<Texture2D> _pendingEmissiveSkinLoadRequest;

	public SpriteRenderer sr => m_renderer ?? (m_renderer = GetComponent<SpriteRenderer>());

	private void OnEnable()
	{
		ApplySkin();
	}

	private void OnDisable()
	{
		AbortPendingLoadRequest();
		UnloadCurrentTexture();
		ApplySkin(reset: true);
	}

	public void LoadAndSetSkinAsync(AssetReferenceTexture2D newSkin, AssetReferenceTexture2D emissiveSkin = null, bool runSynchronously = false, Action onSkinSet = null)
	{
		if (newSkin == null || !newSkin.RuntimeKeyIsValid())
		{
			SetSkin(null);
			return;
		}
		AbortPendingLoadRequest();
		LoadTextureAsync(newSkin, emissiveSkin, onSkinSet);
		if (runSynchronously)
		{
			FinishTextureLoad();
		}
	}

	public void FinishTextureLoad()
	{
		_pendingSkinLoadRequest.WaitForCompletion();
	}

	private void LoadTextureAsync(AssetReferenceTexture2D newSkin, AssetReferenceTexture2D emissiveSkin, [AllowNull] Action onSkinReady)
	{
		_pendingSkinLoadRequest = Addressables.LoadAssetAsync<Texture2D>(newSkin);
		_pendingSkinLoadRequest.Completed += delegate
		{
			OnLoadCompleted(onSkinReady);
		};
		_pendingLoadCount++;
		if (emissiveSkin != null && emissiveSkin.RuntimeKeyIsValid())
		{
			_pendingEmissiveSkinLoadRequest = Addressables.LoadAssetAsync<Texture2D>(emissiveSkin);
			_pendingEmissiveSkinLoadRequest.Completed += delegate
			{
				OnLoadCompleted(onSkinReady);
			};
			_pendingLoadCount++;
		}
	}

	private void OnLoadCompleted([AllowNull] Action onSkinReady)
	{
		_pendingLoadCount--;
		if (_pendingLoadCount <= 0)
		{
			SwapToLoadedTextures();
			ApplySkin();
			onSkinReady?.Invoke();
		}
	}

	private void AbortPendingLoadRequest()
	{
		_pendingSkinLoadRequest.WaitForCompletion();
		if (_pendingSkinLoadRequest.IsValid())
		{
			Addressables.Release(_pendingSkinLoadRequest);
			_pendingSkinLoadRequest = default(AsyncOperationHandle<Texture2D>);
		}
		_pendingEmissiveSkinLoadRequest.WaitForCompletion();
		if (_pendingEmissiveSkinLoadRequest.IsValid())
		{
			Addressables.Release(_pendingEmissiveSkinLoadRequest);
			_pendingEmissiveSkinLoadRequest = default(AsyncOperationHandle<Texture2D>);
		}
	}

	private void UnloadCurrentTexture()
	{
		if (_currentlyLoadedSkin.IsValid())
		{
			Addressables.Release(_currentlyLoadedSkin);
			_currentlyLoadedSkin = default(AsyncOperationHandle<Texture2D>);
		}
		if (_currentlyLoadedEmissiveSkin.IsValid())
		{
			Addressables.Release(_currentlyLoadedEmissiveSkin);
			_currentlyLoadedEmissiveSkin = default(AsyncOperationHandle<Texture2D>);
		}
	}

	private void SwapToLoadedTextures()
	{
		UnloadCurrentTexture();
		if (_pendingSkinLoadRequest.IsValid())
		{
			_currentlyLoadedSkin = _pendingSkinLoadRequest;
			_pendingSkinLoadRequest = default(AsyncOperationHandle<Texture2D>);
			skin = _currentlyLoadedSkin.Result;
		}
		if (_pendingEmissiveSkinLoadRequest.IsValid())
		{
			_currentlyLoadedEmissiveSkin = _pendingEmissiveSkinLoadRequest;
			_pendingEmissiveSkinLoadRequest = default(AsyncOperationHandle<Texture2D>);
			_emissiveSkin = _currentlyLoadedEmissiveSkin.Result;
		}
		else
		{
			_emissiveSkin = null;
		}
	}

	public void SetSkin(Texture2D newSkin)
	{
		AbortPendingLoadRequest();
		UnloadCurrentTexture();
		skin = newSkin;
		ApplySkin();
	}

	public void SetTemporarySkin(Texture2D tmpSkin)
	{
		AbortPendingLoadRequest();
		if (tmpSkin != skin)
		{
			m_previousSkins.Add(skin);
			skin = tmpSkin;
		}
		ApplySkin();
	}

	public void ResetTemporarySkin()
	{
		AbortPendingLoadRequest();
		if (m_previousSkins.Count > 0)
		{
			skin = m_previousSkins[m_previousSkins.Count - 1];
			m_previousSkins.RemoveAt(m_previousSkins.Count - 1);
		}
		ApplySkin();
	}

	public void ResetAllTemporarySkins()
	{
		AbortPendingLoadRequest();
		if (m_previousSkins.Count > 0)
		{
			skin = m_previousSkins[0];
		}
		m_previousSkins.Clear();
		ApplySkin();
	}

	public void ApplySkin(bool reset = false)
	{
		SpriteRenderer spriteRenderer = sr;
		float value = ((skin != null && !reset) ? 1 : 0);
		spriteRenderer.material.SetFloat(_UseReplacementTex, value);
		if (skin != null)
		{
			spriteRenderer.material.SetTexture(_ReplacementTex, skin);
		}
		spriteRenderer.material.SetTexture(EmissiveTex, _emissiveSkin);
	}
}
