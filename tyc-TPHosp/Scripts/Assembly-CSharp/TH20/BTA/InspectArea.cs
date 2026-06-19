using System;
using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20.BTA
{
	[TaskCategory(" TH20/VIP")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/InspectIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class InspectArea : CharacterAction
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

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Animation graph to play on good appraisal")]
		public RuntimeAnimatorController[] _goodAnimationGraphs;

		[BehaviorDesigner.Runtime.Tasks.Tooltip("Animation graph to play on bad appraisal")]
		public RuntimeAnimatorController[] _badAnimationGraphs;

		private bool _playing;

		private RuntimeAnimatorController _animationGraphPlaying;

		private VIPComponent _vipComponent;

		public override void OnStart()
		{
			base.OnStart();
			_playing = false;
			_animationGraphPlaying = null;
			_vipComponent = base.Character.GetComponent<VIPComponent>();
			if (_vipComponent != null)
			{
				_playing = true;
				SetupAnimationGraph();
				if (_animationGraphPlaying != null)
				{
					base.Character.Interruptable = false;
					base.Character.PushAnimationGraph(_animationGraphPlaying, 0.25f);
				}
			}
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_vipComponent = base.Character.GetComponent<VIPComponent>();
			if (_playing)
			{
				Character character = base.Character;
				character.PostRestoreFromSaveCallback = (System.Action)Delegate.Combine(character.PostRestoreFromSaveCallback, (System.Action)delegate
				{
					_animationGraphPlaying = base.Character.AnimationGraph;
				});
			}
		}

		private void SetupAnimationGraph()
		{
			if (_vipComponent != null)
			{
				RuntimeAnimatorController[] animGraphs = (_vipComponent.InspectArea() ? _goodAnimationGraphs : _badAnimationGraphs);
				_animationGraphPlaying = base.Character.FindAnimationGraph(ref animGraphs);
			}
		}

		public override void OnEnd()
		{
			if (_animationGraphPlaying != null)
			{
				base.Character.Interruptable = true;
				base.Character.PopAnimationGraph(_animationGraphPlaying, 0.25f);
			}
			_playing = false;
			base.OnEnd();
		}

		public override TaskStatus OnUpdate()
		{
			if (_vipComponent == null)
			{
				return TaskStatus.Failure;
			}
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
