using UnityEngine.EventSystems;

public class UltimateRadialMenuScreenSizeUpdater : UIBehaviour
{
	protected override void OnRectTransformDimensionsChange()
	{
		UltimateRadialMenu[] componentsInChildren = GetComponentsInChildren<UltimateRadialMenu>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].UpdatePositioning();
		}
	}
}
