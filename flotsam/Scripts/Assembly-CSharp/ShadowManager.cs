using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ShadowManager : MonoBehaviour
{
	[SerializeField]
	private UniversalRenderPipelineAsset _renderPipeline;

	[Header("Shadow Distance")]
	[SerializeField]
	private bool _cacheDefaultShadowDistance;

	[ConditionalHide("_cacheDefaultShadowDistance", Inverse = true)]
	[SerializeField]
	private float _defaultShadowDistance = 240f;

	private static ShadowManager _instance;

	private float _cachedDefaultShadowDistance;

	private void Awake()
	{
		if (_instance == null || _instance == this)
		{
			_instance = this;
			if (_cacheDefaultShadowDistance)
			{
				_cachedDefaultShadowDistance = _renderPipeline.shadowDistance;
			}
			else
			{
				_renderPipeline.shadowDistance = _defaultShadowDistance;
			}
		}
		else
		{
			Object.Destroy(this);
		}
	}

	public void ApplyDefaultShadowDistance()
	{
		_renderPipeline.shadowDistance = (_cacheDefaultShadowDistance ? _cachedDefaultShadowDistance : _defaultShadowDistance);
	}

	public static void ResetShadowDistance()
	{
		if ((bool)_instance)
		{
			_instance.ApplyDefaultShadowDistance();
		}
	}

	public static void SetShadowDistance(float distance)
	{
		if ((bool)_instance)
		{
			_instance._renderPipeline.shadowDistance = distance;
		}
	}
}
