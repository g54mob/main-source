using System.Collections;
using TMPro;
using UnityEngine;

public class Note : MonoBehaviour
{
	[SerializeField]
	private InteractObject noteInter;

	[SerializeField]
	private GameObject note;

	[SerializeField]
	private TextMeshProUGUI text;

	[SerializeField]
	private InteractObject fridge;

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

	private bool reading;

	private bool first;

	public void Read()
	{
		noteInter.interactable = false;
		text.text = Lines.getLine(44);
		note.SetActive(value: true);
		PlayerManager.instance.LockAll();
		StartCoroutine(ICheckReading());
	}

	private void Start()
	{
		UpdateTextFont();
	}

	private void Update()
	{
		if (reading && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)))
		{
			noteInter.interactable = true;
			reading = false;
			note.SetActive(value: false);
			PlayerManager.instance.UnlockAll();
			if (!first)
			{
				first = true;
				fridge.interactable = true;
			}
		}
	}

	private IEnumerator ICheckReading()
	{
		yield return new WaitForSeconds(0.5f);
		reading = true;
	}

	public void UpdateTextFont()
	{
		if (PlayerPrefs.GetInt("language", 0) == 5)
		{
			text.font = arabic;
			text.fontStyle = FontStyles.Normal;
			text.fontSize = 42f;
		}
		else if (PlayerPrefs.GetInt("language", 0) == 21)
		{
			text.font = persian;
			text.fontStyle = FontStyles.Normal;
			text.fontSize = 45f;
		}
		else if (PlayerPrefs.GetInt("language", 0) == 2)
		{
			text.font = chinese;
			text.fontStyle = FontStyles.Normal;
			text.fontSize = 50f;
		}
		else if (PlayerPrefs.GetInt("language", 0) == 28)
		{
			text.font = hindi;
			text.fontStyle = FontStyles.Normal;
			text.fontSize = 40f;
		}
		else if (PlayerPrefs.GetInt("language", 0) == 16 || PlayerPrefs.GetInt("language", 0) == 17)
		{
			text.font = russian;
			text.fontStyle = FontStyles.Normal;
			text.fontSize = 41f;
		}
		else if (PlayerPrefs.GetInt("language", 0) == 11)
		{
			text.fontStyle = FontStyles.Normal;
			text.font = korean;
			text.fontSize = 45f;
		}
		else if (PlayerPrefs.GetInt("language", 0) == 30)
		{
			text.fontStyle = FontStyles.Normal;
			text.font = mongol;
			text.fontSize = 42f;
		}
		else if (PlayerPrefs.GetInt("language", 0) == 31)
		{
			text.fontStyle = FontStyles.Normal;
			text.font = bulgarian;
			text.fontSize = 42f;
		}
		else if (PlayerPrefs.GetInt("language", 0) == 12)
		{
			text.fontStyle = FontStyles.Bold;
			text.font = japanese;
			text.fontSize = 45f;
		}
		else if (PlayerPrefs.GetInt("language", 0) == 19)
		{
			text.fontStyle = FontStyles.Bold;
			text.font = thai;
			text.fontSize = 45f;
		}
		else if (PlayerPrefs.GetInt("language", 0) == 23)
		{
			text.fontStyle = FontStyles.Bold;
			text.font = greek;
			text.fontSize = 38f;
		}
		else
		{
			text.fontStyle = FontStyles.Normal;
			text.font = latin;
			text.fontSize = 38f;
		}
	}
}
