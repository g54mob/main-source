using System.Text;
using LitJson;

namespace Gh.Tk
{
	public abstract class GameItemCraftableBaseTemplate : GameItemTemplate, IPatronRatable
	{
		[JsonIgnore]
		private string _category;

		[JsonIgnore]
		public string Category
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int GetTier()
		{
			return 0;
		}

		public virtual (int, string) GetOkPrice(string race, int tier, bool generateReason)
		{
			return default((int, string));
		}

		public virtual float GetEffectiveQuality(string race, int tier, StringBuilder details = null)
		{
			return 0f;
		}

		public virtual float GetExpectedQuality(string race, int tier)
		{
			return 0f;
		}

		public override bool ShouldBeSealed()
		{
			return false;
		}
	}
}
