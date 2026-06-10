using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardPreview : MonoBehaviour
{
	public Image cardImage;

	public TextMeshProUGUI descriptionText;

	public TextMeshProUGUI Attack;

	public TextMeshProUGUI Health;

	public TextMeshProUGUI Mana;

	public GameObject[] infoObjects;

	public Wizcard showingWizcard;

	public static CardPreview Instance { get; private set; }

	private void Awake()
	{
	}

	public void ShowCardInfo(Wizcard wizcard)
	{
	}

	public void HideCardInfo()
	{
	}
}
