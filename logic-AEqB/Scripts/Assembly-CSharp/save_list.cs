using System;
using System.Collections.Generic;

[Serializable]
public class save_list
{
	public List<save_info> data;

	public List<string> story;

	public save_list()
	{
		data = new List<save_info>();
		story = new List<string>();
	}
}
