using Utility;

namespace ScriptHelpers
{
	public class SaveableBinElement : ISaveableBin
	{
		public ISaveableBin saveable;

		public Version dontLoadIfBeforeVersion;

		public SaveableBinElement(ISaveableBin saveable, Version? dontLoadIfBeforeVersion = null)
		{
			this.saveable = saveable;
			this.dontLoadIfBeforeVersion = dontLoadIfBeforeVersion ?? Version.Null;
		}

		public int BytesSpace()
		{
			return saveable.BytesSpace();
		}

		public byte[] SaveStateBin(byte[] bytes = null, int offset = 0)
		{
			return saveable.SaveStateBin(bytes, offset);
		}

		public void LoadStateBin(byte[] bytes, Version version, int offset = 0, int nBytes = -1)
		{
			if (version >= dontLoadIfBeforeVersion)
			{
				saveable.LoadStateBin(bytes, version, offset, nBytes);
			}
		}
	}
}
