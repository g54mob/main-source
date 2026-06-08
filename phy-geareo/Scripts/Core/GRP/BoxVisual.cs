using UnityEngine;

namespace GRP
{
	public class BoxVisual : MonoBehaviour, ISizedVisual, IMotorVisual
	{
		public Renderer rend;

		public BoxVisualConfig config;

		public MaterialBlockContainer materialBlock { get; set; }

		public Vector3 size => default(Vector3);

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

		public void SetMotorMaterial(Material material)
		{
		}

		public void SetMotorMaterial(Material material, bool half)
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
