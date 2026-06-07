using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

public class ArcadeTransform
{
	private static ProfilerMarker updateDisplayOriginSampler;

	private static ProfilerMarker updateRendererMarker;

	private static ProfilerMarker setFromGameObjectMarker;

	private SpriteCachedData data;

	private Transform _unityTransform;

	private Transform _rendererTransform;

	private SpriteRenderer _unitySpriteRenderer;

	private BaseBody _body;

	public float2 position;

	public float2 scale;

	protected float3 _unityangles;

	protected float _unityz;

	protected float _scalez;

	public float2 displayOrigin;

	private float2 _origin;

	private float2 cachedLocalPosition;

	public ref SpriteCachedData Data
	{
		get
		{
			throw null;
		}
	}

	public float z => 0f;

	public float2 origin => default(float2);

	public float rotation => 0f;

	public ArcadeTransform(Transform unityTransform, SpriteRenderer unitySpriteRenderer, BaseBody body)
	{
	}

	public void Reset(Transform unityTransform, SpriteRenderer unitySpriteRenderer, BaseBody body)
	{
	}

	public void setOrigin(float2 o)
	{
	}

	public void OnSpriteChanged()
	{
	}

	public void OnSpriteChanged(float2 originalSize)
	{
	}

	public void SetFromGameObject()
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void AddPosition(float2 pos)
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void AddPositionForced(float2 pos)
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void SetPosition(float2 pos)
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void SetPositionForced(float2 pos)
	{
	}

	public void UpdateDisplayOrigin(bool forced = false)
	{
	}

	public void UpdateRendererPosition(bool force = false)
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float2 GetRendererPosition(float2 origin, Sprite sprite)
	{
		return default(float2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float2 GetRendererPosition(float2 origin, SpriteCachedData data)
	{
		return default(float2);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void AddRotation(float deltaZ)
	{
	}

	public void ForceSpriteFetch()
	{
	}

	public void ForceFullReupdate()
	{
	}

	public bool SetRotation(float rotation)
	{
		return false;
	}

	public void SetRotationForced(float rotation)
	{
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void SetPositionAndRotationForced(float2 transformPosition, float f)
	{
	}
}
