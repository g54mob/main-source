namespace QRCoder
{
	public abstract class AbstractQRCode
	{
		protected QRCodeData QrCodeData { get; set; }

		protected AbstractQRCode()
		{
		}

		protected AbstractQRCode(QRCodeData data)
		{
		}

		public virtual void SetQRCodeData(QRCodeData data)
		{
		}

		public void Dispose()
		{
		}
	}
}
