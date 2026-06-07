using System.Collections.Generic;

public class AkMultiPosEvent
{
	public bool eventIsPlaying;

	public List<AkAmbient> list;

	public void FinishedPlaying(object in_cookie, AkCallbackType in_type, object in_info)
	{
	}
}
