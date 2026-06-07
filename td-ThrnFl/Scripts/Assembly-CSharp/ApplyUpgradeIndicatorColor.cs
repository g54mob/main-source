using Shapes;
using UnityEngine;

[RequireComponent(typeof(Rectangle))]
public class ApplyUpgradeIndicatorColor : MonoBehaviour
{
	private void Start()
	{
		Rectangle component = GetComponent<Rectangle>();
		if ((bool)ColorAndLightManager.currentColorscheme)
		{
			component.Color = ColorAndLightManager.currentColorscheme.upgradeInteractorColor;
		}
	}
}
