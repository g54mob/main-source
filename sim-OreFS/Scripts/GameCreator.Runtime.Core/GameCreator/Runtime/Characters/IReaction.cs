using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.Characters
{
	public interface IReaction
	{
		ReactionItem CanRun(Character character, Args args, ReactionInput input);

		ReactionOutput Run(Character character, Args args, ReactionInput input, ReactionItem reaction);

		ReactionOutput Run(Character character, Args args, ReactionInput input);
	}
}
