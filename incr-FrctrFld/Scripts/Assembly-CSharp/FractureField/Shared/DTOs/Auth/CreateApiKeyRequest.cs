namespace FractureField.Shared.DTOs.Auth
{
	public class CreateApiKeyRequest
	{
		public string DeviceId { get; set; }

		public string Platform { get; set; }

		public string DeviceModel { get; set; }

		public string AppVersion { get; set; }
	}
}
