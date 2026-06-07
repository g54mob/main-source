namespace RenderHeads.Media.AVProMovieCapture
{
	public interface IMediaApiItem
	{
		int Index { get; }

		string Name { get; }

		MediaApi MediaApi { get; }
	}
}
