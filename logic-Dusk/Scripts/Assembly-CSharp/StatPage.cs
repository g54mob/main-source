using UnityEngine;

public class StatPage : MonoBehaviour
{
	public StatCollection[] statCollection;

	private void Awake()
	{
	}

	public void Refresh()
	{
		if (this.statCollection != null)
		{
			StatCollection[] array = this.statCollection;
			foreach (StatCollection statCollection in array)
			{
				statCollection.Refresh();
			}
		}
	}
}
