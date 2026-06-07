using UltimateReplay;
using UnityEngine;

public class PressureButton : LevelButtonBase
{
	[SerializeField]
	private float stateChangeDelay = 1f;

	[SerializeField]
	private string keyId = "";

	private Renderer[] renderers;

	private Light ledLight;

	private Animator animator;

	private float timeCounter;

	private bool isAnyObjectInButton;

	protected override void Awake()
	{
		base.Awake();
		renderers = GetComponentsInChildren<Renderer>();
		ledLight = GetComponentInChildren<Light>(includeInactive: true);
		SetHighlightVisibility(isVisible: false);
		animator = GetComponent<Animator>();
		timeCounter = stateChangeDelay + 1f;
		isAnyObjectInButton = false;
	}

	protected override void AddReplayComponents()
	{
		base.AddReplayComponents();
		base.gameObject.AddComponent<PressureButtonReplay>();
		Transform transform = base.gameObject.transform.FindChildRecursively("button");
		if (transform != null)
		{
			transform.gameObject.AddComponent<ReplayTransform>();
		}
	}

	public override void Recycle()
	{
		base.Recycle();
		if (animator != null)
		{
			animator.SetBool("IsPressed", value: false);
		}
	}

	public override void SetupToAction()
	{
		base.SetupToAction();
		timeCounter = stateChangeDelay + 1f;
	}

	private void FixedUpdate()
	{
		if (isAnyObjectInButton && !base.IsOn && timeCounter > stateChangeDelay)
		{
			SetHighlightVisibility(isVisible: true);
			if (animator != null)
			{
				animator.SetBool("IsPressed", value: true);
			}
			base.IsOn = true;
			timeCounter = 0f;
			InvokeOnChangedState(isOn: true);
		}
		else if (!isAnyObjectInButton && base.IsOn && timeCounter > stateChangeDelay)
		{
			SetHighlightVisibility(isVisible: false);
			if (animator != null)
			{
				animator.SetBool("IsPressed", value: false);
			}
			base.IsOn = false;
			timeCounter = 0f;
			InvokeOnChangedState(isOn: false);
		}
		if (timeCounter <= stateChangeDelay)
		{
			timeCounter += Time.deltaTime;
		}
		isAnyObjectInButton = false;
	}

	public void SetHighlightVisibility(bool isVisible)
	{
		int num = (isVisible ? 5 : 0);
		Renderer[] array = renderers;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].material.SetColor("_EmissionColor", Color.HSVToRGB(0f, 0f, num));
		}
		ledLight.enabled = isVisible;
	}

	private void OnTriggerEnter(Collider other)
	{
		if ((other.CompareTag("Block") || other.CompareTag("Level")) && !string.IsNullOrEmpty(keyId))
		{
			KeyCrate component = other.gameObject.GetComponent<KeyCrate>();
			if (component != null && component.KeyId == keyId)
			{
				component.SetHighlightVisibility(isVisible: true);
			}
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (!other.CompareTag("Block") && !other.CompareTag("Level"))
		{
			return;
		}
		if (string.IsNullOrEmpty(keyId))
		{
			isAnyObjectInButton = true;
			return;
		}
		KeyCrate component = other.gameObject.GetComponent<KeyCrate>();
		if (component != null && component.KeyId == keyId)
		{
			isAnyObjectInButton = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if ((other.CompareTag("Block") || other.CompareTag("Level")) && !string.IsNullOrEmpty(keyId))
		{
			KeyCrate component = other.gameObject.GetComponent<KeyCrate>();
			if (component != null && component.KeyId == keyId)
			{
				component.SetHighlightVisibility(isVisible: false);
			}
		}
	}
}
