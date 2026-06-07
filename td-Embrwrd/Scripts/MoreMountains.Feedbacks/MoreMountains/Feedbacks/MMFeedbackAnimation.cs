using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[FeedbackHelp("This feedback will allow you to send to an animator (bound in its inspector) a bool, int, float or trigger parameter, allowing you to trigger an animation, with or without randomness.")]
	[AddComponentMenu(null)]
	[FeedbackPath("GameObject/Animation")]
	public class MMFeedbackAnimation : MMFeedback
	{
		public enum TriggerModes
		{
			SetTrigger = 0,
			ResetTrigger = 1
		}

		public enum ValueModes
		{
			None = 0,
			Constant = 1,
			Random = 2,
			Incremental = 3
		}

		public static bool FeedbackTypeAuthorized;

		[Tooltip("the animator whose parameters you want to update")]
		[Header("Animation")]
		public Animator BoundAnimator;

		[Header("Trigger")]
		[Tooltip("if this is true, will update the specified trigger parameter")]
		public bool UpdateTrigger;

		[Tooltip("the selected mode to interact with this trigger")]
		[MMFCondition("UpdateTrigger", true)]
		public TriggerModes TriggerMode;

		[Tooltip("the trigger animator parameter to, well, trigger when the feedback is played")]
		[MMFCondition("UpdateTrigger", true)]
		public string TriggerParameterName;

		[Header("Random Trigger")]
		[Tooltip("if this is true, will update a random trigger parameter, picked from the list below")]
		public bool UpdateRandomTrigger;

		[Tooltip("the selected mode to interact with this trigger")]
		[MMFCondition("UpdateRandomTrigger", true)]
		public TriggerModes RandomTriggerMode;

		[Tooltip("the trigger animator parameters to trigger at random when the feedback is played")]
		public List<string> RandomTriggerParameterNames;

		[Header("Bool")]
		[Tooltip("if this is true, will update the specified bool parameter")]
		public bool UpdateBool;

		[MMFCondition("UpdateBool", true)]
		[Tooltip("the bool parameter to turn true when the feedback gets played")]
		public string BoolParameterName;

		[Tooltip("when in bool mode, whether to set the bool parameter to true or false")]
		[MMFCondition("UpdateBool", true)]
		public bool BoolParameterValue;

		[Tooltip("if this is true, will update a random bool parameter picked from the list below")]
		[Header("Random Bool")]
		public bool UpdateRandomBool;

		[Tooltip("when in bool mode, whether to set the bool parameter to true or false")]
		[MMFCondition("UpdateRandomBool", true)]
		public bool RandomBoolParameterValue;

		[Tooltip("the bool parameter to turn true when the feedback gets played")]
		public List<string> RandomBoolParameterNames;

		[Tooltip("the int parameter to turn true when the feedback gets played")]
		[Header("Int")]
		public ValueModes IntValueMode;

		[Tooltip("the int parameter to turn true when the feedback gets played")]
		[MMFEnumCondition("IntValueMode", new int[] { 1, 2, 3 })]
		public string IntParameterName;

		[MMFEnumCondition("IntValueMode", new int[] { 1 })]
		[Tooltip("the value to set to that int parameter")]
		public int IntValue;

		[MMFEnumCondition("IntValueMode", new int[] { 2 })]
		[Tooltip("the min value (inclusive) to set at random to that int parameter")]
		public int IntValueMin;

		[Tooltip("the max value (exclusive) to set at random to that int parameter")]
		[MMFEnumCondition("IntValueMode", new int[] { 2 })]
		public int IntValueMax;

		[Tooltip("the value to increment that int parameter by")]
		[MMFEnumCondition("IntValueMode", new int[] { 3 })]
		public int IntIncrement;

		[Tooltip("the Float parameter to turn true when the feedback gets played")]
		[Header("Float")]
		public ValueModes FloatValueMode;

		[Tooltip("the float parameter to turn true when the feedback gets played")]
		[MMFEnumCondition("FloatValueMode", new int[] { 1, 2, 3 })]
		public string FloatParameterName;

		[MMFEnumCondition("FloatValueMode", new int[] { 1 })]
		[Tooltip("the value to set to that float parameter")]
		public float FloatValue;

		[MMFEnumCondition("FloatValueMode", new int[] { 2 })]
		[Tooltip("the min value (inclusive) to set at random to that float parameter")]
		public float FloatValueMin;

		[Tooltip("the max value (exclusive) to set at random to that float parameter")]
		[MMFEnumCondition("FloatValueMode", new int[] { 2 })]
		public float FloatValueMax;

		[Tooltip("the value to increment that float parameter by")]
		[MMFEnumCondition("FloatValueMode", new int[] { 3 })]
		public float FloatIncrement;

		protected int _triggerParameter;

		protected int _boolParameter;

		protected int _intParameter;

		protected int _floatParameter;

		protected List<int> _randomTriggerParameters;

		protected List<int> _randomBoolParameters;

		protected override void CustomInitialization(GameObject owner)
		{
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
