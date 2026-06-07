using System;

namespace Gh.Tk
{
	public abstract class MentalBreakTraitBase : ActorTrait
	{
		private static Type[] _mentalBreakTraits;

		protected MentalBreakTraitBase()
		{
		}

		protected MentalBreakTraitBase(Actor owner)
		{
		}

		public virtual bool IsCatharsisActive()
		{
			return false;
		}

		public void Trigger()
		{
		}

		protected abstract void TriggerInternal();

		public static (Type, float)[] GetAllMentalBreakTraitCandidates(Actor actor)
		{
			return null;
		}
	}
}
