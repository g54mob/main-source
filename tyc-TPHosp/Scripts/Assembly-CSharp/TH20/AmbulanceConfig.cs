using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AmbulanceConfig
	{
		public struct StaffRequirement
		{
			public StaffRequired StaffType;

			public int CountRequired;
		}

		public enum Type
		{
			All = 0,
			Road = 1,
			Air = 2
		}

		public enum UniqueAmbulanceID
		{
			Clown = 0,
			Colin = 1,
			Monster = 2,
			Toilet = 3,
			Duck = 4,
			Davinci = 5,
			NUM_AMBULANCE_TYPES = 6
		}

		public LocalisedString AmbulanceName;

		public Type AmbulanceType;

		public LocalisedString AmbulanceDescription;

		public LocalisedString AmbulanceFunction;

		public float Speed;

		public float InGameSpeed = 0.8f;

		public float MaxInGameSpeed = 5.5f;

		public Vector3 DriveInLocation = new Vector3(0f, 15.86f, -3f);

		public Vector3 DriveOutDirection = new Vector3(-1f, 0.5f, 0f);

		public StaffRequirement[] StaffRequirements;

		public int PatientCapacity;

		public int DiagnosisBonus;

		public Sprite UISprite;

		public Sprite UIOutlineSprite;

		public Sprite UISelectionSprite;

		public float UISpriteSize = 75f;

		public AnimationCurve OutroAcceleration;

		public AnimationCurve IntroAcceleration;

		public RuntimeAnimatorController[] BoardAnimGraph = new RuntimeAnimatorController[2];

		public RuntimeAnimatorController[] DisembarkAnimGraph = new RuntimeAnimatorController[2];

		public float MilesPerBreakdown;

		public UniqueAmbulanceID UniqueAmbulance;

		public int FurtherDiagnosisChoiceCount = 3;
	}
}
