#define LOG_LEVEL_VERBOSE
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Interaction")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/InteractionStartIcon.png")]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class OneShot : FindInteractionBase
	{
		public class SaveState : BaseSaveState
		{
			public int _interactionControllerID;

			public SaveState()
			{
			}

			public SaveState(Task task)
				: base(task)
			{
			}
		}

		[Tooltip("Overriddes Interaction Name if not null or empty")]
		public SharedString _interactionNameOverride;

		private int _interactionControllerID;

		public override void OnStart()
		{
			base.OnStart();
			string interactionName = (string.IsNullOrEmpty(_interactionNameOverride.Value) ? _interactionName : _interactionNameOverride.Value);
			if (_interaction.IsValid() && !string.IsNullOrEmpty(_interactionName))
			{
				Logging.Error(LogChannels.Behaviour, "One shot task in '{0}' tree has both interaction name and object set", base.Owner);
			}
			ObjectInteraction objectInteraction = (_interaction.IsValid() ? _interaction.Get : null);
			if (objectInteraction == null)
			{
				objectInteraction = FindInteraction(interactionName);
			}
			if (objectInteraction == null)
			{
				_interactionControllerID = -1;
			}
			else
			{
				_interactionControllerID = base.Character.InteractionControllers.Add(new InteractionController(base.Character, objectInteraction, autoEnd: true));
			}
		}

		public override void OnEnd()
		{
			base.OnEnd();
			base.Character.InteractionControllers.Destroy(_interactionControllerID);
			_interactionControllerID = -1;
		}

		public override TaskStatus OnUpdate()
		{
			if (!base.Character.InteractionControllers.Contains(_interactionControllerID))
			{
				return TaskStatus.Failure;
			}
			return base.Character.InteractionControllers.Get(_interactionControllerID).OnUpdate();
		}

		public override BaseSaveState CreateSaveState()
		{
			return new SaveState(this)
			{
				_interactionControllerID = _interactionControllerID
			};
		}

		public override void RestoreFromSaveState(BaseSaveState baseSaveState)
		{
			base.RestoreFromSaveState(baseSaveState);
			SaveState saveState = (SaveState)baseSaveState;
			_interactionControllerID = saveState._interactionControllerID;
		}
	}
}
