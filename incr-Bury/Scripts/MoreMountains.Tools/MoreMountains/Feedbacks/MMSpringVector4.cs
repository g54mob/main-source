using System;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	public abstract class MMSpringVector4<T> : MMSpringComponentBase, MMEventListener<MMSpringVector4Event>, MMEventListenerBase where T : Component
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
		[Header("SpringVector4")]
		public MMSpringVector4 SpringVector4 = new MMSpringVector4();

		[MMInspectorGroup("Randomness", true, 12, true)]
		[Header("Move To Random")]
		[Tooltip("the minimum vector from which to pick a random value when calling MoveToRandom()")]
		public Vector4 MoveToRandomValueMin = new Vector4(-2f, -2f, -2f, -2f);

		[Tooltip("the maximum vector from which to pick a random value when calling MoveToRandom()")]
		public Vector4 MoveToRandomValueMax = new Vector4(2f, 2f, 2f, 2f);

		[Header("Bump Random")]
		[Tooltip("the minimum vector from which to pick a random value when calling BumpRandom()")]
		public Vector2 BumpAmountRandomValueMin = new Vector4(-20f, -20f, -20f, -20f);

		[Tooltip("the maximum vector from which to pick a random value when calling BumpRandom()")]
		public Vector2 BumpAmountRandomValueMax = new Vector4(20f, 20f, 20f, 20f);

		[MMInspectorGroup("Test", true, 20, true)]
		[Tooltip("the value to move this spring to when interacting with any of the MoveTo debug buttons in its inspector")]
		public Vector4 TestMoveToValue = new Vector4(2f, 2f, 2f, 2f);

		[MMInspectorButtonBar(new string[] { "MoveTo", "MoveToAdditive", "MoveToSubtractive", "MoveToRandom", "MoveToInstant" }, new string[] { "TestMoveTo", "TestMoveToAdditive", "TestMoveToSubtractive", "TestMoveToRandom", "TestMoveToInstant" }, new bool[] { true, true, true, true, true }, new string[] { "main-call-to-action", "", "", "", "" })]
		public bool MoveToToolbar;

		[Tooltip("the amount by which to bump this spring when interacting with the Bump debug button in its inspector")]
		public Vector4 TestBumpAmount = new Vector4(75f, 100f, 50f, 25f);

		[MMInspectorButtonBar(new string[] { "Bump", "BumpRandom" }, new string[] { "TestBump", "TestBumpRandom" }, new bool[] { true, true }, new string[] { "main-call-to-action", "" })]
		public bool BumpToToolbar;

		[MMInspectorButtonBar(new string[] { "Stop", "Finish", "RestoreInitialValue", "ResetInitialValue" }, new string[] { "Stop", "Finish", "RestoreInitialValue", "ResetInitialValue" }, new bool[] { true, true, true, true }, new string[] { "", "", "", "" })]
		public bool OtherControlsToToolbar;

		public override bool LowVelocity => Mathf.Abs(SpringVector4.SpringX.Velocity) + Mathf.Abs(SpringVector4.SpringY.Velocity) + Mathf.Abs(SpringVector4.SpringZ.Velocity) + Mathf.Abs(SpringVector4.SpringW.Velocity) < _velocityLowThreshold;

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

		public virtual Vector4 TargetVector4 { get; set; }

		public virtual void MoveTo(Vector4 newValue)
		{
			Activate();
			SpringVector4.MoveTo(newValue);
		}

		public virtual void MoveToAdditive(Vector4 newValue)
		{
			Activate();
			SpringVector4.MoveToAdditive(newValue);
		}

		public virtual void MoveToSubtractive(Vector4 newValue)
		{
			Activate();
			SpringVector4.MoveToSubtractive(newValue);
		}

		public virtual void MoveToRandom()
		{
			Activate();
			SpringVector4.MoveToRandom(MoveToRandomValueMin, MoveToRandomValueMax);
		}

		public virtual void MoveToInstant(Vector4 newValue)
		{
			Activate();
			SpringVector4.MoveToInstant(newValue);
		}

		public virtual void MoveToRandom(Vector4 min, Vector4 max)
		{
			Activate();
			SpringVector4.MoveToRandom(min, max);
		}

		public virtual void Bump(Vector4 bumpAmount)
		{
			Activate();
			SpringVector4.Bump(bumpAmount);
		}

		public virtual void BumpRandom()
		{
			Activate();
			SpringVector4.BumpRandom(BumpAmountRandomValueMin, BumpAmountRandomValueMax);
		}

		public virtual void BumpRandom(Vector4 min, Vector4 max)
		{
			Activate();
			SpringVector4.BumpRandom(min, max);
		}

		public override void Stop()
		{
			base.Stop();
			base.enabled = false;
			GrabCurrentValue();
			SpringVector4.Stop();
		}

		public override void RestoreInitialValue()
		{
			SpringVector4.RestoreInitialValue();
			ApplyValue(SpringVector4.CurrentValue);
		}

		public override void ResetInitialValue()
		{
			SpringVector4.RestoreInitialValue();
		}

		protected override void UpdateSpringValue()
		{
			SpringVector4.UpdateSpringValue(DeltaTime);
			ApplyValue(SpringVector4.CurrentValue);
		}

		public override void Finish()
		{
			SpringVector4.Finish();
			ApplyValue(SpringVector4.CurrentValue);
		}

		protected override void Initialization()
		{
			base.Initialization();
			GrabCurrentValue();
			SpringVector4.SetInitialValue(SpringVector4.CurrentValue);
			SpringVector4.TargetValue = SpringVector4.CurrentValue;
		}

		protected virtual void ApplyValue(Vector4 newValue)
		{
			TargetVector4 = newValue;
		}

		protected override void GrabCurrentValue()
		{
			base.GrabCurrentValue();
			SpringVector4.CurrentValue = TargetVector4;
		}

		public void OnMMEvent(MMSpringVector4Event springEvent)
		{
			bool num = springEvent.ChannelData != null && MMChannel.Match(springEvent.ChannelData, ChannelMode, Channel, MMChannelDefinition);
			bool flag = springEvent.TargetSpring != null && springEvent.TargetSpring.Equals(this);
			if (num || flag)
			{
				if (springEvent.OverrideDamping)
				{
					SpringVector4.SetDamping(springEvent.NewDamping);
				}
				if (springEvent.OverrideFrequency)
				{
					SpringVector4.SetFrequency(springEvent.NewFrequency);
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
	[Serializable]
	public class MMSpringVector4 : MMSpringDefinition<Vector4>
	{
		public bool SeparateAxis;

		public MMSpringFloat UnifiedSpring;

		public MMSpringFloat SpringX;

		public MMSpringFloat SpringY;

		public MMSpringFloat SpringZ;

		public MMSpringFloat SpringW;

		protected Vector4 _returnCurrentValue;

		protected Vector4 _returnTargetValue;

		protected Vector4 _returnVelocity;

		public override Vector4 CurrentValue
		{
			get
			{
				_returnCurrentValue.x = SpringX.CurrentValue;
				_returnCurrentValue.y = SpringY.CurrentValue;
				_returnCurrentValue.z = SpringZ.CurrentValue;
				_returnCurrentValue.w = SpringW.CurrentValue;
				return _returnCurrentValue;
			}
			set
			{
				SpringX.CurrentValue = value.x;
				SpringY.CurrentValue = value.y;
				SpringZ.CurrentValue = value.z;
				SpringW.CurrentValue = value.w;
			}
		}

		public override Vector4 TargetValue
		{
			get
			{
				_returnTargetValue.x = SpringX.TargetValue;
				_returnTargetValue.y = SpringY.TargetValue;
				_returnTargetValue.z = SpringZ.TargetValue;
				_returnTargetValue.w = SpringW.TargetValue;
				return _returnTargetValue;
			}
			set
			{
				SpringX.TargetValue = value.x;
				SpringY.TargetValue = value.y;
				SpringZ.TargetValue = value.z;
				SpringW.TargetValue = value.w;
			}
		}

		public override Vector4 Velocity
		{
			get
			{
				_returnVelocity.x = SpringX.Velocity;
				_returnVelocity.y = SpringY.Velocity;
				_returnVelocity.z = SpringZ.Velocity;
				_returnVelocity.w = SpringW.Velocity;
				return _returnVelocity;
			}
			set
			{
				SpringX.Velocity = value.x;
				SpringY.Velocity = value.y;
				SpringZ.Velocity = value.z;
				SpringW.Velocity = value.w;
			}
		}

		public MMSpringVector4()
		{
			SpringX = new MMSpringFloat();
			SpringY = new MMSpringFloat();
			SpringZ = new MMSpringFloat();
			SpringW = new MMSpringFloat();
			UnifiedSpring = new MMSpringFloat();
			UnifiedSpring.UnifiedSpring = true;
		}

		public virtual void SetDamping(Vector4 newDamping)
		{
			UnifiedSpring.Damping = newDamping.x;
			SpringX.Damping = newDamping.x;
			SpringY.Damping = newDamping.y;
			SpringZ.Damping = newDamping.z;
			SpringW.Damping = newDamping.w;
		}

		public virtual void SetFrequency(Vector4 newFrequency)
		{
			UnifiedSpring.Frequency = newFrequency.x;
			SpringX.Frequency = newFrequency.x;
			SpringY.Frequency = newFrequency.y;
			SpringZ.Frequency = newFrequency.z;
			SpringW.Frequency = newFrequency.w;
		}

		public override void UpdateSpringValue(float deltaTime)
		{
			if (!SeparateAxis)
			{
				SpringX.Damping = UnifiedSpring.Damping;
				SpringX.Frequency = UnifiedSpring.Frequency;
				SpringY.Damping = UnifiedSpring.Damping;
				SpringY.Frequency = UnifiedSpring.Frequency;
				SpringZ.Damping = UnifiedSpring.Damping;
				SpringZ.Frequency = UnifiedSpring.Frequency;
				SpringW.Damping = UnifiedSpring.Damping;
				SpringW.Frequency = UnifiedSpring.Frequency;
			}
			SpringX.UpdateSpringValue(deltaTime);
			SpringY.UpdateSpringValue(deltaTime);
			SpringZ.UpdateSpringValue(deltaTime);
			SpringW.UpdateSpringValue(deltaTime);
		}

		public override void MoveToInstant(Vector4 newValue)
		{
			SpringX.MoveToInstant(newValue.x);
			SpringY.MoveToInstant(newValue.y);
			SpringZ.MoveToInstant(newValue.z);
			SpringW.MoveToInstant(newValue.w);
		}

		public override void Stop()
		{
			SpringX.Stop();
			SpringY.Stop();
			SpringZ.Stop();
			SpringW.Stop();
		}

		public override void SetInitialValue(Vector4 newInitialValue)
		{
			SpringX.SetInitialValue(newInitialValue.x);
			SpringY.SetInitialValue(newInitialValue.y);
			SpringZ.SetInitialValue(newInitialValue.z);
			SpringW.SetInitialValue(newInitialValue.w);
		}

		public override void RestoreInitialValue()
		{
			SpringX.RestoreInitialValue();
			SpringY.RestoreInitialValue();
			SpringZ.RestoreInitialValue();
			SpringW.RestoreInitialValue();
		}

		public override void SetCurrentValueAsInitialValue()
		{
			SpringX.SetCurrentValueAsInitialValue();
			SpringY.SetCurrentValueAsInitialValue();
			SpringZ.SetCurrentValueAsInitialValue();
			SpringW.SetCurrentValueAsInitialValue();
		}

		public override void MoveTo(Vector4 newValue)
		{
			SpringX.MoveTo(newValue.x);
			SpringY.MoveTo(newValue.y);
			SpringZ.MoveTo(newValue.z);
			SpringW.MoveTo(newValue.w);
		}

		public override void MoveToAdditive(Vector4 newValue)
		{
			SpringX.MoveToAdditive(newValue.x);
			SpringY.MoveToAdditive(newValue.y);
			SpringZ.MoveToAdditive(newValue.z);
			SpringW.MoveToAdditive(newValue.w);
		}

		public override void MoveToSubtractive(Vector4 newValue)
		{
			SpringX.MoveToSubtractive(newValue.x);
			SpringY.MoveToSubtractive(newValue.y);
			SpringZ.MoveToSubtractive(newValue.z);
			SpringW.MoveToSubtractive(newValue.w);
		}

		public override void MoveToRandom(Vector4 min, Vector4 max)
		{
			SpringX.MoveToRandom(min.x, max.x);
			SpringY.MoveToRandom(min.y, max.y);
			SpringZ.MoveToRandom(min.z, max.z);
			SpringW.MoveToRandom(min.w, max.w);
		}

		public override void Bump(Vector4 bumpAmount)
		{
			SpringX.Bump(bumpAmount.x);
			SpringY.Bump(bumpAmount.y);
			SpringZ.Bump(bumpAmount.z);
			SpringW.Bump(bumpAmount.w);
		}

		public override void BumpRandom(Vector4 min, Vector4 max)
		{
			SpringX.BumpRandom(min.x, max.x);
			SpringY.BumpRandom(min.y, max.y);
			SpringZ.BumpRandom(min.z, max.z);
			SpringW.BumpRandom(min.w, max.w);
		}

		public override void Finish()
		{
			SpringX.Finish();
			SpringY.Finish();
			SpringZ.Finish();
			SpringW.Finish();
		}
	}
}
