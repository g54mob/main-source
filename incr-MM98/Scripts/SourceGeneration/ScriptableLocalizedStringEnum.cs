using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(menuName = "Data/Enum/LocalizedString")]
public class ScriptableLocalizedStringEnum : ScriptablePrimitiveEnum
{
	public List<ScriptableDataEnumEntry<LocalizedString>> entries = new List<ScriptableDataEnumEntry<LocalizedString>>();

	public override string Import => "System;\nusing UnityEngine.Localization";

	public override List<string> Entries => entries.Select((ScriptableDataEnumEntry<LocalizedString> x) => x.key).ToList();

	public override List<IScriptableDataEnumEntry> Data => entries.Cast<IScriptableDataEnumEntry>().ToList();

	public override string Type => "LocalizedString";

	public override object Parse(object value)
	{
		LocalizedString localizedString = (LocalizedString)value;
		return $"new LocalizedString(Guid.Parse(\"{localizedString.TableReference.TableCollectionNameGuid}\"), {localizedString.TableEntryReference.KeyId})";
	}
}
