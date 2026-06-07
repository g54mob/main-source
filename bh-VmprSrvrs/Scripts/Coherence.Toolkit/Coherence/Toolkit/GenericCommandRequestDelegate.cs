using System.ComponentModel;

namespace Coherence.Toolkit
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public delegate void GenericCommandRequestDelegate(MessageTarget target, ChannelID channelID, object[] args);
}
