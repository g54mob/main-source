using DV.CabControls;
using DV.PointSet;
using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetSwitchSetterLOD : CustomizerLODObject<GadgetSwitchSetter>
	{
		public const int MAX_SEARCH_DEPTH = 64;

		public const float SEARCH_INTERVAL = 0.5f;

		public LampControl lampInRange;

		public LampControl lampLeft;

		public LampControl lampRight;

		public GameObject btnChange;

		private ControlImplBase btnChangeControl;

		public AudioClip switchChangeAudio;

		public GameObject knbRange;

		private ControlImplBase knbRangeControl;

		public GameObject knbMode;

		private ControlImplBase knbModeControl;

		public GameObject knbSide;

		private ControlImplBase knbSideControl;

		private float calcInterval;

		private Junction currentJunction;

		private void Start()
		{
			btnChangeControl = btnChange.GetComponent<ControlImplBase>();
			knbRangeControl = knbRange.GetComponent<ControlImplBase>();
			knbModeControl = knbMode.GetComponent<ControlImplBase>();
			knbSideControl = knbSide.GetComponent<ControlImplBase>();
			SyncControls();
			btnChangeControl.Used += BtnChange;
			knbRangeControl.ValueChanged += OnControlChanged;
			knbModeControl.ValueChanged += OnControlChanged;
			knbSideControl.ValueChanged += OnControlChanged;
		}

		private void OnDestroy()
		{
			if ((bool)btnChangeControl)
			{
				btnChangeControl.Used -= BtnChange;
			}
			if ((bool)knbRangeControl)
			{
				knbRangeControl.ValueChanged -= OnControlChanged;
			}
			if ((bool)knbModeControl)
			{
				knbModeControl.ValueChanged -= OnControlChanged;
			}
			if ((bool)knbSideControl)
			{
				knbSideControl.ValueChanged -= OnControlChanged;
			}
		}

		private void Update()
		{
			if (!base.Base.PowerState)
			{
				calcInterval = 0.5f;
				return;
			}
			calcInterval -= Time.deltaTime;
			if (!(calcInterval > 0f))
			{
				calcInterval += 0.5f;
				Calc();
			}
		}

		protected internal override void OnPowerStateChanged(bool newValue)
		{
			if (!newValue)
			{
				lampInRange.SetLampState(LampControl.LampState.Off);
				lampLeft.SetLampState(LampControl.LampState.Off);
				lampRight.SetLampState(LampControl.LampState.Off);
			}
		}

		public void BtnChange()
		{
			if (base.Base.PowerState)
			{
				currentJunction?.Switch(Junction.SwitchMode.REGULAR);
				if (switchChangeAudio != null && currentJunction != null)
				{
					switchChangeAudio.Play(btnChangeControl.transform.position, 1f, 1f, 0f, 1f, 10f, default(AudioSourceCurves), null, base.transform);
				}
			}
		}

		public void SyncControls()
		{
			knbRangeControl.SetValue((float)base.Base.Mode / (float)(base.Base.ModeCount - 1));
			knbModeControl.SetValue((float)base.Base.DirectionMode / 2f);
			knbSideControl.SetValue(base.Base.SideCorrectRegime ? 1 : 0);
		}

		private void OnControlChanged(ValueChangedEventArgs _)
		{
			base.Base.Mode = Mathf.RoundToInt(knbRangeControl.Value * (float)(base.Base.ModeCount - 1));
			base.Base.SideCorrectRegime = knbSideControl.Value > 0.5f;
			base.Base.DirectionMode = Mathf.RoundToInt(knbModeControl.Value * 2f);
		}

		private void Calc()
		{
			Junction junction = null;
			bool flag = false;
			bool flag2 = false;
			double num = base.Base.GetRange();
			if (base.IsOnTrainCar)
			{
				flag2 = ((!base.Base.HasControls || !(base.Base.Controls.Reverser != null)) ? (Vector3.Dot(base.transform.right, base.Base.Custom.transform.right) < 0f) : (base.Base.Controls.Reverser.Value < 0.5f));
				switch (base.Base.DirectionMode)
				{
				case 0:
					flag2 = true;
					break;
				case 2:
					flag2 = false;
					break;
				}
				bool flag3 = flag2;
				TrainCar trainCar = base.Base.TrainCar;
				do
				{
					Coupler coupler = (flag2 ? trainCar.rearCoupler : trainCar.frontCoupler);
					if (coupler.coupledTo == null)
					{
						break;
					}
					trainCar = coupler.coupledTo.train;
					if (coupler.isFrontCoupler == coupler.coupledTo.isFrontCoupler)
					{
						flag2 = !flag2;
					}
				}
				while (!(trainCar == base.Base.TrainCar));
				Bogie bogie = trainCar.Bogies[0];
				RailTrack track = bogie.track;
				bool flag4 = bogie.TrackDirectionSign < 0f != flag2;
				if (track != null)
				{
					EquiPointSet.Point curPoint = bogie.traveller.curPoint;
					int num2 = 64;
					num -= (flag4 ? curPoint.span : (bogie.traveller.pointSet.span - curPoint.span));
					while (num2-- > 0 && num > 0.0)
					{
						Junction junction2 = (flag4 ? track.inJunction : track.outJunction);
						Junction.Branch branch = null;
						if (junction2 != null)
						{
							if (junction2.inBranch.track == track)
							{
								junction = junction2;
								flag = junction2.selectedBranch > 0;
								break;
							}
							branch = junction2.inBranch;
						}
						if (branch == null)
						{
							branch = (flag4 ? track.inBranch : track.outBranch);
						}
						if (branch == null || branch.track == null)
						{
							break;
						}
						Junction.Branch potentialBranch = (flag4 ? branch.track.inBranch : branch.track.outBranch);
						Junction potentialJunction = (flag4 ? branch.track.inJunction : branch.track.outJunction);
						if (ContainsRail(track, potentialBranch, potentialJunction))
						{
							flag4 = !flag4;
						}
						track = branch.track;
						num -= track.LogicTrack().length;
					}
				}
				if (currentJunction != junction)
				{
					currentJunction = junction;
					lampInRange.SetLampState(LampControl.LampState.Off);
				}
				if (base.Base.SideCorrectRegime && Vector3.Dot(base.transform.right, base.Base.Custom.transform.right) < 0f != flag3)
				{
					flag = !flag;
				}
			}
			lampInRange.SetLampState(junction ? LampControl.LampState.On : LampControl.LampState.Off, junction);
			lampLeft.SetLampState(((bool)junction && !flag) ? LampControl.LampState.On : LampControl.LampState.Off);
			lampRight.SetLampState(((bool)junction && flag) ? LampControl.LampState.On : LampControl.LampState.Off);
			bool ContainsRail(RailTrack target, Junction.Branch branch2, Junction junction3)
			{
				if (branch2?.track == target)
				{
					return true;
				}
				if (junction3 == null)
				{
					return false;
				}
				if (junction3.inBranch?.track == target)
				{
					return true;
				}
				foreach (Junction.Branch outBranch in junction3.outBranches)
				{
					if (outBranch.track == target)
					{
						return true;
					}
				}
				return false;
			}
		}
	}
}
