using UnityEngine;

namespace Ludiq
{
	public interface IGraphParent
	{
		IGraph childGraph { get; }

		bool isSerializationRoot { get; }

		Object serializedObject { get; }

		IGraph DefaultGraph();
	}
}
