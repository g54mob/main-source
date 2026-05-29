using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;
using UnityEngine.Playables;

namespace Animancer
{
	public class PlayableAssetState : AnimancerState, ICopyable<PlayableAssetState>
	{
		public interface ITransition : ITransition<PlayableAssetState>, Animancer.ITransition, IHasKey, IPolymorphic
		{
		}

		private PlayableAsset _Asset;

		private float _Length;

		private IList<UnityEngine.Object> _Bindings;

		private bool _HasInitializedBindings;

		public PlayableAsset Asset
		{
			get
			{
				return _Asset;
			}
			set
			{
				ChangeMainObject(ref _Asset, value);
			}
		}

		public override UnityEngine.Object MainObject
		{
			get
			{
				return _Asset;
			}
			set
			{
				_Asset = (PlayableAsset)value;
			}
		}

		public override float Length => _Length;

		public override bool ApplyAnimatorIK
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public override bool ApplyFootIK
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public IList<UnityEngine.Object> Bindings
		{
			get
			{
				return _Bindings;
			}
			set
			{
				_Bindings = value;
				InitializeBindings();
			}
		}

		protected override void OnSetIsPlaying()
		{
			int inputCount = _Playable.GetInputCount();
			for (int i = 0; i < inputCount; i++)
			{
				Playable input = _Playable.GetInput(i);
				if (input.IsValid())
				{
					if (base.IsPlaying)
					{
						input.Play();
					}
					else
					{
						input.Pause();
					}
				}
			}
		}

		public override void CopyIKFlags(AnimancerNode copyFrom)
		{
		}

		public PlayableAssetState(PlayableAsset asset)
		{
			if (asset == null)
			{
				throw new ArgumentNullException("asset");
			}
			_Asset = asset;
		}

		protected override void CreatePlayable(out Playable playable)
		{
			playable = _Asset.CreatePlayable(base.Root._Graph, base.Root.Component.gameObject);
			playable.SetDuration(9223372.03685477);
			_Length = (float)_Asset.duration;
			if (!_HasInitializedBindings)
			{
				InitializeBindings();
			}
		}

		public void SetBindings(params UnityEngine.Object[] bindings)
		{
			Bindings = bindings;
		}

		private void InitializeBindings()
		{
			if (base.Root == null)
			{
				return;
			}
			_HasInitializedBindings = true;
			PlayableGraph graph = base.Root._Graph;
			int num = 0;
			int num2 = ((_Bindings != null) ? _Bindings.Count : 0);
			foreach (PlayableBinding output5 in _Asset.outputs)
			{
				GetBindingDetails(output5, out var name, out var type, out var isMarkers);
				UnityEngine.Object obj = ((num < num2) ? _Bindings[num] : null);
				Playable input = _Playable.GetInput(num);
				if (type == typeof(Animator))
				{
					if (obj != null)
					{
						AnimationPlayableOutput output = AnimationPlayableOutput.Create(graph, name, (Animator)obj);
						output.SetReferenceObject(output5.sourceObject);
						output.SetSourcePlayable(input);
						output.SetWeight(1f);
					}
				}
				else if (type == typeof(AudioSource))
				{
					if (obj != null)
					{
						AudioPlayableOutput output2 = AudioPlayableOutput.Create(graph, name, (AudioSource)obj);
						output2.SetReferenceObject(output5.sourceObject);
						output2.SetSourcePlayable(input);
						output2.SetWeight(1f);
					}
				}
				else
				{
					if (isMarkers)
					{
						Component component = base.Root.Component as Component;
						ScriptPlayableOutput output3 = ScriptPlayableOutput.Create(graph, name);
						output3.SetReferenceObject(output5.sourceObject);
						output3.SetSourcePlayable(input);
						output3.SetWeight(1f);
						output3.SetUserData(component);
						List<INotificationReceiver> list = ObjectPool.AcquireList<INotificationReceiver>();
						component.GetComponents(list);
						for (int i = 0; i < list.Count; i++)
						{
							output3.AddNotificationReceiver(list[i]);
						}
						ObjectPool.Release(list);
						continue;
					}
					ScriptPlayableOutput output4 = ScriptPlayableOutput.Create(graph, name);
					output4.SetReferenceObject(output5.sourceObject);
					output4.SetSourcePlayable(input);
					output4.SetWeight(1f);
					output4.SetUserData(obj);
					if (obj is INotificationReceiver receiver)
					{
						output4.AddNotificationReceiver(receiver);
					}
				}
				num++;
			}
		}

		public static void GetBindingDetails(PlayableBinding binding, out string name, out Type type, out bool isMarkers)
		{
			name = binding.streamName;
			type = binding.outputTargetType;
			isMarkers = type == typeof(GameObject) && name == "Markers";
		}

		public override void Destroy()
		{
			_Asset = null;
			base.Destroy();
		}

		public override AnimancerState Clone(AnimancerPlayable root)
		{
			PlayableAssetState playableAssetState = new PlayableAssetState(_Asset);
			playableAssetState.SetNewCloneRoot(root);
			((ICopyable<PlayableAssetState>)playableAssetState).CopyFrom(this);
			return playableAssetState;
		}

		void ICopyable<PlayableAssetState>.CopyFrom(PlayableAssetState copyFrom)
		{
			_Length = copyFrom._Length;
			((ICopyable<AnimancerState>)this).CopyFrom((AnimancerState)copyFrom);
		}

		protected override void AppendDetails(StringBuilder text, string separator)
		{
			base.AppendDetails(text, separator);
			text.Append(separator).Append("Bindings: ");
			int num;
			if (_Bindings == null)
			{
				text.Append("Null");
				num = 0;
			}
			else
			{
				num = _Bindings.Count;
				text.Append('[').Append(num).Append(']');
			}
			text.Append(_HasInitializedBindings ? " (Initialized)" : " (Not Initialized)");
			for (int i = 0; i < num; i++)
			{
				text.Append(separator).Append("Bindings[").Append(i)
					.Append("] = ")
					.Append(AnimancerUtilities.ToStringOrNull(_Bindings[i]));
			}
		}
	}
}
