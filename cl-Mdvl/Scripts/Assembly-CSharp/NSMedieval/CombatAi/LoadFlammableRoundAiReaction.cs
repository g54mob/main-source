using NSMedieval.Manager;

namespace NSMedieval.CombatAi
{
	public class LoadFlammableRoundAiReaction : CombatAiReaction
	{
		public LoadFlammableRoundAiReaction(CombatAiAgent agent)
			: base(agent)
		{
		}

		internal override void Refresh()
		{
			base.Refresh();
			if (!base.CombatAgent.IsNextRoundFlammable() && CombatUtils.CanLoadFlammableRound(base.CombatAgent))
			{
				base.CombatAgent.SetNextRoundFlammable(isNextFlammable: true);
			}
		}
	}
}
