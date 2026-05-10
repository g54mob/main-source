using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ToolBuddy.ThirdParty.VectorGraphics
{
	internal class SVGStyleResolver
	{
		public struct NodeData
		{
			public XmlReaderIterator.Node node;

			public string name;

			public List<string> classes;

			public string id;
		}

		public class StyleLayer
		{
			public SVGStyleSheet styleSheet;

			public SVGPropertySheet attributeSheet;

			public NodeData nodeData;
		}

		[CompilerGenerated]
		private sealed class _003CSortedClasses_003Ed__12 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private string _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public SVGStyleResolver _003C_003E4__this;

			private List<string> classes;

			public List<string> _003C_003E3__classes;

			private List<string>.Enumerator _003C_003E7__wrap1;

			private IEnumerator<string> _003C_003E7__wrap2;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CSortedClasses_003Ed__12(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			private void _003C_003Em__Finally2()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private List<StyleLayer> layers;

		private SVGStyleSheet globalStyleSheet;

		private Dictionary<SceneNode, StyleLayer> nodeLayers;

		public void PushNode(XmlReaderIterator.Node node)
		{
		}

		public void PopNode()
		{
		}

		public void PushLayer(StyleLayer layer)
		{
		}

		public void PopLayer()
		{
		}

		public StyleLayer PeekLayer()
		{
			return null;
		}

		public void SaveLayerForSceneNode(SceneNode node)
		{
		}

		public StyleLayer GetLayerForScenNode(SceneNode node)
		{
			return null;
		}

		public void SetGlobalStyleSheet(SVGStyleSheet sheet)
		{
		}

		public string Evaluate(string attribName, Inheritance inheritance = Inheritance.None)
		{
			return null;
		}

		private bool LookupStyleOrAttribute(StyleLayer layer, string attribName, Inheritance inheritance, out string attrib)
		{
			attrib = null;
			return false;
		}

		private bool LookupProperty(NodeData nodeData, string attribName, SVGStyleSheet sheet, out string val)
		{
			val = null;
			return false;
		}

		private bool LookupPropertyInSheet(SVGStyleSheet sheet, string attribName, string selector, out string val)
		{
			val = null;
			return false;
		}

		[IteratorStateMachine(typeof(_003CSortedClasses_003Ed__12))]
		private IEnumerable<string> SortedClasses(List<string> classes)
		{
			return null;
		}
	}
}
