using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

public class LocalizeStringHandlerContext : InitializerContext<LocalizeStringHandler>
{
	public LocalizeStringHandlerContext SetLocalized(LocalizedString localized)
	{
		Target.AssetReference = localized;
		return this;
	}

	public LocalizeStringHandlerContext SetValue<T>(T value)
	{
		return SetValue("value", value);
	}

	public LocalizeStringHandlerContext SetValue<T>(string key, T value)
	{
		if (Target.AssetReference[key] is Variable<T> variable)
		{
			variable.Value = value;
		}
		return this;
	}

	public LocalizeStringHandlerContext SetVariable(string key, IVariable variable)
	{
		Target.AssetReference[key] = variable;
		return this;
	}
}
