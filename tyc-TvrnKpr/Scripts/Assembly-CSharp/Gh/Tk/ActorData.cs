using System.Collections.Generic;
using UnityEngine.Serialization;

namespace Gh.Tk
{
	public abstract class ActorData : IPersistable, IReferenceableObject
	{
		public int Id { get; private set; }

		public string ActorType { get; set; }

		[field: FormerlySerializedAs("Name")]
		public string NameKey { get; set; }

		public string CustomNameKey { get; set; }

		public string Gender { get; set; }

		public string Race { get; set; }

		public string PrefabVariant { get; set; }

		public List<string> Traits { get; set; }

		public List<string> ConversationThemes { get; set; }

		public CharacterColors Colors { get; set; }

		public ActorData()
		{
		}

		public virtual string GetFullNameKey()
		{
			return null;
		}

		public string GetNameKey()
		{
			return null;
		}

		public bool IsFemale()
		{
			return false;
		}

		public bool MatchesConversationTheme(string theme)
		{
			return false;
		}
	}
}
