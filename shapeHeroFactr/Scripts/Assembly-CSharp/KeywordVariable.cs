using UnityEngine.Localization.SmartFormat.Core.Extensions;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

internal struct KeywordVariable : IVariable
{
	private string m_Keyword;

	public object GetSourceValue(ISelectorInfo _)
	{
		return null;
	}

	public KeywordVariable(string keyword)
	{
		m_Keyword = null;
	}
}
