using UnityEngine;

public class MinionDurationBar : MonoBehaviour
{
	public MinionBase entityMono;

	public GameObject root;

	public GameObject durationBarPivot;

	private void LateUpdate()
	{
		if (Manager.prefs.hideInGameUI)
		{
			root.SetActive(value: false);
			return;
		}
		OwnerReferenceCD value;
		bool flag = EntityUtility.TryGetComponentData<OwnerReferenceCD>(entityMono.entity, entityMono.world, out value) && value.owner == Manager.main.player.entity;
		root.SetActive(!entityMono.isHidden && flag);
		if (root.activeSelf && EntityUtility.TryGetComponentData<MinionCD>(entityMono.entity, entityMono.world, out var value2))
		{
			durationBarPivot.transform.localScale = new Vector3(Mathf.Clamp(value2.normalizedLifespanTimer, 0f, 1f), 1f, 1f);
		}
	}
}
