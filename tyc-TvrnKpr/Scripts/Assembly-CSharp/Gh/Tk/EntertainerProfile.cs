using System.Text;
using LitJson;
using UnityEngine.Serialization;

namespace Gh.Tk
{
	public class EntertainerProfile : IPersistable, IPatronRatable
	{
		public string id;

		[FormerlySerializedAs("name")]
		public string nameKey;

		public int costOverride;

		public int playtime;

		public int tier;

		public EntertainerData entertainerData;

		[JsonIgnore]
		private TooltipData _tooltipData;

		[JsonIgnore]
		public string FullNameKey => null;

		[JsonIgnore]
		public int Cost => 0;

		[JsonIgnore]
		public int Stars => 0;

		[JsonIgnore]
		public string Category => null;

		public TooltipData GetTooltipData()
		{
			return null;
		}

		public int GetPrice()
		{
			return 0;
		}

		public (int, string) GetOkPrice(string race, int tier, bool generateReason)
		{
			return default((int, string));
		}

		public float GetEffectiveQuality(string race, int tier, StringBuilder details = null)
		{
			return 0f;
		}

		public float GetExpectedQuality(string race, int tier)
		{
			return 0f;
		}

		public int GetTier()
		{
			return 0;
		}
	}
}
