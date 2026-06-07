using System.Collections.Generic;
using System.Linq;

public abstract class ScriptableAssetEnum : ScriptableBaseEnum
{
	public abstract List<IScriptableDataEnumEntry> Data { get; }

	public abstract string Type { get; }
}
public abstract class ScriptableAssetEnum<T> : ScriptableAssetEnum
{
	public List<ScriptableDataEnumEntry<T>> entries = new List<ScriptableDataEnumEntry<T>>();

	public override List<string> Entries => entries.Select((ScriptableDataEnumEntry<T> x) => x.key).ToList();

	public override List<IScriptableDataEnumEntry> Data => entries.Cast<IScriptableDataEnumEntry>().ToList();

	public override string Type => typeof(T).Name;
}
