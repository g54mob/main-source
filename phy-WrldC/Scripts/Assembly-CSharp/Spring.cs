using UnityEngine;

public class Spring : BaseComponentView
{
	private BlockBodyView secondBodyView;

	private Rigidbody secondBodyRb;

	private ConfigurableJoint configurableJoint;

	public override void SetUpToAction()
	{
		base.SetUpToAction();
		GameObject obj = base.transform.FindChildRecursively("Bar").gameObject;
		obj.AddComponent<BarPositioner>().Initialize(base.gameObject, secondBodyView.gameObject);
		obj.AddComponent<BarPositionerReplay>();
		configurableJoint = GetComponent<ConfigurableJoint>();
		if (configurableJoint == null)
		{
			configurableJoint = base.gameObject.AddComponent<ConfigurableJoint>();
		}
		configurableJoint.connectedBody = secondBodyRb;
		configurableJoint.xMotion = ConfigurableJointMotion.Locked;
		configurableJoint.yMotion = ConfigurableJointMotion.Limited;
		configurableJoint.zMotion = ConfigurableJointMotion.Locked;
		configurableJoint.angularXMotion = ConfigurableJointMotion.Locked;
		configurableJoint.angularYMotion = ConfigurableJointMotion.Locked;
		configurableJoint.angularZMotion = ConfigurableJointMotion.Locked;
		configurableJoint.linearLimitSpring = new SoftJointLimitSpring
		{
			spring = 6000f,
			damper = 100f
		};
		configurableJoint.linearLimit = new SoftJointLimit
		{
			limit = 0.001f,
			bounciness = 0.5f,
			contactDistance = 0f
		};
		GameObject gameObject = new GameObject("OrientationTempObject");
		gameObject.transform.SetParent(base.transform.parent);
		gameObject.transform.position = base.transform.position;
		gameObject.transform.LookAt(secondBodyView.gameObject.transform, Vector3.up);
		configurableJoint.axis = base.transform.parent.InverseTransformDirection(gameObject.transform.up);
		configurableJoint.secondaryAxis = base.transform.parent.InverseTransformDirection(gameObject.transform.forward);
		Object.Destroy(gameObject);
	}

	protected override void InternalInitialize(Properties properties)
	{
		base.InternalInitialize(properties);
		secondBodyView = base.BlockBodyView.ParentBlockView.GetBlockBodyView(1);
		secondBodyRb = secondBodyView.GetComponent<Rigidbody>();
	}

	protected override void InternalResetComponent()
	{
		base.InternalResetComponent();
		if (configurableJoint != null)
		{
			Object.Destroy(configurableJoint);
		}
	}

	public override string GetComponentName()
	{
		return typeof(Spring).Name;
	}
}
