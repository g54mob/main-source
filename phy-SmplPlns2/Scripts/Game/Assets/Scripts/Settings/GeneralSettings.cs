using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Input;
using Assets.Scripts.Storage;
using Jundroo.Common.Math;
using Jundroo.Common.Settings;
using Jundroo.Common.Settings.Events;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Settings
{
	public class GeneralSettings : SettingsCategory<GeneralSettings>
	{
		public NumericSetting<float> InteractablePartColliderScale { get; private set; }

		public BoolSetting InvertTouchControlsPitch { get; private set; }

		public override int Order => -1;

		public BoolSetting SupportUnknownGamepadsOnAndroid { get; private set; }

		public EnumSetting<TouchControlsType> TouchControlsType { get; private set; }

		public UnitSystem UnitSystem
		{
			get
			{
				return Units.CurrentUnitSystem;
			}
			set
			{
				Units.CurrentUnitSystem = value;
			}
		}

		public List<UnitSystem> UnitSystems { get; set; } = new List<UnitSystem>();

		public BoolSetting UseDirectInput { get; private set; }

		public NumericSetting<float> UserInterfaceScale { get; private set; }

		protected NumericSetting<int> UnitSystemIndex { get; private set; }

		public GeneralSettings()
			: base("General")
		{
		}

		protected override void InitializeSettings()
		{
			LoadUnitSystems();
			float min = 0.5f;
			float max = 2f;
			float num = 1f;
			UserInterfaceScale = CreateNumeric("User Interface Size", min, max, 0.05f).SetDisplayFormatter((float x) => Utilities.FormatPercentage(x)).SetDescription("Increases or decreases the size of the user interface.").SetDefault(num);
			UserInterfaceScale.ApplyOnSliderRelease = true;
			UnitSystemIndex = CreateNumeric("Unit System", 0, UnitSystems.Count - 1, 1, "unitSystem").SetDisplayFormatter((int x) => UnitSystems[Mathf.Clamp(x, 0, UnitSystems.Count - 1)].Name).SetApplyType(SettingApplyType.RequiresSceneRestart).SetDescription("The unit system used by the game.")
				.SetDefault(Mathf.Clamp(UnitSystems.FindIndex((UnitSystem x) => x.Name == UnitSystem.Imperial.Name), 0, UnitSystems.Count - 1));
			UnitSystemIndex.UseSpinnerUI = true;
			TouchControlsType = CreateEnum<TouchControlsType>("On-Screen Flight Controls").SetDefault(Game.Instance.Device.IsTouchEnabled ? Assets.Scripts.Input.TouchControlsType.Mode2 : Assets.Scripts.Input.TouchControlsType.Off);
			InvertTouchControlsPitch = CreateBool("Invert On-Screen Flight Controls").SetDefault(value: false);
			UseDirectInput = CreateBool("Use Direct Input").SetState(SettingState.Hidden).SetDefault(value: false);
			SupportUnknownGamepadsOnAndroid = CreateBool("Support Unknown Gamepads On Android").SetState(SettingState.Hidden).SetDefault(value: true);
			float num2 = 1f;
			if (Game.Instance.Device.IsVRExclusiveBuild)
			{
				num2 = 1.25f;
			}
			else if (Game.Instance.Device.IsMobileBuild)
			{
				num2 = 1.5f;
			}
			InteractablePartColliderScale = CreateNumeric("Interactable Part Collider Scale", 1f, 5f, 0.1f).SetState(SettingState.Hidden).SetDefault(num2);
			UnitSystemIndex.Changed += OnUnitSystemChanged;
			UnitSystemIndex.RaiseSettingChangedEvent();
		}

		private void LoadUnitSystems()
		{
			UnitSystems.Clear();
			string path = GameData.GetPath("UnitSystems.xml");
			bool flag = false;
			XDocument xDocument = null;
			if (File.Exists(path))
			{
				try
				{
					xDocument = XDocument.Load(path);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					Debug.LogError("An error occurred reading the unit systems from XML: " + path);
					flag = true;
				}
			}
			if (xDocument == null)
			{
				xDocument = new XDocument(new XElement("UnitSystems"));
			}
			UnitSystems.Add(UnitSystem.Metric);
			UnitSystems.Add(UnitSystem.Imperial);
			UnitSystems.Add(UnitSystem.Nautical);
			foreach (UnitSystem sys in UnitSystems)
			{
				if (!xDocument.Root.Elements().Any((XElement x) => x.Name.LocalName == sys.Name))
				{
					xDocument.Root.Add(sys.Save());
					flag = true;
				}
			}
			foreach (XElement item in xDocument.Root.Elements())
			{
				UnitSystem sys2 = UnitSystem.Load(item);
				if (sys2 != null)
				{
					int num = UnitSystems.FindIndex((UnitSystem x) => x.Name == sys2.Name);
					if (num < 0)
					{
						UnitSystems.Add(sys2);
					}
					else
					{
						UnitSystems[num] = sys2;
					}
				}
			}
			if (flag)
			{
				xDocument.Save(path);
			}
		}

		private void OnUnitSystemChanged(object sender, SettingChangedEventArgs<int> e)
		{
			UnitSystem = UnitSystems[Mathf.Clamp(e.Setting.Value, 0, UnitSystems.Count - 1)];
		}
	}
}
