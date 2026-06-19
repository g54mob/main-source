using ModIO.Util;

namespace ModIOBrowser
{
	internal struct Tag
	{
		public string category;

		public string name;

		public string CategoryTranslated => SelfInstancingMonoSingleton<TranslationManager>.Instance.Get(category);

		public string NameTranslated => SelfInstancingMonoSingleton<TranslationManager>.Instance.Get(name);

		public Tag(string category, string name)
		{
			this.category = category;
			this.name = name;
		}

		public override string ToString()
		{
			return category + ": " + name;
		}

		public override bool Equals(object obj)
		{
			if (obj is Tag tag)
			{
				if (tag.category == category)
				{
					return tag.name == name;
				}
				return false;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (name + category).GetHashCode();
		}
	}
}
