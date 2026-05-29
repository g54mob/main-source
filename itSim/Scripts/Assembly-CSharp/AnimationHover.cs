using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnimationHover : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private Image bg;

	private Color newColor;

	private Color oldColor;

	private Coroutine currentCoroutine;

	public Coroutine test1AnimationHover;

	private void Start()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
