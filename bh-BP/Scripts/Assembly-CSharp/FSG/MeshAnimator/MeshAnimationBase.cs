using System;
using UnityEngine;

namespace FSG.MeshAnimator
{
	[Serializable]
	public abstract class MeshAnimationBase : ScriptableObject, IMeshAnimation
	{
		public string animationName;

		public float playbackSpeed;

		public WrapMode wrapMode;

		public MeshAnimationEvent[] events;

		public float length;

		[HideInInspector]
		public int frameSkip;

		[HideInInspector]
		public RootMotionMode rootMotionMode;

		[HideInInspector]
		public string[] exposedTransforms;

		[HideInInspector]
		public int vertexCount;

		[HideInInspector]
		public int Mode { get; set; }

		public string AnimationName => null;

		public string[] ExposedTransforms => null;

		public abstract MeshFrameDataBase[] Frames { get; }

		public MeshAnimationEvent[] Events => null;

		public abstract int TotalFrames { get; }

		public float PlaybackSpeed => 0f;

		public float Length => 0f;

		public WrapMode WrapMode => default(WrapMode);

		public bool IsLoopingWrapMode => false;

		public RootMotionMode RootMotionMode => default(RootMotionMode);

		public int FrameSkip => 0;

		public int VertexCount => 0;

		protected virtual void OnEnable()
		{
		}

		public void FireEvents(GameObject eventReciever, int frame)
		{
		}

		public bool IsName(string animationName)
		{
			return false;
		}

		public virtual MeshFrameDataBase GetNearestFrame(int frame)
		{
			return null;
		}

		public float GetInterpolatingFrames(int frame, out MeshFrameDataBase previousFrame, out MeshFrameDataBase nextFrame)
		{
			previousFrame = null;
			nextFrame = null;
			return 0f;
		}

		public abstract void SetFrameData(int frame, MeshFrameDataBase frameData);

		public abstract void SetFrameData(MeshFrameDataBase[] frameData);

		public abstract void DisplayFrame(IMeshAnimator meshAnimator, int frame, int previousFrame);

		public abstract void GenerateFrame(Mesh baseMesh, int frame);

		public abstract void GenerateFrames(Mesh baseMesh);

		public abstract void Reset();

		private void OnValidate()
		{
		}
	}
}
