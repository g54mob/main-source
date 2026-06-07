using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuReturnManager : MonoBehaviour
{
	public static MenuReturnManager instance;

	public Image returnImage;

	public Image blackImage;

	public float returnTimer;

	private float returnSeconds;

	public GameObject returnButton;

	private void Awake()
	{
		Object.DontDestroyOnLoad(this);
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		returnSeconds = 0f;
		UpdateSlider();
		if (scene == SceneManager.GetSceneByName("Menu") || scene == SceneManager.GetSceneByName("Chess") || scene == SceneManager.GetSceneByName("Overworld") || scene == SceneManager.GetSceneByName("Credits"))
		{
			if (returnButton != null)
			{
				returnButton.SetActive(value: false);
			}
		}
		else if (returnButton != null)
		{
			returnButton.SetActive(value: true);
		}
	}

	public void Start()
	{
		returnImage.gameObject.SetActive(value: true);
		returnImage.fillAmount = 0f;
	}

	public void Update()
	{
		InputToReturn();
	}

	public void InputToReturn()
	{
		if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Menu"))
		{
			return;
		}
		if (!Input.GetKey(KeyCode.Escape) && !Input.GetKey(KeyCode.Tab))
		{
			if (returnSeconds > 0f)
			{
				returnSeconds -= Time.deltaTime * 2f;
				UpdateSlider();
			}
		}
		else if (returnSeconds < returnTimer)
		{
			returnSeconds += Time.deltaTime;
			UpdateSlider();
		}
		else
		{
			Return();
		}
	}

	public void UpdateSlider()
	{
		float num = returnSeconds / returnTimer;
		returnImage.fillAmount = num;
		blackImage.color = new Color(blackImage.color.r, blackImage.color.g, blackImage.color.b, num);
	}

	public void Return()
	{
		SaveSystem.SavePlayerSaveData(SaveSystem.currentPlayerSaveData);
		SceneManager.LoadScene("Menu");
	}
}
