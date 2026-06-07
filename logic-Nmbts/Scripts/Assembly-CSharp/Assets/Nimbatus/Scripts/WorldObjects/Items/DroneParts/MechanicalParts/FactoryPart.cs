using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.Achievements;
using Assets.Nimbatus.Scripts.ResourceCollection;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.MechanicalParts
{
	public class FactoryPart : SensorPart
	{
		public Renderer CooldownRenderer;

		[EnumSetting("DronePartSettings/StartState", UndoManager.EStoreReason.FactoryPartStartState)]
		public EFactoryStartState StartState;

		public float CoolDownPerPart;

		internal float TotalCoolDown;

		public string DecoupleSound;

		public string PrintSound;

		private EventKeyBinding _readyToPrint;

		private KeyBinding _decoupleBinding;

		private KeyBinding _printBinding;

		[NonSerialized]
		[XmlIgnore]
		private List<DronePartData> _factoryData;

		private float _lastPrintTime;

		private bool _wasTrue;

		private bool _shouldActivatePhysics;

		public override List<KeyBinding> GetKeyBindings()
		{
			_decoupleBinding = new KeyBinding("Decouple", KeyCode.None);
			_printBinding = new KeyBinding("Print", KeyCode.None);
			return new List<KeyBinding> { _decoupleBinding, _printBinding };
		}

		public override List<EventKeyBinding> GetEventBindings()
		{
			_readyToPrint = new EventKeyBinding("Ready to print", KeyCode.None);
			return new List<EventKeyBinding> { _readyToPrint };
		}

		protected override void Awake()
		{
			base.Awake();
			KeyBindings = GetKeyBindings();
			_shouldActivatePhysics = false;
		}

		public override void ActivatePhysics(int layer)
		{
			if (_shouldActivatePhysics)
			{
				base.ActivatePhysics(layer);
			}
		}

		protected override void Start()
		{
			base.Start();
			_lastPrintTime = Time.time;
			UpdateCooldown();
			if (RuntimeGlobals.RunningMode != ERunningMode.DroneCustomization && StartState == EFactoryStartState.NotPrinted && CanControlDrone)
			{
				_lastPrintTime = 0f - TotalCoolDown;
			}
			_shouldActivatePhysics = true;
			ActivatePhysics(base.gameObject.layer);
			if (RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization)
			{
				InvokeRepeating("UpdateCooldown", 0f, 1f);
			}
		}

		public void UpdateCooldown()
		{
			if (_factoryData == null)
			{
				TotalCoolDown = 0f;
				return;
			}
			TotalCoolDown = (float)_factoryData.Sum((DronePartData d) => d.GetNumberOfDroneParts(null)) * CoolDownPerPart;
		}

		public bool Print()
		{
			if (Children.Count > 0)
			{
				return false;
			}
			foreach (DronePartData factoryDatum in _factoryData)
			{
				NimbatusItem nimbatusItem = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.InstantiateItemFromData(factoryDatum);
				if (nimbatusItem is DronePart)
				{
					if (nimbatusItem is FactoryPart)
					{
						BaseSingleton<AchievementManager>.Instance.UnlockAchievement(EAchievement.GodParticle);
					}
					PlaySound(PrintSound);
					DronePart dronePart = nimbatusItem as DronePart;
					DronePartData dronePartData = (DronePartData)dronePart.Data;
					dronePart.SetDrone(RootDrone);
					dronePart.gameObject.SetActive(true);
					Children.Add(dronePart);
					dronePart.gameObject.layer = base.gameObject.layer;
					dronePart.ParentDronePart = this;
					dronePart.transform.parent = base.transform;
					dronePart.transform.localPosition = dronePartData.OriginalPosition;
					dronePart.transform.localRotation = dronePartData.OriginalRotation;
					dronePart.SetDrone(RootDrone);
					dronePart.Reparent();
					dronePart.SetHubRecursive(base.CurrentResourceHub);
					if (dronePart.Joint != null)
					{
						dronePart.Joint.connectedBody = Rigidbody;
						dronePart.Joint.autoConfigureConnectedAnchor = false;
						dronePart.Joint.anchor = Vector3.zero;
						dronePart.Joint.connectedAnchor = dronePart.transform.localPosition;
					}
					dronePart.ActivatePhysics(base.gameObject.layer);
				}
			}
			return true;
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/PartCooldown") + ": " + LabelHelper.Orange + CoolDownPerPart + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/TotalCooldown") + ": " + LabelHelper.Orange + TotalCoolDown;
		}

		public override void Update()
		{
			base.Update();
			if (!IsBroken && CanControlDrone && CooldownRenderer != null)
			{
				CooldownRenderer.material.SetFloat("_Fuel", 1f / TotalCoolDown * (Time.time - _lastPrintTime));
			}
		}

		public override void FixedUpdate()
		{
			base.FixedUpdate();
			if (!IsActive())
			{
				return;
			}
			if (_decoupleBinding.IsPressed(KeyEventHub) && Children.Count > 0)
			{
				foreach (DronePart item in Children.ToList())
				{
					PlaySound(DecoupleSound);
					if (!RuntimeGlobals.HasWirelessResourceTransfer)
					{
						ResourceHub resourceHub = new ResourceHub();
						resourceHub.Init();
						RootDrone.AddDecoupledHub(resourceHub);
						item.DecoupleFromParent(resourceHub);
					}
					else
					{
						item.DecoupleFromParent();
					}
				}
				Children.Clear();
			}
			if (Time.time - _lastPrintTime > TotalCoolDown)
			{
				if (!_wasTrue)
				{
					_readyToPrint.PressKey(true, KeyEventHub);
					_wasTrue = true;
				}
				if (_printBinding.IsPressed(KeyEventHub) && Print() && _wasTrue && Children.Count > 0)
				{
					_readyToPrint.PressKey(false, KeyEventHub);
					_wasTrue = false;
					_lastPrintTime = Time.time;
				}
			}
			else if (_wasTrue)
			{
				_readyToPrint.PressKey(false, KeyEventHub);
				_wasTrue = false;
			}
		}

		public override void OnDisable()
		{
			base.OnDisable();
			if (_wasTrue)
			{
				_readyToPrint.PressKey(false, KeyEventHub);
			}
		}

		public override NimbatusItemData CreateData()
		{
			return new FactoryPartData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			FactoryPartData factoryPartData = data as FactoryPartData;
			if (factoryPartData != null)
			{
				factoryPartData.StartState = StartState;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			FactoryPartData factoryPartData;
			if ((factoryPartData = data as FactoryPartData) == null)
			{
				return;
			}
			StartState = factoryPartData.StartState;
			if (StartState == EFactoryStartState.Printed || RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization)
			{
				foreach (DronePartData child in factoryPartData.Children)
				{
					DronePart childDronePart = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.InstantiateItemFromData(child) as DronePart;
					AddChild(childDronePart);
				}
			}
			_factoryData = factoryPartData.Children.ToList();
		}
	}
}
