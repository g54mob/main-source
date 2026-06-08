using System;
using System.Globalization;
using Amazon.S3.Model;

namespace Amazon.S3
{
	public class DeleteObjectsException : AmazonS3Exception
	{
		private DeleteObjectsResponse response;

		public DeleteObjectsResponse Response
		{
			get
			{
				return response;
			}
			set
			{
				response = value;
			}
		}

		public DeleteObjectsException(DeleteObjectsResponse response)
			: base(CreateMessage(response))
		{
			this.response = response;
		}

		private static string CreateMessage(DeleteObjectsResponse response)
		{
			if (response == null)
			{
				throw new ArgumentNullException("response");
			}
			return string.Format(CultureInfo.InvariantCulture, "Error deleting objects. Deleted objects: {0}. Delete errors: {1}", (response.DeletedObjects != null) ? response.DeletedObjects.Count : 0, (response.DeleteErrors != null) ? response.DeleteErrors.Count : 0);
		}
	}
}
