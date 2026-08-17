using System;

namespace VampireSurvivors.Data.Stage;

[Serializable]
public class TrisectionEvent : Event
{
	public int weight;

	public int minLevel;

	private string _003ClocalisationString_003Ek__BackingField;

	public string localisationString
	{
		get
		{
			return _003ClocalisationString_003Ek__BackingField;
		}
		set
		{
			_003ClocalisationString_003Ek__BackingField = value;
		}
	}
}
