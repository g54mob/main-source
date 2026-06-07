using System;
using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractManager : NetworkBehaviour
{
	public Camera mainCamera;

	public bool checkForInteractables = true;

	public LayerMask interactableLayer;

	public Interactable curInteractable;

	public Interactable prevInteractable;

	public float detectDistance = 5f;

	public PlayerManager playerMan;

	public FPSController fpsScript;

	public GameObject promptObj;

	public TextMeshProUGUI promptText;

	private float taskCompletion;

	private float taskCompletionMax;

	public Image completingTaskFillAmount;

	private bool justStartLookingAtInteractable;

	public GameObject holdText;

	private bool justStopHoldInteracting;

	private bool justStartHoldingInteractable = true;

	private bool justStopHoldingInteractable = true;

	public bool holdInteracting;

	private void Start()
	{
		fpsScript = playerMan.fpsScript;
		if (!base.isLocalPlayer)
		{
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (checkForInteractables)
		{
			ShootRay();
		}
	}

	private void ShootRay()
	{
		if (curInteractable != null && !playerMan.paused)
		{
			if (!curInteractable.gameObject.activeInHierarchy || !curInteractable.interactable)
			{
				curInteractable = null;
				return;
			}
			if (!curInteractable.holdInteractable)
			{
				taskCompletion = 0f;
				holdText.SetActive(value: false);
				if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
				{
					curInteractable.Interact(playerMan);
					promptObj.SetActive(value: false);
				}
			}
			else
			{
				justStopHoldInteracting = true;
				holdText.SetActive(value: true);
				if (justStartLookingAtInteractable)
				{
					if (Input.GetKey(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
					{
						return;
					}
					justStartLookingAtInteractable = false;
				}
				taskCompletionMax = curInteractable.holdInteractableTime;
				if (Input.GetKey(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind7"))))
				{
					holdInteracting = true;
					if (justStartHoldingInteractable)
					{
						curInteractable.startInteractingEvent.Invoke();
						justStartHoldingInteractable = false;
						justStopHoldingInteractable = true;
					}
					promptObj.SetActive(value: false);
					if (PlayerPrefs.GetInt("CamBobbing", 1) != 0)
					{
						playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: true);
					}
					completingTaskFillAmount.gameObject.SetActive(value: true);
					taskCompletion += Time.deltaTime;
					ClientPlayer.Instance.fpsScript.lockCam = true;
					ClientPlayer.Instance.fpsScript.lockMove = true;
				}
				else
				{
					holdInteracting = false;
					if (justStopHoldingInteractable)
					{
						curInteractable.stopInteractingEvent.Invoke();
						justStopHoldingInteractable = false;
						justStartHoldingInteractable = true;
					}
					promptObj.SetActive(value: true);
					playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: false);
					completingTaskFillAmount.gameObject.SetActive(value: false);
					taskCompletion = 0f;
					if (!playerMan.paused)
					{
						ClientPlayer.Instance.fpsScript.lockCam = false;
						ClientPlayer.Instance.fpsScript.lockMove = false;
					}
				}
				completingTaskFillAmount.fillAmount = taskCompletion / taskCompletionMax;
				if (taskCompletion > taskCompletionMax)
				{
					holdInteracting = false;
					playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: false);
					if (!playerMan.paused)
					{
						ClientPlayer.Instance.fpsScript.lockCam = false;
						ClientPlayer.Instance.fpsScript.lockMove = false;
					}
					completingTaskFillAmount.gameObject.SetActive(value: false);
					taskCompletion = 0f;
					curInteractable.Interact(playerMan);
					curInteractable.StopLookAt();
					prevInteractable = curInteractable;
					curInteractable = null;
				}
			}
		}
		else
		{
			if (justStopHoldInteracting)
			{
				justStopHoldInteracting = false;
				playerMan.fpsScript.headbobAnim.SetBool("Tasking", value: false);
				if (!playerMan.paused)
				{
					ClientPlayer.Instance.fpsScript.lockCam = false;
					ClientPlayer.Instance.fpsScript.lockMove = false;
				}
			}
			holdInteracting = false;
			completingTaskFillAmount.gameObject.SetActive(value: false);
			holdText.SetActive(value: false);
			taskCompletion = 0f;
			justStartLookingAtInteractable = true;
			promptObj.SetActive(value: false);
		}
		if (holdInteracting)
		{
			return;
		}
		if (Physics.Raycast(new Ray(mainCamera.transform.position, mainCamera.transform.forward), out var hitInfo, detectDistance, interactableLayer))
		{
			Interactable componentInParent = hitInfo.collider.GetComponentInParent<Interactable>();
			if (!(componentInParent != curInteractable))
			{
				return;
			}
			if (prevInteractable != componentInParent && (bool)prevInteractable)
			{
				prevInteractable.StopLookAt();
			}
			if (curInteractable != null)
			{
				curInteractable.StopLookAt();
				prevInteractable = curInteractable;
				curInteractable = null;
			}
			curInteractable = componentInParent;
			if (curInteractable != null && curInteractable.interactable)
			{
				if (curInteractable.GetComponent<ConstrictedInteractable>() != null)
				{
					if (curInteractable.GetComponent<ConstrictedInteractable>().constrictionAllows)
					{
						curInteractable.LookAt();
						promptObj.SetActive(value: true);
						promptText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
						promptText.text = JSONAccess.Instance.GetMiscText("Interact Prompts", curInteractable.interactText);
					}
				}
				else
				{
					curInteractable.LookAt();
					promptObj.SetActive(value: true);
					promptText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
					promptText.text = JSONAccess.Instance.GetMiscText("Interact Prompts", curInteractable.interactText);
				}
			}
			else if (curInteractable != null && !curInteractable.interactable && !holdInteracting)
			{
				promptObj.SetActive(value: false);
				curInteractable.StopLookAt();
				prevInteractable = curInteractable;
				curInteractable = null;
			}
			else if ((bool)curInteractable && (bool)curInteractable.GetComponent<ConstrictedInteractable>() && !curInteractable.GetComponent<ConstrictedInteractable>().constrictionAllows && !holdInteracting)
			{
				promptObj.SetActive(value: false);
				curInteractable.StopLookAt();
				prevInteractable = curInteractable;
				curInteractable = null;
			}
		}
		else if (curInteractable != null && !holdInteracting)
		{
			curInteractable.StopLookAt();
			prevInteractable = curInteractable;
			curInteractable = null;
		}
	}

	public KeyCode ConvertStringToKeyCode(string keyName)
	{
		return keyName.ToLower() switch
		{
			"left ctrl" => KeyCode.LeftControl, 
			"LeftControl" => KeyCode.LeftControl, 
			"right ctrl" => KeyCode.RightControl, 
			"left shift" => KeyCode.LeftShift, 
			"LeftShift" => KeyCode.LeftShift, 
			"right shift" => KeyCode.RightShift, 
			"shift" => KeyCode.LeftShift, 
			"ctrl" => KeyCode.LeftControl, 
			_ => (KeyCode)Enum.Parse(typeof(KeyCode), keyName, ignoreCase: true), 
		};
	}

	public override bool Weaved()
	{
		return true;
	}
}
