using System;
using System.Collections.Generic;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Utilities/Effects - Audio/Step Manager")]
	public class StepsManager : MonoBehaviour, IAnimatorListener
	{
		[Tooltip("Enable Disable the Steps Manager")]
		public bool Active = true;

		[Tooltip("Time to wait to create a new track")]
		public float WaitNextStep = 0.2f;

		[Tooltip("Layer Mask used to find the ground")]
		public LayerReference GroundLayer = new LayerReference(1);

		[Tooltip("Global Particle System for the Tracks, to have more individual tracks ")]
		public ParticleSystem Tracks;

		private ParticleSystem Instance;

		[Tooltip("Particle System for the Dust")]
		public ParticleSystem Dust;

		[Tooltip("This will instantiate a gameObject instead of using the Particle system")]
		public bool instantiateTracks;

		[Tooltip("Create Foot Tracks Particles only on Static GameObjects")]
		public bool GroundIsStatic;

		public float StepsVolume = 0.2f;

		public int DustParticles = 30;

		[Tooltip("Scale of the dust and track particles")]
		public Vector3 Scale = Vector3.one;

		[Tooltip("Sounds to play when the animal creates a track")]
		public AudioClipReference sounds;

		[Tooltip("Distance to Instantiate the tracks on a terrain")]
		public float trackOffset = 0.0085f;

		[Tooltip("Tracks will be on only when the character is on any of these tats")]
		public List<StateID> TracksOnlyOnState;

		private bool InTrackState;

		private ICharacterAction character;

		public List<StepTrigger> Feet { get; set; }

		Transform IAnimatorListener.transform => base.transform;

		private void Awake()
		{
			if (Tracks != null)
			{
				if (Tracks.gameObject.IsPrefab())
				{
					Instance = UnityEngine.Object.Instantiate(Tracks, base.transform, worldPositionStays: false);
				}
				else
				{
					Instance = Tracks;
				}
				Instance.transform.localScale = Scale;
			}
			InTrackState = true;
			character = GetComponentInParent<ICharacterAction>();
		}

		private void OnEnable()
		{
			if (character != null && TracksOnlyOnState != null)
			{
				ICharacterAction characterAction = character;
				characterAction.OnState = (Action<int>)Delegate.Combine(characterAction.OnState, new Action<int>(StateChange));
			}
		}

		private void OnDisable()
		{
			if (character != null && TracksOnlyOnState != null)
			{
				ICharacterAction characterAction = character;
				characterAction.OnState = (Action<int>)Delegate.Remove(characterAction.OnState, new Action<int>(StateChange));
			}
		}

		private void StateChange(int obj)
		{
			if (Feet == null)
			{
				return;
			}
			InTrackState = TracksOnlyOnState.Find((StateID x) => x.ID == obj);
			foreach (StepTrigger foot in Feet)
			{
				foot.gameObject.SetActive(InTrackState);
			}
		}

		internal void EnterStep(StepTrigger foot, Collider surface)
		{
			if (!Active)
			{
				return;
			}
			if ((bool)Dust && Dust.gameObject.IsPrefab())
			{
				Dust = UnityEngine.Object.Instantiate(Dust, base.transform, worldPositionStays: false);
				Dust.transform.localScale = Scale;
			}
			if ((bool)foot.StepAudio && foot.StepAudio.enabled && !sounds.NullOrEmpty())
			{
				sounds.Play(foot.StepAudio);
			}
			Ray ray = new Ray(foot.transform.position, -base.transform.up);
			if (!surface.Raycast(ray, out var hitInfo, 1f))
			{
				return;
			}
			Vector3 position = foot.transform.position;
			position.y += trackOffset;
			Quaternion rotation = Quaternion.FromToRotation(-foot.transform.forward, hitInfo.normal) * foot.transform.rotation;
			if ((bool)Dust)
			{
				Dust.transform.SetPositionAndRotation(position, rotation);
				Dust.transform.Rotate(-90f, 0f, 0f);
				Dust.Emit(DustParticles);
			}
			if (!Instance)
			{
				return;
			}
			ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams
			{
				rotation3D = rotation.eulerAngles,
				position = position
			};
			if (instantiateTracks)
			{
				if (GroundIsStatic && surface.gameObject.isStatic)
				{
					Instance.Emit(emitParams, 1);
					return;
				}
				ParticleSystem newtrack = UnityEngine.Object.Instantiate(Instance);
				Transform ParentFixer = newtrack.transform.SetParentScaleFixer(hitInfo.transform, position);
				ParticleSystem.EmitParams emitParams2 = new ParticleSystem.EmitParams
				{
					rotation3D = rotation.eulerAngles,
					position = Vector3.zero
				};
				ParticleSystem.MainModule main = newtrack.main;
				main.simulationSpace = ParticleSystemSimulationSpace.Local;
				newtrack.Emit(emitParams2, 1);
				this.Delay_Action(() => newtrack.isPlaying, delegate
				{
					if (ParentFixer != null)
					{
						UnityEngine.Object.Destroy(ParentFixer.gameObject);
					}
				});
			}
			else
			{
				Instance.Emit(emitParams, 1);
			}
		}

		public virtual void EnableSteps(bool value)
		{
			Active = value;
		}

		public virtual bool OnAnimatorBehaviourMessage(string message, object value)
		{
			return this.InvokeWithParams(message, value);
		}
	}
}
