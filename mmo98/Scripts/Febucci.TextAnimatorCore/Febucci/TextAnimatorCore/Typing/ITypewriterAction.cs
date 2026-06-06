using Febucci.Parsing;

namespace Febucci.TextAnimatorCore.Typing
{
	public interface ITypewriterAction : ITagProvider
	{
		IActionState CreateActionFrom(ActionMarker marker, object typewriter);
	}
}
