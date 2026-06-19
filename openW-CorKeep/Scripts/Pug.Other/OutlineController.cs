using UnityEngine;

public class OutlineController : MonoBehaviour, IManagedLateUpdate
{
	private static readonly int _MinUV = Shader.PropertyToID("_MinUV");

	private static readonly int _MaxUV = Shader.PropertyToID("_MaxUV");

	private static readonly int _ShowOutline = Shader.PropertyToID("_ShowOutline");

	private static readonly int _UseOuter = Shader.PropertyToID("_UseOuter");

	private static readonly int _OutlineColor = Shader.PropertyToID("_OutlineColor");

	public bool showOutline;

	[SerializeField]
	private bool useOuterOutline;

	[SerializeField]
	private bool isAnimatedForceOutline;

	private Color _outlineColor;

	private bool _overrideColor;

	private SpriteRenderer _sr;

	private MaterialPropertyBlock _propBlock;

	private bool _previousShowOutline;

	private bool _hasValidSprite;

	private void Awake()
	{
		_propBlock = new MaterialPropertyBlock();
		_sr = GetComponent<SpriteRenderer>();
		_hasValidSprite = _sr != null && _sr.sprite != null;
	}

	private void OnEnable()
	{
		Manager.update.AddToLateUpdate(this);
		UpdatePropertyBlock(force: true);
	}

	private void OnDisable()
	{
		Manager.update.RemoveFromLateUpdate(this);
	}

	public void ManagedLateUpdate()
	{
		UpdatePropertyBlock(isAnimatedForceOutline);
	}

	public void SetColor(Color color)
	{
		_overrideColor = true;
		_outlineColor = color;
	}

	public void ResetColor()
	{
		_overrideColor = false;
	}

	private void UpdatePropertyBlock(bool force = false)
	{
		if (force || _previousShowOutline != showOutline)
		{
			_previousShowOutline = showOutline;
			if (_hasValidSprite)
			{
				_sr.GetPropertyBlock(_propBlock);
				Sprite sprite = _sr.sprite;
				Texture2D texture = sprite.texture;
				_propBlock.SetVector(_MinUV, sprite.rect.min * texture.texelSize);
				_propBlock.SetVector(_MaxUV, sprite.rect.max * texture.texelSize);
				_propBlock.SetInt(_ShowOutline, showOutline ? 1 : 0);
				_propBlock.SetInt(_UseOuter, useOuterOutline ? 1 : 0);
				_propBlock.SetColor(_OutlineColor, _overrideColor ? _outlineColor : Manager.effects.outlineColor);
				_sr.SetPropertyBlock(_propBlock);
			}
		}
	}

	private void OnValidate()
	{
		UpdatePropertyBlock(force: true);
	}
}
