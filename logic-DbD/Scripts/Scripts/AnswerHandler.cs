using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class AnswerHandler : MonoBehaviour
{
	[SerializeField]
	private TMP_InputField answerInput;

	[SerializeField]
	private NotificationHandler answerHandler;

	[SerializeField]
	private LevelManager levelManager;

	[SerializeField]
	private Image warrantImage;

	[SerializeField]
	private Button warrantButton;

	[SerializeField]
	private ArrestAnimator arrestAnimator;

	[SerializeField]
	private GameObject confirmationPrefab;

	[SerializeField]
	private GameObject arrestSliderPrefab;

	[SerializeField]
	private AssistantController assistant;

	[SerializeField]
	private Settings settings;

	[SerializeField]
	private CoroutineRunner runner;

	[SerializeField]
	private EmergencyMessagePopup emergencyMessagePopup;

	private static string culprit;

	private static ICollection<string> arrestedSuspects;

	private Canvas canvas;

	private GameObject popup;

	private GameObject notFound;

	protected ArrestAudio audioPlayer;

	private bool hasBeenIncorrect;

	public void Start()
	{
		arrestedSuspects = new HashSet<string>();
		CreateTablesHelpers.LoadCollection(arrestedSuspects, Save.ARRESTED_TABLE);
		audioPlayer = GameObject.Find("/Canvas/Audio Controllers/Arrest").GetComponent<ArrestAudio>();
		canvas = UIUtils.FindCanvasFromChild(base.transform);
		TMP_InputField tMP_InputField = answerInput;
		tMP_InputField.onValidateInput = (TMP_InputField.OnValidateInput)Delegate.Combine(tMP_InputField.onValidateInput, (TMP_InputField.OnValidateInput)((string input, int charIndex, char addedChar) => (char.IsLetter(addedChar) || addedChar == ' ') ? addedChar : '\0'));
		SetWarrantImage();
	}

	public void SubmitAnswerIfValid(InputAction.CallbackContext context)
	{
		if (answerInput.isFocused && answerInput.text.Length > 0)
		{
			SubmitAnswer();
		}
	}

	private void OnEnable()
	{
		GetComponent<PlayerInput>().actions["Enter"].performed += SubmitAnswerIfValid;
	}

	private void OnDisable()
	{
		GetComponent<PlayerInput>().actions["Enter"].performed -= SubmitAnswerIfValid;
	}

	public static void SetAnswer(string name)
	{
		culprit = name;
	}

	public void SubmitAnswer()
	{
		audioPlayer.PlayWarrant();
		if (popup == null)
		{
			popup = UnityEngine.Object.Instantiate(confirmationPrefab, base.transform.position, Quaternion.identity, canvas.transform);
			UIUtils.SetPenultimateLayer(popup);
			Confirmation component = popup.GetComponent<Confirmation>();
			component.SetYesButton(ValidateAnswer);
			component.SetNoButton(component.GetToolbar().Close);
		}
		PanelManager.OpenWindow(popup);
	}

	public void ValidateAnswer()
	{
		bool isCorrectArrest = false;
		string a = RemoveWhitespace(culprit);
		string b = RemoveWhitespace(answerInput.text);
		if (string.Equals("zoran", b, StringComparison.OrdinalIgnoreCase) || string.Equals("zoranponziscam", b, StringComparison.OrdinalIgnoreCase))
		{
			if (emergencyMessagePopup.InstantiatePopupMessage(MessageSpawner.MessageCodes.ArrestZoran))
			{
				UnityEngine.Object.Destroy(popup);
				return;
			}
		}
		else if (string.Equals("frogman", b, StringComparison.OrdinalIgnoreCase) && emergencyMessagePopup.InstantiatePopupMessage(MessageSpawner.MessageCodes.FrogMan))
		{
			UnityEngine.Object.Destroy(popup);
			return;
		}
		if (string.Equals(a, b, StringComparison.OrdinalIgnoreCase) || (CreateTables.DEV_MODE && string.Equals("debug", b, StringComparison.OrdinalIgnoreCase)))
		{
			isCorrectArrest = true;
		}
		else
		{
			if (!IsValidCulprit(answerInput.text.Trim()))
			{
				CreateMessagePopup(answerInput.text + " is not in our list of suspects being considered for the current case. Are you sure you wrote down the right person?");
				return;
			}
			if (HasBeenArrested(answerInput.text.Trim()))
			{
				CreateMessagePopup(answerInput.text.ToUpper() + " has already been arrested!");
				return;
			}
			if (arrestedSuspects == null)
			{
				arrestedSuspects = new HashSet<string>();
			}
			arrestedSuspects.Add(answerInput.text.ToUpperInvariant());
			CreateTablesHelpers.SaveCollection(arrestedSuspects, Save.ARRESTED_TABLE);
			Debug.Log("Nope");
		}
		UIUtils.CloseAllPanels(canvas);
		audioPlayer.PlayStamp();
		GameObject obj = UnityEngine.Object.Instantiate(arrestSliderPrefab, base.transform.position, Quaternion.identity, canvas.transform);
		UIUtils.SetPenultimateLayer(obj);
		PanelManager.OpenWindow(obj);
		obj.GetComponent<ArrestSlider>().StartArrest(arrestAnimator, isCorrectArrest, answerInput.text);
		GetComponent<Panel>().ClosePanel();
		popup.GetComponent<Panel>().ClosePanel();
		runner.StartCoroutine(() => settings.IsAssistantDisabled() ? null : assistant.StartDancing());
		MakeReadOnly();
	}

	private void CreateMessagePopup(string message)
	{
		if (notFound == null)
		{
			notFound = answerHandler.CreateNotificationPanel(message);
		}
		else
		{
			answerHandler.SetNotificationMessage(notFound, message);
		}
		PanelManager.OpenWindow(notFound);
		UnityEngine.Object.Destroy(popup);
	}

	public void CheckEnableSubmit()
	{
		warrantButton.interactable = answerInput.text.Length > 0;
	}

	private string RemoveWhitespace(string text)
	{
		return text.Replace(" ", string.Empty);
	}

	private void MakeReadOnly()
	{
		warrantButton.interactable = false;
		answerInput.interactable = false;
	}

	public void SetWarrantImage()
	{
		CreateTablesHelpers.SaveCollection(arrestedSuspects, Save.ARRESTED_TABLE);
		int currLevel = LevelManager.GetCurrLevel();
		warrantImage.sprite = ResourcesManager.GetImage($"Arrest Warrants/{currLevel}");
		ClearWarrantImage();
	}

	public void ClearArrestedSuspects()
	{
		arrestedSuspects = null;
	}

	public void ResetWarrant()
	{
		warrantButton.interactable = true;
		answerInput.interactable = true;
	}

	public void ClearWarrantImage()
	{
		answerInput.text = "";
		answerInput.interactable = true;
	}

	private static ICollection<string> GetAllPossibleSuspects()
	{
		return LevelManager.GetCurrLevel() switch
		{
			0 => Level0.GetAllPossibleSuspects(), 
			1 => Level1.GetAllPossibleSuspects(), 
			2 => Level2.GetAllPossibleSuspects(), 
			3 => Level3.GetAllPossibleSuspects(), 
			_ => new List<string>(), 
		};
	}

	private static bool IsValidCulprit(string name)
	{
		if (name.Split(' ').Length != 2)
		{
			return false;
		}
		return GetAllPossibleSuspects().Contains(name, StringComparer.OrdinalIgnoreCase);
	}

	private static bool HasBeenArrested(string suspect)
	{
		if (arrestedSuspects != null)
		{
			return arrestedSuspects.Contains(suspect, StringComparer.OrdinalIgnoreCase);
		}
		return false;
	}
}
