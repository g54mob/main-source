using System.Collections.Generic;
using System.Text;
using Aggro.Core;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Global/TextTagData")]
public class TextTagData : GlobalScriptableObject<TextTagData>
{
	public Color color_dilly;

	public Color color_drift;

	public Color color_stress;

	public Color color_grab;

	public Color color_inputOutput;

	public Color color_fired;

	public Color color_fire;

	public Color color_mess;

	private Dictionary<string, string> _tagsToColors;

	private StringBuilder _builder = new StringBuilder();

	public Dictionary<string, string> tagsToColors
	{
		get
		{
			if (_tagsToColors == null)
			{
				InitColorDictionary();
			}
			return _tagsToColors;
		}
	}

	private void InitColorDictionary()
	{
		_tagsToColors = new Dictionary<string, string>
		{
			{
				"<color=dilly>",
				GetColorTag(color_dilly)
			},
			{
				"<color=drift>",
				GetColorTag(color_drift)
			},
			{
				"<color=stress>",
				GetColorTag(color_stress)
			},
			{
				"<color=grab>",
				GetColorTag(color_grab)
			},
			{
				"<color=inputOutput>",
				GetColorTag(color_inputOutput)
			},
			{
				"<color=fired>",
				GetColorTag(color_fired)
			},
			{
				"<color=fire>",
				GetColorTag(color_fire)
			},
			{
				"<color=mess>",
				GetColorTag(color_mess)
			}
		};
	}

	public string ParseText(string text)
	{
		_builder.Clear();
		_builder.Append(text);
		foreach (string key in tagsToColors.Keys)
		{
			_builder.Replace(key, tagsToColors[key]);
		}
		return _builder.ToString();
	}

	private static string GetColorTag(Color color)
	{
		return "<color=#" + ColorUtility.ToHtmlStringRGBA(color) + ">";
	}
}
