using PlaylistsNET.Models;

namespace PlaylistsNET.Content
{
	public class PlaylistToTextHelper
	{
		public static string ToText(IBasePlaylist playlist)
		{
			string result = "";
			if (!(playlist is M3uPlaylist playlist2))
			{
				if (!(playlist is PlsPlaylist playlist3))
				{
					if (!(playlist is WplPlaylist playlist4))
					{
						if (playlist is ZplPlaylist playlist5)
						{
							result = new ZplContent().ToText(playlist5);
						}
					}
					else
					{
						result = new WplContent().ToText(playlist4);
					}
				}
				else
				{
					result = new PlsContent().ToText(playlist3);
				}
			}
			else
			{
				result = new M3uContent().ToText(playlist2);
			}
			return result;
		}
	}
}
