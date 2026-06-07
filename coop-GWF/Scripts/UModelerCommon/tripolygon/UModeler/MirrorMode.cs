using System;

namespace tripolygon.UModeler
{
	[Serializable]
	public class MirrorMode
	{
		public bool enable;

		public PlaneEx plane;

		public bool backup;

		public string propertyJSON = string.Empty;

		public void Backup(EditableMesh mesh)
		{
			if (mesh != null)
			{
				mesh.mirrorMode.Backup(null);
				backup = true;
			}
			else
			{
				backup = false;
			}
		}

		public MirrorMode Clone()
		{
			return new MirrorMode
			{
				enable = enable,
				plane = plane?.Clone()
			};
		}
	}
}
