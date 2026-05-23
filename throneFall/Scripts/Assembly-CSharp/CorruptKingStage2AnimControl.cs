using UnityEngine;

public class CorruptKingStage2AnimControl : MonoBehaviour
{
	public AutoAttack autoAttack;

	public Animator animator;

	public UnitDashJumpEnemy jumper;

	public GameObject jumpMarkerPrefab;

	private void Start()
	{
		autoAttack.onAttackTriggered.AddListener(OnAttack);
		if ((bool)jumper)
		{
			jumper.onStartJump.AddListener(OnJump);
		}
	}

	private void OnAttack()
	{
		animator.SetTrigger("Attack");
	}

	private void OnJump(Vector3 blah)
	{
		animator.SetTrigger("JumpAttack");
		Object.Instantiate(jumpMarkerPrefab, blah, Quaternion.identity);
	}
}
