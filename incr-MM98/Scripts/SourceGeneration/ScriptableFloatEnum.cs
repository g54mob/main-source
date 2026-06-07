using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enum/Float")]
public class ScriptableFloatEnum : ScriptablePrimitiveEnum
{
	public List<ScriptableDataEnumEntry<float>> entries = new List<ScriptableDataEnumEntry<float>>();

	public override List<string> Entries => entries.Select((ScriptableDataEnumEntry<float> x) => x.key).ToList();

	public override List<IScriptableDataEnumEntry> Data => entries.Cast<IScriptableDataEnumEntry>().ToList();

	public override string Type => "float";
}
