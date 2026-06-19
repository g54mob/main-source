using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace JSAM.Example.FirstPerson3D
{
	public class FPSAnimator : MonoBehaviour
	{
		private enum ShooterStates
		{
			Idle = 0,
			Shooting = 1,
			Reloading = 2,
			Running = 3
		}

		[Header("Explore me for examples of playing basic sounds!")]
		[SerializeField]
		private ShooterStates currentState;

		[SerializeField]
		private int magSize = 30;

		private int bullets;

		[SerializeField]
		private float timeBetweenShots = 1f;

		[SerializeField]
		private bool canShoot = true;

		[SerializeField]
		private float aimDownSightsTime = 1f;

		private float adsProgress;

		[SerializeField]
		private Text ammoText;

		[Header("Example of AudioEvents being used when player crouches")]
		[SerializeField]
		private UnityEvent onCrouch;

		private bool reloading;

		private Animator anim;

		private FPSWalker walker;

		private void Awake()
		{
			anim = GetComponent<Animator>();
			walker = GetComponentInParent<FPSWalker>();
		}

		private void Start()
		{
			bullets = magSize;
			canShoot = true;
			ammoText.text = bullets.ToString();
		}

		private void Update()
		{
			if (currentState == ShooterStates.Idle || currentState == ShooterStates.Running)
			{
				if (walker.CurrentState == MovementStates.Running)
				{
					anim.SetBool("Sprint", value: true);
					currentState = ShooterStates.Running;
				}
				else
				{
					anim.SetBool("Sprint", value: false);
					currentState = ShooterStates.Idle;
				}
			}
			switch (currentState)
			{
			case ShooterStates.Idle:
			case ShooterStates.Shooting:
				if (canShoot)
				{
					if (Input.GetKey(KeyCode.Mouse0))
					{
						if (bullets > 1)
						{
							AudioManager.PlaySound(FPSGunSounds.Gunshot);
							StartCoroutine(ShootDelay());
							anim.SetTrigger("Fire");
							bullets--;
							ammoText.text = bullets.ToString();
						}
						else if (bullets == 1)
						{
							anim.SetTrigger("FireFinal");
							StartCoroutine(ShootDelay());
							bullets--;
							ammoText.text = bullets.ToString();
							AudioManager.PlaySound(FPSGunSounds.AKDryFire);
						}
					}
					else if (Input.GetKeyUp(KeyCode.Mouse0))
					{
						anim.SetTrigger("FireStop");
					}
				}
				if (Input.GetMouseButton(1))
				{
					adsProgress = Mathf.Clamp(adsProgress + Time.deltaTime, 0f, aimDownSightsTime);
				}
				if (Input.GetKeyDown(KeyCode.R) && adsProgress == 0f)
				{
					anim.SetInteger("Ammo", bullets);
					anim.SetTrigger("Reload");
					canShoot = false;
					currentState = ShooterStates.Reloading;
				}
				break;
			}
			if (!Input.GetMouseButton(1))
			{
				adsProgress = Mathf.Clamp(adsProgress - Time.deltaTime, 0f, aimDownSightsTime);
			}
			anim.SetFloat("AimDownSights", adsProgress / aimDownSightsTime);
		}

		public void InvokeOnCrouch(bool crouching)
		{
			anim.SetBool("Crouch", crouching);
			onCrouch.Invoke();
		}

		private IEnumerator ShootDelay()
		{
			canShoot = false;
			yield return new WaitForSeconds(timeBetweenShots);
			canShoot = true;
		}

		public void ReloadBullets()
		{
			bullets = magSize;
			canShoot = true;
			currentState = ShooterStates.Idle;
			ammoText.text = bullets.ToString();
		}
	}
}
