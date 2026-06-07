namespace GPUInstancerPro
{
	public interface IGPUIParameterBufferData
	{
		void SetParameterBufferData();

		bool TryGetParameterBufferIndex(out int index);
	}
}
