using System;
using System.Collections.Generic;

[Serializable]
public struct new_level_info
{
	public string id;

	public string title_en;

	public string title_ch;

	public string title_cht;

	public string title_jp;

	public string quest_en;

	public string quest_ch;

	public string quest_cht;

	public string quest_jp;

	public int chapter;

	public int min_lines;

	public List<string> example_input;

	public List<string> input;

	public List<string> output;

	public string editor;

	public string editor_prog;

	public ulong workshop_id;
}
