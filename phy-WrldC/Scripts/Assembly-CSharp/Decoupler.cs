using System;
using UnityEngine;

public class Decoupler : BaseComponentView
{
	private FixedJoint decouplerFixedJoint;

	private LogicIO activeInput;

	private LogicIO separatedOutput;

	private BlockBodyView bottomBlockView;

	private float breakForce;

	private bool alreadyInterconnectedBlocksUpdated;

	private Rigidbody topRigidbody;

	private Rigidbody bottomRigidbody;

	private float breakImpulseForce;

	private float bodyMass;

	public event Action OnActivatedEvent;

	public event Action OnJointBreakEvent;

	public override void SetUpToAction()
	{
		base.SetUpToAction();
		decouplerFixedJoint = base.gameObject.AddComponent<FixedJoint>();
		decouplerFixedJoint.breakForce = breakForce;
		decouplerFixedJoint.breakTorque = breakForce;
		decouplerFixedJoint.enableCollision = true;
		decouplerFixedJoint.connectedBody = bottomBlockView.gameObject.GetComponent<Rigidbody>();
		alreadyInterconnectedBlocksUpdated = false;
		if (base.BlockBodyView.ParentBlockView.ParentCreationView.IsUnbreakableCreation)
		{
			decouplerFixedJoint.breakForce = float.PositiveInfinity;
			decouplerFixedJoint.breakTorque = float.PositiveInfinity;
		}
	}

	protected void Update()
	{
		if (activeInput.ReadDigitalSignal() && decouplerFixedJoint != null)
		{
			UnityEngine.Object.Destroy(decouplerFixedJoint);
			topRigidbody.AddRelativeForce(Vector3.up * breakImpulseForce * bodyMass, ForceMode.Impulse);
			bottomRigidbody.AddRelativeForce(Vector3.up * (0f - breakImpulseForce) * bodyMass, ForceMode.Impulse);
			this.OnActivatedEvent?.Invoke();
		}
		if (decouplerFixedJoint == null && !alreadyInterconnectedBlocksUpdated)
		{
			base.IsBodiesSplited = true;
			base.BlockBodyView.ParentBlockView.ParentCreationView.OrderAnInterconnectionsUpdate();
			alreadyInterconnectedBlocksUpdated = true;
			this.OnJointBreakEvent?.Invoke();
		}
		separatedOutput.SetSignal(decouplerFixedJoint == null);
	}

	protected override void InternalInitialize(Properties properties)
	{
		base.InternalInitialize(properties);
		breakForce = properties.GetPropertyAsFloat("breakForce");
		breakImpulseForce = 1.75f;
		bottomBlockView = base.BlockBodyView.ParentBlockView.GetBlockBodyView(1);
		topRigidbody = GetComponent<Rigidbody>();
		bottomRigidbody = bottomBlockView.GetComponent<Rigidbody>();
		bodyMass = topRigidbody.mass;
		base.gameObject.AddComponent<DecouplerStylesApplier>();
	}

	protected override void SetInitializeConfiguration(Properties properties)
	{
		base.SetInitializeConfiguration(properties);
		activeInput = base.BlockBodyView.AddLogicIO(new LogicIO("decoupler_active", LogicIODirection.Input, digitalSignal: false));
		separatedOutput = base.BlockBodyView.AddLogicIO(new LogicIO("decouple_separated", LogicIODirection.Output, 0f));
	}

	protected override void InternalResetComponent()
	{
		base.InternalResetComponent();
		if (decouplerFixedJoint != null)
		{
			UnityEngine.Object.Destroy(decouplerFixedJoint);
		}
	}

	public override string GetComponentName()
	{
		return typeof(Decoupler).Name;
	}
}
