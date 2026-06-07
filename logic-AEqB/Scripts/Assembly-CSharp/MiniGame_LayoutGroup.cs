using UnityEngine;
using UnityEngine.UI;

public class MiniGame_LayoutGroup : MonoBehaviour
{
	public int maxn;

	public int num;

	public float scale;

	public HorizontalLayoutGroup group;

	private void Start()
	{
		group = GetComponent<HorizontalLayoutGroup>();
	}

	private void Update()
	{
		if (num > maxn)
		{
			group.spacing = (float)Screen.width * scale / (float)num - (float)Screen.width * scale / (float)maxn;
		}
		else
		{
			group.spacing = 0f;
		}
	}
}
