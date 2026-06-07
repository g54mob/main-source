using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.ResourceCollection;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.MechanicalParts
{
	public class Magnet : BindableDronePart, IEnergyConsumer
	{
		private const int MaxRadius = 30;

		private const int MinRadius = 5;

		[IntSetting("DronePartSettings/Radius", 5, 30, 100, UndoManager.EStoreReason.MagnetRadius)]
		public int Radius;

		private const int MaxForce = 100;

		private const int MinForce = 0;

		[IntSetting("DronePartSettings/Strength", 0, 100, 100, UndoManager.EStoreReason.MagnetStrength)]
		public int Force;

		public int EnergyPerSecond;

		public tk2dSprite AttractLight;

		public tk2dSprite RepelLight;

		public tk2dSprite MagnetLight;

		public Color AttractColor;

		public Color RepelColor;

		public Color InactiveColor;

		private KeyBinding _attract;

		private KeyBinding _repel;

		protected override void Validate()
		{
			base.Validate();
			Radius = Mathf.Clamp(Radius, 5, 30);
			Force = Mathf.Clamp(Force, 0, 100);
		}

		public override List<KeyBinding> GetKeyBindings()
		{
			_attract = new KeyBinding("Attract", KeyCode.None, false);
			_repel = new KeyBinding("Repel", KeyCode.None, false);
			return new List<KeyBinding> { _attract, _repel };
		}

		public override void Update()
		{
			bool flag = (base.CurrentResourceHub.HasResource(EResourceType.Energy, (float)EnergyPerSecond * Time.deltaTime) ? true : false);
			if (IsActive() && flag)
			{
				bool num = _attract.IsPressed(KeyEventHub);
				bool flag2 = _repel.IsPressed(KeyEventHub);
				if (num)
				{
					MagnetLight.color = AttractColor;
				}
				else if (flag2)
				{
					MagnetLight.color = RepelColor;
				}
				else
				{
					MagnetLight.color = InactiveColor;
				}
				AttractLight.color = (_attract.IsPressed(KeyEventHub) ? Color.green : ColorHelper.BlackAlpha0);
				RepelLight.color = (_repel.IsPressed(KeyEventHub) ? Color.green : ColorHelper.BlackAlpha0);
			}
			else
			{
				MagnetLight.color = InactiveColor;
				AttractLight.color = ColorHelper.BlackAlpha0;
				RepelLight.color = ColorHelper.BlackAlpha0;
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
			bool flag2 = _repel.IsPressed(KeyEventHub);
			bool flag3 = (base.CurrentResourceHub.HasResource(EResourceType.Energy, (float)EnergyPerSecond * Time.fixedDeltaTime) ? true : false);
			if (!flag3 || !(flag ^ flag2))
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
				if (hashSet.Contains(gameObject))
				{
					continue;
				}
				NimbatusWorldObject component = gameObject.GetComponent<NimbatusWorldObject>();
				if (component == null || component.IsMetallic)
				{
					Vector3 vector = base.transform.position - item.transform.position;
					int num = Force;
					if (flag2)
					{
						num = -Force;
					}
					vector = vector * num / Mathf.Max(1f, vector.sqrMagnitude);
					Vector3 vector2 = vector * item.attachedRigidbody.mass;
					item.attachedRigidbody.AddForce(vector2 * 10f, ForceMode.Force);
					Rigidbody.AddForce(-vector2 * 10f, ForceMode.Force);
				}
				hashSet.Add(gameObject);
			}
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/EnergyPerSecond") + ": " + LabelHelper.Orange + EnergyPerSecond + LabelHelper.NewLine;
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Strength") + ": " + LabelHelper.Orange + Force + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Radius") + ": " + LabelHelper.Orange + Radius;
		}

		public override NimbatusItemData CreateData()
		{
			return new MagnetData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			MagnetData magnetData = data as MagnetData;
			if (magnetData != null)
			{
				magnetData.Force = Force;
				magnetData.Radius = Radius;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			MagnetData magnetData = data as MagnetData;
			if (magnetData != null)
			{
				Force = magnetData.Force;
				Radius = magnetData.Radius;
			}
		}
	}
}
