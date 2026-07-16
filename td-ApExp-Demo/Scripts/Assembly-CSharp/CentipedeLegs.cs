using UnityEngine;

public class CentipedeLegs : MonoBehaviour
{
	[SerializeField]
	private Transform legLeftTf;

	[SerializeField]
	private Transform legRightTf;

	private Animator legLeftAnim;

	private Animator legRightAnim;

	private SpriteRenderer legInsidesSrR;

	private SpriteRenderer legInsidesSrL;

	private void Awake()
	{
		legLeftAnim = legLeftTf.Find("Leg").GetComponent<Animator>();
		legRightAnim = legRightTf.Find("Leg").GetComponent<Animator>();
		legInsidesSrL = legLeftTf.Find("Insides").GetComponent<SpriteRenderer>();
		legInsidesSrR = legRightTf.Find("Insides").GetComponent<SpriteRenderer>();
	}

	public void Initialize(CentipedeController controller, int index)
	{
		legInsidesSrL.sprite = controller.InsidesSpritesLegs[index % 2];
		legInsidesSrR.sprite = controller.InsidesSpritesLegs[index % 2];
	}

	public void Play(int index, int timing)
	{
		legLeftAnim.Play("Walk", 0, ((float)index + (float)timing / 2f) / (float)timing);
		legRightAnim.Play("Walk", 0, (float)index / (float)timing);
	}

	public void SetSpeed(float speed)
	{
		legLeftAnim.SetFloat("WalkSpeedMult", speed);
		legRightAnim.SetFloat("WalkSpeedMult", speed);
	}
}
