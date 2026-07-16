using System;

public static class DirUtils
{
	public static Dir[] Dirs = new Dir[4]
	{
		Dir.Up,
		Dir.Left,
		Dir.Down,
		Dir.Right
	};

	public static Dir Random()
	{
		return Dirs[new Random().Next(0, Dirs.Length)];
	}
}
