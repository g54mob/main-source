namespace MiscUtil.Threading
{
	public delegate void BeforeWorkItemHandler(CustomThreadPool pool, ThreadPoolWorkItem workItem, ref bool cancel);
}
