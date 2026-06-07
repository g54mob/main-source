using Sirenix.OdinInspector;

namespace VampireSurvivors
{
	public class EnableableGroupAttribute : PropertyGroupAttribute
	{
		public bool EnableBool { get; }

		public bool UseFoldout { get; }

		public bool HideWhenDisabled { get; }

		public EnableableGroupAttribute(string groupId, float order, bool enableBool = false, bool useFoldout = false, bool hideWhenDisabled = false)
			: base(null, 0f)
		{
		}

		public EnableableGroupAttribute(string groupId, bool enableBool = false, bool useFoldout = false, bool hideWhenDisabled = false)
			: base(null, 0f)
		{
		}
	}
}
