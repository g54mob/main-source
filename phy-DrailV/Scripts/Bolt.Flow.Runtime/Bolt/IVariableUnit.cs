using System;
using Ludiq;

namespace Bolt
{
	public interface IVariableUnit : IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable
	{
		ValueInput name { get; }
	}
}
