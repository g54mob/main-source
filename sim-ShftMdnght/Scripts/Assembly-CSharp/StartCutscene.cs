using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartCutscene : MonoBehaviour
{
	public Transform titleText;

	public Transform titleTextPosition;

	public GameObject firstNextButton;

	public string petString;

	public TextMeshProUGUI pickedPetText1;

	public TextMeshProUGUI pickedPetText2;

	public Transform pickedPetText;

	public Transform pickedPetTextPosition;

	public GameObject pickPetScreen;

	public GameObject namePetScreen;

	public GameObject inputField;

	public TextMeshProUGUI petNameInputField;

	public TextMeshProUGUI setPetName;

	public GameObject nextButton4Holder;

	public GameObject nextButton6Holder;

	public GameObject finalCutsceneScreen;

	public GameObject namedParticles;

	public Sprite[] sadPet;

	public Sprite[] happyPet;

	public Sprite[] couchPet;

	public Sprite[] sickPet;

	public Image happyPetImage1;

	public Image happyPetImage2;

	public Image sleepyPetImage;

	public Image sickPetImage;

	public Image sickPetImage2;

	private void Start()
	{
		Invoke("EnableFirstNextButton", 4.3f);
	}

	public void GoToFinalCutscene()
	{
		Invoke("EnableFinalCutscene", 2f);
		Invoke("EnableButton6", 6f);
	}

	private void EnableFinalCutscene()
	{
		finalCutsceneScreen.SetActive(value: true);
	}

	private void EnableButton6()
	{
		nextButton6Holder.SetActive(value: true);
	}

	public void SetPetName()
	{
		PlayerPrefs.SetString("PetName", petNameInputField.text);
		setPetName.text = PlayerPrefs.GetString("PetName");
		inputField.SetActive(value: false);
		setPetName.gameObject.SetActive(value: true);
		Invoke("EnableButton4", 1.3f);
		namedParticles.SetActive(value: true);
	}

	private void EnableButton4()
	{
		nextButton4Holder.SetActive(value: true);
	}

	private void EnableFirstNextButton()
	{
		firstNextButton.SetActive(value: true);
	}

	public void InvokePickPetScreen()
	{
		Invoke("EnablePickPetScreen", 1.3f);
	}

	private void EnablePickPetScreen()
	{
		pickPetScreen.SetActive(value: true);
	}

	public void PickPet(int petIndex)
	{
		petString = "PickPet" + petIndex;
		PlayerPrefs.SetInt("Pet", petIndex);
		happyPetImage1.sprite = happyPet[petIndex];
		happyPetImage2.sprite = happyPet[petIndex];
		sleepyPetImage.sprite = couchPet[petIndex];
		sickPetImage.sprite = sickPet[petIndex];
		sickPetImage2.sprite = sickPet[petIndex];
		pickedPetText1.text = JSONAccess.Instance.GetMiscText("RevealText", petString);
		pickedPetText2.text = JSONAccess.Instance.GetMiscText("RevealText", petString);
		pickedPetText.gameObject.SetActive(value: false);
	}

	public void MovePetTextUp()
	{
		pickedPetText.position = pickedPetText1.transform.position;
		pickedPetText.gameObject.SetActive(value: true);
		StartCoroutine(MovePetUpCoroutine());
		Invoke("NamePetScreen", 1.3f);
	}

	private void NamePetScreen()
	{
		namePetScreen.SetActive(value: true);
	}

	private IEnumerator MovePetUpCoroutine()
	{
		while (Vector3.Distance(pickedPetText.position, pickedPetTextPosition.position) > 0.1f)
		{
			pickedPetText.position = Vector3.Lerp(pickedPetText.position, pickedPetTextPosition.position, 3f * Time.deltaTime);
			yield return null;
		}
		pickedPetText.position = pickedPetTextPosition.position;
	}

	public void MoveTitleTextUp()
	{
		StartCoroutine(MoveTitleTextUpCoroutine());
	}

	private IEnumerator MoveTitleTextUpCoroutine()
	{
		while (Vector3.Distance(titleText.position, titleTextPosition.position) > 0.1f)
		{
			titleText.position = Vector3.Lerp(titleText.position, titleTextPosition.position, 3f * Time.deltaTime);
			yield return null;
		}
		titleText.position = titleTextPosition.position;
	}
}
