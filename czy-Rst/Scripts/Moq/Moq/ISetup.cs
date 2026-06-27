using System.Linq.Expressions;

namespace Moq
{
	public interface ISetup
	{
		LambdaExpression Expression { get; }

		Mock InnerMock { get; }

		bool IsConditional { get; }

		bool IsMatched { get; }

		bool IsOverridden { get; }

		bool IsVerifiable { get; }

		Mock Mock { get; }

		Expression OriginalExpression { get; }

		void Verify(bool recursive = true);

		void VerifyAll();
	}
}
