using System.Collections;
using UnityEngine;

namespace JSAM.Example.Shmup2D
{
	public class ShipController : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("Speed at which player moves")]
		private float moveSpeed = 8f;

		[SerializeField]
		[Tooltip("Speed at which player moves when focused")]
		private float focusSpeed = 3f;

		[SerializeField]
		[Tooltip("Time between each shot")]
		private float shotCooldown = 0.15f;

		private bool canShoot = true;

		[SerializeField]
		private Transform bulletSpawnZone;

		[Header("Object References")]
		[SerializeField]
		private ObjectPool bulletPool;

		[SerializeField]
		private SoundFileObject controlSound;

		private Rigidbody2D rb;

		private Animator anim;

		private SpriteRenderer hitBox;

		private void Awake()
		{
			rb = GetComponent<Rigidbody2D>();
			anim = GetComponentInChildren<Animator>();
			hitBox = base.transform.GetChild(0).GetComponent<SpriteRenderer>();
		}

		private void Update()
		{
			float num = (Input.GetKey(KeyCode.LeftShift) ? focusSpeed : moveSpeed);
			hitBox.enabled = Input.GetKey(KeyCode.LeftShift);
			Vector2 zero = Vector2.zero;
			if (Input.GetKey(KeyCode.UpArrow))
			{
				zero += Vector2.up;
			}
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				zero += Vector2.left;
			}
			if (Input.GetKey(KeyCode.RightArrow))
			{
				zero += Vector2.right;
			}
			if (Input.GetKey(KeyCode.DownArrow))
			{
				zero += Vector2.down;
			}
			rb.MovePosition((Vector2)base.transform.position + zero.normalized * num * Time.fixedDeltaTime);
			if (!(Time.timeScale > 0f))
			{
				return;
			}
			anim.SetBool("left", Input.GetKey(KeyCode.LeftArrow));
			anim.SetBool("right", Input.GetKey(KeyCode.RightArrow));
			if (Input.GetKey(KeyCode.Z) && canShoot)
			{
				GameObject obj = bulletPool.GetObject();
				obj.transform.position = bulletSpawnZone.position;
				obj.SetActive(value: true);
				if (!AudioManager.IsSoundPlaying(Shmup2DSounds.Shooting))
				{
					AudioManager.PlaySound(Shmup2DSounds.Shooting, base.transform);
				}
				StartCoroutine(ShotCooldown());
			}
			else if (!Input.GetKey(KeyCode.Z))
			{
				AudioManager.StopSoundIfPlaying(Shmup2DSounds.Shooting, base.transform);
			}
		}

		private IEnumerator ShotCooldown()
		{
			canShoot = false;
			yield return new WaitForSeconds(shotCooldown);
			canShoot = true;
		}
	}
}
