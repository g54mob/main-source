using System;

namespace Epic.OnlineServices.PlayerDataStorage
{
	internal delegate WriteResult OnWriteFileDataCallbackInternal(IntPtr data, IntPtr outDataBuffer, ref uint outDataWritten);
}
