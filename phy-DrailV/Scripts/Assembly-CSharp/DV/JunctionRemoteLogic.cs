using UnityEngine;

namespace DV
{
	public class JunctionRemoteLogic : MonoBehaviour, ICommsRadioMode
	{
		private static Color laserColor = new Color(1f, 0f, 0f, 1f);

		public Transform signalOrigin;

		public CommsRadioDisplay display;

		public ArrowLCD lcd;

		private CommsJunctionSwitcher switcher;

		private Vector3 laserTarget;

		public ButtonBehaviourType ButtonBehaviour => ButtonBehaviourType.Regular;

		private void Awake()
		{
			if (!lcd)
			{
				Debug.LogError("ArrowLCD isn't set!", this);
			}
			if (!signalOrigin)
			{
				Debug.LogError("signalOrigin on JunctionRemoteLogic isn't set, using this.transform!", this);
				signalOrigin = base.transform;
			}
			if (display == null)
			{
				Debug.LogError("display not set, can't function properly!", this);
			}
			switcher = base.gameObject.AddComponent<CommsJunctionSwitcher>();
			switcher.pointerOrigin = signalOrigin;
			switcher.JunctionSwitched += delegate
			{
				UpdateLCDArrow();
			};
			switcher.JunctionUnHovered += delegate
			{
				UpdateHover(isHovered: false);
			};
			switcher.JunctionHovered += delegate
			{
				UpdateHover(isHovered: true);
			};
		}

		private void Start()
		{
			lcd.TurnOff();
			if (!VRManager.IsVREnabled())
			{
				base.gameObject.AddComponent<JunctionRemotePointerCheckNonVr>();
			}
			else
			{
				base.gameObject.AddComponent<JunctionRemoteHaptics>();
			}
		}

		public void OnUpdate()
		{
		}

		public void Enable()
		{
			switcher.enabled = true;
		}

		public void Disable()
		{
			switcher.enabled = false;
		}

		public void OverrideSignalOrigin(Transform signalOrigin)
		{
			this.signalOrigin = signalOrigin;
			switcher.pointerOrigin = signalOrigin;
		}

		public void OnUse()
		{
			switcher.Use();
			UpdateLCDArrow();
		}

		public bool ButtonACustomAction()
		{
			Debug.LogError("Unexpected ButtonACustomAction!", this);
			return false;
		}

		public bool ButtonBCustomAction()
		{
			Debug.LogError("Unexpected ButtonACustomAction!", this);
			return false;
		}

		public void SetStartingDisplay()
		{
			display.SetDisplay(CommsRadioLocalization.MODE_SWITCH, CommsRadioLocalization.SWITCH_INSTRUCTION);
		}

		public Color GetLaserBeamColor()
		{
			return laserColor;
		}

		private void UpdateHover(bool isHovered)
		{
			JunctionSwitchRemoteControllable junctionSwitchRemoteControllable = ((switcher != null) ? switcher.PointedSwitch : null);
			UpdateLCDArrow();
			if (isHovered)
			{
				string action = ((junctionSwitchRemoteControllable != null) ? junctionSwitchRemoteControllable.IdLong : string.Empty);
				display.SetDisplay(CommsRadioLocalization.MODE_SWITCH, CommsRadioLocalization.SWITCH_INSTRUCTION, action);
			}
			else
			{
				display.SetDisplay(CommsRadioLocalization.MODE_SWITCH, CommsRadioLocalization.SWITCH_INSTRUCTION);
			}
		}

		private void UpdateLCDArrow()
		{
			if (!switcher || !switcher.PointedSwitch)
			{
				lcd.TurnOff();
				return;
			}
			bool flag = switcher.PointedSwitch.IsPointingLeft();
			if (switcher.IndirectlyPointing)
			{
				lcd.TurnOn(flag);
				return;
			}
			bool left = (switcher.PointedSwitch.IsBehind(base.transform) ? flag : (!flag));
			lcd.TurnOn(left);
		}

		public bool IsPointingToSwitch()
		{
			if (!switcher || !switcher.PointedSwitch)
			{
				return false;
			}
			return switcher.PointedSwitch;
		}
	}
}
