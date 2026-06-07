using System;
using System.Collections;
using System.Collections.Generic;
using Ludiq;
using UnityEngine;

namespace Bolt
{
	public abstract class NesterState<TGraph, TMacro> : State, INesterState, IState, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IGraphElementWithData, IGraphNesterElement, IGraphParentElement, IGraphParent, IGraphNester where TGraph : class, IGraph, new() where TMacro : Macro<TGraph>
	{
		[Serialize]
		public GraphNest<TGraph, TMacro> nest { get; private set; } = new GraphNest<TGraph, TMacro>();

		[DoNotSerialize]
		IGraphNest IGraphNester.nest => nest;

		[DoNotSerialize]
		IGraph IGraphParent.childGraph => nest.graph;

		[DoNotSerialize]
		bool IGraphParent.isSerializationRoot => nest.source == GraphSource.Macro;

		[DoNotSerialize]
		UnityEngine.Object IGraphParent.serializedObject => nest.macro;

		[DoNotSerialize]
		public override IEnumerable<ISerializationDependency> deserializationDependencies => nest.deserializationDependencies;

		[DoNotSerialize]
		public override IEnumerable<object> aotStubs => LinqUtility.Concat<object>(new IEnumerable[2] { base.aotStubs, nest.aotStubs });

		StateGraph IState.graph => base.graph;

		protected NesterState()
		{
			nest.nester = this;
		}

		protected NesterState(TMacro macro)
		{
			nest.nester = this;
			nest.macro = macro;
			nest.source = GraphSource.Macro;
		}

		protected void CopyFrom(NesterState<TGraph, TMacro> source)
		{
			CopyFrom((State)source);
			nest = source.nest;
		}

		public abstract TGraph DefaultGraph();

		IGraph IGraphParent.DefaultGraph()
		{
			return DefaultGraph();
		}

		void IGraphNester.InstantiateNest()
		{
			InstantiateNest();
		}

		void IGraphNester.UninstantiateNest()
		{
			UninstantiateNest();
		}
	}
}
