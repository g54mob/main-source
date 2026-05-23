using Febucci.UI.Core;
using UnityEngine;

public class EpilogueEnd : MonoBehaviour
{
	[SerializeField]
	private TypewriterCore typewriter;

	[SerializeField]
	private Animator anim;

	private bool skipText;

	private void Start()
	{
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			SkipText();
		}
	}

	public void SkipText()
	{
		if (!skipText)
		{
			typewriter.SkipTypewriter();
			skipText = true;
		}
		else
		{
			typewriter.ShowText(" ");
			anim.SetTrigger("StartEnding");
		}
	}
}
