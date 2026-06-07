using System.Collections.Generic;

namespace LVA.Limbs.Variants
{
	public abstract class HumanLimb : Limb<vi>
	{
		protected sealed override List<wv> gso()
		{
			return null;
		}

		protected virtual List<wv> hla()
		{
			return null;
		}
	}
}
