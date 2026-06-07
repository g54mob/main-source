using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Accessibility_SwitchImageMaterialToStatic : MonoBehaviour
{
	[SerializeField]
	private Image image;

	[SerializeField]
	private Material mat_Static;

	private void Start()
	{
	}

	private void Reset()
	{
	}
}
