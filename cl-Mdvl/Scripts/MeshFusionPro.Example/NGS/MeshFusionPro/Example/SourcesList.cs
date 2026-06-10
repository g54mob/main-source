using System.Collections.Generic;
using UnityEngine;

namespace NGS.MeshFusionPro.Example
{
	public class SourcesList : MonoBehaviour
	{
		private static HashSet<MeshRenderer> _combinedObjects;

		private static HashSet<MeshFusionSource> _sources;

		public static bool UpdatedDirty { get; set; }

		public static IReadOnlyCollection<MeshFusionSource> Sources => _sources;

		public static IReadOnlyCollection<MeshRenderer> CombinedObjects => _combinedObjects;

		static SourcesList()
		{
			_combinedObjects = new HashSet<MeshRenderer>();
			_sources = new HashSet<MeshFusionSource>();
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void ResetDomain()
		{
			UpdatedDirty = false;
			if (_combinedObjects != null)
			{
				_combinedObjects.Clear();
			}
			if (_sources != null)
			{
				_sources.Clear();
			}
		}

		private void Awake()
		{
			MeshFusionSource component = GetComponent<MeshFusionSource>();
			if (component == null)
			{
				throw new MissingComponentException();
			}
			component.onCombineFinished += OnSourceCombined;
			_sources.Add(component);
			UpdatedDirty = true;
		}

		private void OnSourceCombined(MeshFusionSource source, IEnumerable<ICombinedObjectPart> parts)
		{
			foreach (ICombinedObjectPart part in parts)
			{
				if (part is CombinedLODGroupPart)
				{
					MeshRenderer[] componentsInChildren = ((MonoBehaviour)part.Root).GetComponentsInChildren<MeshRenderer>();
					for (int i = 0; i < componentsInChildren.Length; i++)
					{
						_combinedObjects.Add(componentsInChildren[i]);
					}
				}
				else
				{
					_combinedObjects.Add(((MonoBehaviour)part.Root).GetComponent<MeshRenderer>());
				}
			}
			UpdatedDirty = true;
		}
	}
}
