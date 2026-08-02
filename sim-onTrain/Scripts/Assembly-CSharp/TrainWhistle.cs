using DG.Tweening;
using UnityEngine;

public class TrainWhistle : MonoBehaviour, IInteractable
{
	[Header("Blendshape Settings")]
	[SerializeField]
	private SkinnedMeshRenderer targetRenderer;

	[SerializeField]
	private int blendshapeIndex;

	[SerializeField]
	private float pullDuration = 0.3f;

	[SerializeField]
	private float releaseDuration = 0.5f;

	[Header("Interaction Settings")]
	[SerializeField]
	private Transform interactionParent;

	[SerializeField]
	private float customInteractionDistance = 2f;

	private TrainSoundController soundController;

	private InteractionPanel interactionPanel;

	private bool isAnimating;

	private Sequence whistleSequence;

	public bool IsActive { get; set; }

	public Transform InteractionParent
	{
		get
		{
			return interactionParent;
		}
		set
		{
			interactionParent = value;
		}
	}

	public float CustomInteractionDistance => customInteractionDistance;

	private void Start()
	{
		soundController = GetComponentInParent<TrainSoundController>();
		if (soundController == null)
		{
			soundController = Object.FindObjectOfType<TrainSoundController>();
		}
		interactionPanel = InteractionPanel.Instance;
	}

	public void Interact(PlayerInventory player, Vector3 hitPoint)
	{
		if (!isAnimating)
		{
			ShowInteractionUI(player.transform);
			if (Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.InteractKey))
			{
				PlayWhistle();
			}
		}
	}

	public void StopInteract()
	{
		HideInteractionUI();
	}

	private void PlayWhistle()
	{
		if (isAnimating)
		{
			return;
		}
		isAnimating = true;
		if (soundController != null)
		{
			soundController.RequestWhistle();
		}
		if (targetRenderer != null)
		{
			whistleSequence?.Kill();
			whistleSequence = DOTween.Sequence();
			whistleSequence.Append(DOTween.To(() => targetRenderer.GetBlendShapeWeight(blendshapeIndex), delegate(float x)
			{
				targetRenderer.SetBlendShapeWeight(blendshapeIndex, x);
			}, 100f, pullDuration).SetEase(Ease.OutQuad));
			whistleSequence.Append(DOTween.To(() => targetRenderer.GetBlendShapeWeight(blendshapeIndex), delegate(float x)
			{
				targetRenderer.SetBlendShapeWeight(blendshapeIndex, x);
			}, 0f, releaseDuration).SetEase(Ease.InOutQuad));
			whistleSequence.OnComplete(delegate
			{
				isAnimating = false;
			});
		}
		else
		{
			isAnimating = false;
		}
	}

	private void OnDestroy()
	{
		whistleSequence?.Kill();
	}

	private void ShowInteractionUI(Transform player)
	{
		interactionPanel.ShowInteractionOverlay(InteractionParent, player, Singleton<UserPrefencesManager>.Instance.keyData.InteractKey, "Whistle");
	}

	private void HideInteractionUI()
	{
		interactionPanel.HidePanels();
	}
}
