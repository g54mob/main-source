using UnityEngine;

public class MolemanAppearerizer : MonoBehaviour
{
	private const int MAX_CHAPTER_LEVEL = 8;

	[SerializeField]
	private GameObject molemanStart;

	[SerializeField]
	private GameObject molemanEnd;

	private void OnEnable()
	{
		bool flag = LevelManager.GetCurrLevel() + 1 >= 8;
		molemanStart.SetActive(!flag);
		molemanEnd.SetActive(flag);
	}
}
