public class BufferStopController : BufferControllerBase
{
	private void Awake()
	{
		bufferCompressionRange = 0f;
		sidewaysOffset = 0.86f;
		bufferWidth = 0.3f;
	}
}
