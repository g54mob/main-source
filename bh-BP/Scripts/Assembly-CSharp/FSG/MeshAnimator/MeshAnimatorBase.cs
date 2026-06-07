using System;
using System.Collections.Generic;
using UnityEngine;

namespace FSG.MeshAnimator
{
	[RequireComponent(typeof(MeshFilter))]
	public abstract class MeshAnimatorBase : MonoBehaviour, IMeshAnimator
	{
		[Serializable]
		public struct MeshAnimatorLODLevel
		{
			public int fps;

			public float distance;

			[NonSerialized]
			public float distanceSquared;
		}

		public Mesh baseMesh;

		public float speed;

		public bool updateWhenOffscreen;

		public bool playAutomatically;

		public bool resetOnEnable;

		public GameObject eventReciever;

		public int FPS;

		public bool skipLastLoopFrame;

		public int currentFrame;

		public Transform LODCamera;

		public MeshAnimatorLODLevel[] LODLevels;

		[HideInInspector]
		public float nextTick;

		[HideInInspector]
		public MeshFilter meshFilter;

		[HideInInspector]
		public MeshRenderer meshRenderer;

		[HideInInspector]
		public MeshAnimationBase currentAnimation;

		protected int currentAnimIndex;

		protected bool isVisible;

		protected float lastFrameTime;

		protected bool isPaused;

		protected float currentAnimTime;

		protected Queue<string> queuedAnims;

		protected int currentLodLevel;

		protected Transform mTransform;

		protected Dictionary<string, Transform> childMap;

		protected bool initialized;

		protected int previousEventFrame;

		protected bool hasExposedTransforms;

		protected bool hasLODCamera;

		protected float nextLODCheck;

		protected int animationCount;

		protected ExposedTransformCrossfade exposedTransformCrossfade;

		public abstract IMeshAnimation defaultAnimation { get; set; }

		public abstract IMeshAnimation[] animations { get; }

		public Action<string> OnAnimationFinished { get; set; }

		public Action OnFrameUpdated { get; set; }

		public Action<bool> OnVisibilityChanged { get; set; }

		public MeshRenderer MeshRenderer => null;

		public MeshFilter MeshFilter => null;

		public IMeshAnimation[] Animations => null;

		public float NextTick => 0f;

		protected virtual void Start()
		{
		}

		private void OnBecameVisible()
		{
		}

		private void OnBecameInvisible()
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		protected virtual void AddMeshCount(Dictionary<Mesh, int> counter)
		{
		}

		protected virtual void RemoveMeshCount(Dictionary<Mesh, int> counter)
		{
		}

		private void FireAnimationEvents(IMeshAnimation meshAnimation, float totalSpeed, bool finished)
		{
		}

		private Matrix4x4 MatrixLerp(Matrix4x4 from, Matrix4x4 to, float time)
		{
			return default(Matrix4x4);
		}

		protected virtual bool UpdateExposedTransformCrossfade(int previousFrame)
		{
			return false;
		}

		protected virtual bool DisplayFrame(int previousFrame)
		{
			return false;
		}

		protected virtual void OnAnimationCompleted(bool stopUpdate)
		{
		}

		protected virtual bool StartCrossfade(int index, float speed)
		{
			return false;
		}

		protected virtual void ReturnCrossfadeToPool(bool destroying)
		{
		}

		protected abstract void OnCurrentAnimationChanged(IMeshAnimation meshAnimation);

		protected void GetAnimationStartData(MeshAnimationBase meshAnimationBase, out int frame, out float time)
		{
			frame = default(int);
			time = default(float);
		}

		public abstract void SetAnimations(IMeshAnimation[] meshAnimations);

		public abstract void StoreAdditionalMeshData(Mesh mesh);

		public void UpdateTick(float time)
		{
		}

		public virtual void Play()
		{
		}

		public virtual void Play(string animationName, float normalizedTime = -1f)
		{
		}

		public virtual void Play(int index)
		{
		}

		public void PlayRandom(params string[] animationNames)
		{
		}

		public void PlayQueued(string animationName)
		{
		}

		public virtual void Pause()
		{
		}

		public virtual void RestartAnim()
		{
		}

		public void Crossfade(int index)
		{
		}

		public void Crossfade(string animationName)
		{
		}

		public abstract void Crossfade(int index, float speed);

		public void Crossfade(string animationName, float speed)
		{
		}

		public abstract void PrepopulateCrossfadePool(int count);

		public virtual void SetTime(float time, bool instantUpdate = false)
		{
		}

		public virtual void SetTimeNormalized(float time, bool instantUpdate = false)
		{
		}

		public IMeshAnimation GetClip(string animationName)
		{
			return null;
		}

		public void DisplayFrame(int frame, MeshRenderer meshRenderer)
		{
		}

		public bool IsPlaying()
		{
			return false;
		}
	}
}
