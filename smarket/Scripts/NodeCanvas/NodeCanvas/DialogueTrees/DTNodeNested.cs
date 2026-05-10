using System.Collections.Generic;
using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.DialogueTrees
{
	[Category("SubGraphs")]
	[Color("ffe4e1")]
	public abstract class DTNodeNested<T> : DTNode, IGraphAssignable<T>, IGraphAssignable, IGraphElement
	{
		[SerializeField]
		private List<BBMappingParameter> _variablesMap;

		public abstract T subGraph { get; set; }

		public abstract BBParameter subGraphParameter { get; }

		public T currentInstance { get; set; }

		public Dictionary<Graph, Graph> instances { get; set; }

		public List<BBMappingParameter> variablesMap
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		Graph IGraphAssignable.subGraph
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		Graph IGraphAssignable.currentInstance
		{
			get
			{
				return null;
			}
			set
			{
			}
		}
	}
}
