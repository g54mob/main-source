using Utility;

namespace ScriptHelpers
{
	public interface ISaveableBin
	{
		int BytesSpace();

		byte[] SaveStateBin(byte[] bytes = null, int offset = 0);

		void LoadStateBin(byte[] bytes, Version version, int offset = 0, int nBytes = -1);
	}
}
