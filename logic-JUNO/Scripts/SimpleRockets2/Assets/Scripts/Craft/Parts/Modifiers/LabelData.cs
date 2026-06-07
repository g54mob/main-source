using System;
using Assets.Scripts.Design;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	[DesignerPartModifier("Label")]
	[PartModifierTypeId("Label")]
	public class LabelData : PartModifierData<LabelScript>
	{
		[SerializeField]
		[DesignerPropertySlider(MinValue = 0f, MaxValue = 180f, NumberOfSteps = 181, Label = "Curvature", Order = 49, Tooltip = "This is used to warp the text around fuel tanks.")]
		private float _curvatureAngle;

		[SerializeField]
		[DesignerPropertySpinner(Label = "Curve Direction", Order = 48)]
		private LabelCurvatureDirection _curvatureDirection;

		[SerializeField]
		[DesignerPropertyTextInput(Label = "Text", Order = 10)]
		private string _designText = "Text";

		[SerializeField]
		[DesignerPropertySpinner(new string[] { "Default", "Roboto", "Anita Semi Square", "Future Earth", "Stencil", "Classic 14-Segment", "Modern 14-Segment" }, Label = "Font", Order = 15)]
		private string _fontName = "Default";

		[SerializeField]
		[DesignerPropertySlider(MinValue = 0.1f, MaxValue = 4f, NumberOfSteps = 79, Label = "Font Size", Order = 20)]
		private float _fontSize = 1f;

		[SerializeField]
		[DesignerPropertySpinner(TextFormat = DesignerPropertySpinnerTextFormat.Auto, Label = "Gradient", Order = 45, Tooltip = "The gradient type (if any) to use for the label colors. The colors are defined by the 'Primary' and 'Trim 1' colors.")]
		private LabelPartGradientType _gradient;

		[SerializeField]
		[DesignerPropertySlider(MinValue = 0.1f, MaxValue = 5f, NumberOfSteps = 50, Label = "Height", Order = 60)]
		private float _height = 0.5f;

		[SerializeField]
		[DesignerPropertySpinner(new object[]
		{
			HorizontalAlignmentOptions.Left,
			HorizontalAlignmentOptions.Center,
			HorizontalAlignmentOptions.Right
		}, Label = "Horizontal Anchor", Order = 30)]
		private HorizontalAlignmentOptions _horizontalAlignment = HorizontalAlignmentOptions.Center;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private Vector3 _offset = new Vector3(0f, 0.005f, 0f);

		[SerializeField]
		[DesignerPropertySlider(MinValue = 0f, MaxValue = 0.5f, NumberOfSteps = 51, Label = "Outline Width", Order = 25, Tooltip = "The width of the outline around the text, the color of which is defined by the Trim 2 Material.")]
		private float _outlineWidth;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _paintIndexShift;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private string _parentPath;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private Vector3 _rotation = new Vector3(0f, 180f, 0f);

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _supportsCurvature = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _supportsGradient = true;

		[SerializeField]
		[DesignerPropertySpinner(new object[]
		{
			VerticalAlignmentOptions.Top,
			VerticalAlignmentOptions.Middle,
			VerticalAlignmentOptions.Bottom
		}, Label = "Vertical Anchor", Order = 40)]
		private VerticalAlignmentOptions _verticalAlignment = VerticalAlignmentOptions.Middle;

		[SerializeField]
		[DesignerPropertySlider(MinValue = 0.1f, MaxValue = 5f, NumberOfSteps = 50, Label = "Width", Order = 50)]
		private float _width = 1f;

		public float CurvatureAngle => _curvatureAngle;

		public LabelCurvatureDirection CurvatureDirection => _curvatureDirection;

		public string DesignText => _designText;

		public string FontName => _fontName;

		public float FontSize => _fontSize;

		public LabelPartGradientType Gradient => _gradient;

		public float Height => _height;

		public HorizontalAlignmentOptions HorizontalAlignment => _horizontalAlignment;

		public Vector3 Offset => _offset;

		public string ParentPath => _parentPath;

		public float OutlineWidth => _outlineWidth;

		public int PaintIndexShift => _paintIndexShift;

		public Vector3 Rotation => _rotation;

		public bool SupportsGradient => _supportsGradient;

		public VerticalAlignmentOptions VerticalAlignment => _verticalAlignment;

		public float Width => _width;

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			base.OnDesignerInitialization(d);
			d.OnPropertyChanged(() => _designText, delegate(string newVal, string oldVal)
			{
				Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(LabelData modifier)
				{
					modifier.Script.OnDesignerTextChanged(newVal);
				});
				base.Script.OnDesignerTextChanged(newVal);
			});
			d.OnPropertyChanged(() => _fontName, delegate
			{
				HandleParametersChanged();
			});
			d.OnPropertyChanged(() => _fontSize, delegate
			{
				HandleParametersChanged();
			});
			d.OnPropertyChanged(() => _gradient, delegate
			{
				HandleParametersChanged();
			});
			d.OnPropertyChanged(() => _outlineWidth, delegate
			{
				HandleParametersChanged();
			});
			d.OnPropertyChanged(() => _curvatureAngle, delegate
			{
				HandleParametersChanged();
			});
			d.OnPropertyChanged(() => _curvatureDirection, delegate
			{
				HandleParametersChanged();
			});
			d.OnPropertyChanged(() => _horizontalAlignment, delegate
			{
				HandleParametersChanged();
			});
			d.OnPropertyChanged(() => _verticalAlignment, delegate
			{
				HandleParametersChanged();
			});
			d.OnPropertyChanged(() => _width, delegate
			{
				HandleParametersChanged();
			});
			d.OnPropertyChanged(() => _height, delegate
			{
				HandleParametersChanged();
			});
			d.OnValueLabelRequested(() => _fontSize, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _outlineWidth, (float x) => Utilities.FormatPercentage(x * 2f));
			d.OnVisibilityRequested(() => _curvatureAngle, (bool x) => _supportsCurvature);
			d.OnVisibilityRequested(() => _curvatureDirection, (bool x) => _supportsCurvature);
			d.OnVisibilityRequested(() => _gradient, (bool x) => _supportsGradient);
		}

		private void HandleParametersChanged()
		{
			Symmetry.SynchronizePartModifiers(base.Part.PartScript);
			Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(LabelData modifier)
			{
				modifier.Script.UpdateAlignment((TextAlignmentOptions)((int)modifier._horizontalAlignment + (int)modifier._verticalAlignment));
				modifier.Script.OnCurvatureAngleChanged();
				modifier.Script.UpdateFontSize(modifier._fontSize);
				modifier.Script.OnFontChanged();
			});
		}
	}
}
