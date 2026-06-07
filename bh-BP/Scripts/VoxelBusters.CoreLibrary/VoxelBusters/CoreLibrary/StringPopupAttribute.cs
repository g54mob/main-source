using UnityEngine;

namespace VoxelBusters.CoreLibrary
{
	[IncludeInDocs]
	public class StringPopupAttribute : PropertyAttribute
	{
		private static readonly string[] s_emptyOptions;

		private readonly string[] m_fixedOptions;

		private readonly bool m_usesFixedOptions;

		public string PreferencePropertyName { get; private set; }

		public bool PreferencePropertyValue { get; private set; }

		public string[] Options => null;

		public StringPopupAttribute(string preferencePropertyName = null, bool preferencePropertyValue = true, params string[] fixedOptions)
		{
		}

		protected virtual string[] GetDynamicOptions()
		{
			return null;
		}
	}
}
