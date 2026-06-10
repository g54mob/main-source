using System.Collections.Generic;
using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Google.Apis.Sheets.v4.Data
{
	public class CancelDataSourceRefreshResponse : IDirectResponseSchema
	{
		[JsonProperty("statuses")]
		public virtual IList<CancelDataSourceRefreshStatus> Statuses { get; set; }

		public virtual string ETag { get; set; }
	}
}
