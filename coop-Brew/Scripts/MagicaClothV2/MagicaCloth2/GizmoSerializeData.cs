using System;

namespace MagicaCloth2
{
	[Serializable]
	public class GizmoSerializeData
	{
		public bool always;

		public ClothDebugSettings clothDebugSettings;

		public bool IsAlways()
		{
			return false;
		}
	}
}
