namespace Amazon.S3.Model
{
	public class TopicConfiguration : NotificationConfiguration
	{
		public string Id { get; set; }

		public string Topic { get; set; }

		internal bool IsSetId()
		{
			return Id != null;
		}

		internal bool IsSetTopic()
		{
			return Topic != null;
		}
	}
}
