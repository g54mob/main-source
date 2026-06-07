using UnityEngine;

namespace MalbersAnimations.Controller
{
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/main-components/manimal-controller/modes#mode-behaviour")]
	[AddComponentMenu("Malbers/Mode Behavior")]
	public class ModeBehaviour : StateMachineBehaviour
	{
		public ModeID ModeID;

		[Tooltip("Calls 'Animation Tag Enter' on the Modes")]
		public bool EnterMode = true;

		[Tooltip("Calls 'Animation Tag Exit' on the Modes")]
		public bool ExitMode = true;

		[Tooltip("Next Ability to do on the Mode.If is set to -1, The Exit On Ability Logic will be ignored.\nUsed this when you need an ability to finish on another Ability.\nE.g. If the wolf is in the Ability SIT, and you activate the HOWL; When HOWL finish you can play again SIT right after")]
		public int ExitAbility = -1;

		[Tooltip("(Experimental)\nIf true the Animation will exit automatically after the Exit Time. No need for exit/interrupted transitions")]
		public bool NoExitTransitions;

		private bool DoExit;

		[Range(0f, 1f)]
		[Tooltip("Time to Exit the Animation Automatically with no exit transitions")]
		public float ExitTime = 0.8f;

		private MAnimal animal;

		private Mode ModeOwner;

		private Ability ActiveAbility;

		public void InitializeBehaviour(MAnimal animal)
		{
			this.animal = animal;
			if (ModeID != null)
			{
				ModeOwner = animal.Mode_Get(ModeID);
				return;
			}
			Debug.LogWarning("There's a Mode behaviour without an ID. Please check all your Mode Animations states.");
			Object.Destroy(this);
		}

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			DoExit = false;
			if (animal == null)
			{
				animal = animator.GetComponent<MAnimal>();
				ModeOwner = animal.Mode_Get(ModeID);
			}
			if (ModeID == null)
			{
				Debug.LogError("Mode behaviour needs an ID");
				return;
			}
			if (ModeOwner == null)
			{
				Debug.LogError("There's no [" + ModeID.name + "] mode on your character");
				return;
			}
			ActiveAbility = ModeOwner.ActiveAbility;
			if (animal.ModeStatus != Int_ID.Loop && EnterMode)
			{
				ModeOwner.AnimationTagEnter(stateInfo.fullPathHash);
			}
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (animator.GetCurrentAnimatorStateInfo(layerIndex).fullPathHash != stateInfo.fullPathHash && ExitMode)
			{
				ModeOwner.AnimationTagExit(ActiveAbility, ExitAbility);
			}
		}

		public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			ModeOwner.OnModeStateMove(stateInfo, animator, layerIndex);
			if (ExitMode && !DoExit && NoExitTransitions && stateInfo.normalizedTime > ExitTime)
			{
				DoExit = true;
				if (ActiveAbility != animal.ActiveMode.ActiveAbility)
				{
					Debug.Log("Playing different Ability ..ingore exit");
					return;
				}
				Debug.Log("Automatic Exit");
				ModeOwner.AnimationTagExit(ActiveAbility, ExitAbility);
			}
		}
	}
}
