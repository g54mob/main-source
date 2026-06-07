using System.Collections.Generic;

namespace Gh.Tk.Story
{
	public interface IVoiceOverContentSource
	{
		IEnumerable<VoiceOverPart> GenerateParts(string language);
	}
}
