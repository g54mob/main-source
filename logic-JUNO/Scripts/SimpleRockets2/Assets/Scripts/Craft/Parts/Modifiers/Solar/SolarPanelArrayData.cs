using System;
using Assets.Scripts.Design;
using Jundroo.ModTools.Serialization.Xml;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using ModApi.Math;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Solar
{
	[Serializable]
	[DesignerPartModifier("Solar Panel Array", PanelOrder = 2000)]
	public class SolarPanelArrayData : PartModifierData<SolarPanelArrayScript>
	{
		public const float Density = 500f;

		[SerializeField]
		[DesignerPropertySlider(0.5f, 2.5f, 21, Label = "Deploy Speed", Order = 10, Tooltip = "The speed at which the solar panels will extend and retract.")]
		private float _deploySpeed = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _efficiency = 0.46f;

		[SerializeField]
		[DesignerPropertySlider(-20f, 20f, 21, Label = "Folds Angle", Order = 9, Tooltip = "Adds some detail to the panels by not fully stretching them. Too much fold can result in the panels clipping when extending.")]
		private float _folds;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Hide Base", Order = 12, Tooltip = "Toggles the solar panel array cover on/off.")]
		private bool _hideBase;

		[SerializeField]
		[DesignerPropertyToggleButton(Order = 98, Tooltip = "If enabled, the panel will be rotated 180.")]
		private bool _invert;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Invert on Mirror", Order = 99, Tooltip = "If enabled, then the Invert setting will be flipped when the part is mirrored to the other side.")]
		private bool _invertOnMirror;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "ESA Hinge", Order = 13, Tooltip = "Whether the solar panel has a first hinge similar to the one in the JUICE mission by ESA.")]
		private bool _juicyBase;

		[SerializeField]
		[DesignerPropertySlider(0.5f, 2f, 7, Label = "Array Length", Order = 2, Tooltip = "The length of the solar panel array, stretching it along the length of the panels.", TechTreeIdForMaxValue = "SolarPanelArray.Shape")]
		private float _length = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _mainOpenPercentage;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _open;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _openingSideDepth;

		[SerializeField]
		[DesignerPropertySlider(0f, 2f, 21, Label = "Rotate Speed", Order = 11, Tooltip = "The speed at which the solar panels track the sun.")]
		private float _rotateSpeed = 1f;

		[SerializeField]
		[DesignerPropertySlider(1f, 10f, 10, Label = "Rows", Order = 5, Tooltip = "The number of rows of panels.", TechTreeIdForMaxValue = "SolarPanelArray.Rows")]
		private int _rows = 3;

		[SerializeField]
		[DesignerPropertySlider(1f, 7f, 7, Label = "Row Size", Order = 6, Tooltip = "The number of panels in each row.", TechTreeIdForMaxValue = "SolarPanelArray.Columns")]
		private int _rowSize = 3;

		[SerializeField]
		[PartModifierProperty(true, false, SerializationOptions = XmlSerializationFlags.SingleAttribute)]
		private int[] _rowSizeOverride = new int[1] { -1 };

		[SerializeField]
		[DesignerPropertySlider(0.25f, 4f, 76, Label = "Size", Order = 1, Tooltip = "The overall size of the solar panel array.", TechTreeIdForMaxValue = "MaxSize.SolarPanelArray")]
		private float _scale = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _sideOpenPercentage;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Start Open", Order = 20, Tooltip = "Determines if the solar panel array should start out open or closed.")]
		private bool _startOpen;

		public float DeploySpeed
		{
			get
			{
				return _deploySpeed;
			}
			set
			{
				_deploySpeed = value;
			}
		}

		public float Efficiency
		{
			get
			{
				if (!Game.InDesignerScene)
				{
					return _efficiency * Mathf.Max(0f, (0.015f - 2.5E-05f * base.Part.PartScript.Temperature) * base.Part.PartScript.Temperature - 1.25f);
				}
				return _efficiency;
			}
		}

		public float Folds => _folds;

		public bool HideBase => _hideBase;

		public bool Invert
		{
			get
			{
				return _invert;
			}
			set
			{
				_invert = value;
			}
		}

		public bool InvertOnMirror => _invertOnMirror;

		public bool Juicy => _juicyBase;

		public float Length
		{
			get
			{
				return _length;
			}
			set
			{
				_length = value;
			}
		}

		public float MainOpenPercentage
		{
			get
			{
				return _mainOpenPercentage;
			}
			set
			{
				_mainOpenPercentage = value;
			}
		}

		public override float MassDry => (CalculateBaseVolume() * 250f + CalculateTotalPanelVolume() * 500f) * 0.01f;

		public bool Open
		{
			get
			{
				return _open;
			}
			set
			{
				_open = value;
			}
		}

		public int OpeningSideDepth
		{
			get
			{
				return _openingSideDepth;
			}
			set
			{
				_openingSideDepth = value;
			}
		}

		public override long Price => (long)((HideBase ? 0f : (10000f * _scale)) + 500000f * _efficiency * _efficiency * _efficiency * CalculateTotalPanelArea());

		public float RotateSpeed => _rotateSpeed;

		public int Rows
		{
			get
			{
				return _rows;
			}
			set
			{
				_rows = value;
			}
		}

		public int RowSize
		{
			get
			{
				return _rowSize;
			}
			set
			{
				_rowSize = value;
			}
		}

		public int[] RowSizeOverride => _rowSizeOverride;

		public override float Scale
		{
			get
			{
				return _scale;
			}
			set
			{
				_scale = value;
			}
		}

		public override string ScaleCareerID => "MaxSize.SolarPanelArray";

		public float SideOpenPercentage
		{
			get
			{
				return _sideOpenPercentage;
			}
			set
			{
				_sideOpenPercentage = value;
			}
		}

		public bool StartOpen
		{
			get
			{
				return _startOpen;
			}
			set
			{
				_startOpen = value;
			}
		}

		public float CalculateBaseVolume()
		{
			float num = 1f * _scale;
			float num2 = 1f * _scale;
			return 0.2f * num * num2;
		}

		public float CalculateSinglePanelArea()
		{
			float num = 0.8f * _scale * _length;
			float num2 = 0.65f * _scale;
			return num * num2;
		}

		public float CalculateSinglePanelVolume()
		{
			float num = 0.8f * _scale * _length;
			float num2 = 0.65f * _scale;
			return 0.0175f * num * num2;
		}

		public float CalculateTotalPanelArea()
		{
			return CalculateSinglePanelArea() * (float)RowSize * (float)(Juicy ? (Rows - 1) : Rows);
		}

		public float CalculateTotalPanelVolume()
		{
			return CalculateSinglePanelVolume() * (float)RowSize * (float)(Juicy ? (Rows - 1) : Rows);
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			d.OnPartStyleChanged(delegate
			{
				UpdateSymmetricParts();
			});
			d.OnPropertyChanged(() => _invert, delegate
			{
				UpdateSymmetricParts();
			});
			d.OnPropertyChanged(() => _invertOnMirror, delegate
			{
				UpdateSymmetricParts();
			});
			d.OnPropertyChanged(() => _length, delegate
			{
				UpdateSymmetricParts();
			});
			d.OnPropertyChanged(() => _hideBase, delegate
			{
				UpdateSymmetricParts();
			});
			d.OnPropertyChanged(() => _juicyBase, delegate
			{
				UpdateSymmetricParts();
			});
			d.OnPropertyChanged(() => _folds, delegate
			{
				UpdateSymmetricParts();
			});
			d.OnPropertyChanged(() => _rows, delegate
			{
				UpdateSymmetricParts();
			});
			d.OnPropertyChanged(() => _rowSize, delegate
			{
				UpdateSymmetricParts();
			});
			d.OnPropertyChanged(() => _scale, delegate
			{
				UpdateSymmetricParts();
			});
			d.OnPropertyChanged(() => _startOpen, delegate(bool newVal, bool oldVal)
			{
				SetStartOpen(newVal);
			});
			d.OnValueLabelRequested(() => _folds, (float x) => Units.GetAngleString(x, 0));
			d.OnValueLabelRequested(() => _scale, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _length, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _deploySpeed, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _rotateSpeed, (float x) => Utilities.FormatPercentage(x));
			d.OnActivated(delegate
			{
				Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(SolarPanelArrayData x)
				{
					x.Script.DisplayPanels();
				});
				base.Script.PartScript.CraftScript.SetStructureChanged();
			});
			d.OnDeactivated(delegate
			{
				if (!base.Part.IsDestroyed)
				{
					Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(SolarPanelArrayData x)
					{
						x.Script.DisplayPanels(_startOpen);
					});
					base.Script.PartScript.CraftScript.SetStructureChanged();
				}
			});
		}

		private void SetStartOpen(bool startOpen = true)
		{
			Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(SolarPanelArrayData y)
			{
				if (startOpen || _hideBase)
				{
					y.Script.DisplayPanels();
				}
				y._open = startOpen;
				y._mainOpenPercentage = (startOpen ? 1f : 0f);
				y._sideOpenPercentage = (startOpen ? 1f : 0f);
				y._openingSideDepth = (startOpen ? Mathf.Max(0, (y._rowSize - 1) / 2) : 0);
			});
		}

		private void UpdateSymmetricParts()
		{
			Symmetry.SynchronizePartModifiers(base.Part.PartScript);
			Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, this, delegate(SolarPanelArrayData t, SolarPanelArrayData s)
			{
				t.Part.Styles[1].TextureStyle = t.Part.Styles[2].TextureStyle;
				t._efficiency = t.Part.Styles[2].Style.GetData("Efficiency", 1f);
				t.Script.UpdateScale();
				t.Script.UpdatePanelCount();
			});
			base.Script.PartScript.CraftScript.SetStructureChanged();
		}
	}
}
