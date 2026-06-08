using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskbarButton : MonoBehaviour
{
	public static readonly int MAX_TASKBAR_BUTTON_WIDTH = 180;

	public static readonly int MIN_TASKBAR_BUTTON_WIDTH = 110;

	[SerializeField]
	private Sprite clickedImage;

	[SerializeField]
	private Sprite defaultImage;

	[SerializeField]
	private Image icon;

	[SerializeField]
	private TextMeshProUGUI taskbarName;

	private GameObject window;

	private bool isClicked;

	private static TaskbarButton lastClicked;

	private static Animator animator;

	public void SetSize(int newSize)
	{
		int num = MAX_TASKBAR_BUTTON_WIDTH;
		if (newSize < MAX_TASKBAR_BUTTON_WIDTH && newSize > MIN_TASKBAR_BUTTON_WIDTH)
		{
			num = newSize;
		}
		else if (newSize < MIN_TASKBAR_BUTTON_WIDTH)
		{
			num = MIN_TASKBAR_BUTTON_WIDTH;
		}
		RectTransform component = GetComponent<RectTransform>();
		component.sizeDelta = new Vector2(num, component.sizeDelta.y);
	}

	public void OpenPanel()
	{
		if (lastClicked != null && lastClicked != this)
		{
			lastClicked.DisableImage();
		}
		if (isClicked)
		{
			MinimizeWindow(window);
		}
		else
		{
			OpenWindow(window);
		}
		lastClicked = this;
	}

	public static void MinimizeWindow(GameObject window)
	{
		Panel component = window.GetComponent<Panel>();
		if (component != null)
		{
			component.MinimizePanel();
		}
	}

	public static void OpenWindow(GameObject window)
	{
		window.SetActive(value: true);
		UIUtils.SetPenultimateLayer(window);
		Panel component = window.GetComponent<Panel>();
		if (component != null)
		{
			component.MaximizePanel();
		}
	}

	public void EnableImage()
	{
		if (lastClicked != null && lastClicked != this)
		{
			lastClicked.DisableImage();
		}
		isClicked = true;
		GetComponent<Image>().sprite = clickedImage;
		lastClicked = this;
	}

	public void DisableImage()
	{
		isClicked = false;
		GetComponent<Image>().sprite = defaultImage;
	}

	public void SetIcon(Sprite sprite)
	{
		icon.sprite = sprite;
	}

	public void SetName(string name)
	{
		taskbarName.text = name;
	}

	public void SetWindow(GameObject window)
	{
		this.window = window;
	}

	public void RemoveTaskbarButton()
	{
		if (animator == null)
		{
			animator = GetComponent<Animator>();
		}
		animator.enabled = false;
		StartCoroutine(ChangeWidth());
	}

	private IEnumerator ChangeWidth()
	{
		RectTransform rect = GetComponent<RectTransform>();
		float startingScale = rect.localScale.x;
		float startingSize = rect.sizeDelta.x;
		float delta = -0.05f;
		while (startingScale - delta > 0f)
		{
			delta += 0.06f;
			rect.localScale = new Vector2(startingScale - delta, rect.localScale.y);
			rect.sizeDelta = new Vector2(startingSize * (startingScale - delta), rect.sizeDelta.y);
			yield return new WaitForSeconds(0.01f);
		}
		Object.Destroy(base.gameObject);
	}
}
