using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DirtComponent : MonoBehaviour, IInteraction
{
	[SerializeField]
	private Dirt dirt = new Dirt();

	[SerializeField]
	private Item neededToolItem;

	[SerializeField]
	private AnimationCurve disappearCurve;

	[SerializeField]
	private string hintTag = "Dirt_Interaction";

	[Header("Sound")]
	[SerializeField]
	private string soundOnCleanup;

	private bool isPlayingSound;

	private AudioSource soundSource;

	[Header("Localization")]
	[SerializeField]
	private string localizationKeyNeedsItem;

	private DecalProjector projector;

	private GameObject dirtObject;

	private HealthComponent healthComponent;

	private Outline outline;

	private Vector3 size;

	private float interactionAlpha;

	public Dirt GetDirt()
	{
		return dirt;
	}

	private void Start()
	{
		healthComponent = GetComponent<HealthComponent>();
		CustomerManager.RegisterDirtObstacle(this);
		healthComponent.SubscribeOnDieEvent(delegate
		{
			CustomerManager.UnregisterDirtObstacle(this);
			ProgressionManager.GainXP("RemovedDirt", 1);
		});
		outline = GetComponent<Outline>();
		if (outline != null)
		{
			outline.enabled = false;
		}
		projector = GetComponentInChildren<DecalProjector>();
		if (projector != null)
		{
			projector.material.SetFloat("_Interact", 0f);
			Material material = new Material(projector.material);
			projector.material = material;
			size = projector.size;
		}
		else
		{
			dirtObject = base.transform.GetChild(0).gameObject;
			size = Vector3.one;
		}
	}

	private void OnDestroy()
	{
		CustomerManager.UnregisterDirtObstacle(this);
	}

	private void FixedUpdate()
	{
		if (!MouseCursorInteraction.IsValidated())
		{
			return;
		}
		if (MouseCursorInteraction.IsLookingAtObject(base.gameObject))
		{
			if (GlobalReferences.GetCharacterController().socket.IsTool(neededToolItem))
			{
				ShowOutline();
			}
			return;
		}
		HideOutline();
		if (!(soundSource == null))
		{
			if (soundSource.isPlaying)
			{
				soundSource.Stop();
			}
			isPlayingSound = false;
		}
	}

	public bool IsNeededItem(Item neededItem)
	{
		return neededToolItem.id == neededItem.id;
	}

	void IInteraction.OnPlayerHoldInteraction(CharacterControllerComponent character)
	{
		if (!character.socket.IsTool(neededToolItem))
		{
			string localizedName = InventorySystem.GetItemLibrary().itemInfos[neededToolItem.id].GetLocalizedName();
			PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyNeedsItem, 1.5f, localizedName);
			return;
		}
		healthComponent.ReduceHealth(1f * Time.deltaTime);
		float num = Mathf.InverseLerp(healthComponent.GetMaxHealth(), 0f, healthComponent.GetHealth());
		if (!isPlayingSound)
		{
			soundSource = SoundManager.PlaySoundLoop(soundOnCleanup, base.transform);
			isPlayingSound = true;
		}
		if (ProgressbarManager.GetCleaningProgressBar().IsVisible())
		{
			ProgressbarManager.GetCleaningProgressBar().UpdateBar(num);
			character.socket.GetItemComponent().PointToolToTarget(base.transform.position);
			character.socket.GetItemComponent().PointToolToGround();
			UpdateDisappear(num);
		}
		else
		{
			ProgressbarManager.GetCleaningProgressBar().ShowProgressbar(num);
		}
	}

	void IInteraction.OnPlayerHoldInteractionStopped(CharacterControllerComponent character)
	{
		HintBox hintBoxByTag = PopupMessageManager.GetPopHint().GetHintBoxByTag(hintTag);
		if (PopupMessageManager.GetPopHint().TryShow(hintBoxByTag))
		{
			return;
		}
		ProgressbarManager.GetCleaningProgressBar().HideProgressbar();
		if (healthComponent.GetHealth() > 0f)
		{
			if (isPlayingSound)
			{
				soundSource.Stop();
			}
			isPlayingSound = false;
		}
		else if (isPlayingSound)
		{
			soundSource.Stop();
			isPlayingSound = false;
			CustomerManager.UnregisterDirtObstacle(this);
			Object.Destroy(GetComponent<SaveableInstance>());
			Object.Destroy(soundSource.gameObject);
		}
	}

	private void UpdateDisappear(float progress)
	{
		if (projector != null)
		{
			projector.size = Vector3.Lerp(size, new Vector3(0f, 0f, size.z), disappearCurve.Evaluate(progress));
		}
		else
		{
			dirtObject.transform.localScale = Vector3.Lerp(size, Vector3.zero, disappearCurve.Evaluate(progress));
		}
	}

	public void ShowOutline()
	{
		if (projector != null)
		{
			if (interactionAlpha < 1f)
			{
				interactionAlpha += 6f * Time.deltaTime;
			}
			if (interactionAlpha > 1f)
			{
				interactionAlpha = 1f;
			}
			projector.material.SetFloat("_Interact", interactionAlpha);
		}
		if (!(outline == null))
		{
			outline.enabled = true;
		}
	}

	public void HideOutline()
	{
		if (projector != null)
		{
			if (interactionAlpha > 0f)
			{
				interactionAlpha -= 6f * Time.deltaTime;
			}
			if (interactionAlpha <= 0f)
			{
				interactionAlpha = 0f;
			}
			projector.material.SetFloat("_Interact", interactionAlpha);
		}
		if (!(outline == null))
		{
			outline.enabled = false;
		}
	}
}
