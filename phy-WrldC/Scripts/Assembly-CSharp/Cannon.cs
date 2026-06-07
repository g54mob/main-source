using System;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : BaseComponentView
{
	private GameObject cannonBallPrefab;

	private LogicIO fireInput;

	private Vector3 firePosition;

	private Vector3 fireDirection;

	private int totalBullets;

	private float bulletVelocity;

	private int bulletsCounter;

	private bool isUnlimitedAmmo;

	private Rigidbody cannonRb;

	private List<CannonBall> cannonBalls;

	public event Action<Vector3, Vector3> OnFireEvent;

	public event Action OnEmptyEvent;

	public override void SetUpToAction()
	{
		base.SetUpToAction();
		bulletsCounter = 0;
		isUnlimitedAmmo = base.BlockBodyView.ParentBlockView.ParentCreationView.IsUnlimitedAmmo;
	}

	protected void Update()
	{
		if (!fireInput.ReadDigitalSignal())
		{
			return;
		}
		if (bulletsCounter < totalBullets || isUnlimitedAmmo)
		{
			if (isUnlimitedAmmo && bulletsCounter >= totalBullets)
			{
				bulletsCounter = 0;
			}
			CannonBall cannonBall = cannonBalls[bulletsCounter];
			cannonBall.SetExistence(isExisting: true);
			Vector3 velocity = cannonRb.velocity;
			Vector3 vector = base.transform.TransformPoint(firePosition);
			Vector3 vector2 = base.transform.TransformDirection(fireDirection);
			cannonBall.transform.position = vector;
			Rigidbody rigidbody = cannonBall.GetRigidbody();
			rigidbody.velocity = Vector3.zero;
			rigidbody.angularVelocity = Vector3.zero;
			rigidbody.isKinematic = false;
			rigidbody.AddForce(velocity + vector2 * bulletVelocity, ForceMode.VelocityChange);
			cannonBall.transform.SetParent(base.BlockBodyView.ParentBlockView.transform);
			cannonRb.AddForceAtPosition(-vector2 * bulletVelocity * 0.25f, vector, ForceMode.Impulse);
			bulletsCounter++;
			this.OnFireEvent?.Invoke(vector, vector2);
		}
		else
		{
			this.OnEmptyEvent?.Invoke();
		}
	}

	protected override void InternalInitialize(Properties properties)
	{
		base.InternalInitialize(properties);
		cannonBalls = new List<CannonBall>();
		firePosition = properties.GetPropertyAsVector3("firePos");
		fireDirection = properties.GetPropertyAsVector3("fireDir");
		totalBullets = properties.GetPropertyAsInt("bullets");
		bulletVelocity = properties.GetPropertyAsFloat("velocity");
		cannonBallPrefab = Resources.Load<GameObject>("cannon_ball");
		cannonRb = GetComponent<Rigidbody>();
		for (int i = 0; i < totalBullets; i++)
		{
			CannonBall component = UnityEngine.Object.Instantiate(cannonBallPrefab, base.transform, worldPositionStays: false).GetComponent<CannonBall>();
			component.SetExistence(isExisting: false);
			cannonBalls.Add(component);
			allComponentRigidbodies.Add(component.GetRigidbody());
		}
		base.gameObject.AddComponent<CannonStylesApplier>();
	}

	protected override void SetInitializeConfiguration(Properties properties)
	{
		base.SetInitializeConfiguration(properties);
		fireInput = base.BlockBodyView.AddLogicIO(new LogicIO("cannon_fire", LogicIODirection.Input, digitalSignal: false)
		{
			DefaultKeyType = LogicIODefaultKeyType.UpToDown
		});
	}

	protected override void InternalResetComponent()
	{
		base.InternalResetComponent();
		foreach (CannonBall cannonBall in cannonBalls)
		{
			cannonBall.SetExistence(isExisting: false);
			cannonBall.transform.SetParent(base.transform);
			cannonBall.transform.localPosition = Vector3.zero;
			cannonBall.transform.localRotation = Quaternion.identity;
		}
	}

	private void OnDestroy()
	{
		if (cannonBalls == null || cannonBalls.Count == 0)
		{
			return;
		}
		foreach (CannonBall cannonBall in cannonBalls)
		{
			if (cannonBall != null)
			{
				UnityEngine.Object.Destroy(cannonBall.gameObject);
			}
		}
	}

	protected override void InternalInitializeGizmos<CannonModel>(CannonModel componentModel)
	{
		base.InternalInitializeGizmos(componentModel);
		GameObject obj = InstantiateGizmoObject("CannonGizmo");
		Vector3 propertyAsVector = componentModel.Properties.GetPropertyAsVector3("firePos");
		Vector3 propertyAsVector2 = componentModel.Properties.GetPropertyAsVector3("fireDir");
		obj.transform.localPosition = propertyAsVector;
		obj.transform.localRotation = Quaternion.LookRotation(propertyAsVector2, Vector3.up);
	}

	public override string GetComponentName()
	{
		return typeof(Cannon).Name;
	}
}
