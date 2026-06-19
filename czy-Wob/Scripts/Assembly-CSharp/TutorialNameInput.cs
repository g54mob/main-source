using TMPro;
using UnityEngine;

public class TutorialNameInput : MonoBehaviour
{
	public TMP_InputField inputRef;

	public TextMeshProUGUI doneText;

	public CoreButtonUnityGUI doneButton;

	private float doneTextInactiveAlpha = 0.75f;

	private DogRegistration dogRegRef;

	private void Awake()
	{
		LockDoneButton();
		inputRef.characterLimit = GlobalProperties.dogNameCharLimit;
		dogRegRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
	}

	private void Update()
	{
		string text = inputRef.text;
		if (text.Length < 1)
		{
			LockDoneButton();
		}
		else
		{
			UnlockDoneButton();
		}
		doneButton.SetCallbackArg(text);
	}

	public void RandomizeName()
	{
		inputRef.text = dogRegRef.ChooseRandomDogNameNonDestructive(inputRef.text);
	}

	private void LockDoneButton()
	{
		doneButton.interactable = false;
		doneText.alpha = doneTextInactiveAlpha;
	}

	private void UnlockDoneButton()
	{
		doneText.alpha = 1f;
		doneButton.interactable = true;
	}
}
