using System;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	public class TestPilotData : PartModifierData<TestPilotScript>
	{
		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Anchor feet in place", Tooltip = "Anchors the feet down and makes them immobile.")]
		private bool _anchorFeet;

		public bool AnchorFeet
		{
			get
			{
				return _anchorFeet;
			}
			set
			{
				_anchorFeet = value;
				if (Game.InDesignerScene)
				{
					base.DesignerPartProperties.Manager?.RefreshUI();
				}
			}
		}
	}
}
