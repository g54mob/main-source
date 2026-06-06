using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.UGUIGlow
{
	public abstract class GlowAnimation : IGlowAnimation
	{
		public enum State
		{
			Stopped = 0,
			Playing = 1,
			Paused = 2
		}

		private static List<IGlowAnimation> _activeAnimations = new List<IGlowAnimation>();

		private static List<IGlowAnimation> _tmpAnimationsResult = new List<IGlowAnimation>();

		protected State _state;

		protected MeshCreator _creator;

		public string Name { get; set; }

		public MeshCreator MeshCreator
		{
			get
			{
				return _creator;
			}
			private set
			{
				_creator = value;
			}
		}

		public event Action<GlowAnimation> OnValueChanged;

		public static IGlowAnimation AddAnimationCopyTo(MeshCreator creator, IGlowAnimation animationTemplate, bool linkToTemplate = false, bool reuseExisting = true)
		{
			return AddAnimationCopyTo(animationTemplate, creator, linkToTemplate, reuseExisting);
		}

		public static void GetAnimationsOnCreator(MeshCreator creator, List<IGlowAnimation> animations)
		{
			GlowAnimation.GetAnimationsOnCreator<IGlowAnimation>(creator, animations);
		}

		public static void GetAnimationsOnCreator<T>(MeshCreator creator, List<T> animations) where T : IGlowAnimation
		{
			if (creator == null)
			{
				return;
			}
			foreach (IGlowAnimation activeAnimation in _activeAnimations)
			{
				if (activeAnimation.MeshCreator != null && activeAnimation.MeshCreator == creator && activeAnimation is T)
				{
					animations.Add((T)activeAnimation);
				}
			}
		}

		public static IGlowAnimation GetAnimationOnCreator(MeshCreator creator)
		{
			return GetAnimationOnCreator<IGlowAnimation>(creator);
		}

		public static IGlowAnimation GetAnimationOnCreator(MeshCreator creator, Type type)
		{
			_tmpAnimationsResult.Clear();
			GetAnimationsOnCreator(creator, _tmpAnimationsResult);
			foreach (IGlowAnimation item in _tmpAnimationsResult)
			{
				if (item.GetType() == type)
				{
					return item;
				}
			}
			return null;
		}

		public static T GetAnimationOnCreator<T>(MeshCreator creator) where T : IGlowAnimation
		{
			_tmpAnimationsResult.Clear();
			GetAnimationsOnCreator(creator, _tmpAnimationsResult);
			foreach (IGlowAnimation item in _tmpAnimationsResult)
			{
				if (item.GetType() == typeof(T))
				{
					return (T)item;
				}
			}
			return default(T);
		}

		public static IGlowAnimation AddAnimationCopyTo(IGlowAnimation animationTemplate, MeshCreator creator, bool linkToTemplate = false, bool reuseExisting = true)
		{
			if (creator == null)
			{
				return null;
			}
			IGlowAnimation glowAnimation = null;
			if (animationTemplate != null)
			{
				glowAnimation = GetAnimationOnCreator(creator, animationTemplate.GetType());
				if (glowAnimation != null && glowAnimation.MeshCreator != null && glowAnimation.GetType() == animationTemplate.GetType() && !reuseExisting)
				{
					glowAnimation.RemoveFromMeshCreator(creator);
					glowAnimation = null;
				}
				if (glowAnimation == null)
				{
					glowAnimation = animationTemplate.Copy();
					glowAnimation.AddToMeshCreator(creator);
				}
				if (linkToTemplate)
				{
					animationTemplate.OnValueChanged -= glowAnimation.CopyValuesFrom;
					animationTemplate.OnValueChanged += glowAnimation.CopyValuesFrom;
				}
			}
			return glowAnimation;
		}

		public static IGlowAnimation AddAnimationTo(MeshCreator creator, GlowConfig config = null)
		{
			IGlowAnimation glowAnimation = null;
			glowAnimation?.AddToMeshCreator(creator);
			return glowAnimation;
		}

		public void TriggerOnValueChanged()
		{
			this.OnValueChanged?.Invoke(this);
		}

		public virtual IGlowAnimation AddCopyToCreator(MeshCreator creator, bool linkToTemplate = false, bool reuseExisting = true)
		{
			return AddAnimationCopyTo(this, creator, linkToTemplate, reuseExisting);
		}

		public virtual void AddToMeshCreator(MeshCreator creator)
		{
			if (_creator != null && _creator != creator)
			{
				RemoveFromMeshCreator(creator);
			}
			_creator = creator;
			if (!_activeAnimations.Contains(this))
			{
				_activeAnimations.Add(this);
			}
			creator.OnBeforeMeshWrite = (MeshCreator.OnBeforeMeshWriteDelegate)Delegate.Remove(creator.OnBeforeMeshWrite, new MeshCreator.OnBeforeMeshWriteDelegate(OnUpdateMesh));
			creator.OnBeforeMeshWrite = (MeshCreator.OnBeforeMeshWriteDelegate)Delegate.Combine(creator.OnBeforeMeshWrite, new MeshCreator.OnBeforeMeshWriteDelegate(OnUpdateMesh));
			Play();
		}

		public virtual void RemoveFromMeshCreator(MeshCreator creator)
		{
			if (creator != null)
			{
				creator.OnBeforeMeshWrite = (MeshCreator.OnBeforeMeshWriteDelegate)Delegate.Remove(creator.OnBeforeMeshWrite, new MeshCreator.OnBeforeMeshWriteDelegate(OnUpdateMesh));
				if (_activeAnimations.Contains(this))
				{
					_activeAnimations.Remove(this);
				}
			}
		}

		public void Play()
		{
			_state = State.Playing;
		}

		public bool IsPaused()
		{
			return _state == State.Paused;
		}

		public bool IsPlaying()
		{
			return _state == State.Playing;
		}

		public bool IsStopped()
		{
			return _state == State.Stopped;
		}

		public void Stop()
		{
			_state = State.Stopped;
		}

		protected abstract void updateAnimation(float deltaTime);

		public abstract IGlowAnimation Copy();

		public virtual void CopyValuesFrom(IGlowAnimation source)
		{
		}

		public virtual void Update(float deltaTime)
		{
			if (_creator != null && !IsPaused() && !IsStopped())
			{
				updateAnimation(deltaTime);
				_creator.MarkDirtyAnimation();
			}
		}

		public void Pause()
		{
			_state = State.Paused;
		}

		protected virtual void onCreatorRemoved(MeshCreator creator)
		{
			Pause();
			RemoveFromMeshCreator(creator);
		}

		public void OnUpdateMesh(MeshCreator creator, List<UIVertex> vertices, List<ushort> triangles, List<ushort> outerIndices, List<ushort> innerIndices, Dictionary<ushort, ushort> outerToInnerIndices)
		{
			if (!IsStopped())
			{
				onUpdateMesh(creator, vertices, triangles, outerIndices, innerIndices, outerToInnerIndices);
			}
		}

		protected abstract void onUpdateMesh(MeshCreator creator, List<UIVertex> vertices, List<ushort> triangles, List<ushort> outerIndices, List<ushort> innerIndices, Dictionary<ushort, ushort> outerToInnerIndices);
	}
}
