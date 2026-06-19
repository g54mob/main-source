using BehaviorDesigner.Runtime;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffRequired
	{
		[SerializeField]
		private SharedInstance<StaffDefinition> Type;

		[SerializeField]
		private SharedInstance<QualificationDefinition> Qualification;

		[SerializeField]
		private ExternalBehavior _behaviour;

		[SerializeField]
		private SharedInstance<StaffDefinition> AlternativeType;

		public StaffDefinition Definition => Type.Instance;

		public StaffDefinition AlternativeDefinition
		{
			get
			{
				if (!(AlternativeType != null))
				{
					return null;
				}
				return AlternativeType.Instance;
			}
		}

		public QualificationDefinition QualificationInstance
		{
			get
			{
				if (!(Qualification != null))
				{
					return null;
				}
				return Qualification.Instance;
			}
		}

		public ExternalBehavior Behaviour => _behaviour;

		public bool Equals(StaffRequired other)
		{
			if (Type != other.Type && AlternativeType != other.AlternativeType)
			{
				return false;
			}
			if (Qualification != other.Qualification)
			{
				return false;
			}
			if (Behaviour != other.Behaviour)
			{
				return false;
			}
			return true;
		}

		public override string ToString()
		{
			if (QualificationInstance == null)
			{
				return GameStringUtils.GetStaffTypeTextLoc(Type.Instance._type);
			}
			return $"{Type.Instance._type} : {QualificationInstance}";
		}

		public bool IsSuitable(Staff staff)
		{
			if (staff != null && (staff.Definition == Type.Instance || (AlternativeType != null && staff.Definition == AlternativeType.Instance) || (Type.Instance._type == StaffDefinition.Type.Janitor && staff.GetComponent<RoboJanitorComponent>() != null)) && (QualificationInstance == null || staff.HasCompletedQualification(QualificationInstance)))
			{
				return true;
			}
			return false;
		}
	}
}
