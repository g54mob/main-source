using UnityEngine;

public class UIPoolMgr : MonoBehaviour
{
	public static UIPoolMgr I;

	public SerializedObjectPool<StatDisplayItem> StatDisplayPool;

	public SerializedObjectPool<StatDisplayItem> StatDisplayNoChangePool;

	public SerializedObjectPool<StatPropDisplayItem> StatPropPool;

	public SerializedObjectPool<StatPropDisplayItem> StatPropNoChangePool;

	public SerializedObjectPool<UISpacer> SpacerPool;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnSceneAboutToChange()
	{
	}

	public UISpacer CreateSpacer(float height, Transform parent)
	{
		return null;
	}
}
