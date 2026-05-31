using System;
using JetBrains.Annotations;

namespace Eflatun.SceneReference
{
	[PublicAPI]
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class SceneReferenceOptionsAttribute : Attribute
	{
		public ColoringBehaviour SceneInBuildColoring;

		public ToolboxBehaviour Toolbox;

		public ColoringBehaviour AddressableColoring;
	}
}
