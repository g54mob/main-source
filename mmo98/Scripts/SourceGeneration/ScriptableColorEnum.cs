using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enum/Color")]
public class ScriptableColorEnum : ScriptablePrimitiveEnum
{
	public List<ScriptableDataEnumEntry<Color>> entries = new List<ScriptableDataEnumEntry<Color>>();

	public override List<string> Entries => entries.Select((ScriptableDataEnumEntry<Color> x) => x.key).ToList();

	public override List<IScriptableDataEnumEntry> Data => entries.Cast<IScriptableDataEnumEntry>().ToList();

	public override string Type => "Color";

	public override object Parse(object value)
	{
		Color color = (Color)value;
		return "new Color(" + color.r.ToString(CultureInfo.InvariantCulture) + "f, " + color.g.ToString(CultureInfo.InvariantCulture) + "f, " + color.b.ToString(CultureInfo.InvariantCulture) + "f, " + color.a.ToString(CultureInfo.InvariantCulture) + "f)";
	}
}
