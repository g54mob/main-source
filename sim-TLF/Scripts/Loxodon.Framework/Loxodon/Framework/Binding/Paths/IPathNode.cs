using System.Text;

namespace Loxodon.Framework.Binding.Paths
{
	public interface IPathNode
	{
		bool IsStatic { get; }

		void AppendTo(StringBuilder output);
	}
}
