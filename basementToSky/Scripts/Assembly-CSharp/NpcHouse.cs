using System;
using System.Collections;
using Suburb;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Localization;

public class NpcHouse : MonoBehaviour, IInteractable
{
	private LocalizedString interactionText = new LocalizedString("MyTable", "interaction-knock");

	[SerializeField]
	private NPC npc;

	public CinemachineCamera doorCam;

	private Animator myAnimator;

	private Animator additionalAnimator;

	public bool objectOpen;

	public bool objectOpenAdditional;

	public GameObject animateAdditional;

	private bool hasAdditional;

	private float myNormalizedTime;

	private BoxCollider coll;

	private int defaultLayer;

	[SerializeField]
	private string ignoreLayerName = "DoorIgnorePlayer";

	private int ignoreLayer;

	public float changeSpeed = 5f;

	private Outline outLine;

	public string InteractionText
	{
		get
		{
			if (interactionText != null && !interactionText.IsEmpty)
			{
				return interactionText.GetLocalizedString();
			}
			return "Knock";
		}
	}

	public static event Action OnDoorKnocked;

	private void Awake()
	{
		defaultLayer = base.gameObject.layer;
		ignoreLayer = LayerMask.NameToLayer(ignoreLayerName);
	}

	private void Start()
	{
		myAnimator = GetComponent<Animator>();
		if (myAnimator == null)
		{
			myAnimator = GetComponentInParent<Animator>();
		}
		coll = GetComponent<BoxCollider>();
		if (objectOpen)
		{
			myAnimator.Play("Open", 0, 1f);
		}
		if (animateAdditional != null)
		{
			if ((bool)animateAdditional.GetComponent<SimpleOpenClose>())
			{
				additionalAnimator = animateAdditional.GetComponent<Animator>();
				hasAdditional = true;
				objectOpenAdditional = animateAdditional.GetComponent<SimpleOpenClose>().objectOpen;
			}
			else
			{
				hasAdditional = false;
			}
		}
		outLine = GetComponent<Outline>();
		if (outLine != null)
		{
			outLine.enabled = false;
		}
	}

	private void Update()
	{
	}

	public void Interact()
	{
		if (outLine != null)
		{
			outLine.enabled = false;
		}
		DoorKnocked();
	}

	public void OnDetected()
	{
		if (outLine != null)
		{
			outLine.enabled = true;
		}
	}

	public void OnLost()
	{
		if (outLine != null)
		{
			outLine.enabled = false;
		}
	}

	public void DoorKnocked()
	{
		NpcHouse.OnDoorKnocked?.Invoke();
		AudioManager.S.PlaySFX(AudioManager.S.knockingDoor);
		doorCam.Priority = 2;
		npc.CheckDoor(this);
	}

	public void Opened()
	{
		ObjectClicked();
		StartCoroutine(ChangeFOVCoroutine(40f));
	}

	public void Closed()
	{
		ObjectClicked();
		StartCoroutine(ChangeFOVCoroutine(70f));
	}

	private void ObjectClicked()
	{
		myNormalizedTime = myAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;
		if (!hasAdditional && (double)myNormalizedTime >= 1.0)
		{
			if (objectOpen)
			{
				AudioManager.S.PlaySFX(AudioManager.S.doorClose);
				myAnimator.Play("Close", 0, 0f);
				objectOpen = false;
			}
			else
			{
				AudioManager.S.PlaySFX(AudioManager.S.doorOpen);
				myAnimator.Play("Open", 0, 0f);
				objectOpen = true;
			}
		}
		if (!hasAdditional || !((double)myNormalizedTime >= 1.0))
		{
			return;
		}
		if (objectOpen)
		{
			AudioManager.S.PlaySFX(AudioManager.S.doorClose);
			myAnimator.Play("Close", 0, 0f);
			objectOpen = false;
			if (objectOpenAdditional)
			{
				additionalAnimator.Play("Close", 0, 0f);
				objectOpenAdditional = false;
			}
		}
		else
		{
			AudioManager.S.PlaySFX(AudioManager.S.doorOpen);
			myAnimator.Play("Open", 0, 0f);
			objectOpen = true;
			if (!objectOpenAdditional)
			{
				additionalAnimator.Play("Open", 0, 0f);
				objectOpenAdditional = true;
			}
		}
	}

	public void DoorColliderOnOff()
	{
		if (base.gameObject.layer == defaultLayer)
		{
			base.gameObject.layer = ignoreLayer;
		}
		else
		{
			StartCoroutine(DoorActiveDelay());
		}
	}

	private IEnumerator DoorActiveDelay()
	{
		yield return new WaitForSeconds(1f);
		base.gameObject.layer = defaultLayer;
		npc.NpcResetPos();
	}

	private IEnumerator ChangeFOVCoroutine(float targetFOV)
	{
		float startFOV = doorCam.Lens.FieldOfView;
		float t = 0f;
		while (t < 1f)
		{
			t += Time.deltaTime * changeSpeed;
			doorCam.Lens.FieldOfView = Mathf.Lerp(startFOV, targetFOV, t);
			yield return null;
		}
		doorCam.Lens.FieldOfView = targetFOV;
	}
}
