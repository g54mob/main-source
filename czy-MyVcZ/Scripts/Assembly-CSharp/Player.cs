using UnityEngine;
using UnityEngine.U2D.Animation;

public class Player : MonoBehaviour
{
	[SerializeField]
	private float moveSpeed = 5f;

	[SerializeField]
	private SpriteRenderer spriteRenderer;

	[SerializeField]
	private Rigidbody2D rb;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private SpriteLibrary _spriteLibrary;

	private bool isFacingRight;

	private bool _isMoveLock;

	private Vector2 _input;

	private void Update()
	{
		if (_isMoveLock)
		{
			_input = Vector2.zero;
			animator.SetBool("isRun", value: false);
			return;
		}
		float axisRaw = Input.GetAxisRaw("Horizontal");
		float axisRaw2 = Input.GetAxisRaw("Vertical");
		_input = new Vector2(axisRaw, axisRaw2).normalized;
		animator.SetBool("isRun", _input.sqrMagnitude > 0f);
		if (axisRaw > 0f)
		{
			spriteRenderer.flipX = true;
			isFacingRight = true;
		}
		else if (axisRaw < 0f)
		{
			spriteRenderer.flipX = false;
			isFacingRight = false;
		}
		else
		{
			spriteRenderer.flipX = isFacingRight;
		}
	}

	private void FixedUpdate()
	{
		rb.velocity = _input * moveSpeed;
	}

	public void MoveLock(Animal animal = null)
	{
		_isMoveLock = true;
	}

	public void MoveLock()
	{
		_isMoveLock = true;
	}

	public void MoveUnlock(Animal animal = null)
	{
		_isMoveLock = false;
	}

	public void MoveUnlock()
	{
		_isMoveLock = false;
	}

	public void PlayStepSound()
	{
		MonoSingleton<SoundManager>.Instance.PlaySFX(SFXType.SFX_PlayerStep);
	}

	public void ChangeCostume(SpriteLibraryAsset spriteLibraryAsset)
	{
		_spriteLibrary.spriteLibraryAsset = spriteLibraryAsset;
		_spriteLibrary.RefreshSpriteResolvers();
	}
}
