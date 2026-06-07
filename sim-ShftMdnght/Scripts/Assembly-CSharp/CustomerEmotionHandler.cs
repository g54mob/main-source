using UnityEngine;

public class CustomerEmotionHandler : MonoBehaviour
{
	private void Start()
	{
		ReviewsManager.Instance.emotionSprites.Add(GetComponent<SpriteRenderer>());
		ReviewsManager.Instance.UpdateReviewUI();
	}
}
