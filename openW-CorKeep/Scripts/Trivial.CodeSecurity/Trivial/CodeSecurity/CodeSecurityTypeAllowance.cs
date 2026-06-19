using System;
using System.Collections.Generic;
using System.Reflection;
using Trivial.Mono.Cecil;
using UnityEngine;

namespace Trivial.CodeSecurity
{
	[Serializable]
	public class CodeSecurityTypeAllowance
	{
		[SerializeField]
		[HideInInspector]
		private string typeName = "";

		[SerializeField]
		[HideInInspector]
		private List<int> allowedMemberHashes = new List<int>();

		[SerializeField]
		[HideInInspector]
		private bool allowAllMembers = true;

		public string TypeName => typeName;

		public IEnumerable<int> AllowedMemberHashes => allowedMemberHashes;

		public bool AllowAllMembers
		{
			get
			{
				return allowAllMembers;
			}
			set
			{
				allowAllMembers = value;
			}
		}

		public CodeSecurityTypeAllowance()
		{
		}

		public CodeSecurityTypeAllowance(string typeName)
		{
			this.typeName = typeName;
		}

		public void AddMemberAllowance(MemberInfo member)
		{
			int memberReferenceHashPersistent = CodeSecurityAllowance.GetMemberReferenceHashPersistent(member.Name);
			if (memberReferenceHashPersistent != -1 && !allowedMemberHashes.Contains(memberReferenceHashPersistent))
			{
				allowedMemberHashes.Add(memberReferenceHashPersistent);
			}
		}

		public void RemoveMemberAllowance(MemberInfo member)
		{
			int memberReferenceHashPersistent = CodeSecurityAllowance.GetMemberReferenceHashPersistent(member.Name);
			if (memberReferenceHashPersistent != -1 && allowedMemberHashes.Contains(memberReferenceHashPersistent))
			{
				allowedMemberHashes.Remove(memberReferenceHashPersistent);
			}
		}

		public bool IsMemberAllowed(MemberReference memberReference)
		{
			if (allowAllMembers)
			{
				return true;
			}
			int memberReferenceHashPersistent = CodeSecurityAllowance.GetMemberReferenceHashPersistent(memberReference.Name);
			return allowedMemberHashes.Contains(memberReferenceHashPersistent);
		}
	}
}
