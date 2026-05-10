using System;
using CTS.BBT;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class SimpleStation<TData> : FurnitureInteractor, IContextActor where TData : SimpleStationData
	{
		[SerializeField]
		private SerializableDictionary<StringKey, Transform[]> _targets = new SerializableDictionary<StringKey, Transform[]>();

		private Animation _animator;

		public TData Data { get; private set; }

		public ContextActorData ContextActorData { get; private set; } = new ContextActorData();

		public Animation Animator
		{
			get
			{
				if (!_animator)
				{
					_animator = GetComponentInChildren<Animation>();
				}
				return _animator;
			}
		}

		public ReadOnlyDictionary<StringKey, Transform[]> Targets => _targets;

		public ReadOnlyDictionary<StringKey, ActionData[]> Actions => Data.Actions;

		public Transform GetRandomTarget(StringKey key)
		{
			if (!_targets.TryGetValue(key, out var value) || value.Length == 0)
			{
				return null;
			}
			return value.GetRandom();
		}

		public ActionData GetRandomActionData(StringKey key)
		{
			if (!Actions.TryGetValue(key, out var value) || value.Length == 0)
			{
				return null;
			}
			return value.GetRandom();
		}

		public void PlayAnimation(AnimationClip clip)
		{
			Animation animator = Animator;
			if (!animator.GetClip(clip.name))
			{
				animator.AddClip(clip, clip.name);
			}
			animator.Play(clip.name);
		}

		public void PlayAnimation(StringKey key)
		{
			AnimationClip animation = Data.GetAnimation(key);
			if (!animation)
			{
				throw new NullReferenceException($"Station doesn't have an animation with the key {key}");
			}
			PlayAnimation(animation);
		}
	}
}
