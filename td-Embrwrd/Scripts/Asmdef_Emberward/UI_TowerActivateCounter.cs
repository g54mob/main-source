using TMPro;
using UnityEngine;

public class UI_TowerActivateCounter : MonoBehaviour
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private GameObject node_Content;

	[SerializeField]
	private TMP_Text text_Value;

	[SerializeField]
	private ABaseTower trackTower;

	[SerializeField]
	private Vector3 offset;

	private Vector3 worldPosition;

	private Vector3 curCameraPos;

	public static UI_TowerActivateCounter Create()
	{
		return null;
	}

	public void Setup(ABaseTower tower)
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
