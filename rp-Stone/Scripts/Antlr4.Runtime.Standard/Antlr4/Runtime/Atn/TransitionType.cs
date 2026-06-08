namespace Antlr4.Runtime.Atn
{
	public enum TransitionType
	{
		INVALID = 0,
		EPSILON = 1,
		RANGE = 2,
		RULE = 3,
		PREDICATE = 4,
		ATOM = 5,
		ACTION = 6,
		SET = 7,
		NOT_SET = 8,
		WILDCARD = 9,
		PRECEDENCE = 10
	}
}
