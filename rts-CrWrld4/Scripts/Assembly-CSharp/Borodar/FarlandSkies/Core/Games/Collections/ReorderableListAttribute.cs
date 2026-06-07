using System;
using UnityEngine;

namespace Borodar.FarlandSkies.Core.Games.Collections
{
	public sealed class ReorderableListAttribute : PropertyAttribute
	{
		public string ElementsPropertyName { get; private set; }

		public Type DroppableObjectType { get; private set; }

		public ReorderableListFlags Flags { get; private set; }

		public ReorderableListAttribute(string elementsPropertyName = "elements", Type droppableObjectType = null, ReorderableListFlags flags = (ReorderableListFlags)0)
		{
		}
	}
}
