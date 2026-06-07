using UnityEngine;
using UnityEngine.PajamaLlama;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
	[SerializeField]
	private string _hoverTrigger = "Hover";

	[SerializeField]
	private string _normalTrigger = "Normal";

	[SerializeField]
	private Image _iconImage;

	[SerializeField]
	[NamedArrayElement(new string[] { "CursorState" })]
	private CursorStateSprite[] _cursorStateSprites;

	private static Crosshair _instance;

	private bool _active;

	private bool _blocked;

	private CursorState _cursorState;

	private Animator _animator;

	private CursorContext _context;

	private void Awake()
	{
		if ((bool)_instance && _instance != this)
		{
			Object.Destroy(this);
			return;
		}
		_instance = this;
		_animator = GetComponent<Animator>();
		GameEventDispatcher.AddListener(GameEventType.GameStartedLoading, OnGameStartedLoading);
		GameEventDispatcher.AddListener(GameEventType.GameStart, OnGameStart);
		if (LoadingScreen.IsLoading)
		{
			OnGameStartedLoading();
		}
	}

	private void OnEnable()
	{
		i_SetContext(_context);
	}

	private void LateUpdate()
	{
		if (!(_context == null) && !(_iconImage.sprite == _context.CrosshairIcon))
		{
			SetCrosshairIcon(_context.CrosshairIcon);
		}
	}

	private void OnDisable()
	{
		i_SetContext(null);
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.GameStartedLoading, OnGameStartedLoading);
		GameEventDispatcher.RemoveListener(GameEventType.GameStart, OnGameStart);
	}

	private void OnGameStartedLoading(GameEvent gameEvent = null)
	{
		base.gameObject.SetActive(value: false);
	}

	private void OnGameStart(GameEvent gameEvent)
	{
		SetActive(_active);
	}

	private void i_SetContext(CursorContext context)
	{
		if (!(context == _context))
		{
			_context = context;
			_cursorState = CursorState.Normal;
			if ((bool)_context)
			{
				SetCrosshairIcon(context.CrosshairIcon);
				SetAnimatorTrigger(_hoverTrigger);
			}
			else
			{
				SetAnimatorTrigger(_normalTrigger);
			}
		}
	}

	private void i_SetCursorState(CursorState cursorState)
	{
		if (_cursorState == cursorState)
		{
			return;
		}
		_cursorState = cursorState;
		CursorStateSprite[] cursorStateSprites = _cursorStateSprites;
		for (int i = 0; i < cursorStateSprites.Length; i++)
		{
			CursorStateSprite cursorStateSprite = cursorStateSprites[i];
			if (cursorStateSprite.CursorState == cursorState)
			{
				SetCrosshairIcon(cursorStateSprite.Sprite);
				SetAnimatorTrigger(_hoverTrigger);
				return;
			}
		}
		SetCrosshairIcon(null);
		SetAnimatorTrigger(_normalTrigger);
	}

	private void SetActive(bool value)
	{
		_active = value;
		base.gameObject.SetActive(value && !_blocked && !LoadingScreen.IsLoading);
	}

	private void i_SetBlocked(bool value)
	{
		if (_blocked != value)
		{
			_blocked = value;
			SetActive(_active);
		}
	}

	private void SetCrosshairIcon(Sprite icon)
	{
		if ((bool)icon)
		{
			_iconImage.sprite = icon;
			_iconImage.enabled = true;
		}
		else
		{
			_iconImage.sprite = null;
			_iconImage.enabled = false;
		}
	}

	private void SetAnimatorTrigger(string name)
	{
		_animator.ResetTrigger(_normalTrigger);
		_animator.ResetTrigger(_hoverTrigger);
		_animator.SetTrigger(name);
	}

	public static void Enable()
	{
		_instance?.SetActive(value: true);
	}

	public static void SetBlocked(bool value)
	{
		_instance?.i_SetBlocked(value);
	}

	public static void SetContext(CursorContext context)
	{
		_instance?.i_SetContext(context);
	}

	public static void SetCursorState(CursorState cursorState)
	{
		_instance?.i_SetCursorState(cursorState);
	}

	public static void Disable()
	{
		_instance?.SetActive(value: false);
	}
}
