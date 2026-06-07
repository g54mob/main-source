using System;
using Assets.Scripts.Design;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	[DesignerPartModifier("Fuel Cross Feed", PanelOrder = 2000)]
	public class CrossFeedData : PartModifierData<CrossFeedScript>
	{
		public enum CrossFeedMode
		{
			Disabled = 0,
			Normal = 1,
			Reversed = 2,
			Equalize = 3
		}

		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _attachPointA;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _attachPointB;

		[SerializeField]
		[DesignerPropertySpinner(Label = "Fuel Transfer Mode", Order = 0, Tooltip = "Allows for automatic transfer of fuel between the connected fuel tanks.")]
		private CrossFeedMode _mode;

		public int AttachPointA => _attachPointA;

		public int AttachPointB => _attachPointB;

		public CrossFeedMode Mode
		{
			get
			{
				return _mode;
			}
			set
			{
				_mode = value;
			}
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			if (_attachPointA >= base.Part.AttachPoints.Count || _attachPointB >= base.Part.AttachPoints.Count)
			{
				Debug.LogError("Cross Feed has attach point that is out of range");
			}
			d.OnPropertyChanged(() => _mode, delegate
			{
				OnPropertyChangedInDesigner();
			});
		}

		private void OnPropertyChangedInDesigner()
		{
			Symmetry.SynchronizePartModifiers(base.Part.PartScript);
			base.Part.PartScript.CraftScript.SetStructureChanged();
		}
	}
}
