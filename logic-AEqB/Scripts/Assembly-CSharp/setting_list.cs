using System;

[Serializable]
public class setting_list
{
	public int saveslot;

	public int language;

	public bool theme;

	public int sound;

	public int fullscreen;

	public int last_chapter;

	public int fontsize;

	public setting_list()
	{
		saveslot = 0;
		language = 0;
		theme = true;
		sound = 0;
		fullscreen = 0;
		last_chapter = 1;
		fontsize = 3;
	}
}
