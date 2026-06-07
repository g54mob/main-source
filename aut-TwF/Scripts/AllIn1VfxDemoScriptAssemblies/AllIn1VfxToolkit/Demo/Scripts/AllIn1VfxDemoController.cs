using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace AllIn1VfxToolkit.Demo.Scripts
{
	public class AllIn1VfxDemoController : MonoBehaviour
	{
		[SerializeField]
		private int startingCollectionIndex;

		[SerializeField]
		private int startingEffectIndex;

		[Space]
		[Header("Demo Effects")]
		[SerializeField]
		private All1VfxDemoEffectCollection[] effectsToSpawnCollections;

		[Space]
		[Header("Projectile References")]
		[Space]
		[SerializeField]
		private GameObject projectileBasePrefab;

		[SerializeField]
		private GameObject projectileSceneSetupObject;

		[SerializeField]
		private Transform projectileSpawnPoint;

		[Space]
		[Header("Demo Controller Input")]
		[SerializeField]
		private KeyCode playEffectKey = KeyCode.Q;

		[SerializeField]
		private KeyCode nextEffectKey = KeyCode.RightArrow;

		[SerializeField]
		private KeyCode nextEffectKeyAlt = KeyCode.D;

		[SerializeField]
		private KeyCode previousEffectKey = KeyCode.LeftArrow;

		[SerializeField]
		private KeyCode previousEffectKeyAlt = KeyCode.A;

		[Space]
		[Header("UI and Other References")]
		[SerializeField]
		private Text currentEffectLabel;

		[SerializeField]
		private Button playEffectButton;

		[SerializeField]
		private GameObject playEffectInstructionsGo;

		[SerializeField]
		private Button nextEffectButton;

		[SerializeField]
		private Button previousEffectButton;

		[SerializeField]
		private Transform groundSpawnTransform;

		[SerializeField]
		private Transform cameraPivotTransform;

		[SerializeField]
		private float camPivotHeightSmoothing;

		[SerializeField]
		private GameObject projectileEffectUI;

		[SerializeField]
		private GameObject normalEffectUI;

		private All1VfxDemoEffect currDemoEffect;

		private int currDemoCollectionIndex;

		private int currDemoEffectIndex;

		private int currentEffectPlays;

		private AllIn1DemoScaleTween currLabelTween;

		private AllIn1DemoScaleTween playButtTween;

		private AllIn1DemoScaleTween nextButtTween;

		private AllIn1DemoScaleTween prevButtTween;

		private float timeSinceEffectPlay;

		private AllIn1TimeControl allIn1TimeControl;

		private void Start()
		{
			projectileSceneSetupObject.SetActive(value: false);
			currDemoCollectionIndex = startingCollectionIndex;
			currDemoEffectIndex = startingEffectIndex;
			currLabelTween = currentEffectLabel.GetComponent<AllIn1DemoScaleTween>();
			playButtTween = playEffectButton.GetComponent<AllIn1DemoScaleTween>();
			nextButtTween = nextEffectButton.GetComponent<AllIn1DemoScaleTween>();
			prevButtTween = previousEffectButton.GetComponent<AllIn1DemoScaleTween>();
			allIn1TimeControl = base.gameObject.GetComponent<AllIn1TimeControl>();
			SetupAndInstantiateCurrentEffect();
		}

		private void Update()
		{
			if (currDemoEffect.canBePlayedAgain && Input.GetKeyDown(playEffectKey))
			{
				PlayCurrentEffect();
			}
			if (Input.GetKeyDown(nextEffectKey) || Input.GetKeyDown(nextEffectKeyAlt))
			{
				ChangeCurrentEffect(1);
			}
			else if (Input.GetKeyDown(previousEffectKey) || Input.GetKeyDown(previousEffectKeyAlt))
			{
				ChangeCurrentEffect(-1);
			}
			if (currDemoEffect.spawnTouchingFloor)
			{
				cameraPivotTransform.position = Vector3.Lerp(cameraPivotTransform.position, new Vector3(0f, 0.1f, 0f), Time.unscaledDeltaTime * camPivotHeightSmoothing);
			}
			if (!currDemoEffect.spawnTouchingFloor)
			{
				cameraPivotTransform.position = Vector3.Lerp(cameraPivotTransform.position, new Vector3(0f, 2f, 0f), Time.unscaledDeltaTime * camPivotHeightSmoothing);
			}
			CooldownHandling();
		}

		private void CooldownHandling()
		{
			if (currDemoEffect.canBePlayedAgain)
			{
				timeSinceEffectPlay += Time.deltaTime;
				playEffectButton.interactable = currentEffectPlays < 1 || timeSinceEffectPlay >= currDemoEffect.cooldown;
			}
		}

		public void PlayCurrentEffect(bool isAfterSetupAndInstantiateEffect = false)
		{
			if (currentEffectPlays > 0 && timeSinceEffectPlay < currDemoEffect.cooldown)
			{
				return;
			}
			if (!isAfterSetupAndInstantiateEffect && Time.timeSinceLevelLoad > 0.1f)
			{
				playButtTween.ScaleUpTween();
			}
			if (!isAfterSetupAndInstantiateEffect && currDemoEffect.onlyOneAtATime)
			{
				DestroyAllChildren();
			}
			timeSinceEffectPlay = 0f;
			Transform transform = null;
			if (currDemoEffect.isShootProjectile)
			{
				if (currDemoEffect.muzzleFlashPrefab != null)
				{
					transform = Object.Instantiate(currDemoEffect.muzzleFlashPrefab, projectileSpawnPoint.position, Quaternion.identity).transform;
					transform.localRotation = Quaternion.identity;
					transform.forward = projectileSpawnPoint.forward;
					transform.parent = base.transform;
					transform.localScale *= currDemoEffect.scaleMultiplier;
				}
				Transform transform2 = Object.Instantiate(projectileBasePrefab, projectileSpawnPoint.position, Quaternion.identity).transform;
				transform2.forward = projectileSpawnPoint.forward;
				transform2.parent = base.transform;
				transform2.localRotation = Quaternion.identity;
				transform = Object.Instantiate(currDemoEffect.projectilePrefab, projectileSpawnPoint.position, Quaternion.identity).transform;
				transform.localRotation = Quaternion.identity;
				transform.forward = projectileSpawnPoint.forward;
				transform.parent = transform2;
				AllIn1DemoProjectile component = transform2.GetComponent<AllIn1DemoProjectile>();
				component.Initialize(base.transform, projectileSpawnPoint.forward, currDemoEffect.projectileSpeed, currDemoEffect.impactPrefab, currDemoEffect.scaleMultiplier);
				if (currDemoEffect.doCameraShake)
				{
					component.AddScreenShakeOnImpact(currDemoEffect.projectileImpactShakeAmount);
				}
			}
			else
			{
				transform = Object.Instantiate(currDemoEffect.effectPrefab, base.transform).transform;
				if (!currDemoEffect.spawnTouchingFloor)
				{
					transform.localPosition = Vector3.zero;
				}
				else
				{
					transform.position = groundSpawnTransform.position;
				}
				transform.localRotation = currDemoEffect.effectPrefab.transform.rotation;
				if (currDemoEffect.canBePlayedAgain && currDemoEffect.randomSpreadRadius > 0f && currentEffectPlays > 0)
				{
					transform.position += new Vector3(Random.Range(0f - currDemoEffect.randomSpreadRadius, currDemoEffect.randomSpreadRadius), 0f, Random.Range(0f - currDemoEffect.randomSpreadRadius, currDemoEffect.randomSpreadRadius));
				}
			}
			transform.localScale *= currDemoEffect.scaleMultiplier;
			transform.position += currDemoEffect.positionOffset;
			if (!isAfterSetupAndInstantiateEffect && currDemoEffect.doCameraShake)
			{
				AllIn1Shaker.i.DoCameraShake(currDemoEffect.mainEffectShakeAmount);
			}
			currentEffectPlays++;
		}

		public void ChangeCurrentEffect(int changeAmount)
		{
			if (changeAmount < 0)
			{
				prevButtTween.ScaleUpTween();
			}
			else if (changeAmount > 0)
			{
				nextButtTween.ScaleUpTween();
			}
			StartCoroutine(CurrentEffectLabelTweenEffectCR());
			currDemoEffectIndex += changeAmount;
			SetupAndInstantiateCurrentEffect();
			allIn1TimeControl.CurrentEffectChanged();
		}

		private void SetupAndInstantiateCurrentEffect()
		{
			DestroyAllChildren();
			currentEffectPlays = 0;
			ComputeValidEffectAndCollectionIndex();
			currDemoEffect = effectsToSpawnCollections[currDemoCollectionIndex].demoEffectCollection[currDemoEffectIndex];
			projectileSceneSetupObject.SetActive(currDemoEffect.isShootProjectile);
			projectileEffectUI.SetActive(currDemoEffect.isShootProjectile);
			normalEffectUI.SetActive(!currDemoEffect.isShootProjectile);
			currentEffectLabel.text = (currDemoEffect.isShootProjectile ? currDemoEffect.projectilePrefab.name : currDemoEffect.effectPrefab.name);
			playEffectButton.gameObject.SetActive(currDemoEffect.canBePlayedAgain);
			playEffectInstructionsGo.SetActive(currDemoEffect.canBePlayedAgain);
			PlayCurrentEffect(isAfterSetupAndInstantiateEffect: true);
		}

		private void ComputeValidEffectAndCollectionIndex()
		{
			int num = 0;
			if (currDemoEffectIndex < 0)
			{
				currDemoCollectionIndex--;
				num = 2;
			}
			else if (currDemoEffectIndex >= effectsToSpawnCollections[currDemoCollectionIndex].demoEffectCollection.Length)
			{
				currDemoCollectionIndex++;
				num = 1;
			}
			if (currDemoCollectionIndex < 0)
			{
				currDemoCollectionIndex = effectsToSpawnCollections.Length - 1;
				num = 2;
			}
			else if (currDemoCollectionIndex >= effectsToSpawnCollections.Length)
			{
				currDemoCollectionIndex = 0;
				num = 1;
			}
			switch (num)
			{
			case 1:
				currDemoEffectIndex = 0;
				break;
			case 2:
				currDemoEffectIndex = effectsToSpawnCollections[currDemoCollectionIndex].demoEffectCollection.Length - 1;
				break;
			}
		}

		private IEnumerator CurrentEffectLabelTweenEffectCR()
		{
			Color startColor = currentEffectLabel.color;
			currLabelTween.ScaleDownTween();
			currentEffectLabel.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
			yield return null;
			currentEffectLabel.color = new Color(startColor.r, startColor.g, startColor.b, 1f);
		}

		private void DestroyAllChildren()
		{
			foreach (Transform item in base.transform)
			{
				Object.Destroy(item.gameObject);
			}
		}
	}
}
