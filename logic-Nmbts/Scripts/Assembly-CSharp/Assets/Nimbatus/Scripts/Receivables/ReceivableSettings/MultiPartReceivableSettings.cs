using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;

namespace Assets.Nimbatus.Scripts.Receivables.ReceivableSettings
{
	public class MultiPartReceivableSettings : BaseReceivableSettings
	{
		public EMultiPartType MultiPartType;

		public List<DronePart> DroneParts = new List<DronePart>();

		public TranslationTerm Title;

		public override BaseReceivable CreateReceivable(int seed, int amount)
		{
			return new MultiPartReceivable
			{
				MultiPartType = MultiPartType,
				DroneParts = DroneParts.Select((DronePart p) => p.UniqueId).ToList(),
				Amount = amount,
				Title = Title
			};
		}
	}
}
