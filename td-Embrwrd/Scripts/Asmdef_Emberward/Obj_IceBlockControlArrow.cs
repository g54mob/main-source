using DG.Tweening;
using UnityEngine;

[SelectionBase]
public class Obj_IceBlockControlArrow : MonoBehaviour
{
	[SerializeField]
	private Obj_IceBlock iceBlock;

	[SerializeField]
	private eDirectionType directionType;

	private Tweener tween;

	public eDirectionType DirectionType => default(eDirectionType);

	public void Setup(Obj_IceBlock iceBlock)
	{
	}

	private void OnMouseDown()
	{
	}

	private void OnMouseEnter()
	{
	}

	private void OnMouseExit()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
