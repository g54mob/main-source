using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	public abstract class MMSpringFloatComponent<T> : MMSpringComponentBase, MMEventListener<MMSpringFloatEvent>, MMEventListenerBase where T : Component
	{
		[MMInspectorGroup("Target", true, 17, false)]
		public T Target;

		[MMInspectorGroup("Channel & TimeScale", true, 16, true)]
		[Tooltip("whether this spring should run on scaled time (and be impacted by time scale changes) or unscaled time (and not be impacted by time scale changes)")]
		public TimeScaleModes TimeScaleMode = TimeScaleModes.Scaled;

		[Tooltip("whether to listen on a channel defined by an int or by a MMChannel scriptable object. Ints are simple to setup but can get messy and make it harder to remember what int corresponds to what. MMChannel scriptable objects require you to create them in advance, but come with a readable name and are more scalable")]
		public MMChannelModes ChannelMode;

		[Tooltip("the channel to listen to - has to match the one on the feedback")]
		[MMEnumCondition("ChannelMode", new int[] { 0 })]
		public int Channel;

		[Tooltip("the MMChannel definition asset to use to listen for events. The feedbacks targeting this shaker will have to reference that same MMChannel definition to receive events - to create a MMChannel, right click anywhere in your project (usually in a Data folder) and go MoreMountains > MMChannel, then name it with some unique name")]
		[MMEnumCondition("ChannelMode", new int[] { 1 })]
		public MMChannel MMChannelDefinition;

		[MMInspectorGroup("Spring Settings", true, 18, false)]
		public MMSpringFloat FloatSpring;

		[MMInspectorGroup("Randomness", true, 12, true)]
		[Tooltip("the min (x) and max (y) values between which a random target value will be picked when calling MoveToRandom")]
		[MMVector(new string[] { "Min", "Max" })]
		public Vector2 MoveToRandomValue = new Vector2(-2f, 2f);

		[Tooltip("the min (x) and max (y) values between which a random bump value will be picked when calling BumpRandom")]
		[MMVector(new string[] { "Min", "Max" })]
		public Vector2 BumpAmountRandomValue = new Vector2(20f, 100f);

		[MMInspectorGroup("Test", true, 20, true)]
		[Tooltip("the value to move this spring to when interacting with any of the MoveTo debug buttons in its inspector")]
		public float TestMoveToValue = 2f;

		[MMInspectorButtonBar(new string[] { "MoveTo", "MoveToAdditive", "MoveToSubtractive", "MoveToRandom", "MoveToInstant" }, new string[] { "TestMoveTo", "TestMoveToAdditive", "TestMoveToSubtractive", "TestMoveToRandom", "TestMoveToInstant" }, new bool[] { true, true, true, true, true }, new string[] { "main-call-to-action", "", "", "", "" })]
		public bool MoveToToolbar;

		[Tooltip("the amount by which to bump this spring when interacting with the Bump debug button in its inspector")]
		public float TestBumpAmount = 75f;

		[MMInspectorButtonBar(new string[] { "Bump", "BumpRandom" }, new string[] { "TestBump", "TestBumpRandom" }, new bool[] { true, true }, new string[] { "main-call-to-action", "" })]
		public bool BumpToToolbar;

		[MMInspectorButtonBar(new string[] { "Stop", "Finish", "RestoreInitialValue", "ResetInitialValue" }, new string[] { "Stop", "Finish", "RestoreInitialValue", "ResetInitialValue" }, new bool[] { true, true, true, true }, new string[] { "", "", "", "" })]
		public bool OtherControlsToToolbar;

		public override bool LowVelocity => Mathf.Abs(FloatSpring.Velocity) < _velocityLowThreshold;

		public float DeltaTime
		{
			get
			{
				if (TimeScaleMode != TimeScaleModes.Scaled)
				{
					return Time.unscaledDeltaTime;
				}
				return Time.deltaTime;
			}
		}

		public virtual float TargetFloat { get; set; }

		public virtual void MoveTo(float newValue)
		{
			Activate();
			FloatSpring.MoveTo(newValue);
		}

		public virtual void MoveToAdditive(float newValue)
		{
			Activate();
			FloatSpring.MoveToAdditive(newValue);
		}

		public virtual void MoveToSubtractive(float newValue)
		{
			Activate();
			FloatSpring.MoveToSubtractive(newValue);
		}

		public virtual void MoveToRandom()
		{
			Activate();
			FloatSpring.MoveToRandom(MoveToRandomValue.x, MoveToRandomValue.y);
		}

		public virtual void MoveToInstant(float newValue)
		{
			Activate();
			FloatSpring.MoveToInstant(newValue);
		}

		public virtual void MoveToRandom(float min, float max)
		{
			Activate();
			FloatSpring.MoveToRandom(min, max);
		}

		public virtual void Bump(float bumpAmount)
		{
			Activate();
			FloatSpring.Bump(bumpAmount);
		}

		public virtual void BumpRandom()
		{
			Activate();
			FloatSpring.BumpRandom(BumpAmountRandomValue.x, BumpAmountRandomValue.y);
		}

		public virtual void BumpRandom(float min, float max)
		{
			Activate();
			FloatSpring.BumpRandom(min, max);
		}

		public override void Stop()
		{
			base.Stop();
			base.enabled = false;
			GrabCurrentValue();
			FloatSpring.Stop();
		}

		public override void RestoreInitialValue()
		{
			FloatSpring.RestoreInitialValue();
			ApplyValue(FloatSpring.CurrentValue);
		}

		public override void ResetInitialValue()
		{
			FloatSpring.SetCurrentValueAsInitialValue();
		}

		protected override void UpdateSpringValue()
		{
			FloatSpring.UpdateSpringValue(DeltaTime);
			ApplyValue(FloatSpring.CurrentValue);
		}

		public override void Finish()
		{
			FloatSpring.Finish();
			ApplyValue(FloatSpring.CurrentValue);
		}

		protected override void Initialization()
		{
			base.Initialization();
			GrabCurrentValue();
			FloatSpring.SetInitialValue(FloatSpring.CurrentValue);
			FloatSpring.TargetValue = FloatSpring.CurrentValue;
		}

		protected virtual void ApplyValue(float newValue)
		{
			TargetFloat = newValue;
		}

		protected override void GrabCurrentValue()
		{
			base.GrabCurrentValue();
			FloatSpring.CurrentValue = TargetFloat;
		}

		public void OnMMEvent(MMSpringFloatEvent springEvent)
		{
			bool num = springEvent.ChannelData != null && MMChannel.Match(springEvent.ChannelData, ChannelMode, Channel, MMChannelDefinition);
			bool flag = springEvent.TargetSpring != null && springEvent.TargetSpring.Equals(this);
			if (num || flag)
			{
				if (springEvent.OverrideDamping)
				{
					FloatSpring.Damping = springEvent.NewDamping;
				}
				if (springEvent.OverrideFrequency)
				{
					FloatSpring.Frequency = springEvent.NewFrequency;
				}
				switch (springEvent.Command)
				{
				case SpringCommands.MoveTo:
					MoveTo(springEvent.MoveToValue);
					break;
				case SpringCommands.MoveToAdditive:
					MoveToAdditive(springEvent.MoveToValue);
					break;
				case SpringCommands.MoveToSubtractive:
					MoveToSubtractive(springEvent.MoveToValue);
					break;
				case SpringCommands.MoveToRandom:
					MoveToRandom(springEvent.MoveToRandomValue.x, springEvent.MoveToRandomValue.y);
					break;
				case SpringCommands.MoveToInstant:
					MoveToInstant(springEvent.MoveToValue);
					break;
				case SpringCommands.Bump:
					Bump(springEvent.BumpAmount);
					break;
				case SpringCommands.BumpRandom:
					BumpRandom(springEvent.BumpAmountRandomValue.x, springEvent.BumpAmountRandomValue.y);
					break;
				case SpringCommands.Stop:
					Stop();
					break;
				case SpringCommands.Finish:
					Finish();
					break;
				case SpringCommands.RestoreInitialValue:
					RestoreInitialValue();
					break;
				case SpringCommands.ResetInitialValue:
					ResetInitialValue();
					break;
				}
			}
		}

		protected override void Awake()
		{
			if (Target == null)
			{
				Target = GetComponent<T>();
			}
			base.Awake();
			this.MMEventStartListening();
		}

		protected void OnDestroy()
		{
			this.MMEventStopListening();
		}

		protected override void TestMoveTo()
		{
			MoveTo(TestMoveToValue);
		}

		protected override void TestMoveToAdditive()
		{
			MoveToAdditive(TestMoveToValue);
		}

		protected override void TestMoveToSubtractive()
		{
			MoveToSubtractive(TestMoveToValue);
		}

		protected override void TestMoveToRandom()
		{
			MoveToRandom();
		}

		protected override void TestMoveToInstant()
		{
			MoveToInstant(TestMoveToValue);
		}

		protected override void TestBump()
		{
			Bump(TestBumpAmount);
		}

		protected override void TestBumpRandom()
		{
			BumpRandom();
		}
	}
}
