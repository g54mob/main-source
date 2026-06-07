using UnityEngine;

namespace DV.VFX
{
	public class ColorSetter : MonoBehaviour
	{
		public string propertyName = "_EmissionColor";

		public Color color = Color.black;

		private void Start()
		{
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			materialPropertyBlock.SetColor(propertyName, color);
			GetComponent<MeshRenderer>().SetPropertyBlock(materialPropertyBlock);
		}
	}
}
