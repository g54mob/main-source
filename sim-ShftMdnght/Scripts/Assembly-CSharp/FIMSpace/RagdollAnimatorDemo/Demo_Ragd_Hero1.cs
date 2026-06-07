using System;
using System.Collections;
using System.Collections.Generic;
using FIMSpace.FProceduralAnimation;
using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	[DefaultExecutionOrder(10)]
	public class Demo_Ragd_Hero1 : FimpossibleComponent
	{
		public FBasic_RigidbodyMover Mover;

		public Animator Mecanim;

		public RagdollAnimator2 Ragdoll;

		public LayerMask HittableLayermask;

		public GameObject PushParticle;

		[Space(6f)]
		public float PunchPower = 10f;

		public float UppercutPower = 10f;

		public float PushForcePower = 50f;

		public float ThrowPower = 50f;

		public float GripEndPushPower = 10f;

		[Space(6f)]
		public Transform UpperArm;

		public Transform Hand;

		public AudioSource HitAudio;

		[Header("References")]
		public RA2MagnetPoint CatchMagnet;

		public RA2MagnetPoint GripMagnet;

		[Header("Input")]
		public KeyCode PunchKey;

		public KeyCode PunchUppercutKey;

		public KeyCode PushForceKey;

		public KeyCode GridForceKey;

		public KeyCode CatchKey;

		private int actionHash = Animator.StringToHash("Action");

		private List<Collider> toIgnore = new List<Collider>();

		private KeyCode chargeKey;

		private float chargedScale = 1f;

		private float chargeAmount = -1f;

		private float rotated;

		private RagdollHandler gripped;

		private Vector3 magnetPosLocal = Vector3.zero;

		private RagdollHandler isHoldingUp;

		private bool updateUpperBodyLayer;

		private float _sd_layer;

		private Collider[] surround = new Collider[64];

		private int surroundCount;

		private Collider[] far = new Collider[32];

		private int farCount;

		private Collider[] mid = new Collider[32];

		private int midCount;

		private Collider[] close = new Collider[16];

		private int closeCount;

		private List<Collider> used = new List<Collider>();

		private List<RagdollHandler> detectedRagdolls = new List<RagdollHandler>();

		private bool InAction => Mecanim.GetBool(actionHash);

		private bool Action
		{
			get
			{
				return Mecanim.GetBool(actionHash);
			}
			set
			{
				Mecanim.SetBool(actionHash, value);
			}
		}

		private void Start()
		{
			Collider[] componentsInChildren = Mover.GetComponentsInChildren<Collider>();
			foreach (Collider item in componentsInChildren)
			{
				toIgnore.Add(item);
			}
			if ((bool)Ragdoll)
			{
				foreach (Collider item2 in Ragdoll.Settings.User_GetAllDummyColliders())
				{
					toIgnore.Add(item2);
				}
			}
			if ((bool)GripMagnet)
			{
				GripMagnet.transform.SetParent(null);
			}
		}

		private void LateUpdate()
		{
			Vector2 zero = Vector2.zero;
			if (!InAction)
			{
				if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
				{
					zero += Vector2.left;
				}
				else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
				{
					zero += Vector2.right;
				}
				if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
				{
					zero += Vector2.up;
				}
				else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
				{
					zero += Vector2.down;
				}
				if (Input.GetKeyDown(PunchKey))
				{
					StartCharge(PunchKey);
				}
				else if (Input.GetKeyDown(PunchUppercutKey))
				{
					StartCharge(PunchUppercutKey);
				}
				else if (Input.GetKeyDown(PushForceKey))
				{
					DoPushForce();
				}
				else if (Input.GetKeyDown(GridForceKey))
				{
					DoGripForce();
				}
				else if (Input.GetKeyDown(CatchKey))
				{
					DoCatch();
				}
				else if (Input.GetKeyDown(KeyCode.Space))
				{
					DoJump();
				}
			}
			else if (chargeKey != KeyCode.None)
			{
				if (Input.GetKeyUp(chargeKey))
				{
					float timeOffset = Mathf.Clamp(chargeAmount, 0f, 0.125f);
					if (chargeKey == PunchKey)
					{
						DoPunchF(timeOffset);
					}
					else if (chargeKey == PunchUppercutKey)
					{
						DoPunchU(timeOffset);
					}
					chargeKey = KeyCode.None;
				}
				else
				{
					rotated += Time.deltaTime * (110f + Mathf.Clamp(chargeAmount * 75f, 0f, 100f)) * 10f;
					chargeAmount += Time.deltaTime;
					chargedScale = 1f + Mathf.Clamp(chargeAmount * 0.5f, 0f, 0.8f);
				}
			}
			if (chargeKey == KeyCode.None)
			{
				chargedScale = Mathf.Lerp(chargedScale, 1f, Time.deltaTime * 4f);
			}
			if ((bool)Hand)
			{
				Hand.localScale = new Vector3(chargedScale, chargedScale, chargedScale);
			}
			UpdateHoldingUp();
			Mover.moveDirectionLocal = zero;
		}

		private void StartCharge(KeyCode key)
		{
			Action = true;
			chargeKey = key;
			chargeAmount = -0.2f;
			rotated = 0f;
			PlayClip("Punch Charge");
		}

		public void DoPunchF(float timeOffset = 0f)
		{
			PlayClip("Punch F", timeOffset);
		}

		public void DoPunchU(float timeOffset = 0f)
		{
			PlayClip("Punch U", timeOffset);
		}

		public void DoPushForce(float timeOffset = 0f)
		{
			PlayClip("Force Push", timeOffset);
		}

		public void DoGripForce()
		{
			if (GripMagnet.enabled)
			{
				GripMagnet.enabled = false;
				updateUpperBodyLayer = false;
				RagdollChainBone ragdollChainBone = gripped.User_GetBoneSetupByHumanoidBone(HumanBodyBones.Head);
				ragdollChainBone.GameRigidbody.isKinematic = false;
				gripped.User_OverrideMusclesPower = null;
				gripped.Mecanim.CrossFadeInFixedTime("Fall Pose", 0.2f);
				gripped.RigidbodyDragValue = 0f;
				gripped.User_UpdateAllBonesParametersAfterManualChanges();
				RAF_FallingBlendTreePoser extraFeature = gripped.GetExtraFeature<RAF_FallingBlendTreePoser>();
				if ((bool)extraFeature)
				{
					extraFeature.Helper.Enabled = true;
				}
				gripped.User_AddBoneImpact(ragdollChainBone, base.transform.forward * GripEndPushPower, 0.15f, ForceMode.Force, 0f, 1);
				gripped.User_AddBoneImpact(gripped.GetAnchorBoneController, base.transform.forward * GripEndPushPower * 0.75f, 0.1f, ForceMode.Force, 0f, 1);
				gripped = null;
				return;
			}
			CastSurroundSphere();
			List<RagdollHandler> list = FindRagdollsIn(surround, surroundCount);
			float num = float.MaxValue;
			RagdollHandler ragdollHandler = null;
			foreach (RagdollHandler item in list)
			{
				Vector3 vector = item.GetBaseTransform().position - base.transform.position;
				if (!(vector.magnitude > 10f))
				{
					float num2 = Vector3.Angle(vector.normalized, base.transform.forward);
					if (!(num2 > 30f) && num2 < num)
					{
						num = num2;
						ragdollHandler = item;
					}
				}
			}
			if (ragdollHandler != null)
			{
				gripped = ragdollHandler;
				gripped.User_SwitchFallState();
				gripped.Mecanim.CrossFadeInFixedTime("Gripped", 0.2f);
				gripped.User_OverrideMusclesPower = 0.9f;
				RAF_FallingBlendTreePoser extraFeature2 = gripped.GetExtraFeature<RAF_FallingBlendTreePoser>();
				if ((bool)extraFeature2)
				{
					extraFeature2.Helper.Enabled = false;
				}
				Mecanim.CrossFadeInFixedTime("Force Grip", 0.1f, 1);
				gripped.RigidbodyDragValue = 3f;
				GripMagnet.ToMove = gripped.User_GetBoneSetupByHumanoidBone(HumanBodyBones.Head).GameRigidbody.transform;
				magnetPosLocal = base.transform.InverseTransformPoint(GripMagnet.ToMove.position + Vector3.up * 1f);
				GripMagnet.transform.position = GripMagnet.ToMove.position;
				GripMagnet.enabled = true;
				GripMagnet.DragPower = 0f;
				GripMagnet.RotatePower = 0f;
				updateUpperBodyLayer = true;
				gripped.User_UpdateAllBonesParametersAfterManualChanges();
			}
			PlayClip("Force Grip");
		}

		public void DoCatch()
		{
			if (isHoldingUp == null)
			{
				CastCloseBox();
				Mecanim.CrossFadeInFixedTime("Holding", 0.1f, 1);
				RagdollHandler ragdollHandler = FindRagdollIn(close, closeCount);
				isHoldingUp = ragdollHandler;
				if (isHoldingUp != null)
				{
					isHoldingUp.User_SwitchFallState();
					isHoldingUp.Mecanim.CrossFadeInFixedTime("Gripped", 0.15f);
					isHoldingUp.User_OverrideMusclesPower = 0.9f;
					RagdollChainBone ragdollChainBone = isHoldingUp.User_GetBoneSetupByHumanoidBone(HumanBodyBones.Head);
					CatchMagnet.DragPower = 1f;
					CatchMagnet.ToMove = ragdollChainBone.GameRigidbody.transform;
					CatchMagnet.enabled = true;
				}
				updateUpperBodyLayer = isHoldingUp != null;
			}
			else
			{
				updateUpperBodyLayer = false;
				PlayClip("Holding Throw");
			}
		}

		public void DoJump()
		{
			if (Mover.isGrounded)
			{
				Mover.jumpRequest = Mover.JumpPower;
			}
		}

		private void UpdateHoldingUp()
		{
			if (CatchMagnet.enabled)
			{
				CatchMagnet.DragPower = Mathf.Min(3f, CatchMagnet.DragPower + Time.deltaTime * 6f);
				CatchMagnet.RotatePower = CatchMagnet.DragPower;
			}
			if ((bool)GripMagnet && GripMagnet.enabled && gripped != null)
			{
				GripMagnet.DragPower = Mathf.MoveTowards(GripMagnet.DragPower, 0.5f, Time.deltaTime * 1f);
				GripMagnet.RotatePower = GripMagnet.DragPower * 5f;
				gripped.OverrideSpringsValueOnFall = 4000f;
				Transform transform = Camera.main.transform;
				Vector3 position = base.transform.TransformPoint(magnetPosLocal);
				position = transform.InverseTransformPoint(position);
				position.x = 0f;
				position.z = magnetPosLocal.z + 1f;
				if (transform.TransformPoint(new Vector3(position.x, 1f, position.z)).y > base.transform.TransformPoint(magnetPosLocal).y)
				{
					position.y = 1f;
				}
				GripMagnet.transform.position = Vector3.MoveTowards(GripMagnet.transform.position, transform.TransformPoint(position), Time.deltaTime * 30f);
				GripMagnet.transform.rotation = Quaternion.LookRotation(transform.position - GripMagnet.transform.position);
			}
			float target = -0.001f;
			float smoothTime = 0.045f;
			if (updateUpperBodyLayer)
			{
				target = 1.001f;
				smoothTime = 0.07f;
				if ((bool)GripMagnet && GripMagnet.enabled)
				{
					smoothTime = 0.4f;
				}
			}
			float layerWeight = Mecanim.GetLayerWeight(1);
			layerWeight = Mathf.SmoothDamp(layerWeight, target, ref _sd_layer, smoothTime, 100000f, Time.deltaTime);
			Mecanim.SetLayerWeight(1, layerWeight);
		}

		public void PlayClip(string state, float timeOffset = 0f)
		{
			Mecanim.CrossFadeInFixedTime(state, 0.145f, 0, timeOffset);
		}

		public void EThrow()
		{
			CatchMagnet.enabled = false;
			RagdollChainBone ragdollChainBone = isHoldingUp.User_GetBoneSetupByHumanoidBone(HumanBodyBones.Head);
			ragdollChainBone.GameRigidbody.isKinematic = false;
			isHoldingUp.User_OverrideMusclesPower = null;
			isHoldingUp.Mecanim.CrossFadeInFixedTime("Fall Pose", 0.2f);
			isHoldingUp.User_AddBoneImpact(ragdollChainBone, base.transform.forward * ThrowPower, 0.15f, ForceMode.Force, 0f, 1);
			isHoldingUp.User_AddBoneImpact(isHoldingUp.GetAnchorBoneController, base.transform.forward * ThrowPower * 0.75f, 0.1f, ForceMode.Force, 0f, 1);
			isHoldingUp = null;
		}

		public void EPunchForward()
		{
			CastCloseBox(1f, 0.3f, 0.25f, 1.1f);
			RagdollHandler ragdollHandler = FindRagdollIn(close, closeCount);
			if (ragdollHandler != null)
			{
				if ((bool)HitAudio)
				{
					HitAudio.Play();
				}
				Vector3 vector = base.transform.forward + new Vector3(0f, 0.33f, 0f);
				Rigidbody rigidbody = ragdollHandler.User_GetNearestRagdollRigidbodyToPosition(base.transform.TransformPoint(new Vector3(0f, 1.45f, 0.2f)), fast: true, ERagdollChainType.Core);
				if (!(rigidbody == null))
				{
					ragdollHandler.User_SwitchFallState();
					float num = 1f + chargeAmount * 0.4f;
					ragdollHandler.User_AddAllBonesImpact(vector * (PunchPower * 0.5f * num), 0.05f);
					ragdollHandler.User_AddRigidbodyImpact(rigidbody, vector * (PunchPower * 1.5f * num), 0f);
				}
			}
		}

		public void EPunchUp()
		{
			CastCloseBox(1f, 0.05f, 0.25f, 0.9f);
			RagdollHandler ragdollHandler = FindRagdollIn(close, closeCount);
			if (ragdollHandler != null)
			{
				if ((bool)HitAudio)
				{
					HitAudio.Play();
				}
				Vector3 up = Vector3.up;
				Rigidbody rigidbody = ragdollHandler.User_GetNearestRagdollRigidbodyToPosition(base.transform.TransformPoint(new Vector3(0f, 1.45f, 0.2f)), fast: true, ERagdollChainType.Core);
				if (!(rigidbody == null))
				{
					ragdollHandler.User_SwitchFallState();
					float num = 1f + chargeAmount * 0.3f;
					ragdollHandler.User_AddAllBonesImpact(up * (UppercutPower * 0.55f * num), 0f, ForceMode.VelocityChange);
					ragdollHandler.User_AddRigidbodyImpact(rigidbody, up * (UppercutPower * 2.1f * num), 0f, ForceMode.Impulse, 0.05f);
				}
			}
		}

		public void EPushForce()
		{
			CastFarSphere(3f, 1.5f);
			CastMidBox(1f, 1.4f, 1f, 4f);
			if ((bool)PushParticle)
			{
				GameObject obj = UnityEngine.Object.Instantiate(PushParticle);
				obj.transform.position = base.transform.position + Vector3.up + base.transform.forward;
				obj.transform.rotation = base.transform.rotation;
			}
			used.Clear();
			StartCoroutine(_IE_CallAfter(0.06f, delegate
			{
				for (int i = 0; i < farCount; i++)
				{
					AddForce(far[i]);
				}
				for (int j = 0; j < midCount; j++)
				{
					if (!used.Contains(mid[j]))
					{
						AddForce(mid[j]);
					}
				}
			}));
			List<RagdollHandler> list = FindRagdollsIn(far, farCount);
			for (int num = 0; num < list.Count; num++)
			{
				RagdollHandler iHandler = list[num];
				iHandler.User_SwitchFallState(RagdollHandler.EAnimatingMode.Falling);
				Rigidbody rigidbody = iHandler.User_GetNearestRagdollRigidbodyToPosition(base.transform.TransformPoint(Vector3.up * 1.5f), fast: true, ERagdollChainType.Core);
				if (!(rigidbody == null))
				{
					Vector3 normalized = (iHandler.User_GetPosition_Center() - Mover.transform.position).normalized;
					iHandler.User_AddRigidbodyImpact(rigidbody, (normalized + new Vector3(0f, 0.4f, 0f)) * (PushForcePower * 0.5f), 0.14f, ForceMode.Impulse, 0.06f);
				}
			}
		}

		private IEnumerator _IE_CallAfter(float delay, Action act)
		{
			if (act != null)
			{
				if (delay > 0f)
				{
					yield return new WaitForSeconds(delay);
				}
				act();
			}
		}

		private void CastSurroundSphere(float forwardDistance = 6f, float radius = 8f)
		{
			Vector3 position = base.transform.TransformPoint(new Vector3(0f, 1f, forwardDistance));
			surroundCount = Mathf.Min(surround.Length - 1, Physics.OverlapSphereNonAlloc(position, radius, surround, HittableLayermask));
		}

		private void CastFarSphere(float distance = 3f, float radius = 1f)
		{
			Vector3 position = base.transform.TransformPoint(new Vector3(0f, 1f, distance));
			farCount = Mathf.Min(far.Length - 1, Physics.OverlapSphereNonAlloc(position, radius, far, HittableLayermask));
		}

		private void CastMidBox(float y = 1f, float width = 1.5f, float height = 1f, float zScale = 2f)
		{
			Vector3 center = base.transform.TransformPoint(new Vector3(0f, y, 0.5f + zScale * 0.5f));
			midCount = Mathf.Min(mid.Length - 1, Physics.OverlapBoxNonAlloc(center, new Vector3(width, height, zScale), mid, base.transform.rotation, HittableLayermask));
		}

		private void CastCloseBox(float y = 1f, float width = 0.05f, float height = 0.25f, float zScale = 1f)
		{
			Vector3 center = base.transform.TransformPoint(new Vector3(0f, y, 0.5f * zScale));
			closeCount = Mathf.Min(close.Length - 1, Physics.OverlapBoxNonAlloc(center, new Vector3(width, height, zScale), close, base.transform.rotation, HittableLayermask));
		}

		private void AddForce(Collider c)
		{
			if (!toIgnore.Contains(c) && !(c == null))
			{
				used.Add(c);
				Rigidbody attachedRigidbody = c.attachedRigidbody;
				if (!(attachedRigidbody == null))
				{
					Vector3 forward = base.transform.forward;
					forward = Vector3.Lerp(forward, (c.bounds.center - base.transform.TransformPoint(Vector3.up) + new Vector3(0f, UnityEngine.Random.Range(0f, 0.5f))).normalized, UnityEngine.Random.Range(0.6f, 1f)).normalized;
					attachedRigidbody.AddForce(forward * (PushForcePower * UnityEngine.Random.Range(0.6f, 0.8f)), ForceMode.Impulse);
					attachedRigidbody.AddTorque(forward * (PushForcePower * 0.5f * UnityEngine.Random.Range(0.9f, 1.1f)), ForceMode.Impulse);
				}
			}
		}

		private RagdollHandler FindRagdollIn(Collider[] c, int length)
		{
			for (int i = 0; i < length; i++)
			{
				if (c[i] == null || toIgnore.Contains(c[i]))
				{
					continue;
				}
				RagdollAnimator2BoneIndicator component = c[i].gameObject.GetComponent<RagdollAnimator2BoneIndicator>();
				if ((bool)component)
				{
					if (!Ragdoll)
					{
						return component.ParentHandler;
					}
					if (component.ParentHandler != Ragdoll.Settings)
					{
						return component.ParentHandler;
					}
				}
			}
			return null;
		}

		private List<RagdollHandler> FindRagdollsIn(Collider[] c, int length, bool clear = true)
		{
			if (clear)
			{
				detectedRagdolls.Clear();
			}
			for (int i = 0; i < length; i++)
			{
				if (!(c[i] == null) && !toIgnore.Contains(c[i]))
				{
					RagdollAnimator2BoneIndicator component = c[i].gameObject.GetComponent<RagdollAnimator2BoneIndicator>();
					if ((bool)component && (!Ragdoll || component.ParentHandler != Ragdoll.Settings) && !detectedRagdolls.Contains(component.ParentHandler))
					{
						detectedRagdolls.Add(component.ParentHandler);
					}
				}
			}
			return detectedRagdolls;
		}
	}
}
