using System;

namespace MiscUtil.Threading
{
	public delegate void ThreadPoolExceptionHandler(CustomThreadPool pool, ThreadPoolWorkItem workItem, Exception e, ref bool handled);
}
