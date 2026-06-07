using System;
using System.Collections.ObjectModel;
using Ludiq;

namespace Bolt
{
	public interface IMultiInputUnit : IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable
	{
		int inputCount { get; set; }

		ReadOnlyCollection<ValueInput> multiInputs { get; }
	}
}
