using System.Collections;
using TMPro;
using UnityEngine;

public class Spell : MonoBehaviour
{
	[SerializeField]
	private GameObject spell;

	[SerializeField]
	private TextMeshProUGUI text;

	private bool reading;

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

	public void Read()
	{
		GetComponent<InteractObject>().interactable = false;
		spell.SetActive(value: true);
		text.text = Lines.getLine(118);
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
			Manager4.instance.TriggerEvent();
			Object.Destroy(spell);
			Object.Destroy(base.gameObject);
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
		}
		else if (PlayerPrefs.GetInt("language", 0) == 21)
		{
			text.font = persian;
		}
		else if (PlayerPrefs.GetInt("language", 0) == 2)
		{
			text.font = chinese;
		}
		else if (PlayerPrefs.GetInt("language", 0) == 28)
		{
			text.font = hindi;
		}
		else if (PlayerPrefs.GetInt("language", 0) == 31)
		{
			text.font = bulgarian;
		}
		else if (PlayerPrefs.GetInt("language", 0) == 30)
		{
			text.font = mongol;
		}
		else if (PlayerPrefs.GetInt("language", 0) == 16 || PlayerPrefs.GetInt("language", 0) == 17)
		{
			text.font = russian;
		}
		else if (PlayerPrefs.GetInt("language", 0) == 11)
		{
			text.font = korean;
		}
		else if (PlayerPrefs.GetInt("language", 0) == 12)
		{
			text.font = japanese;
		}
		else if (PlayerPrefs.GetInt("language", 0) == 19)
		{
			text.font = thai;
		}
		else if (PlayerPrefs.GetInt("language", 0) == 23)
		{
			text.font = greek;
		}
		else
		{
			text.font = latin;
		}
	}
}
