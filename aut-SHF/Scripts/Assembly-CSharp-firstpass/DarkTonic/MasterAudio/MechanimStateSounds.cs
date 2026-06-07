using UnityEngine;

namespace DarkTonic.MasterAudio
{
	public class MechanimStateSounds : StateMachineBehaviour
	{
		[Header("Select For Sounds To Follow Object")]
		public bool SoundFollowsObject;

		[Tooltip("Select for sounds to retrigger each time animation loops without exiting state")]
		[Header("Retrigger Sounds Each Time Anim Loops w/o Exiting State")]
		public bool RetriggerWhenStateLoops;

		[Tooltip("Play a Sound Group when state is Entered")]
		[Header("Enter Sound Group")]
		public bool playEnterSound;

		public bool stopEnterSoundOnExit;

		[SoundGroup]
		public string enterSoundGroup;

		[Tooltip("Random Variation plays if blank, otherwise name a Variation from the above Sound Group to play.")]
		public string enterVariationName;

		private bool wasEnterSoundPlayed;

		[Tooltip("Play a Sound Group when state is Exited")]
		[Header("Exit Sound Group")]
		public bool playExitSound;

		[SoundGroup]
		public string exitSoundGroup;

		[Tooltip("Random Variation plays if blank, otherwise name a Variation from the above Sound Group to play.")]
		public string exitVariationName;

		[Tooltip("Play a Sound Group (Normal or Looped Chain Variation Mode) timed to the animation state's normalized time.  Normalized time is simply the length in time of the animation.  Time is represented as a float from 0f - 1f.  0f is the beginning, .5f is the middle, 1f is the end...etc.etc.  Select a Start time from 0 - 1.  Select a stop time greater than the start time or leave stop time equals to zero and select Stop Anim Time Sound On Exit.  This can be used for Looped Chain Sound Groups since you have to define a stop time.")]
		[Header("Play Sound Group Timed to Animation")]
		public bool playAnimTimeSound;

		public bool stopAnimTimeSoundOnExit;

		[Tooltip("If selected, When To Stop Sound (below) will be used. Otherwise the sound will not be stopped unless you have Stop Anim Time Sound On Exit selected above.")]
		public bool useStopTime;

		[Tooltip("This value will be compared to the normalizedTime of the animation you are playing. NormalizedTime is represented as a float so 0 is the beginning, 1 is the end and .5f would be the middle etc.")]
		[Range(0f, 1f)]
		public float whenToStartSound;

		[Tooltip("This value will be compared to the normalizedTime of the animation you are playing. NormalizedTime is represented as a float so 0 is the beginning, 1 is the end and .5f would be the middle etc.")]
		[Range(0f, 1f)]
		public float whenToStopSound;

		[SoundGroup]
		public string TimedSoundGroup;

		[Tooltip("Random Variation plays if blank, otherwise name a Variation from the above Sound Group to play.")]
		public string timedVariationName;

		private bool playSoundStart;

		private bool playSoundStop;

		[Tooltip("Play a Sound Group with each variation timed to the animation.  This allows you to time your sounds to the actions in you animation.  Example: A sword swing combo where you want swoosh soundsor character grunts timed to the acceleration phase of the sword swing.  Select the number of sounds to be played, up to 4.  Then set the time you want each sound to start with each subsequent time greater than the previous time.")]
		[Header("Play Multiple Sounds Timed to Anim")]
		public bool playMultiAnimTimeSounds;

		public bool StopMultiAnimTimeSoundsOnExit;

		[Range(0f, 4f)]
		public int numOfMultiSoundsToPlay;

		[Tooltip("This value will be compared to the normalizedTime of the animation you are playing. NormalizedTime is represented as a float so 0 is the beginning, 1 is the end and .5f would be the middle etc.")]
		[Range(0f, 1f)]
		public float whenToStartMultiSound1;

		[Tooltip("This value will be compared to the normalizedTime of the animation you are playing. NormalizedTime is represented as a float so 0 is the beginning, 1 is the end and .5f would be the middle etc.")]
		[Range(0f, 1f)]
		public float whenToStartMultiSound2;

		[Tooltip("This value will be compared to the normalizedTime of the animation you are playing. NormalizedTime is represented as a float so 0 is the beginning, 1 is the end and .5f would be the middle etc.")]
		[Range(0f, 1f)]
		public float whenToStartMultiSound3;

		[Tooltip("This value will be compared to the normalizedTime of the animation you are playing. NormalizedTime is represented as a float so 0 is the beginning, 1 is the end and .5f would be the middle etc.")]
		[Range(0f, 1f)]
		public float whenToStartMultiSound4;

		[SoundGroup]
		public string MultiSoundsTimedGroup;

		[Tooltip("Random Variation plays if blank, otherwise name a Variation from the above Sound Group to play.")]
		public string multiTimedVariationName;

		private bool playMultiSound1;

		private bool playMultiSound2;

		private bool playMultiSound3;

		private bool playMultiSound4;

		private Transform _actorTrans;

		private int _lastRepetition;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
		}

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
		}

		private Transform ActorTrans(Animator anim)
		{
			return null;
		}

		private static string GetVariationName(string varName)
		{
			return null;
		}
	}
}
