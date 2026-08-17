namespace VampireSurvivors.Framework.Platforms;

public interface ILastErrorProvider
{
	ErroInfo LastError { get; }
}
