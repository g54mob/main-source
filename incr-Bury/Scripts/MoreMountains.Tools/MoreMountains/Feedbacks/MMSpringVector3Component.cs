using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	public abstract class MMSpringVector3Component<T> : MMSpringComponentBase, MMEventListener<MMSpringVector3Event>, MMEventListenerBase where T : Component
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
		[Header("SpringVector3")]
		public MMSpringVector3 SpringVector3 = new MMSpringVector3();

		[MMInspectorGroup("Randomness", true, 12, true)]
		[Header("Move To Random")]
		[Tooltip("the minimum vector from which to pick a random value when calling MoveToRandom()")]
		public Vector3 MoveToRandomValueMin = new Vector3(-2f, -2f, -2f);

		[Tooltip("the maximum vector from which to pick a random value when calling MoveToRandom()")]
		public Vector3 MoveToRandomValueMax = new Vector3(2f, 2f, 2f);

		[Header("Bump Random")]
		[Tooltip("the minimum vector from which to pick a random value when calling BumpRandom()")]
		public Vector3 BumpAmountRandomValueMin = new Vector3(-20f, 20f, -20f);

		[Tooltip("the maximum vector from which to pick a random value when calling BumpRandom()")]
		public Vector3 BumpAmountRandomValueMax = new Vector3(20f, 20f, 20f);

		[MMInspectorGroup("Test", true, 20, true)]
		[Tooltip("the value to move this spring to when interacting with any of the MoveTo debug buttons in its inspector")]
		public Vector3 TestMoveToValue = new Vector3(2f, 2f, 2f);

		[MMInspectorButtonBar(new string[] { "MoveTo", "MoveToAdditive", "MoveToSubtractive", "MoveToRandom", "MoveToInstant" }, new string[] { "TestMoveTo", "TestMoveToAdditive", "TestMoveToSubtractive", "TestMoveToRandom", "TestMoveToInstant" }, new bool[] { true, true, true, true, true }, new string[] { "main-call-to-action", "", "", "", "" })]
		public bool MoveToToolbar;

		[Tooltip("the amount by which to bump this spring when interacting with the Bump debug button in its inspector")]
		public Vector3 TestBumpAmount = new Vector3(75f, 100f, 50f);

		[MMInspectorButtonBar(new string[] { "Bump", "BumpRandom" }, new string[] { "TestBump", "TestBumpRandom" }, new bool[] { true, true }, new string[] { "main-call-to-action", "" })]
		public bool BumpToToolbar;

		[MMInspectorButtonBar(new string[] { "Stop", "Finish", "RestoreInitialValue", "ResetInitialValue" }, new string[] { "Stop", "Finish", "RestoreInitialValue", "ResetInitialValue" }, new bool[] { true, true, true, true }, new string[] { "", "", "", "" })]
		public bool OtherControlsToToolbar;

		public override bool LowVelocity => Mathf.Abs(SpringVector3.Velocity.x) + Mathf.Abs(SpringVector3.Velocity.y) + Mathf.Abs(SpringVector3.Velocity.z) < _velocityLowThreshold;

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

		public virtual Vector3 TargetVector3 { get; set; }

		public virtual void MoveTo(Vector3 newValue)
		{
			Activate();
			SpringVector3.MoveTo(newValue);
		}

		public virtual void MoveToAdditive(Vector3 newValue)
		{
			Activate();
			SpringVector3.MoveToAdditive(newValue);
		}

		public virtual void MoveToSubtractive(Vector3 newValue)
		{
			Activate();
			SpringVector3.MoveToSubtractive(newValue);
		}

		public virtual void MoveToRandom()
		{
			Activate();
			SpringVector3.MoveToRandom(MoveToRandomValueMin, MoveToRandomValueMax);
		}

		public virtual void MoveToInstant(Vector3 newValue)
		{
			Activate();
			SpringVector3.MoveToInstant(newValue);
		}

		public virtual void MoveToRandom(Vector3 min, Vector3 max)
		{
			Activate();
			SpringVector3.MoveToRandom(min, max);
		}

		public virtual void Bump(Vector3 bumpAmount)
		{
			Activate();
			SpringVector3.Bump(bumpAmount);
		}

		public virtual void BumpRandom()
		{
			Activate();
			SpringVector3.BumpRandom(BumpAmountRandomValueMin, BumpAmountRandomValueMax);
		}

		public virtual void BumpRandom(Vector3 min, Vector3 max)
		{
			Activate();
			SpringVector3.BumpRandom(min, max);
		}

		public override void Stop()
		{
			base.Stop();
			base.enabled = false;
			GrabCurrentValue();
			SpringVector3.Stop();
		}

		public override void RestoreInitialValue()
		{
			SpringVector3.RestoreInitialValue();
			ApplyValue(SpringVector3.CurrentValue);
		}

		public override void ResetInitialValue()
		{
			SpringVector3.SetCurrentValueAsInitialValue();
		}

		protected override void UpdateSpringValue()
		{
			SpringVector3.UpdateSpringValue(DeltaTime);
			ApplyValue(SpringVector3.CurrentValue);
		}

		public override void Finish()
		{
			SpringVector3.Finish();
			ApplyValue(SpringVector3.CurrentValue);
		}

		protected override void Initialization()
		{
			base.Initialization();
			GrabCurrentValue();
			SpringVector3.SetInitialValue(SpringVector3.CurrentValue);
			SpringVector3.TargetValue = SpringVector3.CurrentValue;
		}

		protected virtual void ApplyValue(Vector3 newValue)
		{
			TargetVector3 = newValue;
		}

		protected override void GrabCurrentValue()
		{
			base.GrabCurrentValue();
			SpringVector3.CurrentValue = TargetVector3;
		}

		public void OnMMEvent(MMSpringVector3Event springEvent)
		{
			bool num = springEvent.ChannelData != null && MMChannel.Match(springEvent.ChannelData, ChannelMode, Channel, MMChannelDefinition);
			bool flag = springEvent.TargetSpring != null && springEvent.TargetSpring.Equals(this);
			if (num || flag)
			{
				if (springEvent.OverrideDamping)
				{
					SpringVector3.SetDamping(springEvent.NewDamping);
				}
				if (springEvent.OverrideFrequency)
				{
					SpringVector3.SetFrequency(springEvent.NewFrequency);
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
					MoveToRandom(springEvent.MoveToRandomValueMin, springEvent.MoveToRandomValueMax);
					break;
				case SpringCommands.MoveToInstant:
					MoveToInstant(springEvent.MoveToValue);
					break;
				case SpringCommands.Bump:
					Bump(springEvent.BumpAmount);
					break;
				case SpringCommands.BumpRandom:
					BumpRandom(springEvent.BumpAmountRandomValueMin, springEvent.BumpAmountRandomValueMax);
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
