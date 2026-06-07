using System;
using MalbersAnimations.Reactions;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations.Utilities
{
	[Serializable]
	public class Effect
	{
		public string Name = "EffectName";

		public int ID;

		public bool active = true;

		public Transform root;

		public bool isChild;

		public bool disableOnStop = true;

		public bool useRootRotation = true;

		public GameObject effect;

		public TransformOffset Offset = new TransformOffset(1);

		public AudioSource audioSource;

		public AudioClipReference Clip;

		[Min(0f)]
		public float life = 10f;

		[Min(0f)]
		public float delay;

		public float scale = 1f;

		[SerializeReference]
		[SubclassSelector]
		public Reaction OnPlayReaction;

		[SerializeReference]
		[SubclassSelector]
		public Reaction OnStopReaction;

		public UnityEvent OnPlay;

		public UnityEvent OnStop;

		[NonSerialized]
		private GameObject instance;

		public Transform Owner { get; set; }

		public bool IsPlaying { get; set; }

		public GameObject Instance
		{
			get
			{
				return instance;
			}
			set
			{
				instance = value;
			}
		}

		public TrailRenderer IsTrailRenderer { get; set; }

		public ParticleSystem IsParticleSystem { get; set; }

		internal void Initialize()
		{
			if (effect != null && !effect.IsPrefab())
			{
				effect.gameObject.SetActive(value: false);
				IsTrailRenderer = effect.FindComponent<TrailRenderer>();
				IsParticleSystem = effect.FindComponent<ParticleSystem>();
			}
		}
	}
}
