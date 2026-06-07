public class GiphyUpload
{
	public class Response
	{
		public Data data;

		public Meta meta;
	}

	public class Data
	{
		public string id;
	}

	public class Meta
	{
		public int status;

		public string msg;

		public string response_id;
	}
}
