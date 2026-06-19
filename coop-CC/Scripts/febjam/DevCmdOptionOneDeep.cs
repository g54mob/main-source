using System;
using System.Collections.Generic;
using DevCmdLine.UI;

public class DevCmdOptionOneDeep : DevCmdOptionUIBase
{
	[Serializable]
	public struct Entry
	{
		public string label;

		public string cmd;
	}

	public string mainLabel;

	public Entry[] entries;

	public override bool TryGetInitial(out string optionStr, out bool isEnd)
	{
		optionStr = mainLabel;
		isEnd = false;
		return true;
	}

	public override List<DevCmdSubOption> Selected(List<object> contexts)
	{
		List<DevCmdSubOption> list = new List<DevCmdSubOption>();
		for (int i = 0; i < entries.Length; i++)
		{
			Entry entry = entries[i];
			list.Add(new DevCmdSubOption
			{
				text = entry.label,
				context = i,
				isEnd = true
			});
		}
		return list;
	}

	public override string ConstructCmd(List<object> contexts)
	{
		int num = (int)contexts[0];
		return entries[num].cmd;
	}
}
