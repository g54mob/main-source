using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Framework.Internal
{
	public struct GraphLoadData
	{
		public GraphSource source;

		public string json;

		public List<Object> references;

		public Component agent;

		public IBlackboard parentBlackboard;

		public bool preInitializeSubGraphs;
	}
}
