using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	public abstract class State : ScriptableObject, IState, ISerializationCallbackReceiver
	{
		[SerializeField]
		protected AvatarMask m_StateMask;

		[SerializeField]
		private EntryAnimationClip m_Entry = new EntryAnimationClip();

		[SerializeField]
		private ExitAnimationClip m_Exit = new ExitAnimationClip();

		[SerializeField]
		private LocomotionProperties m_Properties = new LocomotionProperties();

		[SerializeField]
		private RunInstructionsList m_OnChange = new RunInstructionsList();

		[NonSerialized]
		private GameObject m_TemplateOnChange;

		public abstract RuntimeAnimatorController StateController { get; }

		public AvatarMask StateMask => m_StateMask;

		public bool HasStateMask => m_StateMask != null;

		public bool EntryRootMotion => m_Entry.RootMotion;

		public AnimationClip EntryClip => m_Entry.EntryClip;

		public bool HasEntryClip => m_Entry.EntryClip != null;

		public AvatarMask EntryMask => m_Entry.EntryMask;

		public bool ExitRootMotion => m_Exit.RootMotion;

		public AnimationClip ExitClip => m_Exit.ExitClip;

		public bool HasExitClip => m_Exit.ExitClip != null;

		public AvatarMask ExitMask => m_Exit.ExitMask;

		public void RunChange(Args args)
		{
			if (!ApplicationManager.IsExiting)
			{
				RunnerConfig config = new RunnerConfig
				{
					Name = "On " + TextUtils.Humanize(base.name) + " Refresh",
					Location = new RunnerLocationLocation((args.Self != null) ? args.Self.transform.position : Vector3.zero, (args.Self != null) ? args.Self.transform.rotation : Quaternion.identity)
				};
				m_Properties.Update(args.Self.Get<Character>(), 1f);
				m_OnChange.Run(args.Clone, config);
			}
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		protected abstract void BeforeSerialize();

		protected abstract void AfterSerialize();
	}
}
