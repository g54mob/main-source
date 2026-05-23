using TMPro;
using UnityEngine;

public class ScoreTextUI : MonoBehaviour
{
	public TextMeshProUGUI scoreText;

	public Animator animator;

	private void Start()
	{
		animator.Play("In");
	}

	private void Update()
	{
	}
}
