using UnityEngine;
using UnityEngine.UI;

public class CreativeModeChapterUI : MonoBehaviour
{
	private Button button;

	[SerializeField]
	private Image unlockedImage;

	[SerializeField]
	private Image outline;

	[SerializeField]
	private Image tagNew;

	private bool isUnlocked;

	private void Awake()
	{
		button = GetComponent<Button>();
	}

	private void Start()
	{
		if (!isUnlocked)
		{
			unlockedImage.gameObject.SetActive(value: false);
		}
	}

	public void Unlock(bool tagActive)
	{
		isUnlocked = true;
		unlockedImage.gameObject.SetActive(value: true);
		tagNew.gameObject.SetActive(tagActive);
	}

	public void Select()
	{
		outline.gameObject.SetActive(value: true);
		base.transform.localScale = Vector3.one * 1.1f;
	}

	public void Unselect()
	{
		outline.gameObject.SetActive(value: false);
		base.transform.localScale = Vector3.one;
	}

	public bool IsUnlocked()
	{
		return isUnlocked;
	}

	public Button GetButton()
	{
		return button;
	}
}
