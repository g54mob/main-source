using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Controls.Keybinds;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.Common;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.MeleeWeapons
{
	public class Explosive : BindableDronePart
	{
		private const int MaxRadius = 20;

		private const int MinRadius = 1;

		[IntSetting("DronePartSettings/Radius", 1, 20, 21, UndoManager.EStoreReason.ExplosionRadius)]
		public int ExplosionRadius;

		public int ExplosionDamage;

		public int ExplosionForce;

		private KeyBinding _activate;

		private bool _explodeImmediately;

		protected override void Start()
		{
			base.Start();
			DontDestroyOnBreak = true;
			if (Rigidbody == null)
			{
				Rigidbody = GetComponentInParent<Rigidbody>();
			}
		}

		public override List<KeyBinding> GetKeyBindings()
		{
			_activate = new KeyBinding("Explode", BaseSingleton<KeybindManager>.Instance.GetKeyCode(EKeybinding.DefaultShootButton));
			return new List<KeyBinding> { _activate };
		}

		public override void FixedUpdate()
		{
			if (IsActive() && (_activate.IsPressed(KeyEventHub) || HealthPool.CurrentState == EChemicalState.Burning))
			{
				Break();
				Explode();
			}
			ShowRadius = true;
			DisplayRadius = ExplosionRadius;
			base.FixedUpdate();
		}

		protected override void DronePartBreak()
		{
			base.DronePartBreak();
			Invoke("Explode", Random.Range(0.05f, 0.1f));
		}

		protected void Explode()
		{
			if (ExplosionEffect != null)
			{
				ExplosionEffect.PlayEffect(base.transform);
			}
			Vector3 position = base.transform.position;
			TerrainModificationHelper.LerpRemoveTerrainSphere(RuntimeGlobals.WorldController.ForeGroundTerrain, position, ExplosionRadius, 0f);
			position.z = 0f;
			List<Collider> list = new List<Collider>();
			list.AddRange(Physics.OverlapSphere(position, ExplosionRadius));
			HashSet<GameObject> hashSet = new HashSet<GameObject>();
			foreach (Collider item in list)
			{
				if (item != null && !hashSet.Contains(item.gameObject) && !item.isTrigger)
				{
					if (item.attachedRigidbody != null)
					{
						item.attachedRigidbody.AddExplosionForce(ExplosionForce, position, ExplosionRadius);
					}
					item.gameObject.SendMessage("TakeDamage", new DamageInformation(ExplosionDamage, EDamageReason.Player, this), SendMessageOptions.DontRequireReceiver);
					hashSet.Add(item.gameObject);
				}
			}
			Object.Destroy(base.gameObject);
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Radius") + ": " + LabelHelper.Orange + ExplosionRadius + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Damage") + ": " + LabelHelper.Orange + ExplosionDamage;
		}

		public override NimbatusItemData CreateData()
		{
			return new ExplosiveData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			ExplosiveData explosiveData;
			if ((explosiveData = data as ExplosiveData) != null)
			{
				explosiveData.Radius = ExplosionRadius;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			ExplosiveData explosiveData;
			if ((explosiveData = data as ExplosiveData) != null)
			{
				ExplosionRadius = explosiveData.Radius;
			}
		}
	}
}
