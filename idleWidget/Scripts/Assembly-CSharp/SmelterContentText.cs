using Assets.Source.World;
using TMPro;
using UnityEngine;

public class SmelterContentText : MonoBehaviour
{
	private TMP_Text _text;

	private FurnaceFrame _frame;

	private void Start()
	{
		_text = GetComponent<TMP_Text>();
		_frame = GetComponentInParent<ActiveWorldFrame>().ActiveFrame as FurnaceFrame;
	}

	private void Update()
	{
		int maxContents = _frame.GetMaxContents();
		_text.text = ((_frame.CurrentContents > maxContents) ? (maxContents + "+") : _frame.CurrentContents.ToString()) + "/" + maxContents;
	}
}
