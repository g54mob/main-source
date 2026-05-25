using UnityEngine;

public class EndPeon : MonoBehaviour
{
	public void Disapear()
	{
		base.transform.localScale = new Vector3(0f, 0f, 1f);
	}

	public void Turn()
	{
		base.transform.Find("Body").GetComponent<SpriteRenderer>().flipX = true;
		base.transform.Find("Body").Find("Eye").GetComponent<SpriteRenderer>()
			.flipX = true;
		base.transform.Find("Body").Find("Mouth").GetComponent<SpriteRenderer>()
			.flipX = true;
	}
}
