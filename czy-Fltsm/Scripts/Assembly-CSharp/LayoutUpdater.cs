using UnityEngine;
using UnityEngine.UI;

public class LayoutUpdater : MonoBehaviour
{
	private void OnEnable()
	{
		ForceRebuild(base.transform);
		Object.Destroy(this);
	}

	public static void ForceRebuild(Transform parent)
	{
		LayoutRebuilder.ForceRebuildLayoutImmediate(parent as RectTransform);
		for (int i = 0; i < parent.childCount; i++)
		{
			ForceRebuild(parent.GetChild(i));
		}
	}
}
