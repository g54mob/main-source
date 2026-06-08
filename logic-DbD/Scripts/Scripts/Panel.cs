using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Panel : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	protected RectTransform rectTransform;

	protected TextMeshProUGUI windowName;

	protected Animator panelAnimator;

	protected AudioSource audioSource;

	protected bool isOpen;

	protected bool isMinimizing;

	protected ClosePanelAudio sfxPlayer;

	protected Vector3 currentPosition;

	protected virtual void Awake()
	{
		rectTransform = base.gameObject.GetComponent<RectTransform>();
		windowName = base.transform.Find("Toolbar/Window Name").GetComponent<TextMeshProUGUI>();
		panelAnimator = GetComponent<Animator>();
		if (!panelAnimator)
		{
			panelAnimator = base.gameObject.AddComponent<Animator>();
		}
		GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/Panel/Panel");
		audioSource = base.gameObject.AddComponent<AudioSource>();
		sfxPlayer = SoundEffectUtils.GetOpenClosePanelPlayer();
	}

	protected virtual void Start()
	{
		SetCurrentPosition();
	}

	public void OnPointerDown(PointerEventData data)
	{
		UIUtils.SetPenultimateLayer(rectTransform);
		TaskbarManager.SetTaskbarActive(base.gameObject);
	}

	public void SetToolbarName(string name)
	{
		windowName.text = name;
	}

	public string GetToolbarName()
	{
		return windowName.text;
	}

	public TextMeshProUGUI GetToolbarNameObject()
	{
		return windowName;
	}

	public virtual void ClosePanel()
	{
		panelAnimator.SetBool("Is Taskbar Open", value: false);
		isOpen = false;
		if (!isMinimizing || IsPanelMaximizing())
		{
			panelAnimator.Play("Close Panel");
		}
		isMinimizing = false;
		float currentAnimationLength = UIUtils.GetCurrentAnimationLength(panelAnimator);
		StartCoroutine(OnPanelClose(currentAnimationLength));
		TaskbarManager.RemoveFromTaskbar(base.gameObject);
	}

	public bool IsClosing()
	{
		return !isOpen;
	}

	public void SetCurrentPosition()
	{
		currentPosition = base.transform.position;
	}

	public void MinimizePanel()
	{
		OnMinimizePanel();
		if (!isMinimizing)
		{
			panelAnimator.Play("Fast Close");
		}
		else
		{
			panelAnimator.SetBool("Is Taskbar Open", value: false);
		}
		isMinimizing = true;
		GameObject gameObject = TaskbarManager.SetTaskbarInactive(base.gameObject);
		if (gameObject != null)
		{
			MoveToTaskbar(gameObject, 0.2f);
		}
		sfxPlayer.PlayMinimize();
	}

	public virtual void OnMinimizePanel()
	{
	}

	public void MaximizePanel()
	{
		GameObject gameObject = TaskbarManager.SetTaskbarActive(base.gameObject);
		if (isMinimizing && !IsPanelMaximizing())
		{
			OnMaximizePanel();
			panelAnimator.SetBool("Is Taskbar Open", value: true);
			if (gameObject != null)
			{
				MoveBack(gameObject, 0.25f);
			}
			if (base.transform.position != currentPosition)
			{
				sfxPlayer.PlayMaximize();
			}
		}
	}

	public virtual void OnMaximizePanel()
	{
	}

	public virtual void OpenPanel()
	{
		isMinimizing = false;
		isOpen = true;
		panelAnimator.SetBool("Is Taskbar Open", value: false);
		panelAnimator.Play("Open Panel");
	}

	protected virtual IEnumerator OnPanelClose(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		if (!isOpen)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	public void MoveBack(GameObject taskbarButton, float duration)
	{
		Vector2 destination = currentPosition;
		_ = currentPosition;
		Vector3 start = GetTaskbarPosition(taskbarButton);
		start.z = base.transform.position.z;
		StartCoroutine(MoveToTarget(start, destination, duration, isMaximizing: true));
	}

	public void MoveToTaskbar(GameObject taskbarButton, float duration)
	{
		Vector2 taskbarPosition = GetTaskbarPosition(taskbarButton);
		StartCoroutine(MoveToTarget(currentPosition, taskbarPosition, duration, isMaximizing: false));
	}

	private Vector2 GetTaskbarPosition(GameObject taskbarButton)
	{
		Vector2 vector = taskbarButton.transform.position;
		float num = taskbarButton.GetComponent<RectTransform>().rect.width / 4f;
		return new Vector2(vector.x + num, vector.y);
	}

	protected bool IsPanelMaximizing()
	{
		return panelAnimator.GetBool("Is Taskbar Open");
	}

	public IEnumerator MoveToTarget(Vector3 start, Vector2 destination, float duration, bool isMaximizing)
	{
		float elapsedTime = 0f;
		while (elapsedTime < duration && IsPanelMaximizing() == isMaximizing)
		{
			float t = elapsedTime / duration;
			Vector2 vector = Vector2.Lerp(start, destination, t);
			base.transform.position = new Vector3(vector.x, vector.y, start.z);
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		if (IsPanelMaximizing() == isMaximizing)
		{
			base.transform.position = new Vector3(destination.x, destination.y, start.z);
		}
	}
}
