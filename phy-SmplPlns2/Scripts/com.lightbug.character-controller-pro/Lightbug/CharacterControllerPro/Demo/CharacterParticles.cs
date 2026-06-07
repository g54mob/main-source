using Lightbug.CharacterControllerPro.Core;
using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	[AddComponentMenu("Character Controller Pro/Demo/Character/Character Particles")]
	public class CharacterParticles : MonoBehaviour
	{
		[HelpBox("This script contains a \"PlayFootstep\" method, which is intended to be used as an animation event function. Please make sure the animation clip does trigger this event (if you want to see the effect in action).", HelpBoxMessageType.Warning)]
		[Tooltip("This prefab will be used by the grounded and the footsteps particles.")]
		[SerializeField]
		private GameObject groundParticlesPrefab;

		[Header("Grounded particles")]
		[Tooltip("The character vertical speed at the moment of impact (on the horizontal axis) vs the particle system main module start speed (on the vertical axis).")]
		[SerializeField]
		private AnimationCurve groundParticlesSpeed = AnimationCurve.Linear(0f, 0.5f, 10f, 3f);

		[Header("Footsteps particles")]
		[Tooltip("The character on ground speed (on the horizontal axis) vs the particle system main module start speed (on the vertical axis).")]
		[SerializeField]
		private AnimationCurve footstepParticleSpeed = AnimationCurve.Linear(0f, 0.5f, 10f, 3f);

		[Tooltip("The character on ground speed (on the horizontal axis) vs the particle system main module start size (on the vertical axis).")]
		[SerializeField]
		private AnimationCurve footstepParticleSize = AnimationCurve.Linear(0f, 0.5f, 10f, 3f);

		private ParticleSystem[] groundParticlesArray = new ParticleSystem[10];

		private ParticleSystemPooler particlesPooler;

		private MaterialController materialController;

		private CharacterActor CharacterActor;

		private void Awake()
		{
			CharacterActor = this.GetComponentInBranch<CharacterActor>();
			materialController = this.GetComponentInBranch<CharacterActor, MaterialController>();
			if (materialController == null)
			{
				Debug.Log("CharacterMaterial component missing");
				base.enabled = false;
			}
			else if (groundParticlesPrefab != null)
			{
				particlesPooler = new ParticleSystemPooler(groundParticlesPrefab, CharacterActor.transform.position, CharacterActor.transform.rotation, 10);
			}
		}

		private void OnEnable()
		{
			CharacterActor.OnGroundedStateEnter += OnGroundedStateEnter;
		}

		private void OnDisable()
		{
			CharacterActor.OnGroundedStateEnter -= OnGroundedStateEnter;
		}

		private void OnGroundedStateEnter(Vector3 localVelocity)
		{
			Vector3 position = CharacterActor.transform.position;
			Quaternion rotation = Quaternion.LookRotation(CharacterActor.GroundContactNormal);
			float time = Mathf.Abs(localVelocity.y);
			float startSpeed = groundParticlesSpeed.Evaluate(time);
			particlesPooler.Instantiate(position, rotation, materialController.CurrentSurface.color, startSpeed);
		}

		public void PlayFootstep()
		{
			if (base.enabled)
			{
				Vector3 position = CharacterActor.transform.position;
				Quaternion rotation = ((CharacterActor.GroundContactNormal != Vector3.zero) ? Quaternion.LookRotation(CharacterActor.GroundContactNormal) : Quaternion.identity);
				float magnitude = CharacterActor.Velocity.magnitude;
				particlesPooler.Instantiate(position, rotation, materialController.CurrentSurface.color, footstepParticleSpeed.Evaluate(magnitude), footstepParticleSize.Evaluate(magnitude));
			}
		}

		private void Update()
		{
			particlesPooler.Update();
		}
	}
}
