using System.Text;
using LitJson;

namespace Gh.Tk
{
	public class Loan : IPersistable, IReferenceableObject
	{
		public int amount;

		public int minTavernTier;

		public int amountRemaining;

		public int length;

		public int interestRate;

		public float expiryDate;

		private float playerAcceptedTimestamp;

		public int Id { get; private set; }

		[JsonIgnore]
		public bool hasPlayerAccepted => false;

		public bool IsExpired()
		{
			return false;
		}

		public bool IsAvailableToPlayer()
		{
			return false;
		}

		public void TakeLoan()
		{
		}

		public int GetEffectiveInterestRate()
		{
			return 0;
		}

		public int GetTotalCost()
		{
			return 0;
		}

		public int GetDaysRemaining()
		{
			return 0;
		}

		public int GetCostPerDay()
		{
			return 0;
		}

		public int GetNextInstallmentAmount()
		{
			return 0;
		}

		public void ProcessInstallmentPayment()
		{
		}

		public int GetEarlyPaybackCost(StringBuilder detail = null)
		{
			return 0;
		}

		public bool CanPaybackEarly()
		{
			return false;
		}

		public void PaybackEarly()
		{
		}
	}
}
