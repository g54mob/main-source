using System.Collections.Generic;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.MechanicalParts
{
	public class BallastTank : SensorPart
	{
		private const float MinWeight = 0.5f;

		private const float MaxWeight = 10f;

		[FloatSetting("DronePartSettings/Weight", 0.5f, 10f, 96, UndoManager.EStoreReason.BallastTankWeight)]
		public float Weight = 0.5f;

		public Renderer BallastDisplayRenderer;

		public AnimationCurve FillCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		private KeyBinding _increaseWeight;

		private KeyBinding _decreaseWeight;

		protected override void Validate()
		{
			base.Validate();
			Weight = Mathf.Clamp(Weight, 0.5f, 10f);
		}

		protected override void Start()
		{
			base.Start();
			UpdateWeight();
		}

		public override void Update()
		{
			base.Update();
			if (RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization)
			{
				UpdateWeight();
			}
			if (BallastDisplayRenderer != null)
			{
				BallastDisplayRenderer.material.SetFloat("_Fuel", FillCurve.Evaluate(0.1f * Rigidbody.mass));
			}
		}

		public override void FixedUpdate()
		{
			base.FixedUpdate();
			if (IsActive())
			{
				if (_increaseWeight.IsPressed(KeyEventHub))
				{
					float value = Rigidbody.mass + Time.fixedDeltaTime * 10f;
					Rigidbody.mass = Mathf.Clamp(value, 0.5f, 10f);
				}
				if (_decreaseWeight.IsPressed(KeyEventHub))
				{
					float value2 = Rigidbody.mass - Time.fixedDeltaTime * 10f;
					Rigidbody.mass = Mathf.Clamp(value2, 0.5f, 10f);
				}
			}
		}

		private void UpdateWeight()
		{
			if (!(Rigidbody == null))
			{
				Rigidbody.mass = Weight;
			}
		}

		public override List<KeyBinding> GetKeyBindings()
		{
			_increaseWeight = new KeyBinding("Increase Weight", KeyCode.None, false);
			_decreaseWeight = new KeyBinding("Decrease Weight", KeyCode.None, false);
			return new List<KeyBinding> { _increaseWeight, _decreaseWeight };
		}

		public override List<EventKeyBinding> GetEventBindings()
		{
			return new List<EventKeyBinding>();
		}

		public override NimbatusItemData CreateData()
		{
			return new BallastTankData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			BallastTankData ballastTankData;
			if ((ballastTankData = data as BallastTankData) != null)
			{
				ballastTankData.Weight = Weight;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			BallastTankData ballastTankData;
			if ((ballastTankData = data as BallastTankData) != null)
			{
				Weight = ballastTankData.Weight;
			}
		}
	}
}
