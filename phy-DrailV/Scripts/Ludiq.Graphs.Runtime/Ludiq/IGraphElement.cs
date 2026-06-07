using System;
using System.Collections.Generic;

namespace Ludiq
{
	public interface IGraphElement : IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable
	{
		new IGraph graph { get; set; }

		int dependencyOrder { get; }

		new Guid guid { get; set; }

		IEnumerable<ISerializationDependency> deserializationDependencies { get; }

		bool HandleDependencies();

		void Instantiate(GraphReference instance);

		void Uninstantiate(GraphReference instance);
	}
}
