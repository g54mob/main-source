using UnityEngine.Serialization;

namespace Gh.Tk
{
	public class EntertainerData : ActorData
	{
		public int Tier { get; set; }

		public string TemplateId { get; set; }

		public string PrefabName { get; set; }

		[field: FormerlySerializedAs("Title")]
		public string TitleKey { get; set; }

		public override string GetFullNameKey()
		{
			return null;
		}
	}
}
