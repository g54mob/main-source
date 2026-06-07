using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enum/Int")]
public class ScriptableIntEnum : ScriptablePrimitiveEnum
{
	public List<ScriptableDataEnumEntry<int>> entries = new List<ScriptableDataEnumEntry<int>>();

	public override List<string> Entries => entries.Select((ScriptableDataEnumEntry<int> x) => x.key).ToList();

	public override List<IScriptableDataEnumEntry> Data => entries.Cast<IScriptableDataEnumEntry>().ToList();

	public override string Type => "int";
}
