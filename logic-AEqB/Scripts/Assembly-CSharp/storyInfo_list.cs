using System;
using System.Collections.Generic;

[Serializable]
public class storyInfo_list
{
	public List<story_info> data;

	public storyInfo_list()
	{
		data = new List<story_info>();
	}
}
