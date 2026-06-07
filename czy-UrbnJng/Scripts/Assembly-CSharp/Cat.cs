using System;
using System.Collections;
using DG.Tweening;
using MalbersAnimations.Scriptables;
using NewGameplayScripts;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cat : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private IntVar commandIntVar;

	[SerializeField]
	private Transform heartTemplate;

	[SerializeField]
	private float heartMoveOffsetY;

	[SerializeField]
	private float heartMoveDuration;

	[SerializeField]
	private NavMeshSurface navMeshFirstFloor;

	[SerializeField]
	private NavMeshSurface navMeshSecondFloor;

	public event EventHandler OnCatInteracted;

	private void Awake()
	{
		heartTemplate.gameObject.SetActive(value: false);
	}

	private void Start()
	{
		commandIntVar.Value = 0;
		MovementSystem.Instance.OnStartGrabbing += MovementSystem_OnStartGrabbing;
		MovementSystem.Instance.OnStopGrabbing += MovementSystem_OnStopGrabbing;
	}

	private void MovementSystem_OnStartGrabbing(object sender, EventArgs e)
	{
	}

	private void MovementSystem_OnStopGrabbing(object sender, EventArgs e)
	{
	}

	private void OnDestroy()
	{
		MovementSystem.Instance.OnStartGrabbing -= MovementSystem_OnStartGrabbing;
		MovementSystem.Instance.OnStopGrabbing -= MovementSystem_OnStopGrabbing;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			commandIntVar.Value = 1;
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			commandIntVar.Value = 2;
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			commandIntVar.Value = 3;
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		this.OnCatInteracted?.Invoke(this, EventArgs.Empty);
		Transform heart = UnityEngine.Object.Instantiate(heartTemplate, heartTemplate.parent);
		heart.gameObject.SetActive(value: true);
		StartCoroutine(Fade(heart));
		heart.DOMoveY(heart.position.y + heartMoveOffsetY, heartMoveDuration).SetEase(Ease.OutSine).OnComplete(delegate
		{
			UnityEngine.Object.Destroy(heart.gameObject, heartMoveDuration + 1f);
		});
	}

	private IEnumerator Fade(Transform transform)
	{
		yield return new WaitForSeconds(heartMoveDuration / 2f);
		transform.GetComponent<CanvasGroup>().DOFade(0f, heartMoveDuration / 2f);
	}
}
