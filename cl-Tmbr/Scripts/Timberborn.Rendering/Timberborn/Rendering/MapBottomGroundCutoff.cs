using System.Collections.Immutable;
using Timberborn.BaseComponentSystem;
using Timberborn.Common;
using UnityEngine;

namespace Timberborn.Rendering
{
	internal class MapBottomGroundCutoff : BaseComponent, IAwakableComponent
	{
		private readonly MaterialHeightCutoffSetter _materialHeightCutoffSetter;

		public MapBottomGroundCutoff(MaterialHeightCutoffSetter materialHeightCutoffSetter)
		{
			_materialHeightCutoffSetter = materialHeightCutoffSetter;
		}

		public void Awake()
		{
			ImmutableArray<string>.Enumerator enumerator = GetComponent<MapBottomGroundCutoffSpec>().Targets.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				MeshRenderer component = base.GameObject.FindChild(current).GetComponent<MeshRenderer>();
				_materialHeightCutoffSetter.SetCutoff(component.material, -1f);
			}
		}
	}
}
