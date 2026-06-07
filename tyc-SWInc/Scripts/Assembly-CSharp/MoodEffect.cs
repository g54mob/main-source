using System;
using Tyd;

[Serializable]
public class MoodEffect
{
	public string Thought;

	public bool Negative;

	public bool Sue;

	public bool UpdateAlways;

	public bool ClearOnComplaint;

	public float StartValue;

	public float Increment;

	public float Decrement;

	public float Max;

	public float CutOff;

	public float WarningThreshold;

	public float Severity = 1f;

	public string QuitReason;

	public string Warning;

	public string CounterMood;

	public MoodEffect(XMLParser.XMLNode node)
	{
		Negative = node.Name.Equals("Negative");
		Thought = node.GetNode("Thought").Value;
		StartValue = node.GetNodeValue("Start").ConvertToFloat("MoodEffect.StartValue");
		Increment = node.GetNodeValue("Inc").ConvertToFloat("MoodEffect.Increment");
		Decrement = node.GetNodeValue("Dec").ConvertToFloat("MoodEffect.Decrement");
		Max = node.GetNodeValue("Max").ConvertToFloat("MoodEffect.Max");
		CutOff = node.GetNodeValue("CutOff", "1").ConvertToFloat("MoodEffect.CutOff");
		WarningThreshold = node.GetNodeValue("WarnThresh", "0").ConvertToFloat("MoodEffect.WarningThreshold");
		Warning = node.GetNodeValue("Warn");
		QuitReason = node.GetNodeValue("QuitReason");
		CounterMood = node.GetNodeValue("CounterMood");
		Sue = Negative && QuitReason != null && node.GetNodeValue("Sue", false);
		UpdateAlways = node.GetNodeValue("UpdateAlways", false);
		ClearOnComplaint = node.GetNodeValue("ClearOnComplaint", false);
	}

	public MoodEffect(TydTable table)
	{
		Negative = table.Name.Equals("Negative");
		Thought = table.GetChildValue("Thought");
		StartValue = table.GetChildValue("Start", false, 0f);
		Increment = table.GetChildValue("Inc", true, 0f);
		Decrement = table.GetChildValue("Dec", true, 0f);
		Max = table.GetChildValue("Max", true, 0f);
		Severity = table.GetChildValue("Severity", false, 1f);
		CutOff = table.GetChildValue("CutOff", false, 1f);
		WarningThreshold = table.GetChildValue("WarnThresh", false, 0f);
		Warning = table.GetChildValue("Warn", false);
		QuitReason = table.GetChildValue("QuitReason", false);
		CounterMood = table.GetChildValue("CounterMood", false);
		Sue = Negative && QuitReason != null && table.GetChildValue("Sue", false, false);
		UpdateAlways = table.GetChildValue("UpdateAlways", false, false);
		ClearOnComplaint = table.GetChildValue("ClearOnComplaint", false, false);
	}

	public override string ToString()
	{
		return Thought;
	}
}
