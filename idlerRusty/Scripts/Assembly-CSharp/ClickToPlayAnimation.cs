using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
public class ClickToPlayAnimation : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private bool cogAchievement;

	private int clickCycle;

	[Header("Play Animation")]
	[SerializeField]
	private bool playAnimation = true;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private string triggerParameter = "play";

	[Header("Play Particle Effect")]
	[SerializeField]
	private bool playParticles;

	[SerializeField]
	private ParticleSystem particles;

	[Space]
	[SerializeField]
	private float animationDuration = 0.1f;

	[SerializeField]
	private AudioClip audioSFX;

	private bool buffer;

	private void Start()
	{
		Collider2D component = GetComponent<Collider2D>();
		component.enabled = false;
		component.enabled = true;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (buffer)
		{
			return;
		}
		buffer = true;
		if (playAnimation)
		{
			PlayAnimation();
		}
		if (playParticles)
		{
			PlayParticles();
		}
		SoundManager.ins.PlaySound(audioSFX);
		if (!audioSFX)
		{
			SoundManager.ins.PlaySound(GameManager.ins.tickAudio);
		}
		Invoke("TurnOffBuffer", animationDuration);
		if (cogAchievement)
		{
			AchievementManager.ins.SpinCog();
			clickCycle++;
			if (clickCycle >= 5)
			{
				Vector2 position = base.transform.position;
				position += new Vector2(Random.Range(-0.75f, 0.75f), 1f);
				Inventory.ins.AddSpareParts(1);
				GameManager.ins.SpawnSparePartsPopUp(position, 1);
				clickCycle = 0;
			}
		}
	}

	private void PlayAnimation()
	{
		animator.SetTrigger(triggerParameter);
	}

	private void PlayParticles()
	{
		particles.transform.position = GameManager.ins.mainCam.ScreenToWorldPoint(Input.mousePosition);
		particles.transform.position = new Vector3(particles.transform.position.x, particles.transform.position.y, 0f);
		particles.Play();
	}

	private void TurnOffBuffer()
	{
		buffer = false;
	}
}
