using System;
using System.Collections.Generic;
using UnityEngine;

namespace GPUInstancerPro
{
	public class GPUIMaterialPropertyOverrides
	{
		internal struct GPUIMaterialPropertyOverride : IEquatable<GPUIMaterialPropertyOverride>
		{
			public int lodIndex;

			public int rendererIndex;

			public int nameID;

			public object value;

			public void ApplyOverride(MaterialPropertyBlock mpb)
			{
				if (value != null)
				{
					mpb.SetValue(nameID, value);
				}
			}

			public override int GetHashCode()
			{
				return GPUIUtility.GenerateHash(lodIndex + 1, rendererIndex + 1, nameID);
			}

			public bool Equals(GPUIMaterialPropertyOverride other)
			{
				if (lodIndex == other.lodIndex && rendererIndex == other.rendererIndex)
				{
					return nameID == other.nameID;
				}
				return false;
			}

			public override bool Equals(object obj)
			{
				if (obj is GPUIMaterialPropertyOverride other)
				{
					return Equals(other);
				}
				return base.Equals(obj);
			}
		}

		private List<GPUIMaterialPropertyOverride> _overrides;

		public void AddOverride(int lodIndex, int rendererIndex, int nameID, object value)
		{
			if (_overrides == null)
			{
				_overrides = new List<GPUIMaterialPropertyOverride>();
			}
			GPUIMaterialPropertyOverride gPUIMaterialPropertyOverride = new GPUIMaterialPropertyOverride
			{
				lodIndex = lodIndex,
				rendererIndex = rendererIndex,
				nameID = nameID,
				value = value
			};
			int num = _overrides.IndexOf(gPUIMaterialPropertyOverride);
			if (num != -1)
			{
				_overrides[num] = gPUIMaterialPropertyOverride;
			}
			else
			{
				_overrides.Add(gPUIMaterialPropertyOverride);
			}
		}

		public void ApplyOverrides(MaterialPropertyBlock mpb, int lodIndex, int rendererIndex)
		{
			if (_overrides == null)
			{
				return;
			}
			for (int i = 0; i < _overrides.Count; i++)
			{
				GPUIMaterialPropertyOverride gPUIMaterialPropertyOverride = _overrides[i];
				if (gPUIMaterialPropertyOverride.lodIndex == lodIndex && gPUIMaterialPropertyOverride.rendererIndex == rendererIndex)
				{
					gPUIMaterialPropertyOverride.ApplyOverride(mpb);
				}
			}
		}

		public object GetOverrideValue(int lodIndex, int rendererIndex, int nameID)
		{
			if (_overrides != null)
			{
				for (int i = 0; i < _overrides.Count; i++)
				{
					GPUIMaterialPropertyOverride gPUIMaterialPropertyOverride = _overrides[i];
					if (gPUIMaterialPropertyOverride.lodIndex == lodIndex && gPUIMaterialPropertyOverride.rendererIndex == rendererIndex && gPUIMaterialPropertyOverride.nameID == nameID)
					{
						return gPUIMaterialPropertyOverride.value;
					}
				}
			}
			return null;
		}

		public int GetOverrideCount()
		{
			if (_overrides == null)
			{
				return 0;
			}
			return _overrides.Count;
		}
	}
}
