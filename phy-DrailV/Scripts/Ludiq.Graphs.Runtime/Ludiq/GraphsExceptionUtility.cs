using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ludiq
{
	public static class GraphsExceptionUtility
	{
		private const string handledKey = "Ludiq.Graphs.Handled";

		public static Exception GetException(this IGraphElementWithDebugData element, GraphPointer pointer)
		{
			if (!pointer.hasDebugData)
			{
				return null;
			}
			IGraphElementDebugData elementDebugData = pointer.GetElementDebugData<IGraphElementDebugData>(element);
			return elementDebugData.runtimeException;
		}

		public static void SetException(this IGraphElementWithDebugData element, GraphPointer pointer, Exception ex)
		{
			if (pointer.hasDebugData)
			{
				IGraphElementDebugData elementDebugData = pointer.GetElementDebugData<IGraphElementDebugData>(element);
				elementDebugData.runtimeException = ex;
			}
		}

		public static void HandleException(this IGraphElementWithDebugData element, GraphPointer pointer, Exception ex)
		{
			Ensure.That("ex").IsNotNull(ex);
			if (pointer == null)
			{
				Debug.LogError("Caught exception with null graph pointer (flow was likely disposed):\n" + ex);
				return;
			}
			GraphReference graphReference = pointer.AsReference();
			if (!ex.HandledIn(graphReference))
			{
				element.SetException(pointer, ex);
			}
			while (graphReference.isChild)
			{
				IGraphParentElement parentElement = graphReference.parentElement;
				graphReference = graphReference.ParentReference(ensureValid: true);
				if (parentElement is IGraphElementWithDebugData element2 && !ex.HandledIn(graphReference))
				{
					element2.SetException(graphReference, ex);
				}
			}
		}

		private static bool HandledIn(this Exception ex, GraphReference reference)
		{
			Ensure.That("ex").IsNotNull(ex);
			if (!ex.Data.Contains("Ludiq.Graphs.Handled"))
			{
				ex.Data.Add("Ludiq.Graphs.Handled", new HashSet<GraphReference>());
			}
			HashSet<GraphReference> hashSet = (HashSet<GraphReference>)ex.Data["Ludiq.Graphs.Handled"];
			if (hashSet.Contains(reference))
			{
				return true;
			}
			hashSet.Add(reference);
			return false;
		}
	}
}
