using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Localization;

namespace Suburb
{
	public class SimpleOpenClose : MonoBehaviour, IInteractable
	{
		private LocalizedString openText = new LocalizedString("MyTable", "interaction-open");

		private LocalizedString closeText = new LocalizedString("MyTable", "interaction-close");

		public Collider coll;

		private int defaultLayer;

		[SerializeField]
		private string ignoreLayerName = "Door";

		private int ignoreLayer;

		private Animator myAnimator;

		private Animator additionalAnimator;

		public bool objectOpen;

		public bool objectOpenAdditional;

		public GameObject animateAdditional;

		private bool hasAdditional;

		private float myNormalizedTime;

		private Outline outLine;

		public bool locked;

		public string InteractionText
		{
			get
			{
				if (openText != null && !openText.IsEmpty)
				{
					if (!objectOpen)
					{
						return openText.GetLocalizedString();
					}
					return closeText.GetLocalizedString();
				}
				if (!objectOpen)
				{
					return "Open";
				}
				return "Close";
			}
		}

		public static event Action OnTryOpenLockedDoor;

		private void Awake()
		{
			defaultLayer = base.gameObject.layer;
			ignoreLayer = LayerMask.NameToLayer(ignoreLayerName);
		}

		private void Start()
		{
			myAnimator = GetComponent<Animator>();
			if (myAnimator == null)
			{
				myAnimator = GetComponentInParent<Animator>();
			}
			coll = GetComponent<BoxCollider>();
			StartCoroutine(DelayedCheckOpened());
			outLine = GetComponent<Outline>();
			if (outLine != null)
			{
				outLine.enabled = false;
			}
		}

		private IEnumerator DelayedCheckOpened()
		{
			yield return null;
			if (objectOpen)
			{
				myAnimator.Play("Open", 0, 1f);
			}
			if (animateAdditional != null)
			{
				if ((bool)animateAdditional.GetComponent<SimpleOpenClose>())
				{
					additionalAnimator = animateAdditional.GetComponent<Animator>();
					hasAdditional = true;
					objectOpenAdditional = animateAdditional.GetComponent<SimpleOpenClose>().objectOpen;
				}
				else
				{
					hasAdditional = false;
				}
			}
		}

		public void Interact()
		{
			if (!locked)
			{
				ObjectClicked();
				return;
			}
			SimpleOpenClose.OnTryOpenLockedDoor?.Invoke();
			AudioManager.S.PlaySFX(AudioManager.S.doorLocked);
		}

		public void OnDetected()
		{
			if (outLine != null)
			{
				outLine.enabled = true;
			}
		}

		public void OnLost()
		{
			if (outLine != null)
			{
				outLine.enabled = false;
			}
		}

		public void ObjectClicked()
		{
			myNormalizedTime = myAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;
			if (!hasAdditional && (double)myNormalizedTime >= 1.0)
			{
				if (objectOpen)
				{
					AudioManager.S.PlaySFX(AudioManager.S.doorClose);
					myAnimator.Play("Close", 0, 0f);
					objectOpen = false;
				}
				else
				{
					AudioManager.S.PlaySFX(AudioManager.S.doorOpen);
					myAnimator.Play("Open", 0, 0f);
					objectOpen = true;
				}
			}
			if (!hasAdditional || !((double)myNormalizedTime >= 1.0))
			{
				return;
			}
			if (objectOpen)
			{
				AudioManager.S.PlaySFX(AudioManager.S.doorClose);
				myAnimator.Play("Close", 0, 0f);
				objectOpen = false;
				animateAdditional.GetComponent<SimpleOpenClose>().objectOpenAdditional = false;
				if (objectOpenAdditional)
				{
					additionalAnimator.Play("Close", 0, 0f);
					objectOpenAdditional = false;
					animateAdditional.GetComponent<SimpleOpenClose>().objectOpen = false;
				}
			}
			else
			{
				AudioManager.S.PlaySFX(AudioManager.S.doorOpen);
				myAnimator.Play("Open", 0, 0f);
				objectOpen = true;
				animateAdditional.GetComponent<SimpleOpenClose>().objectOpenAdditional = true;
				if (!objectOpenAdditional)
				{
					additionalAnimator.Play("Open", 0, 0f);
					objectOpenAdditional = true;
					animateAdditional.GetComponent<SimpleOpenClose>().objectOpen = true;
				}
			}
		}

		public void DoorColliderOnOff()
		{
			if (base.gameObject.layer == defaultLayer)
			{
				base.gameObject.layer = ignoreLayer;
			}
			else
			{
				base.gameObject.layer = defaultLayer;
			}
		}
	}
}
