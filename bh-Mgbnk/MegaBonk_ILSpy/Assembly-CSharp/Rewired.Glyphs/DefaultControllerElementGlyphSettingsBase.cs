using UnityEngine;

namespace Rewired.Glyphs;

public abstract class DefaultControllerElementGlyphSettingsBase : MonoBehaviour
{
	private ControllerElementGlyphSelectorOptions _options;

	private GameObject _glyphOrTextPrefab;

	public ControllerElementGlyphSelectorOptions options
	{
		get
		{
			return _options;
		}
		set
		{
			_options = value;
			SetDefaults();
		}
	}

	public GameObject glyphOrTextPrefab
	{
		get
		{
			return _glyphOrTextPrefab;
		}
		set
		{
			_glyphOrTextPrefab = value;
			SetDefaults();
		}
	}

	protected virtual void OnEnable()
	{
		SetDefaults();
	}

	protected virtual void OnDisable()
	{
	}

	protected virtual void SetDefaults()
	{
		SetDefaultOptions();
		SetDefaultGlyphOrTextPrefab();
	}

	protected virtual void SetDefaultOptions()
	{
		ControllerElementGlyphSelectorOptions.s_defaultOptions = _options;
	}

	protected abstract void SetDefaultGlyphOrTextPrefab();
}
