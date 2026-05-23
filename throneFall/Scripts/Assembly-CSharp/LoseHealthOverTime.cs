using UnityEngine;

public class LoseHealthOverTime : MonoBehaviour
{
	[SerializeField]
	private Hp hp;

	[SerializeField]
	private float loseHealthPerSecond;

	private void Update()
	{
		hp.TakeDamage(loseHealthPerSecond * Time.deltaTime, null, causedByPlayer: false, invokeFeedbackEvents: false);
	}
}
