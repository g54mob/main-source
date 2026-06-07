using UnityEngine;

namespace Ludiq
{
	public interface IMacro : IGraphRoot, IGraphParent, ISerializationDependency, ISerializationCallbackReceiver, IAotStubbable
	{
		IGraph graph { get; set; }
	}
}
