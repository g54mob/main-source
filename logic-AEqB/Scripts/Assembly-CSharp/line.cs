public class line
{
	public string left;

	public string right;

	public string display;

	public int once;

	public int left_position;

	public int right_position;

	public int line_num;

	public int line_screen_num;

	public int line_in_prog;

	public line(string l, string r, string ss, int t, int ll, int rr, int line0, int line1)
	{
		left = l;
		right = r;
		display = ss;
		once = t;
		left_position = ll;
		right_position = rr;
		line_num = line0;
		line_screen_num = line1;
	}
}
