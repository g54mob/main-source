using System;
using System.Linq;
using JetBrains.Annotations;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class WhoCanUseRoom
	{
		public enum MemberType
		{
			Male = 0,
			Female = 1,
			Staff = 2,
			Patients = 3,
			Doctors = 4,
			Nurses = 5,
			Janitors = 6,
			Assistants = 7
		}

		[Serializable]
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class GroupDefinition
		{
			public MemberType[] Members;
		}

		[Serializable]
		public class GroupMembers
		{
			public bool[] Members;
		}

		private GroupDefinition[] _groupDefinition;

		private GroupMembers[] _groupMembers;

		public GroupDefinition[] Definition => _groupDefinition;

		public WhoCanUseRoom(GroupDefinition[] groupDefinition)
		{
			_groupDefinition = groupDefinition;
			if (_groupDefinition != null)
			{
				_groupMembers = new GroupMembers[groupDefinition.Length];
				for (int i = 0; i < groupDefinition.Length; i++)
				{
					_groupMembers[i] = new GroupMembers
					{
						Members = new bool[groupDefinition[i].Members.Length]
					};
					ArrayUtils.Populate(_groupMembers[i].Members, value: true);
				}
			}
		}

		public bool IsMember(int groupIndex, int memberIndex)
		{
			if (_groupDefinition != null)
			{
				return _groupMembers[groupIndex].Members[memberIndex];
			}
			return true;
		}

		public MemberType GetMember(int groupIndex, int memberIndex)
		{
			if (_groupDefinition != null)
			{
				return _groupDefinition[groupIndex].Members[memberIndex];
			}
			return MemberType.Male;
		}

		public bool IsMember(Character character)
		{
			bool flag = true;
			if (_groupDefinition != null)
			{
				Staff staff = character as Staff;
				Patient patient = character as Patient;
				for (int i = 0; i < _groupMembers.Length; i++)
				{
					bool flag2 = false;
					GroupDefinition groupDefinition = _groupDefinition[i];
					GroupMembers groupMembers = _groupMembers[i];
					for (int j = 0; j < groupDefinition.Members.Length; j++)
					{
						if (flag2)
						{
							break;
						}
						if (groupMembers.Members[j])
						{
							flag2 = groupDefinition.Members[j] switch
							{
								MemberType.Male => character.Gender == Character.Sex.Male, 
								MemberType.Female => character.Gender == Character.Sex.Female, 
								MemberType.Staff => staff != null, 
								MemberType.Patients => patient != null, 
								MemberType.Doctors => staff != null && staff.Definition._type == StaffDefinition.Type.Doctor, 
								MemberType.Nurses => staff != null && staff.Definition._type == StaffDefinition.Type.Nurse, 
								MemberType.Janitors => staff != null && staff.Definition._type == StaffDefinition.Type.Janitor, 
								MemberType.Assistants => staff != null && staff.Definition._type == StaffDefinition.Type.Assistant, 
								_ => throw new ArgumentOutOfRangeException(), 
							};
						}
					}
					flag = flag && flag2;
				}
			}
			return flag;
		}

		public bool ToggleMember(int groupIndex, int memberIndex)
		{
			if (_groupDefinition != null)
			{
				GroupMembers groupMembers = _groupMembers[groupIndex];
				bool flag = groupMembers.Members[memberIndex];
				flag = !flag;
				groupMembers.Members[memberIndex] = flag;
				if (groupMembers.Members.Any((bool member) => member))
				{
					return flag;
				}
				groupMembers.Members[memberIndex] = true;
				return true;
			}
			return false;
		}
	}
}
