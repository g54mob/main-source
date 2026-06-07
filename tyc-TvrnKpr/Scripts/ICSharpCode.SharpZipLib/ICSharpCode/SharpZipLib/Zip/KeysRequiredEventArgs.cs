using System;

namespace ICSharpCode.SharpZipLib.Zip
{
	public class KeysRequiredEventArgs : EventArgs
	{
		private string fileName;

		private byte[] key;

		public string FileName => null;

		public byte[] Key
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public KeysRequiredEventArgs(string name)
		{
		}

		public KeysRequiredEventArgs(string name, byte[] keyValue)
		{
		}
	}
}
