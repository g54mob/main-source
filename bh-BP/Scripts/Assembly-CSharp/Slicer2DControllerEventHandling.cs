using System;
using System.Runtime.CompilerServices;

[Serializable]
public class Slicer2DControllerEventHandling
{
	public delegate void ResultEvent(Slice2D slice);

	public event ResultEvent sliceResultEvent
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void Perform(Slice2D result)
	{
	}
}
