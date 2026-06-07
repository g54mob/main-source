using System;
using Assets.Scripts.State;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Eva
{
	[Serializable]
	[DesignerPartModifier("Crew Member")]
	[PartModifierTypeId("Eva")]
	public class EvaData : PartModifierData<EvaScript>
	{
		public const string UnassignedName = "Unassigned";

		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _crewId;

		[SerializeField]
		[DesignerPropertyLabel]
		private string _crewName;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _grapplingHookEnabled = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _gDamageScale = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _gTolerance = 7f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _jetpackAvailable = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _jetpackEnabled = true;

		[SerializeField]
		[DesignerPropertySlider(0.1f, 5f, 50, Label = "Jetpack Power", Order = 103)]
		private float _jetpackPowerScalar = 1f;

		[SerializeField]
		[DesignerPropertySlider(0.05f, 1f, 20, Label = "Jump Power", Order = 104)]
		private float _jumpPowerScalar = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _requiresCrewMember = true;

		[DesignerPropertyLabel(Order = 102, PreserveState = false, NeverSerialize = true)]
		private string _separator = "The settings below can also be changed during flight";

		public int CrewId => _crewId;

		public CrewMember CrewMember { get; private set; }

		public string CrewName
		{
			get
			{
				return _crewName;
			}
			private set
			{
				_crewName = value;
			}
		}

		public float GDamageScale => _gDamageScale;

		public bool GrapplingHookEnabled
		{
			get
			{
				return _grapplingHookEnabled;
			}
			set
			{
				_grapplingHookEnabled = value;
			}
		}

		public float GTolerance => _gTolerance;

		public bool IsTourist => base.Part.PartType.Id == "Eva-Tourist";

		public bool JetpackAvailable
		{
			get
			{
				return _jetpackAvailable;
			}
			set
			{
				_jetpackAvailable = value;
			}
		}

		public bool JetpackEnabled
		{
			get
			{
				return _jetpackEnabled;
			}
			set
			{
				_jetpackEnabled = value;
			}
		}

		public float JetpackPowerScalar
		{
			get
			{
				return _jetpackPowerScalar;
			}
			set
			{
				_jetpackPowerScalar = value;
			}
		}

		public float JumpPowerScalar
		{
			get
			{
				return _jumpPowerScalar;
			}
			set
			{
				_jumpPowerScalar = value;
			}
		}

		public bool RequiresCrewMember
		{
			get
			{
				return _requiresCrewMember;
			}
			set
			{
				_requiresCrewMember = value;
			}
		}

		public bool UseAlternateJetpackStyle => CrewMember?.UseAlternateJetpack ?? false;

		public void AssignCrewMember(CrewMember crewMember)
		{
			if (crewMember != null)
			{
				_crewId = crewMember.Id;
				_crewName = crewMember.Name;
			}
			else
			{
				_crewId = 0;
				_crewName = "Unassigned";
			}
			CrewMember = crewMember;
			if (base.Script != null)
			{
				base.Script.OnCrewMemberChanged();
			}
		}

		public override void OnPartRecovered()
		{
			base.OnPartRecovered();
			if (CrewMember != null)
			{
				CrewMember.State = CrewMemberState.Available;
			}
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			base.OnDesignerInitialization(d);
			d.OnPropertyChanged(() => _separator, delegate
			{
			});
			d.OnVisibilityRequested(() => _crewName, (bool x) => !IsTourist);
			d.OnVisibilityRequested(() => _jetpackPowerScalar, (bool x) => !IsTourist);
			d.OnVisibilityRequested(() => _jumpPowerScalar, (bool x) => !IsTourist);
			d.OnVisibilityRequested(() => _separator, (bool x) => !IsTourist);
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			CrewMember = Game.Instance.GameState?.Crew.GetCrewMember(_crewId);
		}
	}
}
