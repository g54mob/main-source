using UnityEngine;

namespace GRP
{
	public class CylinderVisual : MonoBehaviour, ISizedVisual, IMotorVisual
	{
		public CylinderVisualConfig config;

		public Renderer rend;

		public MaterialBlockContainer materialBlock { get; set; }

		public void Setup()
		{
		}

		public void SetSize(Vector3 size)
		{
		}

		public void SetColor(Color color)
		{
		}

		public void SetMaterial(MaterialRowConfig material)
		{
		}

		public void SetMaterial(Material material)
		{
		}

		public void SetOffset(Id id)
		{
		}

		private void Reset()
		{
		}

		public void SetMotorMaterial(Material material)
		{
		}

		public void SetMotorInverted(bool inverted)
		{
		}

		public void SetMotorMirror(bool mirror)
		{
		}
	}
}
