using Sirenix.OdinInspector;

namespace VampireSurvivors;

public class EnableableGroupAttribute : PropertyGroupAttribute
{
	private readonly bool _003CEnableBool_003Ek__BackingField;

	private readonly bool _003CUseFoldout_003Ek__BackingField;

	private readonly bool _003CHideWhenDisabled_003Ek__BackingField;

	public bool EnableBool => _003CEnableBool_003Ek__BackingField;

	public bool UseFoldout => _003CUseFoldout_003Ek__BackingField;

	public bool HideWhenDisabled => _003CHideWhenDisabled_003Ek__BackingField;

	public EnableableGroupAttribute(string groupId, float order, bool enableBool = false, bool useFoldout = false, bool hideWhenDisabled = false)
		: base(groupId, order)
	{
		bool flag = default(bool);
		_003CUseFoldout_003Ek__BackingField = flag;
		_003CEnableBool_003Ek__BackingField = enableBool;
		bool flag2 = default(bool);
		_003CHideWhenDisabled_003Ek__BackingField = flag2;
	}

	public EnableableGroupAttribute(string groupId, bool enableBool = false, bool useFoldout = false, bool hideWhenDisabled = false)
		: base(groupId, 0f)
	{
		_003CEnableBool_003Ek__BackingField = enableBool;
		_003CUseFoldout_003Ek__BackingField = useFoldout;
		bool flag = default(bool);
		_003CHideWhenDisabled_003Ek__BackingField = flag;
	}
}
