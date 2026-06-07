using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_AncientTowerActivateCounter : MonoBehaviour
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private GameObject node_Content;

	[SerializeField]
	private TMP_Text text_Value;

	[SerializeField]
	private Image image_Locked;

	[SerializeField]
	private Transform trackTarget;

	[SerializeField]
	private Vector3 offset;

	private Vector3 worldPosition;

	private Vector3 curCameraPos;

	private AMonsterBase trackMonster;

	private ABaseTower trackTower;

	public static UI_AncientTowerActivateCounter Create()
	{
		return null;
	}

	public void Setup(Transform target, Vector3 offset)
	{
	}

	public void ToggleLocked(bool isLocked)
	{
	}

	private void OnMonsterKilled(AMonsterBase @base)
	{
	}

	private void OnTowerDespawn(ABaseTower tower)
	{
	}

	public void SetValue(int value)
	{
	}

	public void ToggleHide(bool isHide)
	{
	}

	private void Update()
	{
	}

	private void UpdatePosition()
	{
	}

	public void Remove()
	{
	}
}
