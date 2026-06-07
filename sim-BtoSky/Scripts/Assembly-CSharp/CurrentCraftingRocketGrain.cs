using System;
using UnityEngine;

public class CurrentCraftingRocketGrain : MonoBehaviour, IInteractable
{
	public SkinnedMeshRenderer propellant;

	public GameObject stick;

	public ParticleSystem ps;

	private float stack;

	private float maxStack = 20f;

	public GameObject motorPrefab;

	public AnimationCurve powerCurve;

	private float igniteCount;

	private float igniteTime = 1f;

	private bool igniting;

	private float launchDuration;

	private float launchTimer;

	private float failDuration;

	public bool fail;

	private bool burnt;

	private bool craftingCompleted;

	private Outline outLine;

	public string InteractionText { get; set; } = "Get";

	public static event Action OnTestingCompleted;

	private void Start()
	{
		stack = 0f;
		igniteCount = 0f;
		igniting = false;
		launchDuration = 1.5f;
		failDuration = launchDuration * 0.8f;
		launchTimer = 0f;
		if (ps != null)
		{
			ps.Stop();
		}
		outLine = GetComponent<Outline>();
		if (outLine != null)
		{
			outLine.enabled = false;
		}
		GameManager.S.OnMotorToTheNextStep += S_OnMotorToTheNextStep;
	}

	private void OnDestroy()
	{
		GameManager.S.OnMotorToTheNextStep -= S_OnMotorToTheNextStep;
	}

	private void S_OnMotorToTheNextStep(object sender, EventArgs e)
	{
		propellant.SetBlendShapeWeight(0, 100f);
	}

	private void Update()
	{
		if (!igniting)
		{
			return;
		}
		launchTimer += Time.deltaTime;
		float num = launchTimer;
		if (stack > 0f)
		{
			stack -= Time.deltaTime * 20f;
			propellant.SetBlendShapeWeight(0, stack);
		}
		if (fail)
		{
			if (num >= failDuration)
			{
				igniting = false;
				launchTimer = 0f;
				igniteCount = 0f;
				if (ps != null)
				{
					ps.Stop();
				}
				AudioManager.S.StopCookingSFX();
				GameManager.S.GrainExploded();
				AudioManager.S.PlayDoorBell(AudioManager.S.motorFail);
			}
		}
		else if (num >= launchDuration)
		{
			igniting = false;
			launchTimer = 0f;
			igniteCount = 0f;
			if (ps != null)
			{
				ps.Stop();
			}
			AudioManager.S.StopTestingSound();
			CurrentCraftingRocketGrain.OnTestingCompleted?.Invoke();
		}
		burnt = true;
	}

	public void HideStick()
	{
		stick.gameObject.SetActive(value: false);
	}

	public void ShowStick()
	{
		stick.SetActive(value: true);
	}

	public void CastingStart()
	{
		stick.SetActive(value: true);
		propellant.SetBlendShapeWeight(0, 0f);
	}

	public void PowderOnMold()
	{
		if (stack < 100f)
		{
			stack += Time.deltaTime * 20f;
			propellant.SetBlendShapeWeight(0, stack);
		}
		else
		{
			propellant.SetBlendShapeWeight(0, 100f);
			stick.SetActive(value: false);
			GameManager.S.MotorToTheNextStep();
		}
	}

	public void Interact()
	{
		if (craftingCompleted)
		{
			GameManager.S.UnlockNewMotor(motorPrefab);
		}
		UnityEngine.Object.Destroy(base.gameObject);
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

	public void Ignite()
	{
		if (!igniting && !burnt)
		{
			if (igniteCount < igniteTime)
			{
				igniteCount += Time.deltaTime;
				return;
			}
			igniting = true;
			GameManager.S.GrainIgnited();
			ps.Play();
			AudioManager.S.PlayCookingSFX(AudioManager.S.motorTesting, 1f);
			stack = 100f;
		}
	}
}
