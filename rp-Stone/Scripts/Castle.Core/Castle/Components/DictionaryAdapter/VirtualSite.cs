using System;
using System.Collections.Generic;
using Castle.Core;

namespace Castle.Components.DictionaryAdapter
{
	public sealed class VirtualSite<TNode, TMember> : IVirtualSite<TNode>, IEquatable<VirtualSite<TNode, TMember>>
	{
		private readonly IVirtualTarget<TNode, TMember> target;

		private readonly TMember member;

		private static readonly IEqualityComparer<IVirtualTarget<TNode, TMember>> TargetComparer = ReferenceEqualityComparer<IVirtualTarget<TNode, TMember>>.Instance;

		private static readonly IEqualityComparer<TMember> MemberComparer = EqualityComparer<TMember>.Default;

		public IVirtualTarget<TNode, TMember> Target => target;

		public TMember Member => member;

		public VirtualSite(IVirtualTarget<TNode, TMember> target, TMember member)
		{
			this.target = target;
			this.member = member;
		}

		public void OnRealizing(TNode node)
		{
			target.OnRealizing(node, member);
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as VirtualSite<TNode, TMember>);
		}

		public bool Equals(VirtualSite<TNode, TMember> other)
		{
			if (other != null && TargetComparer.Equals(target, other.target))
			{
				return MemberComparer.Equals(member, other.member);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return 1928399421 + 37 * TargetComparer.GetHashCode(target) + 37 * MemberComparer.GetHashCode(member);
		}
	}
}
