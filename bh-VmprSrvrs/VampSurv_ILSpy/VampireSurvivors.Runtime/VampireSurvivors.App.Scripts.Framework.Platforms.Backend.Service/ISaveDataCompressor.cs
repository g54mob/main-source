namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service;

public interface ISaveDataCompressor
{
	string Compress(string input);

	string Decompress(string input);
}
