using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.Story
{
	[CreateAssetMenu(fileName = "ActorFilter", menuName = "Greenheart Custom/Story/Filters/Actor")]
	public class ActorFilterConfig : BaseActorConfig
	{
		[DropDownChoice(typeof(ActorFilterConfig), "GetTemplateIds")]
		[Tooltip("If this is specified then other filter settings will be ignored.")]
		public string templateId;

		public bool isStaff;

		public bool isHero;

		[Header("Race")]
		public bool allowDwarf;

		public bool allowElf;

		public bool allowHalfling;

		public bool allowHuman;

		public bool allowOrc;

		public int tier;

		public static List<string> GetTemplateIds()
		{
			return null;
		}

		private bool DoesActorMatchConfig(ActorData data)
		{
			return false;
		}

		private ActorData GetMatch()
		{
			return null;
		}

		public override List<ActorData> GetAllMatches()
		{
			return null;
		}
	}
}
