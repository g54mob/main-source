using DV.CabControls;
using DV.LCD;
using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetRoadrunnerLOD : CustomizerLODObject<GadgetRoadrunner>
	{
		public int increment = 10;

		public GameObject startButton;

		public GameObject ackButton;

		public GameObject lengthKnob;

		public PixelDisplay trackingBar;

		public LampControl indicatorLamp;

		public Color colorTracking = Color.green;

		public Color colorTarget = Color.yellow;

		private ControlImplBase startButtonControl;

		private ControlImplBase ackButtonControl;

		private ControlImplBase lengthKnobControl;

		private int lastTarget = -1;

		private int lastDistance = -1;

		private void Start()
		{
			startButtonControl = startButton.GetComponent<ControlImplBase>();
			startButtonControl.Used += BtnStart;
			ackButtonControl = ackButton.GetComponent<ControlImplBase>();
			ackButtonControl.Used += BtnAck;
			lengthKnobControl = lengthKnob.GetComponent<ControlImplBase>();
			lengthKnobControl.GetComponent<SteppedJoint>().PositionChanged += KnobLength;
		}

		private void BtnStart()
		{
			base.Base.StartMeasure();
		}

		private void BtnAck()
		{
			base.Base.Acknowledge();
		}

		private void KnobLength(ValueChangedEventArgs e)
		{
			base.Base.LengthMeters += (int)e.delta * increment;
		}

		private void Update()
		{
			int num = -1;
			int num2 = -1;
			if (base.Base.PowerState)
			{
				num = DistanceToPixel(base.Base.LengthMeters);
				num2 = DistanceToPixel(base.Base.Countup);
				if (num2 > trackingBar.Resolution.x)
				{
					num2 = trackingBar.Resolution.x;
				}
				LampControl.LampState state = LampControl.LampState.Off;
				if (base.Base.HasCompleted)
				{
					state = LampControl.LampState.Blinking;
				}
				else if (base.Base.IsCounting)
				{
					state = LampControl.LampState.On;
				}
				indicatorLamp.SetLampState(state, base.Base.HasCompleted);
			}
			else
			{
				indicatorLamp.SetLampState(LampControl.LampState.Off);
			}
			if (lastTarget != num || lastDistance != num2)
			{
				lastTarget = num;
				lastDistance = num2;
				trackingBar.Clear(Color.black);
				trackingBar.Fill(0, 0, num2, 1, colorTracking);
				if (num != -1)
				{
					trackingBar.SetOne(num, 0, colorTarget);
				}
			}
			int DistanceToPixel(float d)
			{
				return Mathf.CeilToInt((float)(trackingBar.Resolution.x - 1) * d / (float)base.Base.MaxLength);
			}
		}
	}
}
