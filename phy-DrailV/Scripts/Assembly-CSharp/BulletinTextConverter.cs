using System.Linq;
using TMPro;
using UnityEngine;

public class BulletinTextConverter : MonoBehaviour
{
	[TextArea(3, 40)]
	public string text;

	public TextMeshProUGUI targetTextMeshPro;

	private void OnValidate()
	{
		if (!(targetTextMeshPro == null))
		{
			targetTextMeshPro.text = Convert(text);
		}
	}

	private string Convert(string text)
	{
		string[] source = text.Split('\n');
		return string.Join("", source.Select(ConvertLine).ToArray());
	}

	private string ConvertLine(string line)
	{
		if (line.StartsWith("# "))
		{
			return "<line-height=1.6em><voffset=-0.8em><align=\"center\"><font=\"MateSC SDF\"><u>" + line.Substring(2) + "</u></font></align></voffset>\n</line-height>";
		}
		if (line.StartsWith("$ "))
		{
			return "<line-height=2.2em><voffset=-1.1em><align=\"center\"><font=\"Rakkas SDF\">" + line.Substring(2) + "</font></align></voffset>\n</line-height>";
		}
		if (line.StartsWith("--"))
		{
			return "\n";
		}
		if (line.Trim() == "")
		{
			return "";
		}
		return line + "\n";
	}
}
