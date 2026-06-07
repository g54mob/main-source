using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Design;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	[DesignerPartModifier("Interstage", PanelOrder = 2000)]
	public class DetacherData : PartModifierData<DetacherScript>
	{
		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _detachOnActivated = true;

		[SerializeField]
		[DesignerPropertySlider(0f, 1f, 33, Label = "Detachment Force", Tooltip = "The percentage of maximum force to apply when detaching.")]
		private float _force = 1f;

		[SerializeField]
		[DesignerPropertySlider(0.25f, 4f, 76, Label = "Size", Order = 15, Tooltip = "Defines the scale of the detacher.", TechTreeIdForMaxValue = "MaxSize.Detacher")]
		private float _scale = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _attachPointIndex;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private string _targetAttachPoints;

		private List<string> _targetAttachPointsList;

		public int AttachPointIndex
		{
			get
			{
				return _attachPointIndex;
			}
			set
			{
				_attachPointIndex = value;
			}
		}

		public bool DetachOnActivated => _detachOnActivated;

		public float Force => _force;

		public override float MassDry
		{
			get
			{
				if (!(base.Part.PartType.Id != "DetacherSide1"))
				{
					if (base.Version != 1)
					{
						return Scale * Scale * 100f * 0.01f;
					}
					return 0.5f;
				}
				return 0f;
			}
		}

		public override long Price => (int)(10000f * Scale * (0.1f + Force));

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

		public override string ScaleCareerID
		{
			get
			{
				if (!(base.Part.PartType.Id == "DetacherSide1"))
				{
					return string.Empty;
				}
				return "MaxSize.Detacher";
			}
		}

		public List<string> TargetAttachPointNames => _targetAttachPointsList ?? (_targetAttachPointsList = _targetAttachPoints.Split(new char[1] { ',' }).ToList());

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			d.OnValueLabelRequested(() => _force, (float x) => Utilities.FormatPercentage(x));
			d.OnVisibilityRequested(() => _scale, (bool x) => base.Part.PartType.Id == "DetacherSide1");
			d.OnValueLabelRequested(() => _scale, (float x) => Utilities.FormatPercentage(x));
			d.OnPropertyChanged(() => _force, delegate
			{
				d.Manager.RefreshUI();
				Symmetry.SynchronizePartModifiers(base.Script.PartScript);
				base.Script.PartScript.CraftScript.SetStructureChanged();
			});
			d.OnPropertyChanged(() => _scale, delegate
			{
				d.Manager.RefreshUI();
				base.Script.UpdateScale(repositionAttachedParts: true);
				Symmetry.SynchronizePartModifiers(base.Script.PartScript);
				base.Script.PartScript.CraftScript.SetStructureChanged();
			});
		}
	}
}
