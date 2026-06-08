using System;

public class ApartmentImage
{
	public static readonly Random RANDY = new Random();

	public int residue1;

	public int residue2;

	public int color;

	public ApartmentImage()
	{
		residue1 = RANDY.Next(1, 10);
		residue2 = RANDY.Next(-3, 10);
		color = RANDY.Next(1, 13);
	}
}
