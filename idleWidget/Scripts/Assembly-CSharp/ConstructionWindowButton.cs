using Assets.Source.Player;
using TMPro;
using UnityEngine;

public class ConstructionWindowButton : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _label;

	private void Update()
	{
		int num = GamePlayer.Current?.ConstructionCount ?? 0;
		if (num > 0)
		{
			_label.text = ((num > 999) ? "1k+" : num.ToString());
		}
		_label.gameObject.SetActive(num > 0);
	}
}
