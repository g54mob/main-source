using UnityEngine;

namespace GRP
{
	public interface ISizedVisual
	{
		MaterialBlockContainer materialBlock { get; }

		void Setup();

		void SetSize(Vector3 size);

		void SetColor(Color color);

		void SetMaterial(Material material);

		void SetOffset(Id id);
	}
}
