using System.Runtime.InteropServices;

namespace IdSharp.Tagging.ID3v2
{
	[ComVisible(true)]
	[Guid("E5716B40-9420-44df-A97D-DC397AB2A0E8")]
	public enum MusicEvent : byte
	{
		Padding = 0,
		EndOfInitialSilence = 1,
		IntroStart = 2,
		MainPartStart = 3,
		OutroStart = 4,
		OutroEnd = 5,
		VerseStart = 6,
		RefrainStart = 7,
		InterludeStart = 8,
		ThemeStart = 9,
		VariationStart = 10,
		KeyChange = 11,
		TimeChange = 12,
		MomentaryUnwantedNoise = 13,
		SustainedNoise = 14,
		SustainedNoiseEnd = 15,
		IntroEnd = 16,
		MainPartEnd = 17,
		VerseEnd = 18,
		RefrainEnd = 19,
		ThemeEnd = 20,
		Profanity = 21,
		ProfanityEnd = 22,
		UserEvent1 = 224,
		UserEvent2 = 225,
		UserEvent3 = 226,
		UserEvent4 = 227,
		UserEvent5 = 228,
		UserEvent6 = 229,
		UserEvent7 = 230,
		UserEvent8 = 231,
		UserEvent9 = 232,
		UserEvent10 = 233,
		UserEvent11 = 234,
		UserEvent12 = 235,
		UserEvent13 = 236,
		UserEvent14 = 237,
		UserEvent15 = 238,
		UserEvent16 = 239,
		AudioEnd = 253,
		AudioFileEnds = 254
	}
}
