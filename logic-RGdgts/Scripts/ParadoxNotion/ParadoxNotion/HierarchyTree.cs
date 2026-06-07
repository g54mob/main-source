using System.Collections.Generic;

namespace ParadoxNotion
{
	public class HierarchyTree
	{
		public class Element
		{
			private object _reference;

			private Element _parent;

			private List<Element> _children;

			public object reference => null;

			public Element parent => null;

			public IEnumerable<Element> children => null;

			public Element(object reference)
			{
			}

			public Element AddChild(Element child)
			{
				return null;
			}

			public void RemoveChild(Element child)
			{
			}

			public Element GetRoot()
			{
				return null;
			}

			public Element FindReferenceElement(object target)
			{
				return null;
			}

			public T GetFirstParentReferenceOfType<T>()
			{
				return default(T);
			}

			public IEnumerable<T> GetAllChildrenReferencesOfType<T>()
			{
				return null;
			}
		}
	}
}
