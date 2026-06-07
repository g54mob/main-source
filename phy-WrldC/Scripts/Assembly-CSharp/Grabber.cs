using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Grabber : BaseComponentView
{
	private class GrabbedObject
	{
		public GameObject GameObject { get; set; }

		public FixedJoint FixedJoint { get; set; }
	}

	private LogicIO activeInput;

	private LogicIO activatedOutput;

	private LogicIO grabbedOutput;

	private List<GrabbedObject> inGrabberAreaObjects;

	private bool isToggleMode;

	private bool isToggleChanged;

	private bool isLogicInverted;

	private bool isGrabberTurnedOn;

	private Renderer thisRenderer;

	public bool IsGrabberOn { get; private set; }

	public event Action<bool> OnTurnedOnOffEvent;

	public event Action OnGrabbedEvent;

	private void Awake()
	{
		thisRenderer = GetComponentInChildren<Renderer>(includeInactive: true);
		SetMaterialEmission(isOn: false);
	}

	private void Update()
	{
		if (activeInput.ReadDigitalSignal())
		{
			if (isToggleMode)
			{
				if (!isToggleChanged)
				{
					IsGrabberOn = !IsGrabberOn;
					isToggleChanged = true;
				}
			}
			else
			{
				IsGrabberOn = !isLogicInverted;
			}
		}
		else if (isToggleMode)
		{
			isToggleChanged = false;
		}
		else
		{
			IsGrabberOn = isLogicInverted;
		}
		if (IsGrabberOn)
		{
			if (isGrabberTurnedOn)
			{
				SetMaterialEmission(isOn: true);
				if (this.OnTurnedOnOffEvent != null)
				{
					this.OnTurnedOnOffEvent(obj: true);
				}
				isGrabberTurnedOn = false;
			}
			inGrabberAreaObjects.ForEach(delegate(GrabbedObject grabbed)
			{
				if (grabbed.FixedJoint == null)
				{
					grabbed.FixedJoint = base.gameObject.AddComponent<FixedJoint>();
					grabbed.FixedJoint.connectedBody = grabbed.GameObject.GetComponentInParent<Rigidbody>();
					if (this.OnGrabbedEvent != null)
					{
						this.OnGrabbedEvent();
					}
				}
			});
			grabbedOutput.SetSignal(inGrabberAreaObjects.Count > 0);
		}
		else
		{
			if (!isGrabberTurnedOn)
			{
				SetMaterialEmission(isOn: false);
				if (this.OnTurnedOnOffEvent != null)
				{
					this.OnTurnedOnOffEvent(obj: false);
				}
				isGrabberTurnedOn = true;
			}
			inGrabberAreaObjects.ForEach(delegate(GrabbedObject grabbed)
			{
				if (grabbed.FixedJoint != null)
				{
					UnityEngine.Object.Destroy(grabbed.FixedJoint);
				}
			});
			grabbedOutput.SetSignal(0f);
		}
		activatedOutput.SetSignal(IsGrabberOn);
	}

	public override void SetUpToAction()
	{
		base.SetUpToAction();
		isLogicInverted = base.BlockBodyView.OverridableProperties.GetPropertyAsBool("grabber_invert_logic");
		IsGrabberOn = isLogicInverted;
		int propertyAsInt = base.BlockBodyView.OverridableProperties.GetPropertyAsInt("grabber_btn_type");
		isToggleMode = propertyAsInt != 0;
		inGrabberAreaObjects.Clear();
		SetMaterialEmission(IsGrabberOn);
		isGrabberTurnedOn = !IsGrabberOn;
	}

	protected override void InternalInitialize(Properties properties)
	{
		base.InternalInitialize(properties);
		inGrabberAreaObjects = new List<GrabbedObject>();
		GameObject obj = new GameObject("GrabberTrigger");
		obj.transform.SetParent(base.transform, worldPositionStays: false);
		BoxCollider boxCollider = obj.AddComponent<BoxCollider>();
		boxCollider.center = properties.GetPropertyAsVector3("triggerCenter");
		boxCollider.size = properties.GetPropertyAsVector3("triggerSize");
		boxCollider.isTrigger = true;
		TriggerEvents triggerEvents = obj.AddComponent<TriggerEvents>();
		triggerEvents.OnTriggerStayEvent += GrabberTriggerStayHandler;
		triggerEvents.OnTriggerExitEvent += GrabberTriggerExitHandler;
		base.BlockBodyView.OnSetMaterialEvent += OnSetMaterialHandler;
		base.gameObject.AddComponent<GrabberStylesApplier>();
		base.gameObject.AddComponent<GrabberReplay>();
	}

	protected override void SetInitializeConfiguration(Properties properties)
	{
		base.SetInitializeConfiguration(properties);
		activeInput = base.BlockBodyView.AddLogicIO(new LogicIO("grabber_active", LogicIODirection.Input, digitalSignal: false));
		activatedOutput = base.BlockBodyView.AddLogicIO(new LogicIO("grabber_activated_out", LogicIODirection.Output, 0f));
		grabbedOutput = base.BlockBodyView.AddLogicIO(new LogicIO("grabber_grabbed_out", LogicIODirection.Output, 0f));
	}

	protected override void InternalResetComponent()
	{
		base.InternalResetComponent();
		inGrabberAreaObjects.ForEach(delegate(GrabbedObject grabbed)
		{
			if (grabbed.FixedJoint != null)
			{
				UnityEngine.Object.Destroy(grabbed.FixedJoint);
			}
		});
		inGrabberAreaObjects.Clear();
		SetMaterialEmission(isOn: false);
	}

	protected override void InternalInitializeModel()
	{
		base.InternalInitializeModel();
		base.BlockBodyView.OnSetMaterialEvent += OnSetMaterialHandler;
	}

	private void GrabberTriggerStayHandler(Collider obj)
	{
		if ((obj.CompareTag("Block") || obj.CompareTag("Level")) && !inGrabberAreaObjects.Any((GrabbedObject grabbed) => grabbed.GameObject == obj.gameObject))
		{
			inGrabberAreaObjects.Add(new GrabbedObject
			{
				GameObject = obj.gameObject
			});
		}
	}

	private void GrabberTriggerExitHandler(Collider obj)
	{
		GrabbedObject[] array = inGrabberAreaObjects.ToArray();
		foreach (GrabbedObject grabbedObject in array)
		{
			if (grabbedObject.GameObject == obj.gameObject)
			{
				if (grabbedObject.FixedJoint != null)
				{
					UnityEngine.Object.Destroy(grabbedObject.FixedJoint);
				}
				inGrabberAreaObjects.Remove(grabbedObject);
			}
		}
	}

	private void OnSetMaterialHandler(bool isMainMaterial)
	{
		SetMaterialEmission(isOn: false);
	}

	public void SetMaterialEmission(bool isOn)
	{
		thisRenderer.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
		thisRenderer.material.EnableKeyword("_EMISSION");
		thisRenderer.material.SetColor("_EmissionColor", Color.HSVToRGB(0f, 0f, isOn ? 5 : 0));
	}

	public override string GetComponentName()
	{
		return typeof(Grabber).Name;
	}
}
