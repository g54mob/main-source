using JUTPS.ActionScripts;
using JUTPS.ItemSystem;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

namespace JUTPS.WeaponSystem
{
	[AddComponentMenu("JU TPS/Weapon System/Weapon")]
	[RequireComponent(typeof(AudioSource))]
	public class Weapon : HoldableItem
	{
		public enum WeaponFireMode
		{
			Auto = 0,
			SemiAuto = 1,
			BoltAction = 2,
			Shotgun = 3
		}

		public enum WeaponAimMode
		{
			None = 0,
			CameraApproach = 1,
			Scope = 2
		}

		public enum Axis
		{
			Z = 0,
			X = 1,
			Y = 2
		}

		[HideInInspector]
		public JUCharacterController TPSControllerUser;

		[HideInInspector]
		public Transform mCamera;

		[HideInInspector]
		public Vector3 ShootDirection;

		[HideInInspector]
		public Vector3 CameraPosition;

		[Header("Weapon Setting")]
		public LayerMask RaycastingLayers;

		[Range(1f, 200f)]
		public int BulletsPerMagazine = 10;

		public int TotalBullets = 150;

		public int BulletsAmounts = 10;

		public int NumberOfShotgunBulletsPerShot = 12;

		public bool InfiniteAmmo;

		public float Fire_Rate = 0.3f;

		[HideInInspector]
		public float CurrentFireRateToShoot;

		[Range(0.1f, 50f)]
		public float Precision = 0.5f;

		[Range(0.01f, 1f)]
		public float LossOfAccuracyPerShot = 1f;

		[HideInInspector]
		public float ShotErrorProbability;

		public GameObject BulletPrefab;

		public GameObject MuzzleFlashParticlePrefab;

		public Transform Shoot_Position;

		[HideInInspector]
		public Collider[] ListToIgnoreBulletCollision;

		public WeaponFireMode FireMode;

		public WeaponAimMode AimMode;

		public Vector3 CameraAimingPosition = new Vector3(0f, 0.1f, -0.2f);

		public Sprite ScopeTexture;

		public float CameraFOV = 30f;

		[Header("Procedural Animation")]
		public bool GenerateProceduralAnimation = true;

		[Range(0f, 0.3f)]
		public float RecoilForce = 0.1f;

		[Range(-100f, 100f)]
		public float RecoilForceRotation = 20f;

		public Axis SliderMovementAxis;

		public Transform GunSlider;

		[Range(-0.1f, 0.1f)]
		public float SliderMovementOffset;

		[Range(0f, 2f)]
		public float SliderMovementSpeed = 0.5f;

		[HideInInspector]
		public Vector3 SliderStartLocalPosition;

		public float WeaponPositionSpeed = 20f;

		public float WeaponRotationSpeed = 20f;

		public float CameraRecoilMultiplier = 1f;

		[Header("Bullet Casing Emitter")]
		public GameObject BulletCasingPrefab;

		public ParticleSystem BulletCasingParticle;

		public bool IsParticle;

		[Header("Weapon Sounds")]
		public AudioClip ShootAudio;

		public AudioClip ReloadAudio;

		public AudioClip EmptyMagazineAudio;

		public AudioClip WeaponEquipAudio;

		private AudioSource mAudioSource;

		private bool PlayedEmptySound;

		private bool enableBulletDirectionCorrection = true;

		private GameObject bullet;

		private GameObject spawningObject;

		protected override void Start()
		{
			base.Start();
			CurrentFireRateToShoot = Fire_Rate - 0.05f;
			mCamera = ((CamPivot != null) ? CamPivot.mCamera.transform : null);
			mAudioSource = GetComponent<AudioSource>();
			if (RaycastingLayers.value == 0)
			{
				RaycastingLayers = LayerMask.GetMask("Character", "Bones", "Default", "Walls", "Terrain", "Vehicle", "VehicleMeshCollider", "TrainGround");
			}
			if (Owner != null)
			{
				if (Owner.TryGetComponent<JUCharacterController>(out var component))
				{
					CamPivot = component.MyPivotCamera;
					TPSControllerUser = component;
					ListToIgnoreBulletCollision = component.CharacterHitBoxes;
				}
				if (Owner.TryGetComponent<AimOnMousePosition>(out var _))
				{
					enableBulletDirectionCorrection = false;
				}
				if (Owner.TryGetComponent<AimOnRightJoystickDirection>(out var _))
				{
					enableBulletDirectionCorrection = false;
				}
			}
			if (GunSlider != null)
			{
				SliderStartLocalPosition = GunSlider.localPosition;
			}
			if (BulletCasingPrefab != null && IsParticle)
			{
				BulletCasingParticle = BulletCasingPrefab.GetComponent<ParticleSystem>();
			}
		}

		protected virtual void OnEnable()
		{
			if (mAudioSource != null && WeaponEquipAudio != null)
			{
				mAudioSource.clip = null;
				mAudioSource.PlayOneShot(WeaponEquipAudio);
			}
		}

		public override void Update()
		{
			WeaponControl();
			if (GenerateProceduralAnimation)
			{
				ProceduralAnimation();
			}
		}

		private void WeaponControl()
		{
			if (!CanUseItem)
			{
				CurrentFireRateToShoot += Time.deltaTime;
				if (CurrentFireRateToShoot >= Fire_Rate)
				{
					CanUseItem = true;
					IsUsingItem = false;
					CancelInvoke("StopUseItemDelayed");
				}
			}
			else if (CurrentFireRateToShoot < Fire_Rate)
			{
				CanUseItem = false;
			}
			if (BulletsAmounts == 0 && CanUseItem)
			{
				CanUseItem = false;
			}
			ShotErrorProbability = Mathf.Lerp(ShotErrorProbability, 0f, Precision * Time.deltaTime);
		}

		private void ProceduralAnimation()
		{
			if (!(WeaponRotationCenter == null))
			{
				Vector3 b = WeaponRotationCenter._storedLocalPositions[ItemWieldPositionID];
				Quaternion b2 = WeaponRotationCenter._storedLocalRotations[ItemWieldPositionID];
				WeaponRotationCenter.WeaponPositionTransform[ItemWieldPositionID].localPosition = Vector3.Lerp(WeaponRotationCenter.WeaponPositionTransform[ItemWieldPositionID].localPosition, b, WeaponPositionSpeed * Time.deltaTime);
				WeaponRotationCenter.WeaponPositionTransform[ItemWieldPositionID].localRotation = Quaternion.Lerp(WeaponRotationCenter.WeaponPositionTransform[ItemWieldPositionID].localRotation, b2, WeaponRotationSpeed * Time.deltaTime);
				if (GunSlider != null && BulletsAmounts > 0 && FireMode != WeaponFireMode.BoltAction)
				{
					GunSlider.transform.localPosition = Vector3.MoveTowards(GunSlider.transform.localPosition, SliderStartLocalPosition, SliderMovementSpeed * Time.deltaTime);
				}
			}
		}

		public override void UseItem()
		{
			if (CanUseItem && BulletsAmounts > 0)
			{
				Shot();
			}
			else if (BulletsAmounts <= 0)
			{
				WeaponRotationCenter.WeaponPositionTransform[ItemWieldPositionID].Rotate(0f, 2f, 0f);
				if (mAudioSource != null && EmptyMagazineAudio != null)
				{
					mAudioSource.PlayOneShot(EmptyMagazineAudio);
				}
			}
			if (BulletsAmounts <= 0 && mAudioSource != null && EmptyMagazineAudio != null && !PlayedEmptySound && !IsInvoking("enableEmptyGunSound"))
			{
				mAudioSource.PlayOneShot(EmptyMagazineAudio);
				PlayedEmptySound = true;
				Invoke("enableEmptyGunSound", 0.2f);
			}
			base.UseItem();
		}

		private void enableEmptyGunSound()
		{
			PlayedEmptySound = false;
		}

		[Command(requiresAuthority = false)]
		public void CMDSpawnBullet(Vector3 shootStart, Vector3 shootEnd, Quaternion shootDirection, Vector3 finalPointNormal)
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			writer.WriteVector3(shootStart);
			writer.WriteVector3(shootEnd);
			writer.WriteQuaternion(shootDirection);
			writer.WriteVector3(finalPointNormal);
			SendCommandInternal("System.Void JUTPS.WeaponSystem.Weapon::CMDSpawnBullet(UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Quaternion,UnityEngine.Vector3)", 779806965, writer, 0, requiresAuthority: false);
			NetworkWriterPool.Return(writer);
		}

		[Command(requiresAuthority = false)]
		private void RPCSpawnBullet(Vector3 shootStart, Vector3 shootEnd, Quaternion shootDirection, Vector3 finalPointNormal)
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			writer.WriteVector3(shootStart);
			writer.WriteVector3(shootEnd);
			writer.WriteQuaternion(shootDirection);
			writer.WriteVector3(finalPointNormal);
			SendCommandInternal("System.Void JUTPS.WeaponSystem.Weapon::RPCSpawnBullet(UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Quaternion,UnityEngine.Vector3)", -1998310678, writer, 0, requiresAuthority: false);
			NetworkWriterPool.Return(writer);
		}

		private void BulletSpawn(GameObject BulletPrefab, Vector3 ShootStart, Vector3 ShootEnd, Quaternion ShootDirection, Vector3 FinalPointNormal, float SecondsToDestroy = 10f)
		{
			if (TPSOwner == null)
			{
				RefreshItemDependencies();
			}
			CMDSpawnBullet(ShootStart, ShootEnd, ShootDirection, FinalPointNormal);
		}

		public void SetWeaponOrientation(Vector3 cameraPosition = default(Vector3), Vector3 shootDirection = default(Vector3))
		{
			CameraPosition = cameraPosition;
			ShootDirection = shootDirection;
		}

		public void Shot()
		{
			if (!CanUseItem)
			{
				Debug.Log("Tried to shot but the CanUseItem variable is false, if using Prevent Gun Clipping ignore this message.");
				return;
			}
			RaycastHit hitInfo2;
			if (FireMode != WeaponFireMode.Shotgun)
			{
				if (enableBulletDirectionCorrection && CameraPosition != Vector3.zero && Physics.Raycast(CameraPosition, ShootDirection, out var hitInfo, 500f, RaycastingLayers))
				{
					ShootDirection = (hitInfo.point - Shoot_Position.position).normalized;
					if (Vector3.Dot(ShootDirection, Shoot_Position.forward) < 0.3f)
					{
						ShootDirection = Shoot_Position.forward;
					}
				}
				if (Vector3.Dot(ShootDirection, Shoot_Position.forward) < 0.3f)
				{
					ShootDirection = Shoot_Position.forward;
				}
				Vector3 shootDirection = ShootDirection;
				shootDirection.x += Random.Range((0f - ShotErrorProbability) / 2f, ShotErrorProbability / 2f);
				shootDirection.y += Random.Range((0f - ShotErrorProbability) / 2f, ShotErrorProbability / 2f);
				shootDirection.z += Random.Range((0f - ShotErrorProbability) / 2f, ShotErrorProbability / 2f);
				if (Physics.Raycast(Shoot_Position.transform.position, shootDirection, out hitInfo2, 500f, RaycastingLayers))
				{
					Shoot_Position.LookAt(hitInfo2.point);
					ShotErrorProbability += LossOfAccuracyPerShot;
					BulletSpawn(BulletPrefab, Shoot_Position.position, hitInfo2.point, Shoot_Position.rotation, hitInfo2.normal);
					Debug.DrawLine(Shoot_Position.transform.position, hitInfo2.point, Color.red);
					if (ShootAudio != null)
					{
						mAudioSource.pitch = Random.Range(0.7f, 1.3f);
						mAudioSource.PlayOneShot(ShootAudio);
					}
				}
				else
				{
					Shoot_Position.rotation = Quaternion.LookRotation(shootDirection);
					BulletSpawn(BulletPrefab, Shoot_Position.position, Vector3.zero, Quaternion.LookRotation(shootDirection), -Shoot_Position.forward);
					ShotErrorProbability += LossOfAccuracyPerShot;
					if (ShootAudio != null && mAudioSource != null)
					{
						mAudioSource.pitch = Random.Range(0.7f, 1.1f);
						mAudioSource.PlayOneShot(ShootAudio);
					}
				}
				if (FireMode == WeaponFireMode.Auto || FireMode == WeaponFireMode.SemiAuto)
				{
					EmitBulletShell();
				}
			}
			else
			{
				if (enableBulletDirectionCorrection && CameraPosition != Vector3.zero && Physics.Raycast(CameraPosition, ShootDirection, out var hitInfo3, 500f, RaycastingLayers))
				{
					ShootDirection = (hitInfo3.point - Shoot_Position.position).normalized;
					if (Vector3.Dot(ShootDirection, Shoot_Position.forward) < 0.3f)
					{
						ShootDirection = Shoot_Position.forward;
					}
				}
				if (Vector3.Dot(ShootDirection, Shoot_Position.forward) < 0.3f)
				{
					ShootDirection = Shoot_Position.forward;
				}
				for (int i = 0; i < NumberOfShotgunBulletsPerShot; i++)
				{
					Vector3 shootDirection2 = ShootDirection;
					shootDirection2.x += Random.Range(0f - LossOfAccuracyPerShot, LossOfAccuracyPerShot);
					shootDirection2.y += Random.Range(0f - LossOfAccuracyPerShot, LossOfAccuracyPerShot);
					shootDirection2.z += Random.Range(0f - LossOfAccuracyPerShot, LossOfAccuracyPerShot);
					ShotErrorProbability += 5f * LossOfAccuracyPerShot;
					if (Physics.Raycast(Shoot_Position.transform.position, shootDirection2, out hitInfo2, 500f, RaycastingLayers))
					{
						Shoot_Position.LookAt(hitInfo2.point);
						Debug.DrawLine(Shoot_Position.transform.position, hitInfo2.point, Color.red);
						BulletSpawn(BulletPrefab, Shoot_Position.position, Vector3.zero, Shoot_Position.rotation, Vector3.zero);
						if (bullet.TryGetComponent<Bullet>(out var component))
						{
							component.SetOwner(TPSControllerUser.gameObject);
							component.FinalPoint = hitInfo2.point;
							component.FinalPointNormal = hitInfo2.normal;
							component.Ignore(ListToIgnoreBulletCollision);
						}
						Object.Destroy(bullet, 10f);
						continue;
					}
					Quaternion rotation = Shoot_Position.transform.rotation;
					rotation.x += Random.Range(0f - LossOfAccuracyPerShot, LossOfAccuracyPerShot);
					rotation.y += Random.Range(0f - LossOfAccuracyPerShot, LossOfAccuracyPerShot);
					rotation.z += Random.Range(0f - LossOfAccuracyPerShot, LossOfAccuracyPerShot);
					rotation.w += Random.Range(0f - LossOfAccuracyPerShot, LossOfAccuracyPerShot);
					GameObject obj = Object.Instantiate(BulletPrefab, Shoot_Position.position, rotation);
					obj.layer = LayerMask.NameToLayer("Bullet");
					if (obj.TryGetComponent<Bullet>(out var component2))
					{
						component2.SetOwner(TPSControllerUser.gameObject);
						component2.Ignore(ListToIgnoreBulletCollision);
					}
					Object.Destroy(obj, 10f);
				}
				if (ShootAudio != null)
				{
					mAudioSource.pitch = Random.Range(0.7f, 1.1f);
					mAudioSource.PlayOneShot(ShootAudio);
				}
			}
			IsUsingItem = true;
			Shoot_Position.localEulerAngles = Vector3.zero;
			if (MuzzleFlashParticlePrefab != null)
			{
				Object.Destroy(Object.Instantiate(MuzzleFlashParticlePrefab, Shoot_Position.position, Shoot_Position.rotation, base.transform), 2f);
			}
			CurrentFireRateToShoot = 0f;
			CanUseItem = false;
			if (!InfiniteAmmo)
			{
				BulletsAmounts--;
			}
			if (!GenerateProceduralAnimation)
			{
				return;
			}
			if (GunSlider != null)
			{
				Vector3 localPosition = new Vector3(SliderStartLocalPosition.x, SliderStartLocalPosition.y, SliderStartLocalPosition.z - SliderMovementOffset);
				switch (SliderMovementAxis)
				{
				case Axis.X:
					localPosition = new Vector3(SliderStartLocalPosition.x - SliderMovementOffset, SliderStartLocalPosition.y, SliderStartLocalPosition.z);
					break;
				case Axis.Y:
					localPosition = new Vector3(SliderStartLocalPosition.x, SliderStartLocalPosition.y - SliderMovementOffset, SliderStartLocalPosition.z);
					break;
				}
				GunSlider.localPosition = localPosition;
			}
			Invoke("WeaponRecoil", 0.06f);
		}

		public void EmitBulletShell()
		{
			if (BulletCasingPrefab != null)
			{
				if (IsParticle)
				{
					BulletCasingParticle.Emit(1);
					return;
				}
				GameObject obj = Object.Instantiate(BulletCasingPrefab, GunSlider.position, base.transform.rotation);
				obj.hideFlags = HideFlags.HideInHierarchy;
				Object.Destroy(obj, 5f);
			}
		}

		public void WeaponRecoil()
		{
			if (CamPivot != null)
			{
				CamPivot.RecoilReaction(CameraRecoilMultiplier * 20f * RecoilForce);
			}
			if (!(WeaponRotationCenter == null))
			{
				WeaponRotationCenter.WeaponPositionTransform[ItemWieldPositionID].Translate(0f, 0f, 0f - RecoilForce);
				if (CamPivot == null)
				{
					WeaponRotationCenter.WeaponPositionTransform[ItemWieldPositionID].Rotate(Random.Range((0f - RecoilForceRotation) / 2f, RecoilForceRotation / 2f), Random.Range(0f - RecoilForceRotation, 0f), Random.Range((0f - RecoilForceRotation) / 8f, RecoilForceRotation / 8f));
				}
				else if (!CamPivot.Aiming)
				{
					WeaponRotationCenter.WeaponPositionTransform[ItemWieldPositionID].Rotate(Random.Range((0f - RecoilForceRotation) / 2f, RecoilForceRotation / 2f), Random.Range(0f - RecoilForceRotation, 0f), Random.Range((0f - RecoilForceRotation) / 8f, RecoilForceRotation / 8f));
				}
				else
				{
					WeaponRotationCenter.WeaponPositionTransform[ItemWieldPositionID].Rotate(0f, Random.Range((0f - RecoilForceRotation) / 2f, 0f), 0f);
				}
			}
		}

		public void Reload()
		{
			if (BulletsAmounts < BulletsPerMagazine)
			{
				if (TotalBullets >= BulletsPerMagazine)
				{
					BulletsAmounts = BulletsPerMagazine;
					TotalBullets -= BulletsPerMagazine;
				}
				else
				{
					BulletsAmounts = TotalBullets;
					TotalBullets = 0;
				}
			}
			mAudioSource.PlayOneShot(ReloadAudio);
		}

		public override bool Weaved()
		{
			return true;
		}

		protected void UserCode_CMDSpawnBullet__Vector3__Vector3__Quaternion__Vector3(Vector3 shootStart, Vector3 shootEnd, Quaternion shootDirection, Vector3 finalPointNormal)
		{
			RPCSpawnBullet(shootStart, shootEnd, shootDirection, finalPointNormal);
		}

		protected static void InvokeUserCode_CMDSpawnBullet__Vector3__Vector3__Quaternion__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkServer.active)
			{
				Debug.LogError("Command CMDSpawnBullet called on client.");
			}
			else
			{
				((Weapon)obj).UserCode_CMDSpawnBullet__Vector3__Vector3__Quaternion__Vector3(reader.ReadVector3(), reader.ReadVector3(), reader.ReadQuaternion(), reader.ReadVector3());
			}
		}

		protected void UserCode_RPCSpawnBullet__Vector3__Vector3__Quaternion__Vector3(Vector3 shootStart, Vector3 shootEnd, Quaternion shootDirection, Vector3 finalPointNormal)
		{
			bullet = Object.Instantiate(BulletPrefab, shootStart, shootDirection);
			bullet.layer = LayerMask.NameToLayer("Bullet");
			NetworkServer.Spawn(bullet.gameObject);
			if (bullet.TryGetComponent<Bullet>(out var component))
			{
				component.RPCSetProperties(shootStart, (shootEnd != Vector3.zero) ? shootEnd : Vector3.zero, finalPointNormal);
				bullet.transform.position = shootStart;
				component.Owner = TPSControllerUser.gameObject;
				component.Ignore(ListToIgnoreBulletCollision);
			}
			Object.Destroy(bullet, 10f);
		}

		protected static void InvokeUserCode_RPCSpawnBullet__Vector3__Vector3__Quaternion__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkServer.active)
			{
				Debug.LogError("Command RPCSpawnBullet called on client.");
			}
			else
			{
				((Weapon)obj).UserCode_RPCSpawnBullet__Vector3__Vector3__Quaternion__Vector3(reader.ReadVector3(), reader.ReadVector3(), reader.ReadQuaternion(), reader.ReadVector3());
			}
		}

		static Weapon()
		{
			RemoteProcedureCalls.RegisterCommand(typeof(Weapon), "System.Void JUTPS.WeaponSystem.Weapon::CMDSpawnBullet(UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Quaternion,UnityEngine.Vector3)", InvokeUserCode_CMDSpawnBullet__Vector3__Vector3__Quaternion__Vector3, requiresAuthority: false);
			RemoteProcedureCalls.RegisterCommand(typeof(Weapon), "System.Void JUTPS.WeaponSystem.Weapon::RPCSpawnBullet(UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Quaternion,UnityEngine.Vector3)", InvokeUserCode_RPCSpawnBullet__Vector3__Vector3__Quaternion__Vector3, requiresAuthority: false);
		}
	}
}
