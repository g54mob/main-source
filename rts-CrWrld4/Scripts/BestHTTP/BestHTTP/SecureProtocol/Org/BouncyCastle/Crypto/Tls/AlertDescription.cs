namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Tls
{
	public abstract class AlertDescription
	{
		public const byte close_notify = 0;

		public const byte unexpected_message = 10;

		public const byte bad_record_mac = 20;

		public const byte decryption_failed = 21;

		public const byte record_overflow = 22;

		public const byte decompression_failure = 30;

		public const byte handshake_failure = 40;

		public const byte no_certificate = 41;

		public const byte bad_certificate = 42;

		public const byte unsupported_certificate = 43;

		public const byte certificate_revoked = 44;

		public const byte certificate_expired = 45;

		public const byte certificate_unknown = 46;

		public const byte illegal_parameter = 47;

		public const byte unknown_ca = 48;

		public const byte access_denied = 49;

		public const byte decode_error = 50;

		public const byte decrypt_error = 51;

		public const byte export_restriction = 60;

		public const byte protocol_version = 70;

		public const byte insufficient_security = 71;

		public const byte internal_error = 80;

		public const byte user_canceled = 90;

		public const byte no_renegotiation = 100;

		public const byte unsupported_extension = 110;

		public const byte certificate_unobtainable = 111;

		public const byte unrecognized_name = 112;

		public const byte bad_certificate_status_response = 113;

		public const byte bad_certificate_hash_value = 114;

		public const byte unknown_psk_identity = 115;

		public const byte inappropriate_fallback = 86;

		public static string GetName(byte alertDescription)
		{
			return null;
		}

		public static string GetText(byte alertDescription)
		{
			return null;
		}
	}
}
