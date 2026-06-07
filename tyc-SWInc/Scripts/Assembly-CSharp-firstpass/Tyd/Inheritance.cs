using System;
using System.Collections.Generic;
using System.Linq;

namespace Tyd
{
	public static class Inheritance
	{
		private class InheritanceNode
		{
			public TydCollection TydNode;

			public bool Resolved;

			public InheritanceNode Source;

			private List<InheritanceNode> _heirs;

			public int HeirCount
			{
				get
				{
					if (_heirs == null)
					{
						return 0;
					}
					return _heirs.Count;
				}
			}

			public InheritanceNode(TydCollection tydNode)
			{
				TydNode = tydNode;
			}

			public InheritanceNode GetHeir(int index)
			{
				return _heirs[index];
			}

			public void AddHeir(InheritanceNode n)
			{
				if (_heirs == null)
				{
					_heirs = new List<InheritanceNode>();
				}
				_heirs.Add(n);
			}

			public override string ToString()
			{
				return TydNode.ToString();
			}
		}

		private static List<InheritanceNode> nodesUnresolved = new List<InheritanceNode>();

		private static Dictionary<TydNode, InheritanceNode> nodesResolved = new Dictionary<TydNode, InheritanceNode>();

		private static Dictionary<string, InheritanceNode> nodesByHandle = new Dictionary<string, InheritanceNode>();

		private static HashSet<string> tempUsedNodeNames = new HashSet<string>();

		public static void Clear()
		{
			nodesResolved.Clear();
			nodesUnresolved.Clear();
			nodesByHandle.Clear();
		}

		public static void Register(TydCollection colNode)
		{
			string attributeHandle = colNode.AttributeHandle;
			string attributeSource = colNode.AttributeSource;
			if (attributeHandle != null || attributeSource != null)
			{
				if (attributeHandle != null && nodesByHandle.ContainsKey(attributeHandle))
				{
					throw new Exception(string.Format("Tyd error: Multiple Tyd _nodes with the same handle {0}.", attributeHandle));
				}
				InheritanceNode inheritanceNode = new InheritanceNode(colNode);
				nodesUnresolved.Add(inheritanceNode);
				if (attributeHandle != null)
				{
					nodesByHandle.Add(attributeHandle, inheritanceNode);
				}
			}
		}

		public static void RegisterAllFrom(TydDocument doc)
		{
			for (int i = 0; i < doc.Count; i++)
			{
				TydCollection tydCollection = doc[i] as TydCollection;
				if (tydCollection != null)
				{
					Register(tydCollection);
				}
			}
		}

		public static void ResolveAll()
		{
			LinkAllInheritanceNodes();
			ResolveAllUnresolvedInheritanceNodes();
		}

		private static void ResolveAllUnresolvedInheritanceNodes()
		{
			List<InheritanceNode> list = nodesUnresolved.Where((InheritanceNode x) => x.Source == null || x.Source.Resolved).ToList();
			for (int num = 0; num < list.Count; num++)
			{
				ResolveInheritanceNodeAndHeirs(list[num]);
			}
			for (int num2 = 0; num2 < nodesUnresolved.Count; num2++)
			{
				if (!nodesUnresolved[num2].Resolved)
				{
					throw new FormatException("Tyd error: Cyclic inheritance detected for node:\n" + nodesUnresolved[num2].TydNode.FullTyd);
				}
				nodesResolved.Add(nodesUnresolved[num2].TydNode, nodesUnresolved[num2]);
			}
			nodesUnresolved.Clear();
		}

		private static void LinkAllInheritanceNodes()
		{
			for (int i = 0; i < nodesUnresolved.Count; i++)
			{
				InheritanceNode inheritanceNode = nodesUnresolved[i];
				string attributeSource = inheritanceNode.TydNode.AttributeSource;
				if (attributeSource != null)
				{
					if (!nodesByHandle.TryGetValue(attributeSource, out inheritanceNode.Source))
					{
						throw new Exception(string.Format("Could not find source node named '{0}' for Tyd node: {1}", attributeSource, inheritanceNode.TydNode.FullTyd));
					}
					if (inheritanceNode.Source != null)
					{
						inheritanceNode.Source.AddHeir(inheritanceNode);
					}
				}
			}
		}

		private static void ResolveInheritanceNodeAndHeirs(InheritanceNode node)
		{
			if (node.Resolved)
			{
				throw new Exception(string.Format("Cyclic inheritance detected for Tyd node:\n{0}", node.TydNode.FullTyd));
			}
			if (node.Source == null)
			{
				node.Resolved = true;
			}
			else
			{
				if (!node.Source.Resolved)
				{
					throw new Exception(string.Format("Tried to resolve Tyd inheritance node {0} whose source has not been resolved yet. This means that this method was called in incorrect order.", node));
				}
				CheckForDuplicateNodes(node.TydNode);
				node.Resolved = true;
				string value = node.TydNode.AttributeClass ?? node.Source.TydNode.AttributeClass;
				node.TydNode.SetAttribute("class", value);
				ApplyInheritance(node.Source.TydNode, node.TydNode);
			}
			for (int i = 0; i < node.HeirCount; i++)
			{
				ResolveInheritanceNodeAndHeirs(node.GetHeir(i));
			}
		}

		private static void ApplyInheritance(TydNode source, TydNode heir)
		{
			try
			{
				if (source is TydString)
				{
					return;
				}
				TydCollection tydCollection = heir as TydCollection;
				if (tydCollection != null && tydCollection.AttributeNoInherit)
				{
					return;
				}
				TydTable tydTable = source as TydTable;
				if (tydTable != null)
				{
					TydTable tydTable2 = (TydTable)heir;
					for (int i = 0; i < tydTable.Count; i++)
					{
						TydNode tydNode = tydTable[i];
						TydNode child = tydTable2.GetChild(tydNode.Name);
						if (child != null)
						{
							ApplyInheritance(tydNode, child);
						}
						else
						{
							tydTable2.InsertChild(tydNode.DeepClone(), 0);
						}
					}
					return;
				}
				TydList tydList = source as TydList;
				if (tydList != null)
				{
					TydList tydList2 = (TydList)heir;
					for (int j = 0; j < tydList.Count; j++)
					{
						tydList2.InsertChild(tydList[j].DeepClone(), j);
					}
				}
			}
			catch (Exception ex)
			{
				throw new Exception(string.Concat("ApplyInheritance exception: ", ex, ".\nsource: (", source, ")\n", TydToText.Write(source, true), "\ntarget: (", heir, ")\n", TydToText.Write(heir, true)));
			}
		}

		private static void CheckForDuplicateNodes(TydCollection originalNode)
		{
			tempUsedNodeNames.Clear();
			for (int i = 0; i < originalNode.Count; i++)
			{
				TydNode tydNode = originalNode[i];
				if (tydNode.Name != null)
				{
					if (tempUsedNodeNames.Contains(tydNode.Name))
					{
						throw new FormatException("Tyd error: Duplicate Tyd node _name " + tydNode.Name + " in this Tyd block: " + originalNode);
					}
					tempUsedNodeNames.Add(tydNode.Name);
				}
			}
			tempUsedNodeNames.Clear();
		}
	}
}
