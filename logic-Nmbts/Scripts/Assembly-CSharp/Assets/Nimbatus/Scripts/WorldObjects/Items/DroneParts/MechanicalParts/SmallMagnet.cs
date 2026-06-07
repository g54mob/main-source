using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.ResourceCollection;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.MechanicalParts
{
	public class SmallMagnet : BindableDronePart, IEnergyConsumer
	{
		public int Radius;

		public int Force;

		public int EnergyPerSecond;

		public tk2dSprite MagnetLight;

		public Color AttractColor;

		public Color InactiveColor;

		private KeyBinding _attract;

		public override List<KeyBinding> GetKeyBindings()
		{
			_attract = new KeyBinding("Activate", KeyCode.None);
			return new List<KeyBinding> { _attract };
		}

		public override void Update()
		{
			bool flag = (base.CurrentResourceHub.HasResource(EResourceType.Energy, (float)EnergyPerSecond * Time.deltaTime) ? true : false);
			if (IsActive() && flag)
			{
				if (_attract.IsPressed(KeyEventHub))
				{
					MagnetLight.color = AttractColor;
				}
				else
				{
					MagnetLight.color = InactiveColor;
				}
			}
			else
			{
				MagnetLight.color = InactiveColor;
			}
			ShowRadius = true;
			DisplayRadius = Radius;
			base.Update();
		}

		public override void FixedUpdate()
		{
			base.FixedUpdate();
			if (!IsActive())
			{
				return;
			}
			bool flag = _attract.IsPressed(KeyEventHub);
			bool flag2 = (base.CurrentResourceHub.HasResource(EResourceType.Energy, (float)EnergyPerSecond * Time.fixedDeltaTime) ? true : false);
			if (!(flag2 && flag))
			{
				return;
			}
			base.CurrentResourceHub.UseResourceFromParts(EResourceType.Energy, (float)EnergyPerSecond * Time.fixedDeltaTime);
			List<Collider> list = Physics.OverlapSphere(base.transform.position, Radius).ToList();
			HashSet<GameObject> hashSet = new HashSet<GameObject>();
			foreach (Collider item in list)
			{
				if (!(item.attachedRigidbody != null) || item.isTrigger)
				{
					continue;
				}
				GameObject gameObject = item.attachedRigidbody.gameObject;
				if (!hashSet.Contains(gameObject))
				{
					NimbatusWorldObject component = gameObject.GetComponent<NimbatusWorldObject>();
					if (component == null || component.IsMetallic)
					{
						Vector3 vector = base.transform.position - item.transform.position;
						int force = Force;
						vector = vector * force / Mathf.Max(1f, vector.sqrMagnitude);
						Vector3 vector2 = vector * item.attachedRigidbody.mass;
						item.attachedRigidbody.AddForce(vector2 * 10f, ForceMode.Force);
						Rigidbody.AddForce(-vector2 * 10f, ForceMode.Force);
					}
					hashSet.Add(gameObject);
				}
			}
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/EnergyPerSecond") + ": " + LabelHelper.Orange + EnergyPerSecond + LabelHelper.NewLine;
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Strength") + ": " + LabelHelper.Orange + Force + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Radius") + ": " + LabelHelper.Orange + Radius;
		}
	}
}
