using NSMedieval.Goap;
using NSMedieval.State;

namespace NSMedieval.Draft
{
	public abstract class DraftOrder
	{
		private DraftOrderType type;

		private HourType requiredHourType;

		public DraftOrderType Type => type;

		public HourType RequiredHourType => requiredHourType;

		protected DraftOrder(DraftOrderType type, HourType requiredHourType = HourType.None)
		{
			this.type = type;
			this.requiredHourType = requiredHourType;
		}

		public virtual bool CheckRequirements(HumanoidInstance instance, DraftOrder lastDraftOrder)
		{
			return true;
		}

		public abstract void Execute(HumanoidInstance instance);

		public virtual void OnNewOrder(HumanoidInstance instance, DraftOrder newOrder)
		{
		}

		public virtual void OnDraftEnd(HumanoidInstance instance)
		{
		}
	}
}
