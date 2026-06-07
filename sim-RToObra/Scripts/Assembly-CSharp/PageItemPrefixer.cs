using UnityEngine;

public class PageItemPrefixer : MonoBehaviour
{
	public string prefix;

	private string combinedPrefix_;

	public string combinedPrefix
	{
		get
		{
			if (combinedPrefix_ == null)
			{
				combinedPrefix_ = prefix;
				foreach (GameObject item in base.gameObject.AllAntecedents(false))
				{
					PageItemPrefixer component = item.GetComponent<PageItemPrefixer>();
					if (component != null)
					{
						combinedPrefix_ = component.combinedPrefix + combinedPrefix_;
					}
				}
			}
			return combinedPrefix_;
		}
	}
}
