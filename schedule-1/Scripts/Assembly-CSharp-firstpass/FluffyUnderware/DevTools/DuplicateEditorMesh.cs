using System;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.DevTools
{
	[UsedImplicitly]
	[Obsolete("No more used in Curvy. Will get removed. Copy it if you still need it")]
	[ExecuteAlways]
	[RequireComponent(typeof(MeshFilter))]
	public abstract class DuplicateEditorMesh : DTVersionedMonoBehaviour
	{
		private MeshFilter mFilter;

		public MeshFilter Filter => null;
	}
}
