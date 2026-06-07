using DV.JObjectExtstensions;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.ServicePenalty
{
	public class InsuranceFeeQuota
	{
		private const string INSURANCE_PAID_SO_FAR_KEY = "paid";

		private float _quota;

		public bool InsuranceUsed { get; set; } = true;

		public float Quota
		{
			get
			{
				return _quota;
			}
			set
			{
				_quota = Mathf.Min(value, Globals.G.GameParams.InsuranceFeeQuotaMax);
			}
		}

		public bool QuotaReached => PaidSoFar >= Quota;

		public float PaidSoFar { get; private set; }

		public float LeftToReachQuota => Quota - PaidSoFar;

		public InsuranceFeeQuota(float quota)
		{
			Quota = quota;
		}

		public void PayInsuranceAmount(float amount)
		{
			PaidSoFar = Mathf.RoundToInt(Mathf.Clamp(PaidSoFar + amount, 0f, Quota));
		}

		public void ClearPaidQuota()
		{
			PaidSoFar = 0f;
		}

		public float GetPaidPercentage()
		{
			if (Quota == 0f)
			{
				return 0f;
			}
			return PaidSoFar / Quota;
		}

		public JObject GetSaveData()
		{
			JObject jObject = new JObject();
			jObject.SetFloat("paid", PaidSoFar);
			return jObject;
		}

		public void LoadSaveData(JObject insuranceData)
		{
			float? num = insuranceData.GetFloat("paid");
			if (num.HasValue)
			{
				if (num.Value > Quota)
				{
					Debug.LogError(string.Format("Data not loaded correctly, {0}({1}) is bigger than {2}({3}). Will treat it like {4} is reached.", "loadedPaidSoFar", num, "Quota", Quota, "Quota"));
				}
				PaidSoFar = Mathf.Clamp(num.Value, 0f, Quota);
			}
			else
			{
				Debug.LogError("Bad data: There is no INSURANCE_PAID_SO_FAR_KEY: paid in given insuranceData");
			}
		}
	}
}
