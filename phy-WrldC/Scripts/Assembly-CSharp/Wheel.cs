using System;
using System.Collections.Generic;
using NWH.WheelController3D;
using UltimateReplay;
using UnityEngine;

public class Wheel : BaseComponentView
{
	private class WheelCollisionHandler : MonoBehaviour
	{
		private ConfigurableJoint frictionJoint;

		private void OnCollisionEnter(Collision collision)
		{
			if (!(frictionJoint != null))
			{
				AddFrictionJoint(collision.contacts[0].point);
			}
		}

		private void OnCollisionStay(Collision collision)
		{
			if (!(frictionJoint != null))
			{
				AddFrictionJoint(collision.contacts[0].point);
			}
		}

		private void AddFrictionJoint(Vector3 anchorPosition)
		{
			frictionJoint = base.gameObject.AddComponent<ConfigurableJoint>();
			frictionJoint.anchor = anchorPosition;
			frictionJoint.xMotion = ConfigurableJointMotion.Locked;
			frictionJoint.yMotion = ConfigurableJointMotion.Locked;
			frictionJoint.zMotion = ConfigurableJointMotion.Locked;
			frictionJoint.angularXMotion = ConfigurableJointMotion.Locked;
			frictionJoint.angularYMotion = ConfigurableJointMotion.Locked;
			frictionJoint.angularZMotion = ConfigurableJointMotion.Locked;
			frictionJoint.breakForce = 0f;
			frictionJoint.breakTorque = 0f;
		}
	}

	private PhysicMaterial zeroFriction;

	private float radius;

	private GameObject wheelControllerTemplate;

	private HingeJoint wheelHingeJoint;

	private GameObject wheelColliderObject;

	private Rigidbody blockRigidbody;

	public bool IsWheelMotorActived { get; private set; }

	public WheelMotorWrapper WheelMotor { get; private set; }

	private void Awake()
	{
		zeroFriction = Resources.Load<PhysicMaterial>("ZeroFriction");
		wheelControllerTemplate = Resources.Load<GameObject>("WheelControllerTemplate");
	}

	public override void SetUpToAction()
	{
		base.SetUpToAction();
		WheelMotor = new WheelMotorWrapper();
		IsWheelMotorActived = false;
		HingeJointView correctHingeJointView = GetCorrectHingeJointView(base.BlockBodyView.GetAllHingeJointViews());
		if (correctHingeJointView == null)
		{
			correctHingeJointView = GetCorrectHingeJointView(base.BlockBodyView.GetAllOutsideHingeJoints());
		}
		if (correctHingeJointView != null)
		{
			IsWheelMotorActived = true;
			ConfigureForWheelColliderSource(correctHingeJointView);
			if (correctHingeJointView.MotorJointView != null)
			{
				correctHingeJointView.MotorJointView.Wheel = this;
			}
			wheelHingeJoint = correctHingeJointView.HingeJoint;
		}
	}

	private void SetReplayComponents(GameObject rootGameObject)
	{
		ReplayObject component = GetComponent<ReplayObject>();
		if (component != null)
		{
			UnityEngine.Object.Destroy(component);
		}
		rootGameObject.AddComponent<ReplayObject>().RebuildComponentList();
	}

	private void ConfigureWheelColliders(HingeJointView selectedHingeJointView)
	{
		GetComponent<MeshCollider>().enabled = false;
		int num = 32;
		float num2 = 360 / num;
		float num3 = 0.1f;
		PhysicMaterial sharedMaterial = new PhysicMaterial("new_wheel")
		{
			dynamicFriction = 0f,
			staticFriction = 0f,
			bounciness = 0f,
			frictionCombine = PhysicMaterialCombine.Minimum
		};
		for (int i = 0; i < num; i++)
		{
			GameObject obj = new GameObject("sphere_" + i);
			obj.transform.SetParent(base.transform.parent);
			obj.layer = LayerNames.Wheel;
			SphereCollider sphereCollider = obj.AddComponent<SphereCollider>();
			sphereCollider.radius = num3;
			sphereCollider.sharedMaterial = sharedMaterial;
			float x = 0f;
			float y = (radius - num3) * Mathf.Sin((float)i * num2 * ((float)Math.PI / 180f));
			float z = (radius - num3) * Mathf.Cos((float)i * num2 * ((float)Math.PI / 180f));
			Vector3 vector = new Vector3(x, y, z);
			obj.transform.localPosition = vector;
			obj.transform.localRotation = Quaternion.LookRotation(vector);
			obj.AddComponent<Rigidbody>().mass = 0.01f;
			ConfigurableJoint configurableJoint = obj.AddComponent<ConfigurableJoint>();
			configurableJoint.connectedBody = GetComponent<Rigidbody>();
			configurableJoint.xMotion = ConfigurableJointMotion.Locked;
			configurableJoint.yMotion = ConfigurableJointMotion.Locked;
			configurableJoint.zMotion = ConfigurableJointMotion.Locked;
			configurableJoint.angularXMotion = ConfigurableJointMotion.Locked;
			configurableJoint.angularYMotion = ConfigurableJointMotion.Locked;
			configurableJoint.angularZMotion = ConfigurableJointMotion.Locked;
			obj.AddComponent<WheelCollisionHandler>();
		}
	}

	private HingeJointView GetCorrectHingeJointView(ICollection<HingeJointView> hingeJointViewList)
	{
		HingeJointView result = null;
		foreach (HingeJointView hingeJointView in hingeJointViewList)
		{
			if (hingeJointView.MotorJointView != null)
			{
				result = hingeJointView;
				break;
			}
			if (hingeJointView.SteerableJointView == null)
			{
				result = hingeJointView;
			}
		}
		return result;
	}

	private void ConfigureForWheelColliderSource(HingeJointView selectedHingeJointView)
	{
		wheelColliderObject = new GameObject("WheelCollider");
		wheelColliderObject.tag = "WheelCollider";
		wheelColliderObject.transform.position = base.BlockBodyView.ParentBlockView.transform.position;
		wheelColliderObject.transform.rotation = base.BlockBodyView.ParentBlockView.transform.rotation;
		wheelColliderObject.transform.SetParent(base.BlockBodyView.ParentBlockView.transform, worldPositionStays: true);
		GameObject gameObject = new GameObject("WheelGraphicsFolder");
		gameObject.transform.SetParent(wheelColliderObject.transform, worldPositionStays: false);
		MeshCollider[] components = base.gameObject.GetComponents<MeshCollider>();
		foreach (MeshCollider meshCollider in components)
		{
			meshCollider.isTrigger = true;
			MeshCollider meshCollider2 = wheelColliderObject.AddComponent<MeshCollider>();
			meshCollider2.convex = true;
			meshCollider2.sharedMesh = meshCollider.sharedMesh;
			meshCollider2.material = zeroFriction;
		}
		blockRigidbody.isKinematic = true;
		Rigidbody rigidbody = wheelColliderObject.AddComponent<Rigidbody>();
		rigidbody.mass = blockRigidbody.mass;
		allComponentRigidbodies.Add(rigidbody);
		if (base.gameObject == selectedHingeJointView.ParentBlockBodyView.gameObject)
		{
			HingeJoint hingeJoint = wheelColliderObject.AddComponent<HingeJoint>();
			hingeJoint.connectedBody = selectedHingeJointView.HingeJoint.connectedBody;
			hingeJoint.breakForce = selectedHingeJointView.HingeJoint.breakForce;
			hingeJoint.breakTorque = selectedHingeJointView.HingeJoint.breakTorque;
			UnityEngine.Object.Destroy(selectedHingeJointView.HingeJoint);
			selectedHingeJointView.HingeJoint = hingeJoint;
		}
		else
		{
			selectedHingeJointView.HingeJoint.connectedBody = rigidbody;
		}
		selectedHingeJointView.HingeJoint.useMotor = true;
		selectedHingeJointView.HingeJoint.motor = new JointMotor
		{
			targetVelocity = 0f,
			force = float.PositiveInfinity
		};
		base.gameObject.transform.SetParent(gameObject.transform, worldPositionStays: true);
		WheelColliderSource wheelColliderSource = wheelColliderObject.AddComponent<WheelColliderSource>();
		wheelColliderSource.Renderer = gameObject.transform;
		wheelColliderSource.Radius = radius;
		wheelColliderSource.Mass = blockRigidbody.mass;
		WheelMotor.SetWheelMotor(wheelColliderSource);
		WheelMotor.GameObject = wheelColliderObject;
		SetReplayComponents(wheelColliderObject);
	}

	private void ConfigureForWheelController(HingeJointView selectedHingeJointView)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(wheelControllerTemplate);
		gameObject.transform.SetParent(base.BlockBodyView.ParentBlockView.transform, worldPositionStays: false);
		GameObject gameObject2 = gameObject.transform.GetChild(0).gameObject;
		GameObject gameObject3 = gameObject2.transform.GetChild(0).gameObject;
		base.gameObject.transform.SetParent(gameObject3.transform, worldPositionStays: true);
		MeshCollider[] components = base.gameObject.GetComponents<MeshCollider>();
		foreach (MeshCollider obj in components)
		{
			obj.isTrigger = true;
			obj.enabled = false;
		}
		Rigidbody component = base.gameObject.GetComponent<Rigidbody>();
		component.isKinematic = true;
		Rigidbody component2 = gameObject.GetComponent<Rigidbody>();
		if (base.gameObject == selectedHingeJointView.ParentBlockBodyView.gameObject)
		{
			HingeJoint hingeJoint = gameObject.AddComponent<HingeJoint>();
			hingeJoint.connectedBody = selectedHingeJointView.HingeJoint.connectedBody;
			hingeJoint.breakForce = selectedHingeJointView.HingeJoint.breakForce;
			hingeJoint.breakTorque = selectedHingeJointView.HingeJoint.breakTorque;
			UnityEngine.Object.Destroy(selectedHingeJointView.HingeJoint);
			selectedHingeJointView.HingeJoint = hingeJoint;
		}
		else
		{
			selectedHingeJointView.HingeJoint.connectedBody = component2;
		}
		selectedHingeJointView.HingeJoint.useMotor = true;
		selectedHingeJointView.HingeJoint.motor = new JointMotor
		{
			targetVelocity = 0f,
			force = float.PositiveInfinity
		};
		WheelController component3 = gameObject2.GetComponent<WheelController>();
		component3.tireRadius = radius;
		component3.tireWidth = 0.2f;
		component3.mass = component.mass / 10f;
		WheelMotor.SetWheelMotor(component3);
		WheelMotor.GameObject = gameObject2;
	}

	private void Update()
	{
		if (IsWheelMotorActived && wheelHingeJoint == null && WheelMotor != null)
		{
			WheelMotor.SetActive(shoudEnable: false);
			MeshCollider[] components = WheelMotor.GameObject.GetComponents<MeshCollider>();
			for (int i = 0; i < components.Length; i++)
			{
				components[i].material = base.BlockBodyView.MaterialSchematic.PhysicMaterial;
			}
			IsWheelMotorActived = false;
		}
	}

	protected override void InternalInitialize(Properties properties)
	{
		base.InternalInitialize(properties);
		radius = properties.GetPropertyAsFloat("radius", 0.5f);
		blockRigidbody = base.BlockBodyView.BlockRigidbody;
		base.gameObject.AddComponent<WheelStylesApplier>();
	}

	protected override void InternalResetComponent()
	{
		base.InternalResetComponent();
		base.gameObject.transform.SetParent(base.BlockBodyView.ParentBlockView.transform, worldPositionStays: false);
		if (wheelColliderObject != null)
		{
			Rigidbody component = wheelColliderObject.GetComponent<Rigidbody>();
			if (component != null && allComponentRigidbodies.Contains(component))
			{
				allComponentRigidbodies.Remove(component);
			}
			UnityEngine.Object.Destroy(wheelColliderObject);
		}
		MeshCollider[] components = base.gameObject.GetComponents<MeshCollider>();
		for (int i = 0; i < components.Length; i++)
		{
			components[i].isTrigger = false;
		}
	}

	public override string GetComponentName()
	{
		return typeof(Wheel).Name;
	}
}
