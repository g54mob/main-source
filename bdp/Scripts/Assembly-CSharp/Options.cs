using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
	[SerializeField]
	private GameObject optionsPanel;

	[SerializeField]
	private bool active;

	[SerializeField]
	private Canvas canvas;

	[SerializeField]
	private TMP_Dropdown langDrop;

	[SerializeField]
	private TMP_FontAsset latin;

	[SerializeField]
	private TMP_FontAsset arabic;

	[SerializeField]
	private TMP_FontAsset korean;

	[SerializeField]
	private TMP_FontAsset japanese;

	[SerializeField]
	private TMP_FontAsset chinese;

	[SerializeField]
	private TMP_FontAsset russian;

	[SerializeField]
	private TMP_FontAsset thai;

	[SerializeField]
	private TMP_FontAsset persian;

	[SerializeField]
	private TMP_FontAsset greek;

	[SerializeField]
	private TMP_FontAsset hindi;

	[SerializeField]
	private TMP_FontAsset mongol;

	[SerializeField]
	private TMP_FontAsset bulgarian;

	[SerializeField]
	private UnityEvent langChangedCallback;

	[SerializeField]
	private Material filter;

	[SerializeField]
	private PostProcessProfile[] filters;

	private PostProcessVolume vol;

	private void Start()
	{
		if (langDrop != null)
		{
			langDrop.value = PlayerPrefs.GetInt("language", 0);
		}
		UpdateBrightness();
		if (active)
		{
			canvas.worldCamera = GameObject.Find("UICam").GetComponent<Camera>();
			UpdateTextFont();
			vol = GameObject.Find("PP").GetComponent<PostProcessVolume>();
			UpdateFilter();
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) && active)
		{
			if (optionsPanel.activeSelf)
			{
				optionsPanel.SetActive(value: false);
				Time.timeScale = 1f;
				Cursor.lockState = CursorLockMode.Locked;
			}
			else
			{
				Cursor.lockState = CursorLockMode.None;
				optionsPanel.SetActive(value: true);
				Time.timeScale = 0f;
			}
		}
		if (Input.GetKeyDown(KeyCode.Alpha1) && active)
		{
			float num = PlayerPrefs.GetFloat("mouse", 7f);
			num = Mathf.Clamp(num -= 1f, 0f, 100f);
			PlayerPrefs.SetFloat("mouse", num);
			PlayerManager instance = PlayerManager.instance;
			if (instance != null)
			{
				instance.SetMouseSen(num);
			}
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2) && active)
		{
			float num2 = PlayerPrefs.GetFloat("mouse", 7f);
			num2 = Mathf.Clamp(num2 += 1f, 0f, 100f);
			PlayerPrefs.SetFloat("mouse", num2);
			PlayerManager instance2 = PlayerManager.instance;
			if (instance2 != null)
			{
				instance2.SetMouseSen(num2);
			}
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			float num3 = PlayerPrefs.GetFloat("brightness", 0f);
			num3 = Mathf.Clamp(num3 - 0.01f, 0f, 0.1f);
			PlayerPrefs.SetFloat("brightness", num3);
			UpdateBrightness();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			float num4 = PlayerPrefs.GetFloat("brightness", 0f);
			num4 = Mathf.Clamp(num4 + 0.01f, 0f, 0.1f);
			PlayerPrefs.SetFloat("brightness", num4);
			UpdateBrightness();
		}
		else if (Input.GetKeyDown(KeyCode.Alpha5) && active)
		{
			int num5 = PlayerPrefs.GetInt("filter", 0);
			num5 = ++num5 % 4;
			PlayerPrefs.SetInt("filter", num5);
			UpdateFilter();
		}
	}

	public void Exit()
	{
		Application.Quit();
	}

	public void Home()
	{
		SceneManager.LoadScene("Main");
		Object.Destroy(base.gameObject);
	}

	public void Resume()
	{
		optionsPanel.SetActive(value: false);
		Cursor.lockState = CursorLockMode.Locked;
		Time.timeScale = 1f;
	}

	public void HandleDropDown()
	{
		PlayerPrefs.SetInt("language", langDrop.value);
		if (active)
		{
			UpdateTextFont();
			langChangedCallback?.Invoke();
		}
	}

	public void UpdateTextFont()
	{
		GameObject gameObject = GameObject.Find("Dialogue");
		if (!(gameObject != null))
		{
			return;
		}
		TextMeshProUGUI componentInChildren = gameObject.GetComponentInChildren<TextMeshProUGUI>();
		if (componentInChildren != null)
		{
			if (langDrop.value == 5)
			{
				componentInChildren.font = arabic;
				componentInChildren.fontSize = 40f;
			}
			else if (langDrop.value == 21)
			{
				componentInChildren.font = persian;
				componentInChildren.fontSize = 45f;
			}
			else if (langDrop.value == 28)
			{
				componentInChildren.font = hindi;
				componentInChildren.fontSize = 45f;
			}
			else if (langDrop.value == 30)
			{
				componentInChildren.font = mongol;
				componentInChildren.fontSize = 42f;
			}
			else if (langDrop.value == 31)
			{
				componentInChildren.font = bulgarian;
				componentInChildren.fontSize = 40f;
			}
			else if (langDrop.value == 16 || langDrop.value == 17)
			{
				componentInChildren.font = russian;
				componentInChildren.fontSize = 40f;
			}
			else if (langDrop.value == 2)
			{
				componentInChildren.font = chinese;
				componentInChildren.fontSize = 50f;
			}
			else if (langDrop.value == 11)
			{
				componentInChildren.font = korean;
				componentInChildren.fontSize = 45f;
			}
			else if (langDrop.value == 12)
			{
				componentInChildren.font = japanese;
				componentInChildren.fontSize = 45f;
			}
			else if (langDrop.value == 19)
			{
				componentInChildren.font = thai;
				componentInChildren.fontSize = 45f;
			}
			else if (langDrop.value == 23)
			{
				componentInChildren.font = greek;
				componentInChildren.fontSize = 38f;
			}
			else
			{
				componentInChildren.font = latin;
				componentInChildren.fontSize = 38f;
			}
		}
	}

	private void UpdateBrightness()
	{
		filter.SetFloat("_Brightness", PlayerPrefs.GetFloat("brightness", 0f));
	}

	public void UpdateFilter()
	{
		vol.profile = filters[PlayerPrefs.GetInt("filter")];
	}
}
