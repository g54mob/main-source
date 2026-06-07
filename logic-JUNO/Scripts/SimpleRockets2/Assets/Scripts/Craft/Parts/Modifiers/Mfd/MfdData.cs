using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Design;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Mfd
{
	[Serializable]
	[DesignerPartModifier("Multi-function Display", PanelOrder = 2000)]
	public class MfdData : PartModifierData<MfdScript>
	{
		public class DefaultMfdProgram
		{
			public string Filename { get; set; }

			public bool Hidden { get; set; }

			public string Id { get; set; }

			public string Name { get; set; }

			public DefaultMfdProgram(string id, string name, string filename, bool hidden = false)
			{
				Id = id;
				Name = name;
				Filename = filename;
				Hidden = hidden;
			}
		}

		public const string CustomProgramNameId = "Custom";

		private static DefaultMfdProgram _customMfdProgram;

		private FlightProgramData _flightProgram;

		[SerializeField]
		[DesignerPropertySlider(0.1f, 2.5f, 250, Label = "Height", Order = 2, Tooltip = "Changes the height of the display.")]
		private float _height = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _maxTextureSize = 256;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _maxWidgets = 100;

		[SerializeField]
		[DesignerPropertySpinner(Label = "MFD Program", Order = 3, Tooltip = "The program to run on this MFD.")]
		private string _mfdProgram = "Default";

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _resolution = 256f;

		[SerializeField]
		[DesignerPropertySlider(0.1f, 2.5f, 250, Label = "Width", Order = 1, Tooltip = "Changes the width of the display.")]
		private float _width = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _wattsperm2;

		public static List<DefaultMfdProgram> DefaultMfdPrograms { get; private set; }

		public float Height => _height;

		public int MaxTextureSize => _maxTextureSize;

		public int MaxWidgets => _maxWidgets;

		public DefaultMfdProgram MfdProgram => DefaultMfdPrograms.Where((DefaultMfdProgram x) => x.Id == _mfdProgram).FirstOrDefault() ?? _customMfdProgram;

		public float Resolution => _resolution;

		public XElement RestoredWidgetsElement { get; set; }

		public float Width => _width;

		public float PowerUsage => _width * _height * _wattsperm2;

		public override long Price => (long)(2500f * Width * Height);

		public override float MassDry => 18f * Width * Width * Height * Height * 0.01f;

		static MfdData()
		{
			DefaultMfdPrograms = new List<DefaultMfdProgram>();
			DefaultMfdPrograms.Add(new DefaultMfdProgram("Default", "Default", "DefaultProgram"));
			DefaultMfdPrograms.Add(new DefaultMfdProgram("Navball", "Navball", "NavBallProgram"));
			DefaultMfdPrograms.Add(new DefaultMfdProgram("Map", "Map", "MapProgram"));
			DefaultMfdPrograms.Add(new DefaultMfdProgram("Basic", "Basic Info", "Basic"));
			_customMfdProgram = new DefaultMfdProgram("Custom", "Custom", string.Empty);
			DefaultMfdPrograms.Add(_customMfdProgram);
		}

		public override XElement GenerateStateXml(bool optimizeXml = true)
		{
			XElement xElement = base.GenerateStateXml(optimizeXml);
			base.Script?.SaveXml(xElement);
			return xElement;
		}

		public void OnModifiersCreated(FlightProgramData data)
		{
			_flightProgram = data;
			UpdateEditFlightProgramButton();
		}

		public override void RestoreFromState(XElement stateElement, bool restoreAll)
		{
			base.RestoreFromState(stateElement, restoreAll);
			if (Game.InFlightScene)
			{
				XElement xElement = stateElement.Element("Widgets");
				if (xElement != null)
				{
					RestoredWidgetsElement = new XElement(xElement);
				}
			}
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			d.OnPartStyleChanged(delegate
			{
				InvokeParametersChangedOnSymmetricPartModifiers();
			});
			d.OnPropertyChanged(() => _width, delegate
			{
				UpdateInDesigner();
			});
			d.OnPropertyChanged(() => _height, delegate
			{
				UpdateInDesigner();
			});
			d.OnValueLabelRequested(() => _width, (float x) => $"{x:n2}m");
			d.OnValueLabelRequested(() => _height, (float x) => $"{x:n2}m");
			d.OnPropertyChanged(() => _mfdProgram, delegate
			{
				UpdateEditFlightProgramButton();
				d.Manager.Flyout.RefreshUI();
			});
			d.OnSpinnerValuesRequested(() => _mfdProgram, delegate(List<string> list)
			{
				list.AddRange((from x in DefaultMfdPrograms
					where !x.Hidden
					select x.Id).ToList());
			});
			d.OnValueLabelRequested(() => _mfdProgram, (string x) => MfdProgram.Name);
		}

		private void InvokeParametersChangedOnSymmetricPartModifiers(bool synchronizePartModifiersFirst = true)
		{
			if (synchronizePartModifiersFirst)
			{
				Symmetry.SynchronizePartModifiers(base.Part.PartScript);
			}
			Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(MfdData modifier)
			{
				modifier.Script.UpdatePartStyle();
			});
		}

		private void UpdateEditFlightProgramButton()
		{
			_flightProgram.HideEditButton = _mfdProgram != "Custom";
		}

		private void UpdateInDesigner()
		{
			Symmetry.SynchronizePartModifiers(base.Part.PartScript);
			Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(MfdData m)
			{
				m.Script.UpdateSize();
			});
			base.Part.PartScript.CraftScript.SetStructureChanged();
		}
	}
}
