using System.Collections;

namespace Castle.Components.DictionaryAdapter
{
	public class CascadingDictionaryAdapter : AbstractDictionaryAdapter
	{
		private readonly IDictionary primary;

		private readonly IDictionary secondary;

		public IDictionary Primary => primary;

		public IDictionary Secondary => secondary;

		public override bool IsReadOnly => primary.IsReadOnly;

		public override object this[object key]
		{
			get
			{
				return primary[key] ?? secondary[key];
			}
			set
			{
				primary[key] = value;
			}
		}

		public CascadingDictionaryAdapter(IDictionary primary, IDictionary secondary)
		{
			this.primary = primary;
			this.secondary = secondary;
		}

		public override bool Contains(object key)
		{
			if (!primary.Contains(key))
			{
				return secondary.Contains(key);
			}
			return true;
		}
	}
}
