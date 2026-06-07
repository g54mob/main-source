using UnityEngine;

public class PauseMenuWindow : MonoBehaviour
{
	[Header("Pause Menu Panel")]
	[SerializeField]
	private GameMenuPanel _gameMenuPanel;

	private void Reset()
	{
		if (_gameMenuPanel == null)
		{
			_gameMenuPanel = GetComponentInParent<GameMenuPanel>();
		}
	}

	private void Awake()
	{
		if (_gameMenuPanel == null)
		{
			_gameMenuPanel = GetComponentInParent<GameMenuPanel>();
		}
		if (_gameMenuPanel == null)
		{
			_gameMenuPanel = Object.FindAnyObjectByType<GameMenuPanel>();
		}
	}

	public void Enable()
	{
		base.gameObject.SetActive(value: true);
	}

	protected virtual void OnEnable()
	{
		if (_gameMenuPanel != null)
		{
			_gameMenuPanel.OnPauseMenuWindowEnabled(this);
		}
	}

	public virtual void Disable()
	{
		base.gameObject.SetActive(value: false);
	}

	protected virtual void OnDisable()
	{
		if (_gameMenuPanel != null)
		{
			_gameMenuPanel.OnPauseMenuWindowDisabled(this);
		}
	}
}
