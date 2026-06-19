using UnityEngine;

public class PvPTextUI : MonoBehaviour
{
	public PugText text;

	private Vector3 defaultPosition;

	private void Awake()
	{
		text.gameObject.SetActive(value: false);
		defaultPosition = text.transform.localPosition;
	}

	private void LateUpdate()
	{
		bool flag = Manager.main.currentSceneHandler != null && Manager.main.currentSceneHandler.isInGame && Manager.main.player != null && Manager.main.player.pvpMode && !Manager.ui.isShowingMap;
		if (text.gameObject.activeSelf != flag)
		{
			text.gameObject.SetActive(flag);
		}
		if (flag)
		{
			float y = text.dimensions.height / 2f - text.dimensions.height % 0.0625f;
			text.transform.localPosition = (Manager.ui.mapUI.miniMapBorder.gameObject.activeInHierarchy ? defaultPosition : (defaultPosition + new Vector3(0f, 2.5f, 0f))) - new Vector3(0f, y, 0f);
			text.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		}
	}
}
