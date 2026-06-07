public class GiphyGetById
{
	public class Response
	{
		public Data data;

		public Meta meta;
	}

	public class User
	{
		public string avatar_url;

		public string banner_url;

		public string profile_url;

		public string username;

		public string display_name;
	}

	public class FixedHeight
	{
		public string url;

		public string width;

		public string height;

		public string size;

		public string mp4;

		public string mp4_size;

		public string webp;

		public string webp_size;
	}

	public class FixedHeightStill
	{
		public string url;

		public string width;

		public string height;

		public string size;
	}

	public class FixedHeightDownsampled
	{
		public string url;

		public string width;

		public string height;

		public string size;

		public string webp;

		public string webp_size;
	}

	public class FixedWidth
	{
		public string url;

		public string width;

		public string height;

		public string size;

		public string mp4;

		public string mp4_size;

		public string webp;

		public string webp_size;
	}

	public class FixedWidthStill
	{
		public string url;

		public string width;

		public string height;

		public string size;
	}

	public class FixedWidthDownsampled
	{
		public string url;

		public string width;

		public string height;

		public string size;

		public string webp;

		public string webp_size;
	}

	public class FixedHeightSmall
	{
		public string url;

		public string width;

		public string height;

		public string size;

		public string mp4;

		public string mp4_size;

		public string webp;

		public string webp_size;
	}

	public class FixedHeightSmallStill
	{
		public string url;

		public string width;

		public string height;
	}

	public class FixedWidthSmall
	{
		public string url;

		public string width;

		public string height;

		public string size;

		public string mp4;

		public string mp4_size;

		public string webp;

		public string webp_size;
	}

	public class FixedWidthSmallStill
	{
		public string url;

		public string width;

		public string height;
	}

	public class Downsized
	{
		public string url;

		public string width;

		public string height;

		public string size;
	}

	public class DownsizedStill
	{
		public string url;

		public string width;

		public string height;
	}

	public class DownsizedLarge
	{
		public string url;

		public string width;

		public string height;

		public string size;
	}

	public class DownsizedMedium
	{
		public string url;

		public string width;

		public string height;

		public string size;
	}

	public class Original
	{
		public string url;

		public string width;

		public string height;

		public string size;

		public string frames;

		public string mp4;

		public string mp4_size;

		public string webp;

		public string webp_size;

		public string hash;
	}

	public class OriginalStill
	{
		public string url;

		public string width;

		public string height;

		public string size;
	}

	public class Looping
	{
		public string mp4;
	}

	public class Images
	{
		public FixedHeight fixed_height;

		public FixedHeightStill fixed_height_still;

		public FixedHeightDownsampled fixed_height_downsampled;

		public FixedWidth fixed_width;

		public FixedWidthStill fixed_width_still;

		public FixedWidthDownsampled fixed_width_downsampled;

		public FixedHeightSmall fixed_height_small;

		public FixedHeightSmallStill fixed_height_small_still;

		public FixedWidthSmall fixed_width_small;

		public FixedWidthSmallStill fixed_width_small_still;

		public Downsized downsized;

		public DownsizedStill downsized_still;

		public DownsizedLarge downsized_large;

		public DownsizedMedium downsized_medium;

		public Original original;

		public OriginalStill original_still;

		public Looping looping;
	}

	public class Data
	{
		public string type;

		public string id;

		public string slug;

		public string url;

		public string bitly_gif_url;

		public string bitly_url;

		public string embed_url;

		public string username;

		public string source;

		public string rating;

		public string content_url;

		public User user;

		public string source_tld;

		public string source_post_url;

		public int is_indexable;

		public string import_datetime;

		public string trending_datetime;

		public Images images;
	}

	public class Meta
	{
		public int status;

		public string msg;

		public string response_id;
	}
}
