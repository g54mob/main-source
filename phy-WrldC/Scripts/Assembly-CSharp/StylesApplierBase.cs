using UnityEngine;

[ExecuteInEditMode]
public abstract class StylesApplierBase : MonoBehaviour
{
	[SerializeField]
	protected GameStylesData gameStylesData;

	[SerializeField]
	protected string baseId;

	protected LanguagesManager languages;

	private bool alreadyInitialized;

	public string BaseId
	{
		get
		{
			return baseId;
		}
		set
		{
			baseId = value;
		}
	}

	protected virtual void Awake()
	{
		if (gameStylesData == null && GameManager.Exist)
		{
			gameStylesData = GameManager.Instance.GameStylesData;
		}
		if (gameStylesData != null)
		{
			Initialize();
			UpdateStyles();
		}
	}

	protected virtual void Start()
	{
		if (Application.isPlaying && !alreadyInitialized)
		{
			if (gameStylesData == null)
			{
				gameStylesData = GameManager.Instance.GameStylesData;
				Initialize();
				UpdateStyles();
			}
			languages = LanguagesManager.Instance;
			UpdateTexts();
			languages.OnLanguageChangedEvent += LanguageChangedHandler;
			alreadyInitialized = true;
		}
	}

	private void LanguageChangedHandler()
	{
		UpdateTexts();
	}

	public abstract void Initialize();

	public abstract void UpdateStyles();

	public abstract void UpdateTexts();

	protected virtual void Update()
	{
	}
}
