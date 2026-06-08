using System.Runtime.InteropServices;
using Unity.Entities;

namespace Kitchen
{
	public class GroupUsePatienceReset : InteractionSystem
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct CPatienceResetUsed : IComponentData
		{
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct CGivePatienceReset : IComponentData
		{
		}

		private COccupiedByGroup Group;

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Require<CPartOfTableSet>(data.Target, out CPartOfTableSet comp))
			{
				return false;
			}
			if (!Has<CTableSet>(comp))
			{
				return false;
			}
			if (!Require<COccupiedByGroup>((Entity)comp, out Group))
			{
				return false;
			}
			if (!Require<CCustomerSettings>((Entity)Group, out CCustomerSettings comp2))
			{
				return false;
			}
			if (!Has<CGroupAwaitingOrder>(Group))
			{
				return false;
			}
			if (Has<CPatienceResetUsed>(Group))
			{
				return false;
			}
			if (!comp2.Patience.ResetPatienceOption)
			{
				return false;
			}
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
			data.Context.Add<CPatienceResetUsed>(Group);
			data.Context.Add<CGivePatienceReset>(Group);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
