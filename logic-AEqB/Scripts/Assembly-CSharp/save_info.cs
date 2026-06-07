using System;

[Serializable]
public struct save_info
{
	public string id;

	public bool solved;

	public int lastpanel;

	public bool challenge;

	public int challenge_line;

	public save_info(string i, bool s, int l, bool ch, int chl)
	{
		id = i;
		solved = s;
		lastpanel = l;
		challenge = ch;
		challenge_line = chl;
	}
}
