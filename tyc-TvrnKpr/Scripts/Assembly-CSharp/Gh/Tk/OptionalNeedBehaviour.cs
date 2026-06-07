using UnityEngine.Scripting;

namespace Gh.Tk
{
	[Preserve]
	public class OptionalNeedBehaviour : PatronBehaviour, IAiComponentVisualInfo, IAiComponentIsDoneInfo
	{
		[PersistenceOptIn]
		private bool _isDone;

		private string ToolTipName => null;

		private string IconSuffix => null;

		public OptionalNeedBehaviour()
		{
		}

		public OptionalNeedBehaviour(Patron owner)
		{
		}

		public override bool IsOptionalBehaviour()
		{
			return false;
		}

		protected override bool TriggerInternal()
		{
			return false;
		}

		public override TooltipData GetTooltipData()
		{
			return null;
		}

		public override string GetTraitBadgeIconPrefabName()
		{
			return null;
		}
	}
}
