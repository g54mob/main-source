using DV.CabControls;
using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetATSLOD : CustomizerLODObject<GadgetATS>
	{
		public GameObject regimeSelector;

		public GameObject acknowledgeButton;

		public LCDDriver regimeDisplay;

		public LampControl stateLamp;

		public float alertIndicatorMoveInterval = 0.25f;

		public float regimeDisplayTime = 2f;

		private SteppedJoint regimeSelectorControl;

		private ControlImplBase acknowledgeButtonControl;

		private int alertPosition;

		private float alertPositionTimer;

		private string[] alertStrings;

		private float showRegimeTimer;

		private void Start()
		{
			acknowledgeButtonControl = acknowledgeButton.GetComponent<ControlImplBase>();
			acknowledgeButtonControl.Used += OnAckButton;
			regimeSelectorControl = regimeSelector.GetComponent<SteppedJoint>();
			regimeSelectorControl.PositionChanged += OnRegimeKnob;
			alertStrings = new string[regimeDisplay.numDigits];
			PooledArray<char> pooledArray = ArrayPool<char>.New(regimeDisplay.numDigits);
			for (int i = 0; i < alertStrings.Length; i++)
			{
				for (int j = 0; j < pooledArray.Length; j++)
				{
					pooledArray[j] = ((j == i) ? '0' : '-');
				}
				alertStrings[i] = new string(pooledArray);
			}
			pooledArray.Dispose();
		}

		private void Update()
		{
			LampControl.LampState state = LampControl.LampState.Off;
			if (base.Base.IsActive)
			{
				state = LampControl.LampState.On;
				if (base.Base.DoWarning)
				{
					state = LampControl.LampState.Blinking;
				}
			}
			stateLamp.SetLampState(state);
			UpdateDisplay();
		}

		private void UpdateDisplay()
		{
			showRegimeTimer -= Time.deltaTime;
			if (showRegimeTimer > 0f)
			{
				regimeDisplay.Display((base.Base.CurrentRegimeTimerLength != 0f) ? base.Base.CurrentRegimeTimerLength.ToString() : string.Empty);
				return;
			}
			int num = Mathf.CeilToInt(Mathf.Max(base.Base.currentTimer, 0f));
			if (base.Base.currentTimer == 0f)
			{
				regimeDisplay.Display(string.Empty);
				showRegimeTimer = 0f;
			}
			else if (base.Base.currentTimer < 0f)
			{
				alertPositionTimer -= Time.deltaTime;
				if (alertPositionTimer <= 0f)
				{
					alertPositionTimer += alertIndicatorMoveInterval;
					alertPosition++;
					if (alertPosition > regimeDisplay.numDigits * 2 - 3)
					{
						alertPosition = 0;
					}
					int num2 = alertPosition;
					if (num2 >= regimeDisplay.numDigits)
					{
						num2 = regimeDisplay.numDigits * 2 - 2 - num2;
					}
					regimeDisplay.Display(alertStrings[num2]);
				}
			}
			else
			{
				alertPositionTimer = 0f;
				alertPosition = -1;
				regimeDisplay.Display(num.ToString().PadLeft(regimeDisplay.numDigits));
			}
		}

		public void OnAckButton()
		{
			base.Base.currentTimer = base.Base.CurrentRegimeTimerLength;
		}

		private void OnRegimeKnob(ValueChangedEventArgs e)
		{
			if (showRegimeTimer > 0f || base.Base.CurrentRegimeTimerLength == 0f)
			{
				int num = base.Base.Regime + (int)e.delta;
				if (num < 0)
				{
					num = base.Base.regimeTimes.Length - 1;
				}
				if (num >= base.Base.regimeTimes.Length)
				{
					num = 0;
				}
				base.Base.SetRegime(num);
			}
			showRegimeTimer = regimeDisplayTime;
		}
	}
}
