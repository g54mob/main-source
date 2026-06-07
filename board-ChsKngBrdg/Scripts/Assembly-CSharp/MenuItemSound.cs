using UnityEngine;
using UnityEngine.EventSystems;

public class MenuItemSound : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerClickHandler
{
	private SoundManager soundManager;

	private float elapsedSeconds;

	public void Start()
	{
		soundManager = Object.FindObjectOfType<SoundManager>();
	}

	private void Update()
	{
		if (elapsedSeconds < 0.25f)
		{
			elapsedSeconds += Time.deltaTime;
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		SoundManager.LoadSoundEffect(base.transform, soundManager.chess_piece_drop);
		elapsedSeconds = 0f;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!(elapsedSeconds < 0.25f) && !((double)base.transform.localScale.y < 0.2))
		{
			SoundManager.LoadSoundEffect(base.transform, soundManager.chess_piece_grab);
			elapsedSeconds = 0f;
		}
	}
}
