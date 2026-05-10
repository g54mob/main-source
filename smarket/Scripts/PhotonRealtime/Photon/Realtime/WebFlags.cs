namespace Photon.Realtime
{
	public class WebFlags
	{
		public static readonly WebFlags Default;

		public byte WebhookFlags;

		public const byte HttpForwardConst = 1;

		public const byte SendAuthCookieConst = 2;

		public const byte SendSyncConst = 4;

		public const byte SendStateConst = 8;

		public bool HttpForward
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool SendAuthCookie
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool SendSync
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool SendState
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public WebFlags(byte webhookFlags)
		{
		}
	}
}
