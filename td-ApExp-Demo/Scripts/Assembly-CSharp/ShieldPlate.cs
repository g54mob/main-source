using System;
using System.Linq;
using UnityEngine;

public class ShieldPlate : MonoBehaviour
{
	public bool isPlateActive;

	private Rigidbody2D rb2d;

	public ModuleShield moduleShield;

	private const float LEFT_EDGE_PADDING = 0.16f;

	private bool isAudioPlaying;

	private Vector3 moveVector;

	private float autoMoveTimer;

	private float autoMoveDelay = 2f;

	private Module lowestModule;

	public GameObject ShieldN;

	public GameObject ShieldS;

	public event Action<Module> OnModuleCovered;

	public event Action<Module> OnModuleUncovered;

	private void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		if (moduleShield.IsFullyBroken || moduleShield.IsEMPattached)
		{
			return;
		}
		autoMoveTimer -= Time.deltaTime;
		if (autoMoveTimer <= 0f)
		{
			autoMoveTimer = autoMoveDelay;
			lowestModule = (from module in Train.Instance.Modules
				where (bool)module && (bool)module.HealthComponent
				orderby module.HealthComponent.HealthCurrent
				select module).FirstOrDefault();
		}
		if (isPlateActive)
		{
			InputMoveVelocity();
		}
		else
		{
			if (!(moduleShield.protectLowest & (lowestModule != null)))
			{
				Stop();
				return;
			}
			AutoMoveVelocity();
		}
		Move();
	}

	private void InputMoveVelocity()
	{
		moveVector = moduleShield.Interactable.Interactor.playerController.RawInput;
	}

	private void AutoMoveVelocity()
	{
		Vector3 vector = lowestModule.transform.position - base.transform.position;
		vector.y = 0f;
		if (vector.magnitude > 0.01f)
		{
			vector = vector.normalized;
			moveVector = vector;
		}
		else
		{
			moveVector = Vector3.zero;
		}
	}

	public void Stop()
	{
		isAudioPlaying = false;
		moduleShield.StopModuleUniqueSound(stopAll: true);
		rb2d.velocity = Vector2.zero;
	}

	private void Move()
	{
		base.transform.rotation = base.transform.parent.rotation;
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, 0f);
		float num = GetComponentInChildren<SpriteRenderer>().bounds.size.x / 2f;
		float num2 = Train.Instance.GetLastWagonLeftPosX() + num;
		float num3 = Train.Instance.GetFirstWagonRightPosX() - num - 0.16f;
		if ((moveVector.x < 0f && base.transform.position.x > num2) || (moveVector.x > 0f && base.transform.position.x < num3))
		{
			rb2d.velocity = moveVector * moduleShield.GetUpgradedStatValueByStatType(StatTypes.transformSpeed) * Time.fixedDeltaTime;
			if (!isAudioPlaying)
			{
				isAudioPlaying = true;
				moduleShield.PlayModuleUniqueSound();
			}
		}
		else
		{
			Stop();
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.transform.tag == "Train")
		{
			base.transform.SetParent(collision.transform);
		}
		if (collision.TryGetComponent<Module>(out var component))
		{
			this.OnModuleCovered?.Invoke(component);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.TryGetComponent<Module>(out var component))
		{
			this.OnModuleUncovered?.Invoke(component);
		}
	}
}
