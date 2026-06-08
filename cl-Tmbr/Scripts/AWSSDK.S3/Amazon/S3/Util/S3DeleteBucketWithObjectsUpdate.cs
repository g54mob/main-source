using System.Collections.Generic;
using Amazon.S3.Model;

namespace Amazon.S3.Util
{
	public class S3DeleteBucketWithObjectsUpdate
	{
		public IList<DeletedObject> DeletedObjects { get; set; }

		public IList<DeleteError> DeleteErrors { get; set; }
	}
}
