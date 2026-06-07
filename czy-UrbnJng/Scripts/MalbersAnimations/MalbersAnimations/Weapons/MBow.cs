using System.Collections;
using UnityEngine;

namespace MalbersAnimations.Weapons
{
	[AddComponentMenu("Malbers/Weapons/MBow")]
	public class MBow : MShootable
	{
		public Transform knot;

		public float MaxTension;

		[Range(0f, 1f)]
		public float BowTensionPrev;

		public Transform[] UpperBn;

		public Transform[] LowerBn;

		[SerializeField]
		private Quaternion[] UpperBnInitRot;

		[SerializeField]
		private Quaternion[] LowerBnInitRot;

		[SerializeField]
		private Quaternion[] UpperBnMaxRot;

		[SerializeField]
		private Quaternion[] LowerBnMaxRot;

		[Tooltip("Default position of the Knot to return to when the String is on its default position")]
		public Vector3 DefaultPosKnot;

		public Vector3 KnotHandOffset;

		public Vector3 RotUpperDir = -Vector3.forward;

		public Vector3 RotLowerDir = Vector3.forward;

		public bool BowIsSet;

		[HideInInspector]
		public bool BonesFoldout;

		[HideInInspector]
		public bool proceduralfoldout;

		[HideInInspector]
		public int LowerIndex;

		[HideInInspector]
		public int UpperIndex;

		public bool KnotToHand { get; set; }

		public override bool IsAiming
		{
			get
			{
				return ((MWeapon)this).IsAiming;
			}
			set
			{
				base.IsAiming = value;
				if (!value)
				{
					DestroyProjectileInstance();
				}
			}
		}

		public override bool IsEquiped
		{
			get
			{
				return base.IsEquiped;
			}
			set
			{
				base.IsEquiped = value;
				if (value)
				{
					BowKnotToHand(enabled: false);
				}
				else
				{
					DestroyProjectileInstance();
				}
			}
		}

		public virtual void SerializeBow()
		{
			if (UpperBn == null || LowerBn == null)
			{
				Debug.LogWarning("Please fill the Upper and Low Joints on the Bow");
				BowIsSet = false;
				return;
			}
			if (UpperBn.Length == 0 || LowerBn.Length == 0)
			{
				Debug.LogWarning("Please fill the Upper and Low Joints on the Bow");
				BowIsSet = false;
				return;
			}
			base.ChargeCurrentTime = 0f;
			UpperBnInitRot = new Quaternion[UpperBn.Length];
			LowerBnInitRot = new Quaternion[LowerBn.Length];
			UpperBnMaxRot = new Quaternion[UpperBn.Length];
			LowerBnMaxRot = new Quaternion[LowerBn.Length];
			for (int i = 0; i < UpperBn.Length; i++)
			{
				if (UpperBn[i] == null)
				{
					BowIsSet = false;
					return;
				}
				UpperBnInitRot[i] = UpperBn[i].localRotation;
				UpperBnMaxRot[i] = Quaternion.Euler(RotUpperDir * MaxTension) * UpperBnInitRot[i];
			}
			for (int j = 0; j < LowerBn.Length; j++)
			{
				if (LowerBn[j] == null)
				{
					BowIsSet = false;
					return;
				}
				LowerBnInitRot[j] = LowerBn[j].localRotation;
				LowerBnMaxRot[j] = Quaternion.Euler(RotLowerDir * MaxTension) * LowerBnInitRot[j];
			}
			BowIsSet = true;
			Debug.Log("The Initial Position and Rotation of the bow has been stored corretly");
		}

		public override void FreeHandUse()
		{
			BowKnotToHand(enabled: true);
		}

		public override void FreeHandRelease()
		{
			BowKnotToHand(enabled: false);
		}

		public virtual void BowKnotToHand(bool enabled)
		{
			base.FreeHand = !enabled;
			KnotToHand = enabled;
			if (!KnotToHand)
			{
				RestoreKnot();
			}
		}

		protected void BowKnotInHand(IMWeaponOwner RC)
		{
			if (RC != null && !RC.StoreWeapon && !RC.DrawWeapon && KnotToHand)
			{
				knot.position = (base.IsRightHanded ? RC.LeftHand.TransformPoint(KnotHandOffset) : RC.RightHand.TransformPoint(KnotHandOffset));
			}
		}

		public virtual void BendBow(float normalizedTime)
		{
			if (BowIsSet)
			{
				for (int i = 0; i < UpperBn.Length; i++)
				{
					UpperBn[i].localRotation = Quaternion.Lerp(UpperBnInitRot[i], UpperBnMaxRot[i], normalizedTime);
				}
				for (int j = 0; j < LowerBn.Length; j++)
				{
					LowerBn[j].localRotation = Quaternion.Lerp(LowerBnInitRot[j], LowerBnMaxRot[j], normalizedTime);
				}
				if ((bool)knot && (bool)AimOrigin)
				{
					Debug.DrawRay(knot.position, knot.forward, Color.red);
				}
			}
		}

		public virtual void RestoreKnot()
		{
			knot.localPosition = DefaultPosKnot;
		}

		internal override void Attack_Charge(IMWeaponOwner RC, float time)
		{
			base.Attack_Charge(RC, time);
			if (IsCharging)
			{
				BendBow(base.ChargedNormalized);
			}
		}

		public override void ResetCharge()
		{
			base.ResetCharge();
			BendBow(0f);
			if (Sounds.Length > 5 && m_audio.isPlaying && m_audio.clip == Sounds[5])
			{
				m_audio.Stop();
			}
		}

		internal override void Weapon_LateUpdate(IMWeaponOwner RC)
		{
			base.Weapon_LateUpdate(RC);
			BowKnotInHand(RC);
			knot.rotation = Quaternion.LookRotation((AimOrigin.position - knot.position).normalized, -base.Gravity);
		}

		internal override void StoringWeapon()
		{
			RestoreKnot();
		}

		public override void PlaySound(int ID)
		{
			if (ID >= Sounds.Length || !(Sounds[ID] != null))
			{
				return;
			}
			AudioClip newSound = Sounds[ID];
			if (!m_audio || playingSound || !base.gameObject.activeInHierarchy)
			{
				return;
			}
			if (ID == 5 && CanCharge)
			{
				m_audio.pitch = 1.03f / base.ChargeTime;
				StartCoroutine(BowChargeTimePlay(newSound));
				return;
			}
			m_audio.Stop();
			m_audio.pitch = 1f;
			this.Delay_Action(2, delegate
			{
				m_audio.PlayOneShot(newSound);
				playingSound = false;
			});
		}

		private IEnumerator BowChargeTimePlay(AudioClip sound)
		{
			while (base.ChargedNormalized == 0f)
			{
				yield return null;
			}
			m_audio.PlayOneShot(sound);
		}

		public override void ResetWeapon()
		{
			base.ResetWeapon();
			RestoreKnot();
		}
	}
}
