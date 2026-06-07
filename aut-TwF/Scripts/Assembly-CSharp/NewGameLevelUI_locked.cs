using UnityEngine;
using UnityEngine.UI;

public class NewGameLevelUI_locked : MonoBehaviour
{
	[SerializeField]
	private Image thumbnail;

	public void SetThumbnail(Sprite sprite)
	{
		thumbnail.sprite = sprite;
	}
}
