using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using TH20.BT_Types;
using UnityEngine;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Character")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/InteractionIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class PlayAnimation : CharacterAction
	{
		public class SaveState : BaseSaveState
		{
			public bool _playing;

			public SaveState()
			{
			}

			public SaveState(Task task)
				: base(task)
			{
			}
		}

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Animation graph to play")]
		public RuntimeAnimatorController[] _animationGraphs;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Override anim graph if this is valid")]
		public SharedRuntimeAnimatorController _animationGraphOverride;

		private bool _playing;

		private RuntimeAnimatorController _animationGraphPlaying;

		public override void OnStart()
		{
			base.OnStart();
			_playing = true;
			SetupAnimationGraph();
			if (_animationGraphPlaying != null)
			{
				base.Character.Interruptable = false;
				base.Character.PushAnimationGraph(_animationGraphPlaying, 0.25f);
			}
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (_playing)
			{
				SetupAnimationGraph();
			}
		}

		private void SetupAnimationGraph()
		{
			if (_animationGraphOverride.Value != null)
			{
				_animationGraphPlaying = _animationGraphOverride.Value;
			}
			else
			{
				_animationGraphPlaying = base.Character.FindAnimationGraph(ref _animationGraphs);
			}
		}

		public override void OnEnd()
		{
			if (_playing && _animationGraphPlaying != null)
			{
				base.Character.Interruptable = true;
				base.Character.PopAnimationGraph(_animationGraphPlaying, 0.25f);
			}
			_playing = false;
			base.OnEnd();
		}

		public override TaskStatus OnUpdate()
		{
			if (_animationGraphPlaying == null || base.Character.AnimationGraph != _animationGraphPlaying)
			{
				return TaskStatus.Failure;
			}
			if (base.Character.Animator.IsInState("Exit"))
			{
				return TaskStatus.Success;
			}
			return TaskStatus.Running;
		}

		public override BaseSaveState CreateSaveState()
		{
			return new SaveState(this)
			{
				_playing = _playing
			};
		}

		public override void RestoreFromSaveState(BaseSaveState baseSaveState)
		{
			base.RestoreFromSaveState(baseSaveState);
			SaveState saveState = (SaveState)baseSaveState;
			_playing = saveState._playing;
		}
	}
}
