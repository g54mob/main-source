using System.Collections;
using System.Collections.Generic;
using FIMSpace.FProceduralAnimation;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_PoolableRagdollExample : MonoBehaviour, IRagdollAnimator2Receiver
	{
		public Animator Mecanim;

		public RagdollAnimator2 Ragdoll;

		public List<AnimationClip> PlayRandom = new List<AnimationClip>();

		private PlayableGraph graph;

		private AnimationPlayableOutput baseOutput;

		private AnimationLayerMixerPlayable mixer;

		private AnimationClipPlayable clipPlayable;

		[Space(4f)]
		public Vector3 moveRange = new Vector3(1f, 0f, 1f);

		public float TrigoSpeed = 2f;

		private float trigoTime1;

		private float trigoTime2;

		[Space(4f)]
		public string TagToGetHitOn = "Finish";

		public float StartFallOnHitPower = 4f;

		public float HitImpulse = 8f;

		private bool isDead;

		public Vector3 startPosition { get; private set; }

		public void ResetAnimationOnStart()
		{
			graph = PlayableGraph.Create(base.name);
			graph.SetTimeUpdateMode(DirectorUpdateMode.GameTime);
			baseOutput = AnimationPlayableOutput.Create(graph, "Test", Mecanim);
			mixer = AnimationLayerMixerPlayable.Create(graph, 1);
			baseOutput.SetSourcePlayable(mixer);
			CreatePlayableClip(PlayRandom[Random.Range(0, PlayRandom.Count)]);
			graph.Play();
		}

		private void CreatePlayableClip(AnimationClip clip)
		{
			if (clipPlayable.IsValid())
			{
				clipPlayable.Destroy();
			}
			mixer.DisconnectInput(0);
			clipPlayable = AnimationClipPlayable.Create(graph, clip);
			clipPlayable.SetApplyFootIK(value: true);
			mixer.ConnectInput(0, clipPlayable, 0);
			mixer.SetInputWeight(0, 1f);
		}

		private void Start()
		{
			ResetOnStart();
		}

		public void ResetOnStart()
		{
			isDead = false;
			startPosition = base.transform.position;
			trigoTime1 = Random.Range(-10000f, 100000f);
			trigoTime2 = Random.Range(-10000f, 100000f);
			SetPosition();
			ResetAnimationOnStart();
			Ragdoll.Handler.Initialize(Ragdoll, Ragdoll.gameObject);
			Ragdoll.Handler.ApplyTPoseOnModel();
			Ragdoll.User_WarpRefresh();
			Ragdoll.RA2Event_SwitchToStand();
		}

		private void LateUpdate()
		{
			trigoTime1 += Time.deltaTime * TrigoSpeed;
			trigoTime2 += Time.deltaTime * TrigoSpeed;
			SetPosition();
		}

		private void SetPosition()
		{
			Vector3 vector = new Vector3(0f, 0f, 0f);
			vector.x = Mathf.Sin(trigoTime1) * moveRange.x;
			vector.z = Mathf.Cos(trigoTime2) * moveRange.z;
			Vector3 vector2 = startPosition + vector;
			Vector3 vector3 = vector2 - base.transform.position;
			if (vector3 != Vector3.zero)
			{
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, Quaternion.LookRotation(vector3), Time.deltaTime * 4f);
			}
			base.transform.position = vector2;
		}

		public void RagdollAnimator2_OnCollisionEnterEvent(RA2BoneCollisionHandler hitted, Collision mainCollision)
		{
			if (mainCollision.gameObject.CompareTag(TagToGetHitOn) && mainCollision.impulse.magnitude > StartFallOnHitPower)
			{
				hitted.ParentHandler.User_SwitchFallState();
				hitted.ParentHandler.User_AddBoneImpact(hitted.BoneSettings, mainCollision.relativeVelocity.normalized * HitImpulse, 0.04f);
				if (!isDead)
				{
					StartCoroutine(IEBackToPool());
				}
				isDead = true;
			}
		}

		private IEnumerator IEBackToPool()
		{
			yield return new WaitForSeconds(2f);
			Demo_Ragd_ObjectPoolingManager.Get.GiveBackObject(base.gameObject);
		}
	}
}
