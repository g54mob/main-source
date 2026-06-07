using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Combat;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Attribute.Enums;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.LaserBeams
{
	public class LaserBeam : NimbatusItem
	{
		public bool IgnoreAmmunitionColor;

		public Material LineMaterial;

		public string LaserSound;

		[HideInInspector]
		[SerializeField]
		protected LaserEmitter Emitter;

		public FloatWeaponAttribute Range = new FloatWeaponAttribute();

		public FloatWeaponAttribute Width = new FloatWeaponAttribute();

		public EnumAttribute<ELaserImpactMode> ImpactMode = new EnumAttribute<ELaserImpactMode>();

		public EnumAttribute<ELaserHitMode> HitMode = new EnumAttribute<ELaserHitMode>();

		private readonly List<LaserLine> _lasers = new List<LaserLine>();

		public override void InitStackSettings()
		{
			IsStackable = false;
		}

		public void Init(LaserEmitter emitter)
		{
			ImpactMode.Init(EWeaponAttributeType.LaserImpactMode, true);
			HitMode.Init(EWeaponAttributeType.LaserHitMode, true);
			Range.Init(EWeaponAttributeType.LaserRange, 2, 1f, 250f, !emitter.UsedByEnemy);
			Width.Init(EWeaponAttributeType.LaserWidth, 2, 0.01f, 5f, !emitter.UsedByEnemy, true);
			Emitter = emitter;
		}

		public IEnumerable<WeaponAttribute> GetAttributes()
		{
			return new List<WeaponAttribute> { Range, Width, ImpactMode, HitMode };
		}

		public void SetNumberOfBeams(int value)
		{
			if (_lasers.Count > value)
			{
				DestroyBeam();
				_lasers.Clear();
			}
		}

		public List<RaycastHit> ShootLaser(bool emit, Vector3 position, Vector3 direction, int index)
		{
			float width = Width.Value * 0.02f * (float)Mathf.Max(900, RuntimeGlobals.MainCamera.pixelHeight);
			LaserLine laserLine;
			if (_lasers.Count <= index)
			{
				laserLine = new LaserLine(width, LineMaterial);
				if (!IgnoreAmmunitionColor)
				{
					laserLine.SetColor(Emitter.Ammunition.ColorModifier);
				}
				_lasers.Add(laserLine);
			}
			else
			{
				laserLine = _lasers[index];
			}
			laserLine.SetWidth(width);
			ShowBeam(emit);
			if (emit)
			{
				LayerMask collisionmask = Emitter.Collisionmask;
				return AlignBeam(position, direction, Range.Value, collisionmask, 0, laserLine);
			}
			return new List<RaycastHit>();
		}

		public override void Update()
		{
			base.Update();
			if (RuntimeGlobals.IsGameOver)
			{
				ShowBeam(false);
			}
		}

		public void ShowBeam(bool show)
		{
			foreach (LaserLine laser in _lasers)
			{
				laser.Show(show);
			}
			if (!show)
			{
				StopActiveSoundLoop();
			}
			else
			{
				StartSoundLoop(LaserSound);
			}
		}

		public List<RaycastHit> AlignBeam(Vector3 startPos, Vector3 direction, float range, LayerMask mask, int pointCount, LaserLine laser)
		{
			if (pointCount == 0)
			{
				laser.ResetPoints();
			}
			Ray ray = new Ray(startPos, direction);
			Vector3 inNormal = direction;
			List<RaycastHit> list = new List<RaycastHit>();
			Vector3 point;
			float num;
			RaycastHit hitInfo;
			if (ImpactMode.Value == ELaserImpactMode.Penetrate)
			{
				List<RaycastHit> list2 = new List<RaycastHit>();
				if (Width.Value <= 2f)
				{
					list2.AddRange(Physics.RaycastAll(ray, range, mask));
				}
				else
				{
					list2.AddRange(Physics.SphereCastAll(ray, Width.Value / 2f, range, mask));
				}
				point = ray.GetPoint(range);
				num = range;
				foreach (RaycastHit item in list2.OrderBy((RaycastHit b) => b.distance))
				{
					list.Add(item);
					if (BaseSingleton<CollisionLayerManager>.Instance.IsTerrainLayer(item.collider.gameObject.layer))
					{
						num = item.distance;
						point = ray.GetPoint(item.distance);
						break;
					}
				}
			}
			else if ((!(Width.Value <= 0.5f)) ? Physics.SphereCast(ray, Width.Value / 2f, out hitInfo, range, mask) : Physics.Raycast(ray, out hitInfo, range, mask))
			{
				point = ray.GetPoint(hitInfo.distance);
				num = hitInfo.distance;
				inNormal = hitInfo.normal;
				list.Add(hitInfo);
			}
			else
			{
				point = ray.GetPoint(range);
				num = range;
			}
			point.z = startPos.z;
			inNormal.z = startPos.z;
			laser.AddPoint(startPos);
			laser.AddPoint(point + (point - startPos).normalized * (Width.Value / 2f));
			if (pointCount < 10 && num < range && ImpactMode.Value == ELaserImpactMode.Reflect)
			{
				Vector3 direction2 = Vector3.Reflect(point - startPos, inNormal);
				direction2.z = point.z;
				list.AddRange(AlignBeam(point, direction2, range - num, mask, pointCount + 2, laser));
				return list;
			}
			if (pointCount < 1 && num < range && ImpactMode.Value == ELaserImpactMode.Split)
			{
				Vector3 vector = Vector3.Reflect(point - startPos, inNormal);
				vector.z = point.z;
				Vector3 direction3 = Quaternion.AngleAxis(5f, Vector3.forward) * vector;
				Vector3 direction4 = Quaternion.AngleAxis(10f, Vector3.forward) * vector;
				Vector3 direction5 = Quaternion.AngleAxis(-5f, Vector3.forward) * vector;
				Vector3 direction6 = Quaternion.AngleAxis(-10f, Vector3.forward) * vector;
				list.AddRange(AlignBeam(point, direction3, Range.Value * 0.2f, mask, pointCount + 2, laser));
				list.AddRange(AlignBeam(point, direction4, Range.Value * 0.2f, mask, pointCount + 2, laser));
				list.AddRange(AlignBeam(point, direction5, Range.Value * 0.2f, mask, pointCount + 2, laser));
				list.AddRange(AlignBeam(point, direction6, Range.Value * 0.2f, mask, pointCount + 2, laser));
				return list;
			}
			laser.ApplyLine();
			return list;
		}

		public void OnDestroy()
		{
			DestroyBeam();
		}

		public void DestroyBeam()
		{
			foreach (LaserLine laser in _lasers)
			{
				laser.Destroy();
			}
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
		}

		public override NimbatusItemData CreateData()
		{
			return new NimbatusItemData();
		}
	}
}
