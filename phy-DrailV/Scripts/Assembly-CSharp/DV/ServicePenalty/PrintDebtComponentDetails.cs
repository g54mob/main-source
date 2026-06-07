using DV.ThingTypes;

namespace DV.ServicePenalty
{
	public class PrintDebtComponentDetails
	{
		public readonly ResourceType type;

		public readonly float beforeSnapshotAmount;

		public readonly float afterSnapshotAmount;

		public readonly float totalAmount;

		public readonly float pricePerUnit;

		public readonly float totalPrice;

		public PrintDebtComponentDetails(DebtComponent debtComponent, float pricePerUnit, float totalPrice)
		{
			type = debtComponent.Type;
			beforeSnapshotAmount = (debtComponent.HasSnapshot ? debtComponent.StartToSnapshotDiff : debtComponent.StartToEndDiff);
			afterSnapshotAmount = (debtComponent.HasSnapshot ? debtComponent.SnapshotToEndDiff : 0f);
			totalAmount = debtComponent.StartToEndDiff;
			this.pricePerUnit = pricePerUnit;
			this.totalPrice = totalPrice;
		}
	}
}
