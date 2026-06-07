using FIMSpace.FProceduralAnimation;
using FIMSpace.FTools;
using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	[DefaultExecutionOrder(100001)]
	public class Demo_Ragd_TPPShooter : FimpossibleComponent
	{
		public FBasic_RigidbodyMover Mover;

		public Transform Spine;

		public Animator Mecanim;

		[Space(5f)]
		public Transform ShotPoint;

		public GameObject Muzzle;

		public GameObject Bullet;

		public AudioSource ShotAudio;

		[Space(5f)]
		public float BulletImpact = 2f;

		public float HoldShotCulldown = 0.12f;

		private UniRotateBone rotator;

		private float shotCulldown;

		private void Start()
		{
			rotator = new UniRotateBone(Spine, base.transform);
		}

		private void Update()
		{
			Vector2 zero = Vector2.zero;
			if (Input.GetKey(KeyCode.A))
			{
				zero += Vector2.left;
			}
			else if (Input.GetKey(KeyCode.D))
			{
				zero += Vector2.right;
			}
			if (Input.GetKey(KeyCode.W))
			{
				zero += Vector2.up;
			}
			else if (Input.GetKey(KeyCode.S))
			{
				zero += Vector2.down;
			}
			zero.Normalize();
			Mover.MoveTowards(base.transform.position + base.transform.TransformDirection(new Vector3(zero.x, 0f, zero.y)), setDir: false);
			Vector3 normalized = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up).normalized;
			Mover.SetRotation(normalized);
			Mover.RotateToSpeed = 10000f;
			rotator.PreCalibrate();
		}

		private void Shot()
		{
			shotCulldown = HoldShotCulldown;
			Mecanim.Play("Shot", 2, 0f);
			if ((bool)Muzzle)
			{
				GameObject obj = Object.Instantiate(Muzzle);
				obj.transform.SetParent(ShotPoint, worldPositionStays: true);
				obj.transform.localPosition = Vector3.zero;
				obj.transform.localRotation = Quaternion.identity;
				Object.Destroy(obj, 0.02f);
				GameObject obj2 = Object.Instantiate(Bullet);
				obj2.transform.position = ShotPoint.position;
				Demo_Ragd_Bullet component = obj2.GetComponent<Demo_Ragd_Bullet>();
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				Physics.Raycast(ray.origin, ray.direction, out var hitInfo, 1000f, component.ProjectiletHitMask);
				Quaternion rotation = ShotPoint.rotation;
				rotation = ((!hitInfo.transform) ? Quaternion.LookRotation(ray.origin + ray.direction * 10f - ShotPoint.position) : Quaternion.LookRotation((hitInfo.point - ShotPoint.position).normalized));
				obj2.transform.rotation = rotation;
				component.OnBulletHit = OnBulletHit;
				component.StepForward(0.25f);
			}
			if ((bool)ShotAudio)
			{
				ShotAudio.Play();
			}
		}

		private void LateUpdate()
		{
			if ((bool)Spine)
			{
				Vector3 eulerAngles = Quaternion.LookRotation(base.transform.InverseTransformDirection(Camera.main.transform.forward)).eulerAngles;
				rotator.RotateByDynamic(eulerAngles);
			}
			if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(0))
			{
				Shot();
			}
			else if (Input.GetKey(KeyCode.F) || Input.GetMouseButton(0))
			{
				if (shotCulldown <= 0f)
				{
					Shot();
				}
				else
				{
					shotCulldown -= Time.deltaTime;
				}
			}
			else
			{
				shotCulldown = 0f;
			}
		}

		private void OnBulletHit(Demo_Ragd_Bullet.HitInfo hitInfo)
		{
			if (hitInfo.rHit.collider == null)
			{
				return;
			}
			RagdollAnimator2BoneIndicator component = hitInfo.rHit.collider.transform.GetComponent<RagdollAnimator2BoneIndicator>();
			if ((bool)component)
			{
				if (BulletImpact > 0f)
				{
					component.ParentHandler.User_AddBoneImpact(component.BoneSettings, -hitInfo.rHit.normal * BulletImpact, 0.1f);
					if (!component.ParentHandler.IsFallingOrSleep)
					{
						component.ParentChain.User_ForceOverrideAllBonesBlendFor(0.45f);
					}
				}
				component.ParentRagdollAnimator.SendMessage("Hitted", hitInfo);
			}
			else if (BulletImpact > 0f && hitInfo.rHit.rigidbody != null)
			{
				hitInfo.rHit.rigidbody.AddForce(-hitInfo.rHit.normal * BulletImpact, ForceMode.Force);
			}
		}
	}
}
