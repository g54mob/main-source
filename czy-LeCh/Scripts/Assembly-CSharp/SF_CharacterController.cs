using UnityEngine;

public class SF_CharacterController : MonoBehaviour
{
	[SerializeField]
	private Animator sf_characterAnimator;

	[SerializeField]
	private CharacterState characterState;

	private void Start()
	{
		sf_characterAnimator.SetBool(characterState.ToString(), value: true);
	}
}
