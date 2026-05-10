using UnityEngine;
using UnityEngine.UI;

namespace AllIn1VfxToolkit.Scripts
{
	public class AllIn1GraphicMaterialDuplicate : MonoBehaviour
	{
		private void Awake()
		{
			Graphic component = GetComponent<Graphic>();
			component.material = new Material(component.material);
		}
	}
}
