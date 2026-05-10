using JetBrains.Annotations;

public interface bjk : bjm, bjl, bjp
{
	[CanBeNull]
	string xoj { get; }
}
