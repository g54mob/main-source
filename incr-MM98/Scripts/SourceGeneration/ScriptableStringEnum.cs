using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enum/String")]
public class ScriptableStringEnum : ScriptablePrimitiveEnum
{
	public List<ScriptableDataEnumEntry<string>> entries = new List<ScriptableDataEnumEntry<string>>();

	public override List<string> Entries => entries.Select((ScriptableDataEnumEntry<string> x) => x.key).ToList();

	public override List<IScriptableDataEnumEntry> Data => entries.Cast<IScriptableDataEnumEntry>().ToList();

	public override string Type => "string";

	public override object Parse(object value)
	{
		return "\n\t\t\t@\"" + value.ToString().Replace("\"", "\"\"") + "\"";
	}
}
