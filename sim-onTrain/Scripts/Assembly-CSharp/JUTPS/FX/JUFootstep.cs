using System.Collections.Generic;
using UnityEngine;

namespace JUTPS.FX
{
	[AddComponentMenu("JU TPS/FX/Footstep")]
	public class JUFootstep : MonoBehaviour
	{
		private Animator anim;

		[Header("FX Settings")]
		public AudioSource audioSource;

		public List<SurfaceAudiosWithFX> FootstepAudioClips = new List<SurfaceAudiosWithFX>(4);

		public bool InvertX;

		[Range(0f, 1f)]
		public float MinTimeToPlayAudio = 0.3f;

		[Header("Ground Check")]
		public LayerMask GroundLayers;

		[Range(0f, 1f)]
		public float CheckRadius = 0.1f;

		[Header("Ground Check Position Offset")]
		[Range(-0.2f, 0.2f)]
		public float UpOffset = -0.07f;

		[Range(-0.2f, 0.2f)]
		public float ForwardOffset = 0.07f;

		[Space]
		public Transform LeftFoot;

		public Transform RightFoot;

		private bool LeftFootsteped;

		private bool RightFootsteped;

		private float CurrentTimeToLeftFootstep;

		private float CurrentTimeToRightFootstep;

		private void Start()
		{
			audioSource = ((audioSource == null) ? GetComponent<AudioSource>() : audioSource);
			Animator component = GetComponent<Animator>();
			if (component != null)
			{
				anim = component;
				if (LeftFoot == null || RightFoot == null)
				{
					LeftFoot = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
					RightFoot = anim.GetBoneTransform(HumanBodyBones.RightFoot);
				}
			}
			if (GroundLayers.value == 0)
			{
				GroundLayers = LayerMask.GetMask("Default");
			}
		}

		protected virtual void Update()
		{
			if (LeftFoot == null || RightFoot == null)
			{
				LeftFoot = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
				RightFoot = anim.GetBoneTransform(HumanBodyBones.RightFoot);
			}
			Vector3 position = LeftFoot.position + base.transform.forward * ForwardOffset + base.transform.up * UpOffset;
			Vector3 position2 = RightFoot.position + base.transform.forward * ForwardOffset + base.transform.up * UpOffset;
			Collider[] array = Physics.OverlapSphere(position, CheckRadius, GroundLayers);
			Collider[] array2 = Physics.OverlapSphere(position2, CheckRadius, GroundLayers);
			if (CurrentTimeToLeftFootstep < MinTimeToPlayAudio)
			{
				CurrentTimeToLeftFootstep += Time.deltaTime;
			}
			if (CurrentTimeToRightFootstep < MinTimeToPlayAudio)
			{
				CurrentTimeToRightFootstep += Time.deltaTime;
			}
			if (array.Length == 0)
			{
				LeftFootsteped = false;
			}
			else if (array.Length != 0 && !LeftFootsteped && CurrentTimeToLeftFootstep > MinTimeToPlayAudio)
			{
				DoFootstep(LeftFoot, array[0].tag);
				CurrentTimeToLeftFootstep = 0f;
				LeftFootsteped = true;
			}
			if (array2.Length == 0)
			{
				RightFootsteped = false;
			}
			else if (array2.Length != 0 && !RightFootsteped && CurrentTimeToRightFootstep > MinTimeToPlayAudio)
			{
				DoFootstep(RightFoot, array2[0].tag);
				CurrentTimeToRightFootstep = 0f;
				RightFootsteped = true;
			}
		}

		public virtual void DoFootstep(Transform Foot, string SurfaceTag = "Untagged")
		{
			Physics.Raycast(Foot.position, -base.transform.up, out var hitInfo, 1f, GroundLayers);
			GameObject gameObject = SurfaceAudiosWithFX.Play(audioSource, FootstepAudioClips, hitInfo.point, Quaternion.identity, null, SurfaceTag);
			if (!(gameObject == null))
			{
				Transform transform = gameObject.transform;
				transform.rotation = Foot.rotation;
				transform.rotation = Quaternion.FromToRotation(Foot.up, hitInfo.normal) * Foot.rotation;
				transform.rotation = Quaternion.LookRotation(-transform.forward);
				if (Foot == RightFoot)
				{
					transform.localScale = new Vector3(InvertX ? transform.localScale.x : (0f - transform.localScale.x), transform.localScale.y, transform.localScale.z);
				}
				else
				{
					transform.localScale = new Vector3(InvertX ? (0f - transform.localScale.x) : transform.localScale.x, transform.localScale.y, transform.localScale.z);
				}
				Debug.DrawRay(gameObject.transform.position, gameObject.transform.up * 2f, Color.red, 1f);
			}
		}

		private void OnDrawGizmos()
		{
			if (LeftFoot == null || RightFoot == null)
			{
				anim = GetComponent<Animator>();
				LeftFoot = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
				RightFoot = anim.GetBoneTransform(HumanBodyBones.RightFoot);
				return;
			}
			Color green = Color.green;
			green.a = 0.4f;
			Color red = Color.red;
			red.a = 0.2f;
			Vector3 center = LeftFoot.position + base.transform.forward * ForwardOffset + base.transform.up * UpOffset;
			Vector3 center2 = RightFoot.position + base.transform.forward * ForwardOffset + base.transform.up * UpOffset;
			if (LeftFootsteped)
			{
				Gizmos.color = green;
			}
			else
			{
				Gizmos.color = red;
			}
			Gizmos.DrawSphere(center, CheckRadius);
			Gizmos.DrawWireSphere(center, CheckRadius);
			if (RightFootsteped)
			{
				Gizmos.color = green;
			}
			else
			{
				Gizmos.color = red;
			}
			Gizmos.DrawSphere(center2, CheckRadius);
			Gizmos.DrawWireSphere(center2, CheckRadius);
		}
	}
}
