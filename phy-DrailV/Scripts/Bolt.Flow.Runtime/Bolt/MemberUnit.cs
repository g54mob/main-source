using System;
using System.Collections.Generic;
using Ludiq;
using UnityEngine;

namespace Bolt
{
	[SpecialUnit]
	public abstract class MemberUnit : Unit, IAotStubbable
	{
		[Serialize]
		[MemberFilter(Fields = true, Properties = true, Methods = true, Constructors = true)]
		public Member member { get; set; }

		[DoNotSerialize]
		[PortLabelHidden]
		[NullMeansSelf]
		public ValueInput target { get; private set; }

		public override bool canDefine => member != null;

		IEnumerable<object> IAotStubbable.aotStubs
		{
			get
			{
				if (member != null && member.isReflected)
				{
					yield return member.info;
				}
			}
		}

		protected MemberUnit()
		{
		}

		protected MemberUnit(Member member)
			: this()
		{
			this.member = member;
		}

		protected override void Definition()
		{
			member.EnsureReflected();
			if (!IsMemberValid(member))
			{
				throw new NotSupportedException("The member type is not valid for this unit.");
			}
			if (member.requiresTarget)
			{
				target = ValueInput(member.targetType, "target");
				target.SetDefaultValue(member.targetType.PseudoDefault());
				if (typeof(UnityEngine.Object).IsAssignableFrom(member.targetType))
				{
					target.NullMeansSelf();
				}
			}
		}

		protected abstract bool IsMemberValid(Member member);

		public override void Prewarm()
		{
			if (member != null && member.isReflected)
			{
				member.Prewarm();
			}
		}
	}
}
